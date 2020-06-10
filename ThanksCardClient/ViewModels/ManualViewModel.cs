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
    public class ManualViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private User _AuthorizedUser;
        private HumanPassword _AuthorizedHumanPassword;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }

        public HumanPassword AuthorizedHumanPassword
        {
            get { return _AuthorizedHumanPassword; }
            set { SetProperty(ref _AuthorizedHumanPassword, value); }
        }
        public ManualViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
            this.AuthorizedHumanPassword = SessionService.Instance.AuthorizedHumanPassword;
        }
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
