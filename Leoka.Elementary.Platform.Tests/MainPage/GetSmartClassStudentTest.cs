using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetSmartClassStudentTest : BaseServiceTest
{
    [Test]
    public async Task GetSmartClassStudentAsyncTest()
    {
        var result = await PostgreDbContext.SmartClassStudent.AnyAsync();

        Assert.IsTrue(result);
    }
}