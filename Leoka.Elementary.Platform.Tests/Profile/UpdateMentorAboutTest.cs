using System.Collections.Generic;
using System.Threading.Tasks;
using Leoka.Elementary.Platform.Models.Profile.Input;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.Profile;

[TestFixture]
public class UpdateMentorAboutTest : BaseServiceTest
{
    [Test]
    public async Task UpdateMentorAboutAsyncTest()
    {
        var result = await ProfileService.UpdateMentorAboutAsync(new List<MentorAboutInfo>
        {
            new()
            {
                AboutInfoText = "test"
            },
            
            new()
            {
                AboutInfoText = "О себе"
            }
        }, "skyexx@mail.ru");
        
        Assert.IsNotNull(result);
    }
}