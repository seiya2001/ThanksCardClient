using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThanksCardClient.ViewModels
{
    public class HumanManagementViewModel : BindableBase
    {
        public HumanManagementViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        #region ShowHumanManagementMenuCommand
        private DelegateCommand _ShowHumanManagementMenuCommand;
        private IRegionManager regionManager;

        public DelegateCommand ShowHumanManagementMenuCommand =>
            _ShowHumanManagementMenuCommand ?? (_ShowHumanManagementMenuCommand = new DelegateCommand(ExecuteShowHumanManagementMenuCommand));


        void ExecuteShowHumanManagementMenuCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.HumanManagementMenu));
        }
        #endregion
    }
}
