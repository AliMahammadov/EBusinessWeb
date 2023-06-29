using EBusinessData.UnitOfWorks;
using EBusinessEntity.Entities;
namespace EBusinessService.Services
{

    internal class ContactService : IContactService
    {
        private readonly IUnitOfWork unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddContactAsync(Contact contact)
        {
            await unitOfWork.GetRepository<Contact>().AddAsync(contact);
            await unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteContactAsync(int id)
        {
            var contactId = await unitOfWork.GetRepository<Contact>().GetByIdAsync(id);
            await unitOfWork.GetRepository<Contact>().DeleteAsync(contactId);
            await unitOfWork.SaveChangeAsync();

        }

        public async Task<ICollection<Contact>> GetAllContactsAsync()
        {
            return await unitOfWork.GetRepository<Contact>().GetAllAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await unitOfWork.GetRepository<Contact>().GetByIdAsync(id);
        }
    }
}
