using ProyectoPortafolioNetCore.Models;

namespace ProyectoPortafolioNetCore.Interfaces
{
    public interface IRepositorioProyecto
    {
        List<Proyecto> ObtenerProyectos();
    }
}
