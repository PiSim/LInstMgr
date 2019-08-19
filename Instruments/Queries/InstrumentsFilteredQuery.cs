using DataAccessCore;
using LInst;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Instruments.Queries
{
    /// <summary>
    /// Query object that returns multiple Instrument entities and provides various fields for filtering results
    /// </summary>
    public class InstrumentsFilteredQuery : Query<Instrument, LInstContext>
    {
        public string Code { get; set; } = "";

        public string InstrumentType { get; set; } = "";

        public string Description { get; set; } = "";

        public string UtilizationArea { get; set; } = "";
                
        #region Methods

        public override IQueryable<Instrument> Execute(LInstContext context)
        {
            IQueryable<Instrument> query = context.Instruments;

            if (AsNoTracking)
                query = query.AsNoTracking();

            if (EagerLoadingEnabled)
                query = query.Include(inst => inst.InstrumentType)
                    .Include(inst => inst.Manufacturer)
                    .Include(inst => inst.UtilizationArea);

            if (!string.IsNullOrWhiteSpace(Code))
                query = query.Where(inst => inst.Code.Contains(Code));

            if (!string.IsNullOrWhiteSpace(InstrumentType))
                query = query.Where(inst => inst.InstrumentType.Name.Contains(InstrumentType));

            if (!string.IsNullOrWhiteSpace(Description))
                query = query.Where(inst => inst.Description.Contains(Description));

            if (!string.IsNullOrWhiteSpace(UtilizationArea))
                query = query.Where(inst => inst.UtilizationArea.Name.Contains(UtilizationArea));

            if (OrderResults)
                query = query.OrderBy(inst => inst.Code);

            return query;
        }

        #endregion Methods
    }
}