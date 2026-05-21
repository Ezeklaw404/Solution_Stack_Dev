using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution_stack_shared.models
{
    public class OrderUpdateDto : OrderBase
    {
        public OrderStatus Status { get; set; }
    }
}
