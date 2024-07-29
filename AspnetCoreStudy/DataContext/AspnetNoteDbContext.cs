using AspnetCoreStudy.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;


namespace AspnetCoreStudy.DataContext
{


        public class AspnetNoteDbContext : DbContext
        {
        public AspnetNoteDbContext()
        {
        }

        public DbSet<User> Members { get; set; }

            public DbSet<Note> Notes { get; set; }

       
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=bb;User Id=sa;Password=a123; TrustServerCertificate=True");
        }
    }
}


//optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=AspnetCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

//@"Server=localhost;Database=AspnetNoteDb;User Id=sa;Password=a123;
