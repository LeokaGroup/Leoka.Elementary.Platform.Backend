﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Leoka.Elementary.Platform.Tests.MainPage;

[TestFixture]
public class GetWhereBeginItemsTest : BaseServiceTest
{
    [Test]
    public async Task GetWhereBeginItemsAsyncTest()
    {
        var result = await PostgreDbContext.WhereBeginItems.AnyAsync();
        
        Assert.IsTrue(result);
    }
}