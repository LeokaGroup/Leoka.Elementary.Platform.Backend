using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetMainBestQuestionOptionsTest : BaseServiceTest
{
    [Test]
    public async Task GetMainBestQuestionOptionsAsyncTest()
    {
        var result = await PostgreDbContext.MainBestQuestionOptions.AnyAsync();
        
        Assert.IsTrue(result);
    }
}