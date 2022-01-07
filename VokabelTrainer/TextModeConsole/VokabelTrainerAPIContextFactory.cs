using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextModeConsole
{
    public class VokabelTrainerAPIContextFactory : IDesignTimeDbContextFactory<VokabelTrainerAPI.Data.VokabelTrainerAPIContext>
    {
        public VokabelTrainerAPI.Data.VokabelTrainerAPIContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VokabelTrainerAPI.Data.VokabelTrainerAPIContext>();

            optionsBuilder.UseSqlite("Data Source = c:\\temp\\vokabeln.db");

            return new VokabelTrainerAPI.Data.VokabelTrainerAPIContext(optionsBuilder.Options);
        }
    }
}
