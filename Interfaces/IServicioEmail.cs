using ProyectoPortafolioNetCore.Models;

namespace ProyectoPortafolioNetCore.Interfaces
{
    public interface IServicioEmail
    {
        Task Enviar(Contacto contacto);
    }
}
