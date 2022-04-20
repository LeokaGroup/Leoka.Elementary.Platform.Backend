using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetWhereBeginTest : BaseServiceTest
{
    [Test]
    public async Task GetWhereBeginAsyncTest()
    {
        var result = await PostgreDbContext.WhereBegin.AnyAsync();
        
        Assert.IsTrue(result);
    }
}