using System.Collections;
using System.Collections.ObjectModel;
using System.Net;

namespace OrcamentoGenerico.Api.Configuracoes.Notifications
{
    public class NotificationContext : IEnumerable<Notification>
    {
        private readonly Collection<Notification> _notifications = new Collection<Notification>();

        public bool HasNotifications => _notifications.Any();

        public int Count => _notifications.Count;

        public IEnumerator<Notification> GetEnumerator() => _notifications.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _notifications.GetEnumerator();

        public IEnumerable<string> GetMessage() => _notifications.Select(x => x.Message);

        public void Add(string message) => _notifications.Add(new Notification(message));

        public void Add(string message, HttpStatusCode statusCode) => _notifications.Add(new Notification(message, statusCode));

    }
}
