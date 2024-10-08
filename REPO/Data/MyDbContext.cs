﻿using CORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.DATA
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Designation> Designations { get; set; }

        public DbSet<ClassLevel> ClassLevels { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ResultSheet> ResultsSheets { get; set; }





    }
}