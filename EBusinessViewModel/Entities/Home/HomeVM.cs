using EBusinessEntity.Entities;


    public class HomeVM
    {
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Position>? Positions { get; set; }


    }

