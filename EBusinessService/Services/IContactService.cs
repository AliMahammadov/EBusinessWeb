using EBusinessEntity.Entities;
namespace EBusinessService.Services
{
    public interface IContactService
    {
        Task AddContactAsync(Contact contact);
        Task DeleteContactAsync(int id);
        Task<ICollection<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);


    }
}
