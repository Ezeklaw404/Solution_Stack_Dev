using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution_stack_shared.models
{
    public class Order
    {
        public string ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        New = 0,
        InProgress = 1,
        Completed = 2,
        Cancelled = 3
    }
}
