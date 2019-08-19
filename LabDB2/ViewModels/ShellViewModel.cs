using Prism.Events;
using Prism.Mvvm;
using Infrastructure.Events;
using Infrastructure;
using Prism.Regions;

namespace LabDB2.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        #region Fields

        private string _title = "LabDB2";

        #endregion Fields

        #region Constructors

        public ShellViewModel(RegionManager regionManager)
        {
        }

        #endregion Constructors
        
        #region Properties

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #endregion Properties
    }
}