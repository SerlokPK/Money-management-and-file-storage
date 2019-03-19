using System.Collections.ObjectModel;

namespace Services.Interface
{
    public interface IWorkstationService
    {
        ObservableCollection<Models.Workstation.Workstation> GetAllWorkstations(int userId);
    }
}
