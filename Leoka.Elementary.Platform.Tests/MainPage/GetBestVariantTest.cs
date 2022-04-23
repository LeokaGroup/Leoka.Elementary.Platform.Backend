using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetBestVariantTest : BaseServiceTest
{
    [Test]
    public async Task GetBestVariantAsyncTest()
    {
        var result = await MainPageService.GetBestVariantAsync();

        Assert.IsNotNull(result);
    } 
}