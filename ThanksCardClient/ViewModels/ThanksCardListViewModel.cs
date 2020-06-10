using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class ThanksCardListViewModel : BindableBase, INavigationAware
    {
        private IRegionManager regionManager;

        #region ThanksCardsProperty
        private List<ThanksCard> _ThanksCards;
        public List<ThanksCard> ThanksCards
        {
            get { return _ThanksCards; }
            set { SetProperty(ref _ThanksCards, value); }
        }
        #endregion

        public ThanksCardListViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }


        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }


        #region ThanksCardReplyCommand

        private DelegateCommand<ThanksCard> _ThanksCardReplyCommand;
        public DelegateCommand<ThanksCard> ThanksCardReplyCommand =>
            _ThanksCardReplyCommand ?? (_ThanksCardReplyCommand = new DelegateCommand<ThanksCard>(ExecuteThanksCardReplyCommand));

        void ExecuteThanksCardReplyCommand(ThanksCard SelectedThanksCard)
        {
            // 対象のUserをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedThanksCard", SelectedThanksCard);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardReply), parameters);
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