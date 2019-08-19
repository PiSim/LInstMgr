﻿using DataAccessCore;
using LInst;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Instruments.Queries
{
    /// <summary>
    /// Query object that returns multiple CalibrationReport entities
    /// </summary>
    public class CalibrationFilesQuery : Query<CalibrationFile, LInstContext>
    {
        #region Properties

        public int? CalibrationReportID { get; set; }

        #endregion Properties

        #region Methods

        public override IQueryable<CalibrationFile> Execute(LInstContext context)
        {
            IQueryable<CalibrationFile> query = context.CalibrationFiles;

            if (AsNoTracking)
                query = query.AsNoTracking();

            if (CalibrationReportID != null)
                query = query.Where(cf => cf.CalibrationReportID == CalibrationReportID);

            return query;
        }

        #endregion Methods
    }
}