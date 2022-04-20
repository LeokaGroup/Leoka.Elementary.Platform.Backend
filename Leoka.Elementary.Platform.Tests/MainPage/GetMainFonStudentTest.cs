using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetMainFonStudentTest : BaseServiceTest
{
    [Test]
    public async Task GetMainFonStudentAsyncTest()
    {
        var result = await PostgreDbContext.MainFonStudent.AnyAsync();
        
        Assert.IsTrue(result);
    }
}