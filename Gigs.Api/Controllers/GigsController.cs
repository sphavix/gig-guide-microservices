using Gigs.Domain.Entities;
using Gigs.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Gigs.Api.Controllers
{
    public class GigsController : BaseApiController
    {
        private readonly ApplicationDbContext _context;
        public GigsController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<ActionResult<List<Gig>>> GetGigs()
        {
            return await _context.Gigs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gig>> GetGig(Guid id)
        {
            return await _context.Gigs.FindAsync(id);
        }
    }
}