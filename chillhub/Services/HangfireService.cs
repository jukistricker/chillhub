using chillhub.Contexts;
using chillhub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Services
{
    public class HangfireService: IHangfireService
    {
        private readonly AppDbContext _context;

        public HangfireService(AppDbContext context)
        {
            _context = context;
        }

        public async Task RefreshDashboard()
        {
            await _context.Database.ExecuteSqlRawAsync(
                "CALL refresh_dashboard_snapshot();"
            );
        }
    }

   
}
