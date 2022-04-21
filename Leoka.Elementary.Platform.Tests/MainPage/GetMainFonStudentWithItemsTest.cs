using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetMainFonStudentWithItemsTest : BaseServiceTest
{
    [Test]
    public async Task GetMainFonStudentWithItemsAsyncTest()
    {
        var result = await MainPageService.GetMainFonStudentAsync();

        Assert.IsNotNull(result);
    }
}