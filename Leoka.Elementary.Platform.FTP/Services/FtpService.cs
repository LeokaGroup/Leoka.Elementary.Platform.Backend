using System.Net;
using System.Net.FtpClient;
using Leoka.Elementary.Platform.FTP.Abstractions;
using Leoka.Elementary.Platform.Models.Profile.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Leoka.Elementary.Platform.FTP.Services;

/// <summary>
/// Класс реализует методы FTP сервиса.
/// </summary>
public class FtpService : IFtpService
{
    private readonly IConfiguration _configuration;

    // Путь к документам.
    private const string PathDocs = "/docs";

    // Путь к изображениям.
    private const string PathImages = "/images";

    public FtpService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Метод загрузит файлы анкеты профиля пользователя по FTP на сервер.
    /// </summary>
    /// <param name="files">Файлы для отправки.</param>
    /// <param name="userId">Id пользователя.</param>
    public async Task UploadProfileFilesFtpAsync(IFormFileCollection files, long userId)
    {
        try
        {
            // Путь к файлам пользователя.
            var userFolderPath = "/" + userId;

            if (files.Count > 0)
            {
                var host = _configuration.GetSection("FtpSettings:Host").Value;
                var login = _configuration.GetSection("FtpSettings:Login").Value;
                var password = _configuration.GetSection("FtpSettings:Password").Value;
                var ftp = new FtpClient
                {
                    Host = host,
                    Credentials = new NetworkCredential(login, password)
                };

                ftp.Connect();

                var checkDirectoryCertsDocs = ftp.GetListing().Where(f => f.FullName.Equals(PathDocs));

                // Проверит существование папки документов. Если ее нет, то создаст.
                if (!checkDirectoryCertsDocs.Any())
                {
                    ftp.CreateDirectory(PathDocs);
                }

                var checkDirectoryCertsImages = ftp.GetListing().Where(f => f.FullName.Equals(PathImages));

                // Проверит существование папки изображений сертификатов. Если ее нет, то создаст.
                if (!checkDirectoryCertsImages.Any())
                {
                    ftp.CreateDirectory(PathImages);
                }

                // Проверит существование папки изображений пользователя.
                var checkUserImegesFolder = ftp.GetListing().Where(f => f.FullName.Equals(PathImages + userFolderPath));

                if (!checkUserImegesFolder.Any())
                {
                    ftp.CreateDirectory(PathImages + userFolderPath);
                }

                // Проверит существование папки документов пользователя.
                var checkUserDocsFolder = ftp.GetListing().Where(f => f.FullName.Equals(PathDocs + userFolderPath));

                if (!checkUserDocsFolder.Any())
                {
                    ftp.CreateDirectory(PathDocs + userFolderPath);
                }

                // Закачать файлы на сервер в папку фронта (изображения).
                foreach (var file in files)
                {
                    // Если файлы изображений или видео.
                    if (file.FileName.EndsWith(".png")
                        || file.FileName.EndsWith(".jpg")
                        || file.FileName.EndsWith(".jpeg")
                        || file.FileName.EndsWith(".svg"))
                    {
                        ftp.SetWorkingDirectory(PathImages + userFolderPath);
                    }

                    // Если документы.
                    else if (file.FileName.EndsWith(".docx")
                             || file.FileName.EndsWith(".xlsx")
                             || file.FileName.EndsWith(".pdf")
                             || file.FileName.EndsWith(".pptx")
                             || file.FileName.EndsWith(".doc")
                             || file.FileName.EndsWith(".xls"))
                    {
                        ftp.SetWorkingDirectory(PathDocs + userFolderPath);
                    }

                    // Добавит файл на сервер проставляя имя файла учитывая Id пользователя.
                    await using var remote =
                        ftp.OpenWrite(string.Concat(userId, "_") + file.FileName, FtpDataType.Binary);
                    await file.CopyToAsync(remote);
                }

                ftp.Disconnect();
            }
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит список файлов сертификатов с сервера.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="certsUrls">Названия файлов сертификатов.</param>
    /// <returns>Список файлов.</returns>
    public async Task<IEnumerable<FileContentResultOutput>> GetUserCertsFilesAsync(long userId, string[] certsNames)
    {
        try
        {
            // Путь к файлам пользователя.
            var userFolderPath = "/" + userId;
            var host = _configuration.GetSection("FtpSettings:Host").Value;
            var login = _configuration.GetSection("FtpSettings:Login").Value;
            var password = _configuration.GetSection("FtpSettings:Password").Value;
            var ftp = new FtpClient
            {
                Host = host,
                Credentials = new NetworkCredential(login, password)
            };

            var files = new List<FileContentResultOutput>();

            ftp.Connect();
            ftp.SetWorkingDirectory(PathImages + userFolderPath);

            // Получит список сертификатов пользователя.
            foreach (var certName in certsNames)
            {
                await using var readStream = ftp.OpenRead(userId + "_" + certName, FtpDataType.Binary);
                var byteData = await GetByteArrayAsync(readStream);
                var file = new FileContentResult(byteData, "application/octet-stream");

                files.Add(new FileContentResultOutput
                {
                    Cert = file,
                    Extension = Path.GetExtension(certName).Replace(".", "")
                });
            }

            ftp.Disconnect();

            return files;
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Метод получит массив байт из потока.
    /// </summary>
    /// <param name="input">Поток.</param>
    /// <returns>Масив байт.</returns>
    private async Task<byte[]> GetByteArrayAsync(Stream input)
    {
        var buffer = new byte[16 * 1024];
        await using MemoryStream ms = new MemoryStream();
        var read = 0;

        while ((read = await input.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            ms.Write(buffer, 0, read);
        }

        return ms.ToArray();
    }

    /// <summary>
    /// Метод получит аватар профиля пользователя.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="avatar">Изображение аватара.</param>
    /// <returns>Аватар профиля пользователя.</returns>
    public async Task<FileContentAvatarOutput> GetProfileAvatarAsync(long userId, string avatar)
    {
        try
        {
            // Путь к файлам пользователя.
            var userFolderPath = "/" + userId;
            var host = _configuration.GetSection("FtpSettings:Host").Value;
            var login = _configuration.GetSection("FtpSettings:Login").Value;
            var password = _configuration.GetSection("FtpSettings:Password").Value;
            var ftp = new FtpClient
            {
                Host = host,
                Credentials = new NetworkCredential(login, password)
            };
            var result = new FileContentAvatarOutput();

            ftp.Connect();
            ftp.SetWorkingDirectory(PathImages + userFolderPath);
            
            // Получит список файлов пользователя.
            var userFiles = ftp.GetListing();

            // Если аватар был загружен ранее.
            var checkUserAvatar = userFiles.Where(f => f.Name.Replace(userId + "_", "").Equals(avatar));
            
            if (checkUserAvatar.Any())
            {
                await using var readStream = ftp.OpenRead(userId + "_" + avatar, FtpDataType.Binary);
                var byteData = await GetByteArrayAsync(readStream);
                var file = new FileContentResult(byteData, "application/octet-stream");
                result.Avatar = file;
                result.Extension = Path.GetExtension(avatar).Replace(".", "");
            }

            // Вернуть аватар по дефолту.
            else
            {
                result.IsNoPhoto = true;
                result.AvatarUrl = "../../../../../assets/images/profile/nophoto.svg";
            }

            ftp.Disconnect();

            return result;
        }

        // TODO: добавить логирование ошибок.
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}