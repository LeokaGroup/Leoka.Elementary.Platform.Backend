using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Role;

[TestFixture]
public class GetRolesTest : BaseServiceTest
{
    [Test]
    public async Task GetRolesAsyncTest()
    {
        var result = await RoleService.GetRolesAsync();
        
        Assert.IsTrue(result.Any());
    } 
}