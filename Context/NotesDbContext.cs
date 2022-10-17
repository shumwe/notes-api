using Microsoft.EntityFrameworkCore;
using NotesApi.Models;

namespace NotesApi.Context
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options):base(options)
        {}

        public DbSet<Notes>? Notes {get; set;}
    }
}