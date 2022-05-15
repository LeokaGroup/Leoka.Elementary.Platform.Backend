using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Profile;

[TestFixture]
public class GetProfileItemsTest : BaseServiceTest
{
    [Test]
    public async Task GetProfileItemsAsyncTest()
    {
        var result = await ProfileService.GetProfileItemsAsync();

        Assert.IsTrue(result.Any());
    }
}