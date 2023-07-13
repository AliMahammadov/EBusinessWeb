using EBusinessEntity.Entities;


    public class HomeVM
    {
        public IEnumerable<Contact>? Contacts { get; set; }
        public IEnumerable<Employee>? Employees { get; set; }
        public IEnumerable<Position>? Positions { get; set; }
        public IEnumerable<Blog>? Blogs { get; set; }
        public IEnumerable<Post>? Posts { get; set; }
        public IEnumerable<About>? Abouts { get; set;}



    }

