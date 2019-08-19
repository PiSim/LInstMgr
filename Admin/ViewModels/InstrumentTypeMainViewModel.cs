using Controls.Views;
using DataAccessCore;
using Infrastructure;
using Infrastructure.Events;
using Infrastructure.Queries;
using LInst;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace Admin.ViewModels
{
    public class InstrumentTypeMainViewModel : BindableBase
    {
        #region Fields

        private IAdminService _adminService;
        private IEventAggregator _eventAggregator;
        private IDataService<LInstContext> _lInstData;
        private InstrumentType _selectedInstrumentType;

        #endregion Fields

        #region Constructors

        public InstrumentTypeMainViewModel(IEventAggregator eventAggregator,
                                            IAdminService adminService,
                                            IDataService<LInstContext> lInstData)
        {
            _adminService = adminService;
            _lInstData = lInstData;
            _eventAggregator = eventAggregator;

            NewInstrumentTypeCommand = new DelegateCommand(
                () =>
                {
                    _adminService.CreateNewInstrumentType();
                });

            _eventAggregator.GetEvent<EntityChanged>()
                            .Subscribe(
                            token =>
                            {
                                RaisePropertyChanged("InstrumentTypeList");
                            },
                            ThreadOption.PublisherThread,
                            true,
                            token => token.Entity.GetType() == typeof(InstrumentType));
        }

        #endregion Constructors

        #region Properties

        public IEnumerable<InstrumentType> InstrumentTypeList => _lInstData.RunQuery(new InstrumentTypesQuery()).ToList();

        public string InstrumentTypeManagementEditRegionName => RegionNames.InstrumentTypeManagementEditRegion;

        public DelegateCommand NewInstrumentTypeCommand { get; }

        public InstrumentType SelectedInstrumentType
        {
            get { return _selectedInstrumentType; }
            set
            {
                _selectedInstrumentType = value;

                NavigationToken token = new NavigationToken(AdminViewNames.InstrumentTypeEditView,
                                                            _selectedInstrumentType,
                                                            RegionNames.InstrumentTypeManagementEditRegion);

                _eventAggregator.GetEvent<NavigationRequested>()
                                .Publish(token);
            }
        }

        #endregion Properties
    }
}