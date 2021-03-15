using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Model;

namespace TestProject.Data
{
    public class TestContext :DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) :base(options)
        {
        }
        public DbSet<School>Schools { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
