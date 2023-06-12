using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data
{
    public class FirmaContextFactory :IDesignTimeDbContextFactory<FirmaContext>
    {
        public FirmaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FirmaContext>();
            optionsBuilder.UseSqlServer("Server=KACPER;Database=FirmaContext2023;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new FirmaContext(optionsBuilder.Options);
        }
    }
}
