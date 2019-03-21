using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Services.Interface
{
    public interface IWorkstationService
    {
        ObservableCollection<Models.Workstation.Workstation> GetAllWorkstations(int userId);
        bool SaveWorkstation(Models.Workstation.Workstation workstation, int userId);
        void RemoveWorkstation(Models.Workstation.Workstation workstation);
        ObservableCollection<Models.Workstation.File> GetFiles(int workstationId);
        bool SaveFile(Models.Workstation.File file, int workstationId);
        void RemoveFile(Models.Workstation.File file);
    }
}
