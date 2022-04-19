using Leoka.Elementary.Platform.Core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Controllers.MainPage;

/// <summary>
/// Контроллер для работы с пользователями.
/// </summary>
[ApiController, Route("main")]
public class MainPageController : Controller
{
    private readonly PostgreDbContext _postgreDbContext;
    
    public MainPageController(PostgreDbContext postgreDbContext)
    {
        _postgreDbContext = postgreDbContext;
    }

    [HttpGet]
    [Route("header")]
    public async Task GetHeaderItemsAsync()
    {
        var test = await _postgreDbContext.Header.ToListAsync();
        Console.WriteLine();
    }
}