using EventManagementAPICRUD.Models;
using EventManagementAPICRUD.Reporsitory;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPICRUD.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ManagementDbContext context;
        public EventRepository(ManagementDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            var data = await context.Events.ToListAsync();
            return data;
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            var data = await context.Events.FindAsync(id);
            return data ?? null;
        }
        public async Task<bool> CreateEventAsync(Event objEvent)
        {
            await context.Events.AddAsync(objEvent);
            int changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<Event> UpdateEventAsync(Event objEvent)
        {
            var data = context.Events.Update(objEvent);
            await context.SaveChangesAsync();
            return objEvent;
        }
        public async Task<Event> DeleteEventAsync(int id)
        {
            var data = await context.Events.FindAsync(id);
            if (data != null)
            {
                context.Events.Remove(data);
                await context.SaveChangesAsync();
            }
            return data ?? null;
        }

        public async Task<List<Event>> SearchEventAsync(SearchEvent searchEvent)
        {
            var query = context.Events.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchEvent.Name))
            {
                query = query.Where(e => e.Name.Contains(searchEvent.Name));
            }

            if (searchEvent.Date !=null)
            {
                query = query.Where(e => e.Date.Date == searchEvent.Date);
            }

            if (!string.IsNullOrWhiteSpace(searchEvent.Location))
            {
                query = query.Where(e => e.Location.Contains(searchEvent.Location));
            }

            var data = await query.ToListAsync();
            return data ?? new List<Event>();
        }

    }
}

