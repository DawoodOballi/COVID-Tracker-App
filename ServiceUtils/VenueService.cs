using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ServiceUtils
{
    public class VenueService
    {
        public readonly CovidTrackerContext _context;

        public VenueService(CovidTrackerContext context)
        {
            _context = context;
        }

        public async Task AddNewVenueAsync(Venue venue)
        {
            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserAsync(Venue venue)
        {
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
        }
    }
}
