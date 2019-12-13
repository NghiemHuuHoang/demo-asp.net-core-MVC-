using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.data
{
    public class Db:IdentityDbContext
    {
        public Db(DbContextOptions<Db> options):base(options)
        {

        }
        public DbSet<MVC> MVCs { get; set; }
    }
}
