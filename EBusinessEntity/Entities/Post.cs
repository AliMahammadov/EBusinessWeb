using EBusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EBusinessEntity.Entities
{
    public  class Post:EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
