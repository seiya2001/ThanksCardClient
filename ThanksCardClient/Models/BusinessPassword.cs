﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class BusinessPassword : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region PasswordProperty
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
        #endregion

        public async Task<BusinessPassword> BusinessLogonAsync()
        {
            IRestService rest = new RestService();
            BusinessPassword authorizedBusinessPassword = await rest.BusinessLogonAsync(this);
            return authorizedBusinessPassword;
        }
    }
}
