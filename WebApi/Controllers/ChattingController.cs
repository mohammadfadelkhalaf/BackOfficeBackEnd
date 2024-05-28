using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Dtos;
using WebApi.Hubs;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChattingController : ControllerBase
    {
        private readonly ChattingRepository _chattingRepository;
        private readonly IToastNotificationRepository _toastNotificationRepository;

        public ChattingController(ChattingRepository chattingRepository, IToastNotificationRepository toastNotificationRepository)
        {
            _chattingRepository = chattingRepository;
            _toastNotificationRepository = toastNotificationRepository;
        }

        [HttpGet("getallchattinglistbyuserid")]
        public async Task<IActionResult> GetAllChattingOfUserAsync(string toUserId, string fromUserId)
        {
            try
            {
                var res = await _chattingRepository.GetAllChattingOfUserById(toUserId, fromUserId);
                return Ok(res);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getallchattinglistbyuseridwithpagination")]
        public async Task<IActionResult> GetAllChattingOfUserByIdByPaginationAsync(string toUserId, string fromUserId, int pageNumber, int noOfRowsPerPage)
        {
            try
            {
                var res = await _chattingRepository.GetAllChattingOfUserByIdByPaginationAsync(toUserId, fromUserId, pageNumber, noOfRowsPerPage);
                return Ok(res);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertIntoChatAsync(ChattingView chattingView)
        {
            try
            {
                var res = await _chattingRepository.CreateChat(chattingView);
                await _toastNotificationRepository.ChattingNotification(NotificationMapper.ChattingViewMapToChattingNotification(chattingView));
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("chatpreview")]
        public async Task<IActionResult> getChatPreviewAsync(string id)
        {
            try
            {
                var res = await _chattingRepository.GetChatPreview(id);

                return Ok(res);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updateunreadmessage")]
        public async Task<IActionResult> UpdateUnreadmessage(string fromUserId, string toUserId, string userid)
        {
            try
            {
                var res = await _chattingRepository.UpdateChattingIsRead(fromUserId, toUserId, userid);

                return Ok(res);
            }
            catch
            {
                throw;
            }
        }
    }
}
