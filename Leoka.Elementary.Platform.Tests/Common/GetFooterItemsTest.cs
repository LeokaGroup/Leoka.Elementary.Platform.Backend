using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Common;

[TestFixture]
public class GetFooterItemsTest : BaseServiceTest
{
    [Test]
    public async Task GetFooterItemsAsyncTest()
    {
        var result = await PostgreDbContext.Footer.AnyAsync();
        
        Assert.IsTrue(result);
    }
}