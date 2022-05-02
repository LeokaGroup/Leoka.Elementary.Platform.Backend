using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetBeginItemsTest : BaseServiceTest
{
    [Test]
    public async Task GetStudentBeginItemsAsyncTest()
    {
        var result = await MainPageService.GetBeginItemsAsync(1);
        
        Assert.IsNotNull(result);
    }
    
    [Test]
    public async Task GetMentorBeginItemsAsyncTest()
    {
        var result = await MainPageService.GetBeginItemsAsync(2);
        
        Assert.IsNotNull(result);
    }
}