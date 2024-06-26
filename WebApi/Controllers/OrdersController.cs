﻿using Infrastructure.Context;
using Infrastructure.Entites;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Hubs;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly OrdersRepository _ordersRepository;
        private readonly UserCoursesRepository _userCoursesRepository;
        private readonly IToastNotificationRepository _toastNotificationRepository;
        private readonly UserRepository _userRepository;
        private readonly BatchRepository _batchRepository;

        public OrdersController(DataContext context, OrdersRepository ordersRepository,
            UserCoursesRepository userCoursesRepository,
            IToastNotificationRepository toastNotificationRepository,
            UserRepository userRepository, BatchRepository batchRepository)
        {
            _context = context;
            _ordersRepository = ordersRepository;
            _userCoursesRepository = userCoursesRepository;
            _toastNotificationRepository = toastNotificationRepository;
            _userRepository = userRepository;
            _batchRepository = batchRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Orders = await _ordersRepository.GetOrderWithDetails();

            if (Orders != null)
                return Ok(Orders);
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Course = await _ordersRepository.GetSingleOrderWithDetails(id);
            if (Course != null)
                return Ok(Course);
            return NotFound();
        }

        [HttpGet("GetOrderDetailsByUserId/{userId}")]
        public async Task<IActionResult> GetOrderDetailsByUserId(string userId)
        {
            var Course = await _ordersRepository.GetOrderWithDetailsByUserId(userId);
            if (Course != null)
                return Ok(Course);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _ordersRepository.DeleteOneAsync(x => x.Id == id);
            if (response.StausCode == Infrastructure.Models.StatusCode.Ok)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDto entity)
        {
            var orderentity = new OrderEntity
            {
                Id = id,
                UserId = entity.UserId,
                BatchId = entity.CourseBatchId,
                PaidAmount = entity.PaidAmount,
                IsActive = true,
                IsCancel = false,
                CreatorId = entity.UserId,
                ModifierId = entity.UserId,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };
            var response = await _ordersRepository.UPdateOneAsync(x => x.Id == id, orderentity);
            if (response.StausCode == Infrastructure.Models.StatusCode.Ok)
                return Ok("Updated");
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneOrder(OrderDto entity)
        {
            if (ModelState.IsValid)
            {
                var orderentity = new OrderEntity
                {
                    UserId = entity.UserId,
                    BatchId = entity.CourseBatchId,
                    PaidAmount = entity.PaidAmount,
                    IsActive = true,
                    IsCancel = false,
                    CreatorId = entity.UserId,
                    ModifierId = entity.UserId,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                };
                await _ordersRepository.CreateAsync(orderentity);

                return Created("", orderentity);
            }
            return BadRequest();
        }
        [HttpPost("BuyCourse")]
        public async Task<IActionResult> CreateOneOrder(BuyCourse entity)
        {
            if (ModelState.IsValid)
            {
                var orderentity = new OrderEntity
                {
                    UserId = entity.userId,
                    BatchId = entity.batchId,
                    PaidAmount = entity.price,
                    IsActive = true,
                    IsCancel = false,
                    CreatorId = entity.userId,
                    ModifierId = entity.userId,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                };
                await _ordersRepository.CreateAsync(orderentity);

                await _userCoursesRepository.CreateAsync(new UserCourseEntity()
                {
                    BatchId = entity.batchId,
                    IsFullyPaid = true,
                    IsCompleted = false,
                    UserId = entity.userId,
                    CreatorId = entity.userId,
                    ModifierId = entity.userId,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                });
                var adminUsers = await _userRepository.GetAllUserAsync(x => x.RolesId == 1 || x.RolesId == 2);
                var joinedUserDetails = await _userRepository.GetOneUserAsync(x => x.Id == entity.userId);
                var batchDetails = await _batchRepository.GetOneBatchesWithDetails(x => x.Id == entity.batchId);
                foreach (var user in adminUsers)
                {
                    NotificationUserDto mapperdata = new NotificationUserDto();
                    mapperdata.Details = joinedUserDetails.UserName + " joined Batch Name: " + batchDetails.BatchName + ", Course name: " + batchDetails.Course.Title;
                    mapperdata.Id = entity.userId;
                    mapperdata.NotificationForId = user.Id;
                    await _toastNotificationRepository.CommonNotification(NotificationMapper.NotificationObjectViewMapNotification(mapperdata, mapperdata.Id, mapperdata.Details, "GetNotification"));

                }

                return Created("", orderentity);
            }
            return BadRequest();
        }
    }
}
