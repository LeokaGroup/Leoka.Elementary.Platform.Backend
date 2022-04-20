using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetMainBestOptionsTest : BaseServiceTest
{
    [Test]
    public async Task GetMainBestOptionsAsyncTest()
    {
        var result = await PostgreDbContext.MainBestOptions.AnyAsync();
        
        Assert.IsTrue(result);
    }
}