using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetReceptionTest : BaseServiceTest
{
    [Test]
    public async Task GetReceptionAsyncTest()
    {
        var result = await MainPageService.GetReceptionAsync();

        Assert.IsNotNull(result);
    }
}