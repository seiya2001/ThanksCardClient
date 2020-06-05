using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class HumanManagementMenuViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }

        public HumanManagementMenuViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
        }

      

        #region ShowHumanManagementMenu
        private DelegateCommand _ShowHumanManagementMenu;
        public DelegateCommand ShowHumanManagementMenu =>
            _ShowHumanManagementMenu ?? (_ShowHumanManagementMenu = new DelegateCommand(ExecuteShowHumanManagementMenuCommand));

        void ExecuteShowHumanManagementMenuCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.HumanManagementMenu));
        }
        #endregion

        #region ShowMainMenuCommand
        private DelegateCommand _ShowMainMenuCommand;
        public DelegateCommand ShowMainMenuCommand =>
            _ShowMainMenuCommand ?? (_ShowMainMenuCommand = new DelegateCommand(ExecuteShowMainMenuCommand));

        void ExecuteShowMainMenuCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MainMenu));
        }
        #endregion
    }
}

