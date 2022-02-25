using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManterClasseAPI.Models;

namespace ManterClasseAPI.Data
{
    public class ManterClasseAPIContext : DbContext
    {
        public ManterClasseAPIContext (DbContextOptions<ManterClasseAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ManterClasseAPI.Models.ClasseObjeto> ClasseObjeto { get; set; }
    }
}
