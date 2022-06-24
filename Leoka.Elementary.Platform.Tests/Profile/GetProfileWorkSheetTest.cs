using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Profile;

[TestFixture]
public class GetProfileWorkSheetTest : BaseServiceTest
{
    [Test]
    public async Task GetProfileWorkSheetAsyncTest()
    {
        var result = await ProfileService.GetProfileWorkSheetAsync("skyexx@mail.ru");
        
        Assert.IsNotNull(result);
    }
}