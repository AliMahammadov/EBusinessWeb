using EBusinessEntity.Entities;

namespace EBusinessViewModel.Entities.Home
{
    public class HomeVM
    {
        public ICollection<Contact> contacts { get; set; }
        public ICollection<Blog> blogs { get; set; }

    }
}
