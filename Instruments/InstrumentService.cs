using DataAccessCore;
using Infrastructure.Events;
using Instruments.Commands;
using LInst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Prism.Events;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Instruments
{
    public class InstrumentService
    {
        #region Fields

        private IDesignTimeDbContextFactory<LInstContext> _dbContextFactory;
        private IEventAggregator _eventAggregator;
        private IDataService<LInstContext> _lInstData;

        #endregion Fields

        #region Constructors

        public InstrumentService(IDesignTimeDbContextFactory<LInstContext> dbContextFactory,
                            IEventAggregator aggregator,
                            IDataService<LInstContext> lInstData)
        {
            _eventAggregator = aggregator;
            _dbContextFactory = dbContextFactory;
            _lInstData = lInstData;
        }

        #endregion Constructors

        #region Methods


        public Instrument CreateInstrument()
        {
            Views.InstrumentCreationDialog creationDialog = new Views.InstrumentCreationDialog();
            if (creationDialog.ShowDialog() == true)
            {
                _eventAggregator.GetEvent<InstrumentListUpdateRequested>().Publish();
                return creationDialog.InstrumentInstance;
            }
            else
                return null;
        }

        public IEnumerable<Instrument> GetCalibrationCalendar()
        {
            // Returns a list of the instruments under control, ordered by due calibration date

            using (LInstContext entities = _dbContextFactory.CreateDbContext(new string[] { }))
            {
                return entities.Instruments.Include(ins => ins.InstrumentType)
                                            .Include(ins => ins.UtilizationArea)
                                            .Include(ins => ins.CalibrationResponsible)
                                            .Where(ins => ins.IsUnderControl == true)
                                            .OrderBy(ins => ins.CalibrationDueDate)
                                            .ToList();
            }
        }

        /// <summary>
        /// Retrieves and returns the next available CalibrationReport number for a given year
        /// </summary>
        /// <param name="year">The year on which the query is performed</param>
        /// <returns>The first unused calibration number</returns>
        public int GetNextCalibrationNumber(int year)
        {
            using (LInstContext entities = _dbContextFactory.CreateDbContext(new string[] { }))
            {
                try
                {
                    return entities.CalibrationReports
                                    .Where(crep => crep.Year == year)
                                    .Max(crep => crep.Number) + 1;
                }
                catch
                {
                    return 1;
                }
            }
        }

        public CalibrationReport ShowNewCalibrationDialog(Instrument target)
        {
            Views.NewCalibrationDialog calibrationDialog = new Views.NewCalibrationDialog
            {
                InstrumentInstance = target
            };

            if (calibrationDialog.ShowDialog() == true)
            {
                CalibrationReport output = calibrationDialog.ReportInstance;

                _lInstData.Execute(new UpdateInstrumentCalibrationStatusCommand(target));

                _eventAggregator.GetEvent<CalibrationIssued>()
                                .Publish(output);

                return output;
            }
            else return null;
        }

        public void AutofindFilesForCalibrationReports()
        {
            DirectoryInfo directory = new DirectoryInfo("L:\\Documenti macchine e strumenti\\_Report Tarature Laboratorio");
            IDictionary<string, List<FileInfo>> files = new Dictionary<string, List<FileInfo>>();
            foreach (FileInfo file in directory.GetFiles())
            {
                string key = file.Name.Take(7).ToString();
                if (files.ContainsKey(key))
                    files[key].Add(file);
                else files.Add(key, new List<FileInfo>() { file });
            }

            IEnumerable<CalibrationReport> reports = new List<CalibrationReport>();

            foreach (CalibrationReport report in reports)
            {
                string numberString = "RT" + report.Year.ToString("00") + report.Number.ToString("000");
                if (files.ContainsKey(numberString))
                {
                    CalibrationFile file = new CalibrationFile();
                }
            }
        }

        public InstrumentMaintenanceEvent ShowNewMaintenanceDialog(Instrument entry)
        {
            Views.MaintenanceEventCreationDialog maintenanceEventCreationDialog = new Views.MaintenanceEventCreationDialog
            {
                InstrumentInstance = entry
            };

            if (maintenanceEventCreationDialog.ShowDialog() == true)
            {
                return maintenanceEventCreationDialog.InstrumentEventInstance;
            }
            else
                return null;
        }

        #endregion Methods
    }
}