using Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
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
