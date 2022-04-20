using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetMentorWorkTest : BaseServiceTest
{
    [Test]
    public async Task GetMentorWorkAsyncTest()
    {
        var result = await PostgreDbContext.MentorWork.AnyAsync();

        Assert.IsTrue(result);
    }
}