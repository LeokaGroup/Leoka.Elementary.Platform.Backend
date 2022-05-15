using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Profile;

[TestFixture]
public class GetPurposeTrainingsTest : BaseServiceTest
{
    [Test]
    public async Task GetPurposeTrainingsAsyncTest()
    {
        var result = await ProfileService.GetPurposeTrainingsAsync();

        Assert.IsTrue(result.Any());
    } 
}