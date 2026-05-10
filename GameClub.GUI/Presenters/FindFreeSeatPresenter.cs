using System;
using GameClub.GUI.ViewInterfaces;

namespace GameClub.GUI.Presenters
{
    public class FindFreeSeatPresenter
    {
        private readonly IFindFreeSeatView view;

        public FindFreeSeatPresenter(IFindFreeSeatView view)
        {
            this.view = view;
            this.view.ConfirmSelection += OnConfirmSelection;
        }

        private void OnConfirmSelection(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(view.Result))
            {
                view.ShowError("Выберите тип зала!");
                return;
            }

            view.CloseWithOk();
        }
    }
}
