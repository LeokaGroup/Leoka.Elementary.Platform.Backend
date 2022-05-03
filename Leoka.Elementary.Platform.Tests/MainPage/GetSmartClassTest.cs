using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetSmartClassTest : BaseServiceTest
{
    [Test]
    public async Task GetStudentSmartClassAsyncTest()
    {
        var result = await MainPageService.GetSmartClassAsync(1);
        
        Assert.IsNotNull(result);
    }
    
    [Test]
    public async Task GetMentorSmartClassAsyncTest()
    {
        var result = await MainPageService.GetSmartClassAsync(2);
        
        Assert.IsNotNull(result);
    }
}