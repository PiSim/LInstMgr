using Controls.Views;
using Prism.Regions;
using System.Windows;

namespace LabDB2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        private readonly IRegionManager _regionManager;

        #region Constructors

        public Shell(IRegionManager regionManager)
        {
            InitializeComponent();

            _regionManager = regionManager;
            regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion,
                                                typeof(Toolbar));
            regionManager.RegisterViewWithRegion(RegionNames.StatusbarRegion,
                                                typeof(StatusBar));
        }

        #endregion Constructors

    }
}