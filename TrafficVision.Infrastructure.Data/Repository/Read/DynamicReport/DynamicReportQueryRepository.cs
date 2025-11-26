using Microsoft.EntityFrameworkCore;
using TrafficVision.Domain.Entities;
using TrafficVision.Domain.Interfaces.Repository;
using TrafficVision.Infrastructure.Data.Persistence;

namespace TrafficVision.Infrastructure.Data;

public class DynamicReportQueryRepository : IDynamicReportQueryRepository
{
    private readonly AppDbContext _context;

    public DynamicReportQueryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehicle>> QueryAsync(DynamicReport filter, CancellationToken cancellationToken)
    {
        var query = _context.Vehicle.AsQueryable();

        if (filter.InitialDate != default)
            query = query.Where(x => x.CreatedAt >= filter.InitialDate);

        if (filter.FinalDate != null)
            query = query.Where(x => x.CreatedAt <= filter.FinalDate);

        if (filter.ListColor.Any())
            query = query.Where(x => filter.ListColor.Contains(x.Color.ToLower()));

        if (filter.ListModel.Any())
            query = query.Where(x => filter.ListModel.Contains(x.Model.ToLower()));

        if (filter.ListBrand.Any())
            query = query.Where(x => filter.ListBrand.Contains(x.Brand.ToLower()));

        if (filter.ListMunicipality.Any())
            query = query.Where(x => filter.ListMunicipality.Contains(x.VehicleSpec.Municipality.ToLower()));

        if (filter.ListState.Any())
            query = query.Where(x => filter.ListState.Contains(x.VehicleSpec.State.ToLower()));

        if (filter.Wrecked)
            query = query.Where(x => x.VehicleSpec.VehicleRestriction.Wrecked);

        if (filter.JudicialRestriction)
            query = query.Where(x => x.VehicleSpec.VehicleRestriction.JudicialRestriction);

        if (filter.Auction)
            query = query.Where(x => x.VehicleSpec.VehicleRestriction.Auction);

        if (filter.TheftVehicleCondition != 0)
            query = query.Where(x => x.VehicleSpec.VehicleRestriction.TheftVehicleCondition == filter.TheftVehicleCondition);

        return await query.ToListAsync(cancellationToken);
    }
}
