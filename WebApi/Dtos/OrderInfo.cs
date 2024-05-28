using Infrastructure.Entites;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CourseBatchId { get; set; }
        public Double PaidAmount { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public BatchEntity Batch { get; set; }
    }
}
