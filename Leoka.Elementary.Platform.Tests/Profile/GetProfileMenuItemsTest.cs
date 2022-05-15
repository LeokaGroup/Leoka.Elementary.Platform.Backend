using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Profile;

[TestFixture]
public class GetProfileMenuItemsTest : BaseServiceTest
{
    [Test]
    public async Task GetProfileMenuItemsAsyncTest()
    {
        var result = await ProfileService.GetProfileMenuItemsAsync("skyexx@mail.ru");

        Assert.IsNotNull(result);
        Assert.IsTrue(result.ProfileLeftMenuItems.Any());
        Assert.IsTrue(result.ProfileHeaderMenuItems.Any());
        Assert.IsTrue(result.ProfileDropdownMenuItems.Any());
    }
}