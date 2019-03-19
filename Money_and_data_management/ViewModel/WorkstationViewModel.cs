using System;
using System.Collections.ObjectModel;
using Common.Enums;
using Common.Helpers;
using Models.Workstation;
using Services;
using Services.Interface;

namespace Money_and_data_management.ViewModel
{
    public class WorkstationViewModel : BaseViewModel
    {
        private IPageService pageService;
        public ObservableCollection<Workstation> Workstations { get; set; }
        private Workstation selectedWorkstation;

        public CommandHelper<string> ChangePageCommand { get; set; }
        public CommandHelper DeleteCommand { get; set; }
        public CommandHelper AddCommand { get; set; }

        public Workstation SelectedWorkstation
        {
            get { return selectedWorkstation; }
            set
            {
                selectedWorkstation = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public WorkstationViewModel()
        {
            pageService = SimpleDI.Instance.PageService;

            ChangePageCommand = new CommandHelper<string>(ChangePage);
            DeleteCommand = new CommandHelper(DeleteAction, CanDelete);
            AddCommand = new CommandHelper(AddAction);
        }

        private bool CanDelete()
        {
            return SelectedWorkstation != null;
        }

        private void AddAction()
        {
            throw new NotImplementedException();
        }

        private void DeleteAction()
        {
            throw new NotImplementedException();
        }

        private void ChangePage(string page)
        {
            Enum.TryParse(page, out EPages pageName);
            pageService.ChangePage(pageName);
        }
    }
}
