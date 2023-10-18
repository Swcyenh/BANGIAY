using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BANGIAY.Models;

namespace BANGIAY.Data
{
    public class BANGIAYContext : DbContext
    {
        public BANGIAYContext (DbContextOptions<BANGIAYContext> options)
            : base(options)
        {
        }

        public DbSet<BANGIAY.Models.ItemInfo> ItemInfo { get; set; } = default!;
    }
}
