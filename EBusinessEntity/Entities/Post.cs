using EBusinessCore.Entities;

namespace EBusinessEntity.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
