using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetReceptionTest : BaseServiceTest
{
    [Test]
    public async Task GetStudentReceptionAsyncTest()
    {
        var result = await MainPageService.GetReceptionAsync(1);

        Assert.IsNotNull(result);
    }
    
    [Test]
    public async Task GetMentorReceptionAsyncTest()
    {
        var result = await MainPageService.GetReceptionAsync(2);

        Assert.IsNotNull(result);
    }
}