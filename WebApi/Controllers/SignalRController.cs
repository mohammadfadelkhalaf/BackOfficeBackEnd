using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Hubs;
using Infrastructure.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : ControllerBase
    {
        private IToastNotificationRepository messageHub;
        public SignalRController(IToastNotificationRepository _messageHub)
        {
            messageHub = _messageHub;
        }

        [HttpPost]
        [Route("SendNotification")]
        public IActionResult SendNotificationToGroup([FromBody] ToastNotificationView message)
        {
            ToastNotificationView notificationView = new ToastNotificationView()
            {
                Id = Guid.NewGuid().ToString(),
                NotificationMessage = message.NotificationMessage,
                Description = message.Description,
                ClientId = "test",
                Creationdate = DateTime.Now,
                IsRead = true
            };

            messageHub.SendNotificationAsync(notificationView);
            return Ok();
        }

        public class ChatMessage
        {
            public string User { get; set; }
            public string senderId { get; set; }
            public string Message { get; set; }
        }

        public class NotificationMessage
        {
            public string NotificationText { get; set; }
            public string Description { get; set; }
        }
    }
}
