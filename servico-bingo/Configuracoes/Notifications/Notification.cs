using System.Net;

namespace OrcamentoGenerico.Api.Configuracoes.Notifications
{
    public class Notification
    {
        public string Message { get; }
        public HttpStatusCode StatusCode { get; }

        public Notification(string message)
        {
            Message = message;
            StatusCode = HttpStatusCode.BadRequest;
        }

        public Notification(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

    }
}
