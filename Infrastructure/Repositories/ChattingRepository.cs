using Infrastructure.Context;
using Infrastructure.Dtos;
using Infrastructure.Entites;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ChattingRepository : GenericRepository<OrderEntity>
    {
        private readonly DataContext _context;

        public ChattingRepository(DataContext context) : base(context) { _context = context; }

        public async Task<ChattingView> CreateChat(ChattingView chatting)
        {
            try
            {
                var chat = await _context.Chats.Where(s => s.ToUserId == chatting.ToUserId && s.FromUserId == chatting.FromUserId).ToListAsync();
                Random random = new Random();
                if (chat.Count() == 0)
                {


                    await _context.UserChats.AddAsync(new UserchatEntity()
                    {
                        ToUserId = chatting.ToUserId,
                        FromUserId = chatting.FromUserId
                    });
                }
                var insertedChat = new ChatEntity
                {
                    Message = chatting.Message,
                    CreationTimestamp = DateTime.Now,
                    LastUpdated = DateTime.Now,
                    FromUserId = chatting.FromUserId,
                    ToUserId = chatting.ToUserId,
                    UserId = chatting.UserId,
                    Edited = chatting.Edited,
                    Unread = chatting.Unread,
                    Deleted = chatting.Deleted
                };
                await _context.Chats.AddAsync(insertedChat);

                await _context.SaveChangesAsync();

                return chatting;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<ChattingView>> GetAllChattingOfUserById(string toUserId, string fromUserId)
        {
            var chat = await _context.Chats.Where(s => s.ToUserId == toUserId && s.FromUserId == fromUserId).ToListAsync();
            List<ChattingView> chatting = new List<ChattingView>();
            foreach (var item in chat)
            {
                ChattingView chatObj = new ChattingView
                {
                    Id = item.Id,
                    Message = item.Message,
                    CreationTimestamp = item.CreationTimestamp,
                    LastUpdated = item.LastUpdated,
                    FromUserId = item.FromUserId,
                    ToUserId = item.ToUserId,
                    UserId = item.UserId,
                    Edited = item.Edited,
                    Unread = item.Unread,
                    Deleted = item.Deleted
                };
                chatting.Add(chatObj);
            }
            return chatting;
        }
        public async Task<ChattingViewForPagination> GetAllChattingOfUserByIdByPaginationAsync(string toUserId, string fromUserId, int pageNumber, int noOfRowsPerPage)
        {
            var chat = await _context.Chats
            .Where(s => s.ToUserId == toUserId && s.FromUserId == fromUserId)
            .OrderByDescending(s => s.CreationTimestamp)
            .ToListAsync();

            var totalChat = await _context.Chats.Where(s => s.ToUserId == toUserId && s.FromUserId == fromUserId).ToListAsync();
            List<ChattingView> chatting = new List<ChattingView>();
            foreach (var item in chat)
            {
                ChattingView chatObj = new ChattingView
                {
                    Id = item.Id,
                    Message = item.Message,
                    CreationTimestamp = item.CreationTimestamp,
                    LastUpdated = item.LastUpdated,
                    FromUserId = item.FromUserId,
                    ToUserId = item.ToUserId,
                    UserId = item.UserId,
                    Edited = item.Edited,
                    Unread = item.Unread,
                    Deleted = item.Deleted
                };
                chatting.Add(chatObj);
            }
            ChattingViewForPagination chattingViewForPagination = new ChattingViewForPagination();
            chattingViewForPagination.chats = chatting;
            chattingViewForPagination.totalChats = totalChat.Count();
            return chattingViewForPagination;
        }
        public async Task<List<ChatPreview>> GetChatPreview(string Id)
        {
            try
            {
                var chatData = await _context.Chats
                   .Where(chat => chat.ToUserId == Id || chat.FromUserId == Id)
                   .Select(chat => new ChatPreview
                   {
                       ToUserId = chat.ToUserId,
                       FromUserId = chat.FromUserId,
                       LastMessage = chat.Message,
                       CreationTime = chat.CreationTimestamp.ToString("HH:mm:ss"),
                       FriendName = chat.ToUser.Id == Id ? chat.FromUser.UserName : chat.ToUser.UserName,
                       FriendUserId = chat.ToUser.Id == Id ? chat.FromUser.Id : chat.ToUser.Id,
                       ureadCount = _context.Chats.Count(c => c.ToUserId == chat.ToUserId && c.Unread),
                       CreateOn = chat.CreationTimestamp
                   })
                   .OrderByDescending(x => x.CreateOn)
                   .ToListAsync();

                var distinctChatData = chatData
                        .GroupBy(chat => new { chat.ToUserId, chat.FromUserId })
                        .Select(group => group.First())
                        .ToList();

                return distinctChatData;
            }
            catch (Exception ex)
            {
                return new List<ChatPreview>();
            }

        }
        public async Task<string> UpdateChattingIsRead(string fromUserId, string toUserId, string userid)
        {
            var chats = await _context.Chats
                .Where(s => s.ToUserId == toUserId && s.FromUserId == fromUserId)
                .ToListAsync();

            foreach (var chat in chats)
            {
                chat.Unread = false;
            }

            await _context.SaveChangesAsync(); var totalChat = await _context.Chats.Where(s => s.ToUserId == toUserId && s.FromUserId == fromUserId).ToListAsync();

            return "Updated";
        }

    }
}
