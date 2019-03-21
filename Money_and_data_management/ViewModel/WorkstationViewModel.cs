using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        private IWorkstationService workstationService;
        private IUserService userService;
        public ObservableCollection<Workstation> Workstations { get; set; }
        private ObservableCollection<File> files;
        public ObservableCollection<File> Files {
            get { return files; }
            set
            {
                if (files != value)
                {
                    files = value;
                    OnPropertyChanged("Files");
                }
            }
        }
        private Workstation selectedWorkstation;
        private Workstation validationWorkstation;
        private File selectedFile;
        private File validationFile;

        public CommandHelper<string> ChangePageCommand { get; set; }
        public CommandHelper DeleteCommand { get; set; }
        public CommandHelper AddCommand { get; set; }
        public CommandHelper ShowFilesCommand { get; set; }
        public CommandHelper DeleteFileCommand { get; set; }
        public CommandHelper AddFileCommand { get; set; }

        public Workstation SelectedWorkstation
        {
            get { return selectedWorkstation; }
            set
            {
                selectedWorkstation = value;
                DeleteCommand.RaiseCanExecuteChanged();
                ShowFilesCommand.RaiseCanExecuteChanged();
                AddFileCommand.RaiseCanExecuteChanged();
            }
        }

        public Workstation ValidationWorkstation
        {
            get { return validationWorkstation; }
            set
            {
                if (validationWorkstation != value)
                {
                    validationWorkstation = value;
                    OnPropertyChanged("ValidationWorkstation");
                }
            }
        }

        public File SelectedFile
        {
            get { return selectedFile; }
            set
            {
                selectedFile = value;
                DeleteFileCommand.RaiseCanExecuteChanged();
            }
        }
        public File ValidationFile
        {
            get { return validationFile; }
            set
            {
                if (validationFile != value)
                {
                    validationFile = value;
                    OnPropertyChanged("ValidationFile");
                }
            }
        }
        public WorkstationViewModel()
        {
            pageService = SimpleDI.Instance.PageService;
            workstationService = SimpleDI.Instance.WorkstationService;
            userService = SimpleDI.Instance.UserService;
            Files = new ObservableCollection<File>();

            ChangePageCommand = new CommandHelper<string>(ChangePage);

            DeleteCommand = new CommandHelper(DeleteAction, CanDelete);
            AddCommand = new CommandHelper(AddAction);
            ShowFilesCommand = new CommandHelper(ShowFilesAction, CanDelete);
            validationWorkstation = new Workstation();

            DeleteFileCommand = new CommandHelper(DeleteFileAction, CanDeleleFile);
            AddFileCommand = new CommandHelper(AddFileAction, CanDelete);
            validationFile = new File();
        }

        private void AddFileAction()
        {
            ValidationFile.Validate(EPages.WORKSTATION);
            if (ValidationFile.IsValid)
            {
                if (!workstationService.SaveFile(ValidationFile, SelectedWorkstation.WorkstationId))
                {
                    ValidationFile.ValidationErrors["Name"] = "You already used this name.";
                    ValidationFile.ValidationPropertyChange();
                }
                else
                {
                    Files.Add(new File
                    {
                        FileId = ValidationFile.FileId,
                        Name = ValidationFile.Name,
                        CreationDate = ValidationFile.CreationDate,
                        Description = ValidationFile.Description,
                        UrlName = ValidationFile.UrlName,
                        Extension = ValidationFile.Extension,
                        WorkstationId = SelectedWorkstation.WorkstationId,
                    });
                    ValidationFile.Name = "";
                    ValidationFile.UrlName = "";
                }
            }
        }

        private void DeleteFileAction()
        {
            workstationService.RemoveFile(SelectedFile);
            Files.Remove(Files.Where(x => x.FileId == SelectedFile.FileId).Single());
        }
        private void ShowFilesAction()
        {
            Files = workstationService.GetFiles(SelectedWorkstation.WorkstationId);
        }
        private bool CanDelete()
        {
            return SelectedWorkstation != null;
        }

        private bool CanDeleleFile()
        {
            return SelectedFile != null;
        }

        private void AddAction()
        {
            ValidationWorkstation.Validate(EPages.WORKSTATION);
            if (ValidationWorkstation.IsValid)
            {
                if (!workstationService.SaveWorkstation(ValidationWorkstation, userService.GetCurrentUser().UserId))
                {
                    ValidationWorkstation.ValidationErrors["Name"] = "You already used this name.";
                    ValidationWorkstation.ValidationPropertyChange();
                }
                else
                {
                    Workstations.Add(new Workstation
                    {
                        WorkstationId = ValidationWorkstation.WorkstationId,
                        Name = ValidationWorkstation.Name,
                        CreationDate = ValidationWorkstation.CreationDate,
                    });
                    ValidationWorkstation.Name = "";
                }
            }
        }

        private void DeleteAction()
        {
            workstationService.RemoveWorkstation(SelectedWorkstation);
            Workstations.Remove(Workstations.Where(x => x.WorkstationId == SelectedWorkstation.WorkstationId).Single());
            Files.ToList().RemoveAll(x => x.WorkstationId == SelectedWorkstation.WorkstationId);
        }

        private void ChangePage(string page)
        {
            Enum.TryParse(page, out EPages pageName);
            pageService.ChangePage(pageName);
        }
    }
}
