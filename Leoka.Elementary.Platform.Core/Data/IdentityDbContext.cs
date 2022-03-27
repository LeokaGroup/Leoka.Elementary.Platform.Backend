using Leoka.Elementary.Platform.Models.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Core.Data;

public sealed class IdentityContext : IdentityDbContext<UserEntity>
{
    public IdentityContext(DbContextOptions<IdentityDbContext> options) : base(options) { }
}