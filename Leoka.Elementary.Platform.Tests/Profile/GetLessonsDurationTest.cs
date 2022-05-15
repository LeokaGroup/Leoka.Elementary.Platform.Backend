using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Profile;

[TestFixture]
public class GetLessonsDurationTest : BaseServiceTest
{
    [Test]
    public async Task GetLessonsDurationAsyncTest()
    {
        var result = await ProfileService.GetLessonsDurationAsync();

        Assert.IsTrue(result.Any());
    }
}