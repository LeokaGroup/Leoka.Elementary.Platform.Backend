using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetWriteReceptionTest : BaseServiceTest
{
    [Test]
    public async Task GetWriteReceptionAsyncTest()
    {
        var result = await PostgreDbContext.WriteReception.AnyAsync();
        
        Assert.IsTrue(result);
    }
}