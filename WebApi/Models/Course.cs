using Infrastructure.Entites;
using WebApi.Entities;

namespace WebApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ImageName { get; set; }
        public double Price { get; set; }
        public double DisCountPrice { get; set; }
        public double Hours { get; set; }
        public int LikesInNumbers { get; set; }
        public double LikesInProcent { get; set; }
        public string? Author { get; set; }
        public bool IsBestSeller { get; set; }
        //adding course data

        public static implicit operator Course(Infrastructure.Entites.CourseEntity courseentity)
        {


            return new Course
            { 
                Id = courseentity.Id,
                Title = courseentity.Title,
                Price = courseentity.Price,
                ImageName = courseentity.ImageName,
                DisCountPrice = courseentity.DisCountPrice,
                Hours = courseentity.TotalHours,
                IsBestSeller = courseentity.IsBestSeller,
                LikesInNumbers = courseentity.LikesInNumbers,
                LikesInProcent = courseentity.LikesInProcent,
                Author = courseentity.Author
            };
        }
    }
}
