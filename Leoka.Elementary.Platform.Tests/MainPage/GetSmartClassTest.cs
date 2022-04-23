using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetSmartClassTest : BaseServiceTest
{
    [Test]
    public async Task GetSmartClassAsyncTest()
    {
        var result = await MainPageService.GetSmartClassAsync();
        
        Assert.IsNotNull(result);
    }
}