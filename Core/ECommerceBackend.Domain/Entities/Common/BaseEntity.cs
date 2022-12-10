using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
