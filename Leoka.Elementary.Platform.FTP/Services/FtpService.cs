using System.Net;
using System.Net.FtpClient;
using Leoka.Elementary.Platform.FTP.Abstractions;
using Microsoft.AspNetCore.Http;
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

                // Закачать файлы на сервер в папку фронта (изображения).
                foreach (var file in files)
                {
                    // Если файлы изображений или видео.
                    if (file.FileName.EndsWith(".png")
                        || file.FileName.EndsWith(".jpg")
                        || file.FileName.EndsWith(".jpeg")
                        || file.FileName.EndsWith(".svg"))
                    {
                        ftp.SetWorkingDirectory(PathImages);
                    }

                    // Если документы.
                    else if (file.FileName.EndsWith(".docx")
                             || file.FileName.EndsWith(".xlsx")
                             || file.FileName.EndsWith(".pdf")
                             || file.FileName.EndsWith(".pptx")
                             || file.FileName.EndsWith(".doc")
                             || file.FileName.EndsWith(".xls"))
                    {
                        ftp.SetWorkingDirectory(PathDocs);
                    }
                    
                    // Добавит файл на сервер.
                    await using var remote = ftp.OpenWrite(string.Concat(userId, "_") + file.FileName, FtpDataType.Binary);
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
}