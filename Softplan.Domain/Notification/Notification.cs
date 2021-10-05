using MediatR;

namespace Softplan.Domain.Notification
{
	public class Notification : INotification
	{
		public string Key { get; }
		public string Message { get; }

		public Notification(string key, string message)
		{
			Key = key;
			Message = message;
		}
	}
}
