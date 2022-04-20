using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetMainBestQuestionAcceptAnswersTest : BaseServiceTest
{
    [Test]
    public async Task GetMainBestQuestionAcceptAnswersAsyncTest()
    {
        var result = await PostgreDbContext.MainBestQuestionAcceptAnswers.AnyAsync();
        
        Assert.IsTrue(result);
    }
}