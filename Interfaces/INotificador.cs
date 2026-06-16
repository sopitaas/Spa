using Spa.Models;

namespace Spa.Interfaces
{
    public interface INotificador
    {
        // RF3: Envía la notificación simulada usando los datos de la cita
        void EnviarConfirmacion(Cita cita);
    }
}