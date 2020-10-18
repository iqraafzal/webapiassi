using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Assignment1.Data
{
    public class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext(DbContextOptions options): base (options)
        {

        }
        public DbSet<AuthenticationUser> AuthUsers { get; set; }
        public DbSet<Assignments> Asignmentss { get; set; }
        public DbSet<CourseAssignments> CourseAsignmentss { get; set; }
        public DbSet<Courses> Coursess { get; set; }
        public DbSet<UserCourses> Usercourses { get; set; }

    }
}
