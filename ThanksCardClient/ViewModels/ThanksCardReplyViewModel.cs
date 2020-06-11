using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Views;

namespace ThanksCardClient.ViewModels
{
    public class ThanksCardReplyViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion

        #region FromUsersProperty
        private List<User> _FromUsers;
        public List<User> FromUsers
        {
            get { return _FromUsers; }
            set { SetProperty(ref _FromUsers, value); }
        }
        #endregion

        #region ToUsersProperty
        private List<User> _ToUsers;
        public List<User> ToUsers
        {
            get { return _ToUsers; }
            set { SetProperty(ref _ToUsers, value); }
        }
        #endregion

        #region DepartmentsProperty
        private List<Department> _Departments;
        public List<Department> Departments
        {
            get { return _Departments; }
            set { SetProperty(ref _Departments, value); }
        }
        #endregion

        #region TagsProperty
        private List<Tag> _Tags;
        public List<Tag> Tags
        {
            get { return _Tags; }
            set { SetProperty(ref _Tags, value); }
        }
        #endregion

        public ThanksCardReplyViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 画面遷移元から送られる SelectedUser パラメーターを取得。
            this.ThanksCard = navigationContext.Parameters.GetValue<ThanksCard>("SelectedThanksCard");

            /*Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();*/
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            ThanksCard updatedThanskCard = await ThanksCard.PutThanksCardAsync(this.ThanksCard);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion

       


        #region ShowMainMenuCommand
        private DelegateCommand _ShowTanksCardListCommand;
        public DelegateCommand ShowMainMenuCommand =>
            _ShowTanksCardListCommand ?? (_ShowTanksCardListCommand = new DelegateCommand(ExecuteShowTanksCardListCommand));

        void ExecuteShowTanksCardListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion


        #region ShowThanksCardListCommand
        private DelegateCommand _ShowThanksCardListCommand;


        public DelegateCommand ShowThanksCardListCommand =>
            _ShowThanksCardListCommand ?? (_ShowThanksCardListCommand = new DelegateCommand(ExecuteShowThanksCardListCommand));


        void ExecuteShowThanksCardListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion
    }
}
