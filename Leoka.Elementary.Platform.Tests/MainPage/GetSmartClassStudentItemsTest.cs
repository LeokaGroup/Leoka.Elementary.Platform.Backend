using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetSmartClassStudentItemsTest : BaseServiceTest
{
    [Test]
    public async Task GetSmartClassStudentItemsAsyncTest()
    {
        var result = await PostgreDbContext.SmartClassStudentItems.AnyAsync();

        Assert.IsTrue(result);
    }
}