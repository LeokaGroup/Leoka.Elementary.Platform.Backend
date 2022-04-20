using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Common;

[TestFixture]
public class GetHeaderItemsTest : BaseServiceTest
{
    [Test]
    public async Task GetHeaderItemsAsyncTest()
    {
        var result = await PostgreDbContext.Header.AnyAsync();

        Assert.IsTrue(result);
    }
}