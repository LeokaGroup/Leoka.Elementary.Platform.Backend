using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetBeginItemsTest : BaseServiceTest
{
    [Test]
    public async Task GetBeginItemsAsyncTest()
    {
        var result = await MainPageService.GetBeginItemsAsync();
        
        Assert.IsNotNull(result);
    }
}