using GildedRose.Items;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GildedRose
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}