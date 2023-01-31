using ProyectoPortafolioNetCore.Interfaces;
using ProyectoPortafolioNetCore.Models;

namespace ProyectoPortafolioNetCore.Servicios
{
    public class RepositorioProyectos : IRepositorioProyecto
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto> { new Proyecto
            {
                Titulo= "Amazon",
                Descripcion= "E-Commerce realizado en ASP.NET Core",
                link= "https://amazon.com",
                ImagenURL ="/images/amazon.png"
            },
            new Proyecto
            {
                Titulo= "New York Times",
                Descripcion= "Página de noticias en React",
                link= "https://nytimes.com",
                ImagenURL ="/images/nyt.png"
            },
            new Proyecto
                {
                Titulo= "Reddit",
                Descripcion= "Red social para compartir en comunidades",
                link= "https://reddit.com",
                ImagenURL ="/images/reddit.png"
            },
            new Proyecto
                {
                Titulo= "Steam",
                Descripcion= "Tienda on-line para comprar videojuegos",
                link= "https://store.steampowered.com",
                ImagenURL ="/images/steam.png"
            }
            };
        }
    }
}
