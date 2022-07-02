using System.Threading.Tasks;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Profile;

[TestFixture]
public class SaveStudententorAgeTest : BaseServiceTest
{
    [Test]
    public async Task SaveStudententorAgeAsyncTest()
    {
        var result = await ProfileService.SaveStudentMentorAgeAsync(3, "skyexx@mail.ru");

        Assert.IsNotNull(result.StudentAgeMentor);
        Assert.IsTrue(result.StudentAgeMentor.MentorAge.AgeId > 0);
    }
}