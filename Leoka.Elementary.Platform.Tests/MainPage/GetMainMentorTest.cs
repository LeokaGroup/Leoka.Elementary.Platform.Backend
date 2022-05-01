using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetMainMentorTest : BaseServiceTest
{
    [Test]
    public async Task GetMainMentorAsyncTest()
    {
        var result = await MainPageService.GetMainMentorAsync();

        Assert.IsNotNull(result);
    }
}