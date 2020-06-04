using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThanksCardClient.ViewModels
{
    public class BussinessManagementViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;



        public BussinessManagementViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        #region ShowBussinessManagementMenuCommand
        private DelegateCommand _ShowBussinessManagementMenuCommand;
        public DelegateCommand ShowBussinessManagementMenuCommand =>
            _ShowBussinessManagementMenuCommand ?? (_ShowBussinessManagementMenuCommand = new DelegateCommand(ExecuteShowBussinessManagementMenuCommand));


        void ExecuteShowBussinessManagementMenuCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.BussinessManagementMenu));
        }
        #endregion




    }
}


