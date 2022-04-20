using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetMainBestQuestionsTest : BaseServiceTest
{
    [Test]
    public async Task GetMainBestQuestionsAsyncTest()
    {
        var result = await PostgreDbContext.MainBestQuestions.AnyAsync();
        
        Assert.IsTrue(result);
    }
}