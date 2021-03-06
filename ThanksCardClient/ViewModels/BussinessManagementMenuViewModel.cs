﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class BussinessManagementMenuViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;


        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }
        private BusinessPassword _AuthorizedBusinessPassword;
        public BusinessPassword AuthorizedBusinessPassword
        {
            get { return _AuthorizedBusinessPassword; }
            set { SetProperty(ref _AuthorizedBusinessPassword, value); }
        }

        public BussinessManagementMenuViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
            
            this.AuthorizedBusinessPassword = SessionService.Instance.AuthorizedBusinessPassword;

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


        #region ShowUserMstCommand
        private DelegateCommand _ShowUserMstCommand;
        public DelegateCommand ShowUserMstCommand =>
            _ShowUserMstCommand ?? (_ShowUserMstCommand = new DelegateCommand(ExecuteShowUserMstCommand));

        void ExecuteShowUserMstCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserMst));
        }
        #endregion

        #region ShowDepartmentMstCommand
        private DelegateCommand _ShowDepartmentMstCommand;


        public DelegateCommand ShowDepartmentMstCommand =>
            _ShowDepartmentMstCommand ?? (_ShowDepartmentMstCommand = new DelegateCommand(ExecuteShowDepartmentMstCommand));


        void ExecuteShowDepartmentMstCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentMst));
        }
        #endregion

    }
}

