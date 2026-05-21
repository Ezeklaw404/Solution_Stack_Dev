using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution_stack_shared.models
{
    public class OrderUpdateDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public OrderStatus Status { get; set; }
    }
}
