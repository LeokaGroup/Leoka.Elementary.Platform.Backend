using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetHeaderItemsTest : BaseServiceTest
{
    [Test]
    public async Task GetHeaderItemsAsyncTest()
    {
        var result = await PostgreDbContext.Header.ToListAsync();

        Assert.IsTrue(result.Any());
    }
}