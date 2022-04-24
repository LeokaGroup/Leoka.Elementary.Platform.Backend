using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetTitleOptionTest : BaseServiceTest
{
    [Test]
    public async Task GetTitleOptionAsyncTest()
    {
        var result = await MainPageService.GetTitleOptionAsync();

        Assert.IsNotNull(result);
    }
}