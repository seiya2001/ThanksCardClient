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
    public class HumanManagementViewModel : BindableBase
    {

        private IRegionManager regionManager;

        #region HumanPasswordProperty
        private HumanPassword _HumanPassword;
        public HumanPassword HumanPassword
        {
            get { return _HumanPassword; }
            set { SetProperty(ref _HumanPassword, value); }
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
        public HumanManagementViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            
            this.HumanPassword = new HumanPassword();
            //this.HumanPassword.Password = "zinzi";
        }

        #region HumanLogonCommand
        private DelegateCommand _HumanLogonCommand;
        public DelegateCommand HumanLogonCommand =>
            _HumanLogonCommand ?? (_HumanLogonCommand = new DelegateCommand(ExecuteHumanLogonCommandAsync));

        async void ExecuteHumanLogonCommandAsync()
        {
            HumanPassword authorizedHumanPassword = await this.HumanPassword.HumanLogonAsync();

            // authorizedUser が null でなければログオンに成功している。
            if (authorizedHumanPassword != null)
            {
                SessionService.Instance.IsAuthorized/*HumanPassword*/ = true;
                SessionService.Instance.AuthorizedHumanPassword = authorizedHumanPassword;
                this.ErrorMessage = "";
                this.regionManager.RequestNavigate("HeaderRegion", nameof(Views.Header));
                this.regionManager.RequestNavigate("ContentRegion", nameof(Views.HumanManagementMenu));
                this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Footer));
            
        }
            else
            {
                this.ErrorMessage = "ログオンに失敗しました。";
            }
        }
        #endregion

        /*#region ShowHumanManagementMenuCommand
        private DelegateCommand _ShowHumanManagementMenuCommand;
        private IRegionManager regionManager;

        public DelegateCommand ShowHumanManagementMenuCommand =>
            _ShowHumanManagementMenuCommand ?? (_ShowHumanManagementMenuCommand = new DelegateCommand(ExecuteShowHumanManagementMenuCommand));


        void ExecuteShowHumanManagementMenuCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.HumanManagementMenu));
        }
        #endregion*/
    }
}
