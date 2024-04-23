using Microsoft.EntityFrameworkCore;
using Payments.Infrastructure.Data.Models;

namespace Payments.Infrastructure.Data.Context
{
    public partial class AuthorizationContext : DbContext
    {
        public AuthorizationContext(DbContextOptions<AuthorizationContext> options) : base(options) { }

        public virtual DbSet<AuthorizationModel> Authorizations { get; set; }
        public virtual DbSet<ApprovedAuthorizationModel> ApprovedAuthorizations { get; set; }
    }
}
