using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Request;

[TestFixture]
public class GetRequestTest : BaseServiceTest
{
    [Test]
    public async Task GetRequestAsyncTest()
    {
        var result = await MainPageService.GetRequestAsync();

        Assert.IsNotNull(result);
    }
}