using LivrariaWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LivrariaWeb.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Escritor> Escritors { get; set; }

        public DbSet<Livros> Livros { get; set; }
    }
}