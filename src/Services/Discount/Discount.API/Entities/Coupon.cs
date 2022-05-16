using Discount.API.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.API.Entities
{
    public class Coupon : BaseModel<int>
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }
    }
}
