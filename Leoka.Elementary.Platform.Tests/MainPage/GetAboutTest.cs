using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetAboutTest : BaseServiceTest
{
    [Test]
    public async Task GetAboutAsyncTest()
    {
        var result = await MainPageService.GetAboutAsync();

        Assert.IsNotNull(result);
    }
}