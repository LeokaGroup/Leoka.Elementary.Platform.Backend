using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetMentorTest : BaseServiceTest
{
    [Test]
    public async Task GetMentorAsyncTest()
    {
        var result = await MainPageService.GetMentorAsync();

        Assert.IsNotNull(result);
    }
}