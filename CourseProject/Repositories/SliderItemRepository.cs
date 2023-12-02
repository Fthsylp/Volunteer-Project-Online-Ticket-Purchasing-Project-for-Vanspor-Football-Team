using CourseProject.Models.Data;
using CourseProject.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseProject.Repositories
{
    public class SliderItemRepository : ISliderItemRepository
    {
        private readonly TicketApplicationContext _ticketApplicationContext;

        public SliderItemRepository(TicketApplicationContext ticketApplicationContext)
        {
            _ticketApplicationContext = ticketApplicationContext;
        }

        public async Task<SliderItem?> AddAsync(SliderItem sliderItem)
        {
            await _ticketApplicationContext.SliderItems.AddAsync(sliderItem);
            await _ticketApplicationContext.SaveChangesAsync();
            return sliderItem;
        }

        public async Task<SliderItem?> DeleteAsync(int id)
        {
            var existingSliderItem = await _ticketApplicationContext.SliderItems.FindAsync(id);
            if (existingSliderItem != null)
            {
                _ticketApplicationContext.SliderItems.Remove(existingSliderItem);
                await _ticketApplicationContext.SaveChangesAsync();
                return existingSliderItem;
            }
            return null;
        }

        public async Task<IEnumerable<SliderItem>> GetAllAsync()
        {
            return await _ticketApplicationContext.SliderItems.ToListAsync();
        }

        public Task<SliderItem?> GetAsync(int id)
        {
            return _ticketApplicationContext.SliderItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SliderItem?> UpdateAsync(SliderItem sliderItem)
        {
            var existingSliderItem = await _ticketApplicationContext.SliderItems.FindAsync(sliderItem.Id);

            if (existingSliderItem != null)
            {
                existingSliderItem.Title = sliderItem.Title;
                existingSliderItem.Description = sliderItem.Description;
                existingSliderItem.Image = sliderItem.Image;
                existingSliderItem.Date = sliderItem.Date;

                await _ticketApplicationContext.SaveChangesAsync();
                return existingSliderItem;
            }
            return null;
        }

    }
}
