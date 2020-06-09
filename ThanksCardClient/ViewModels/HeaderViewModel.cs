using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class HeaderViewModel : BindableBase
    {
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
        public HeaderViewModel()
        {
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
            this.AuthorizedHumanPassword = SessionService.Instance.AuthorizedHumanPassword;
        }
    }
}
