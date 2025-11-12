using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data.Repository;

public class ReportRegistrationRepository : IReportRegistrationRepository
{
    private readonly AppDbContext _context;

    public ReportRegistrationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ReportRegistration> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
        //await _context.FindAsync(id);
    }

    public async Task AddAsync(ReportRegistration report)
    {
        throw new NotImplementedException();
        //await _context.AddAsync(report);
        //await _context.SaveChangesAsync();
    }
}
