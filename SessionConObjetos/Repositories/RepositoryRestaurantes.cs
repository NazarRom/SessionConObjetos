using SessionConObjetos.Data;
using SessionConObjetos.Models;

namespace SessionConObjetos.Repositories
{
 
    public class RepositoryRestaurantes
    {
        private RestaurantesContext context;
        public RepositoryRestaurantes(RestaurantesContext context)
        {
            this.context = context;
        }

        public List<Restaurante> GetRestaurantes()
        {
             return this.context.Restaurantes.ToList();
        }

        public Restaurante FindRestaurante(int idrest)
        {
            return this.context.Restaurantes.FirstOrDefault(z => z.IdRestaurante == idrest);
        }


    }
}
