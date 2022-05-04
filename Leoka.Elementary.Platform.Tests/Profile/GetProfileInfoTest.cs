using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Profile;

[TestFixture]
public class GetProfileInfoTest : BaseServiceTest
{
    [Test]
    public async Task GetProfileInfoAsyncTest()
    {
        var result = await ProfileService.GetProfileInfoAsync();

        Assert.IsNotNull(result);
    }
}