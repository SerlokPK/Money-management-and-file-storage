using System.Collections.ObjectModel;

namespace Services.Interface
{
    public interface IWorkstationService
    {
        ObservableCollection<Models.Workstation.Workstation> GetAllWorkstations(int userId);
        bool SaveWorkstation(Models.Workstation.Workstation workstation, int userId);
        void RemoveWorkstation(Models.Workstation.Workstation workstation);
    }
}
