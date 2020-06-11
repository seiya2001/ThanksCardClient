using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class BussinessManagementViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        #region BusinessPasswordProperty
        private BusinessPassword _BusinessPassword;
        public BusinessPassword BusinessPassword
        {
            get { return _BusinessPassword; }
            set { SetProperty(ref _BusinessPassword, value); }
        }
        #endregion


        #region ErrorMessage
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { SetProperty(ref _ErrorMessage, value); }
        }
        #endregion
        public BussinessManagementViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;


            this.BusinessPassword = new BusinessPassword();
            //this.HumanPassword.Password = "zinzi";
        }

        #region BusinessLogonCommand
        private DelegateCommand _BusinessLogonCommand;
        public DelegateCommand BusinessLogonCommand =>
            _BusinessLogonCommand ?? (_BusinessLogonCommand = new DelegateCommand(ExecuteBusinessLogonCommandAsync));

        async void ExecuteBusinessLogonCommandAsync()
        {
            BusinessPassword authorizedBusinessPassword = await this.BusinessPassword.BusinessLogonAsync();

            // authorizedUser が null でなければログオンに成功している。
            if (authorizedBusinessPassword != null)
            {
                SessionService.Instance.IsAuthorized/*HumanPassword*/ = true;
                SessionService.Instance.AuthorizedBusinessPassword = authorizedBusinessPassword;
                this.ErrorMessage = "";
                this.regionManager.RequestNavigate("HeaderRegion", nameof(Views.Header));
                this.regionManager.RequestNavigate("ContentRegion", nameof(Views.BussinessManagementMenu));
                this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Footer));

            }
            else
            {
                this.ErrorMessage = "ログオンに失敗しました。";
            }
        }
        #endregion


        /*#region ShowBussinessManagementMenuCommand
        private DelegateCommand _ShowBussinessManagementMenuCommand;
        public DelegateCommand ShowBussinessManagementMenuCommand =>
            _ShowBussinessManagementMenuCommand ?? (_ShowBussinessManagementMenuCommand = new DelegateCommand(ExecuteShowBussinessManagementMenuCommand));


        void ExecuteShowBussinessManagementMenuCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.BussinessManagementMenu));
        }
        #endregion*/


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


