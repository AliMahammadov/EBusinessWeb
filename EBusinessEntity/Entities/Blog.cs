using EBusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBusinessEntity.Entities
{
    public class Blog:EntityBase
    {
        public string Name { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
