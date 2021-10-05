using Microsoft.AspNetCore.Mvc;
using Softplan.Api.Dto.Response;
using Softplan.Domain.Notification;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Softplan.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly NotificationContext _notificationContext;
        public BaseController(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected IEnumerable<Notification> Notifications => _notificationContext.Notifications;
        protected bool IsValidOperation => !_notificationContext.HasNotifications;

        protected  IActionResult Result<TData>(TData data)
          where TData : class
        {
            if (IsValidOperation) return ResultOk(data);

            return ResultErro(data, Notifications.Select(s => $"{s.Key} - {s.Message}"));
        }

        protected IActionResult Result()
        {
            if (IsValidOperation) return ResultOk();

            return ResultErro(Notifications.Select(s => $"{s.Key} - {s.Message}"));
        }

        protected IActionResult ResultOk()
        {
            return ResultOk("Sucesso!");
        }

        protected IActionResult ResultOk<TData>(TData data, IEnumerable<string> messages)
            where TData : class
        {
            return new JsonResult(new BaseResponse<TData>(data, true, HttpStatusCode.OK, messages));
        }

        protected IActionResult ResultOk<TData>(TData data)
            where TData : class
        {
            return new JsonResult(new BaseResponse<TData>(data, true, HttpStatusCode.OK));
        }

        private IActionResult ResultErro(IEnumerable<string> messages)
        {
            return ResultErro("Erro!", messages);
        }

        private IActionResult ResultErro<TData>(TData data, IEnumerable<string> messages)
            where TData : class
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return new JsonResult(new BaseResponse<TData>(data, false, HttpStatusCode.BadRequest, messages));
        }
    }
}
