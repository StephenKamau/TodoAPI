﻿using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) {
        }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
