using Infrastructure.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using WebApp.Models;
using WebApp.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _manager;

        public CoursesController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> manager)
        {
            _signInManager = signInManager;
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            TempData["message"] = "";
            var courses =await GetCourseDetails();
            return View(courses);
        }
        [Route("/details")]
        public async Task<IActionResult> Details(int id)
        {
            using var http = new HttpClient();
            var response = await http.GetAsync($"https://localhost:7098/api/Courses?id={id}");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(json);

            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseRegisterationFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();
                var json = JsonConvert.SerializeObject(model);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await http.PostAsync($"https://localhost:7098/api/Courses", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Courses");
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(BuyCourse model)
        {
            var courses = await GetCourseDetails();
            if (ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model.userId = userId;
                var course = await GetCourseDetailsByUserIdAndBatchId(userId, model.batchId);
                if (course.Count()>0)
                {
                    TempData["message"] = "Already In The Batch";
                    return View(courses);
                }

                //using var http = new HttpClient();
                //var json = JsonConvert.SerializeObject(model);
                //using var content = new StringContent(json, Encoding.UTF8, "application/json");
                //var response = await http.PostAsync($"http://localhost:5233/api/Orders/BuyCourse", content);
                //if (response.IsSuccessStatusCode)
                //{
                //    TempData["message"] = "Successfully Purchase";
                //    return RedirectToAction("Index", "Courses");
                //}
            }
            
            return View(courses);
        }

        public async Task<CourseIndexViewModel> GetCourseDetails()
        {
            var viewmodel = new CourseIndexViewModel();
            using var http = new HttpClient();
            var response = await http.GetAsync("https://localhost:7098/api/Courses");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<CourseViewModel>>(json);
                if (data != null && data.Any())
                {
                    foreach (var item in data)
                    {
                        item.ImageName = "https://localhost:7098/Resources/images/" + item.ImageName;
                    }
                    viewmodel.Courses = data;
                }


            }
            return viewmodel;
        }
        public async Task<List<UserCourseEntity>> GetCourseDetailsByUserIdAndBatchId(string userId,int batchId)
        {
            var viewmodel = new CourseIndexViewModel();
            using var http = new HttpClient();
            var response = await http.GetAsync("https://localhost:7098/api/UserCourses/GetCourseDetailsByUserIdAndBatchId/userId/" + userId+"/batchId/"+ batchId);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<UserCourseEntity>>(json);
                if (data != null && data.Any())
                {
                    return data.ToList();
                }


            }
            return new List<UserCourseEntity>();
        }

        //[Route("/subscribe")]
        //public  IActionResult Subscribe()
        //{
        //    ViewData["Subscribed"] = false;
        //    return View();
        //}
        //[Route("/subscribe")]
        //[HttpPost]
        //public async Task<IActionResult> Subscribe(SubscriberEntity entity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using var http = new HttpClient();
        //        var json = JsonConvert.SerializeObject(entity);
        //        using var content=new StringContent(json,Encoding.UTF8,"pplication/json");
        //        var response = await http.PostAsync($"http://localhost:5233/api/Subscribers?email={entity.Email}",content);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            ViewData["Subscribed"] = true;
        //        }
        //    }
        //    return View();
        //}


    }
}
