using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.LessonTemplate;

[TestFixture]
public class GetTemplateNamesByTypeTest : BaseServiceTest
{
    [Test]
    public async Task GetTemplateNamesByTypeAsyncTest()
    {
        var result = await TemplateService.GetTemplateNamesByTypeAsync("EnglishTemplate_1");

        Assert.IsTrue(result.Any());
    }
}