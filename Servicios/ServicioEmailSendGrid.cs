using ProyectoPortafolioNetCore.Interfaces;
using ProyectoPortafolioNetCore.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ProyectoPortafolioNetCore.Servicios
{
    public class ServicioEmailSendGrid : IServicioEmail
    {
        private IConfiguration configuration;

        public ServicioEmailSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(Contacto contacto)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $"El cliente {contacto.Email} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            var mensajeTextoPlano = contacto.Comentario;
            var contenidoHtml = @$"De: {contacto.Nombre} -
                                    Email: {contacto.Email}
                                    Mensaje: {contacto.Comentario}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }
    }
}
