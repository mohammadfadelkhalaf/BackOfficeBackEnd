using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class OrderDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int CourseBatchId { get; set; }
        [Required]
        public Double PaidAmount { get; set; }
    }
}
