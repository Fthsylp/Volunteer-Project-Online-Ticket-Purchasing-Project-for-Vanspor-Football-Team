using CourseProject.Models.Data;
using CourseProject.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories
{
    public class ContactDetailsRepository : IContactDetailsRepository
    {
        private readonly TicketApplicationContext _ticketApplicationContext;

        public ContactDetailsRepository(TicketApplicationContext ticketApplicationContext)
        {
            _ticketApplicationContext = ticketApplicationContext;
        }

        public async Task<IEnumerable<ContactDetail>> GetAllAsync()
        {
           return await _ticketApplicationContext.ContactDetails.ToListAsync();
        }
        public Task<ContactDetail?> GetAsync(int id)
        {
            return _ticketApplicationContext.ContactDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContactDetail?> UpdateAsync(ContactDetail contactDetail)
        {
            var existingContact = await _ticketApplicationContext.ContactDetails.FindAsync(contactDetail.Id);
            if (existingContact != null) 
            {
                existingContact.Title = contactDetail.Title;
                existingContact.SecondTitle = contactDetail.SecondTitle;
                existingContact.Description = contactDetail.Description;
                existingContact.ButtonName = contactDetail.ButtonName;
                existingContact.PhoneNumber = contactDetail.PhoneNumber;
                existingContact.EmailAdress = contactDetail.EmailAdress;
                existingContact.Adress = contactDetail.Adress;

                await _ticketApplicationContext.SaveChangesAsync();
                return contactDetail;
            }
            return null;
        }
    }
}
