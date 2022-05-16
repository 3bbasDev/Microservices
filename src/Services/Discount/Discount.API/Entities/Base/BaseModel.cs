using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.API.Entities.Base
{
    public class BaseModel<TId>
    {
        public TId? Id { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
