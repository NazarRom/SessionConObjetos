
using Microsoft.EntityFrameworkCore;
using SessionConObjetos.Models;

namespace SessionConObjetos.Data
{

    public class RestaurantesContext : DbContext
    {
        public RestaurantesContext(DbContextOptions<RestaurantesContext> options) 
            : base(options) { }
        public DbSet<Restaurante> Restaurantes { get; set; }
    }
}
