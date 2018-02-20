using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WebApplication8.Models
{
    public class UserDBContext :DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
    : base(options)
        { }

        public DbSet<PersonalInfo> User { get; set; }
        public DbSet<CreditCard> Cards { get; set; }

    }
}
