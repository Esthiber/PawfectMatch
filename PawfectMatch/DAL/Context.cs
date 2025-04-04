using Microsoft.EntityFrameworkCore;

namespace PawfectMatch.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }


    }
}
