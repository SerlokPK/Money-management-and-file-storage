using Services.Interface;
using System.Collections.ObjectModel;
using System.Linq;

namespace Services.Workstation
{
    public class WorstationService : BaseService, IWorkstationService
    {
        public ObservableCollection<Models.Workstation.Workstation> GetAllWorkstations(int userId)
        {
            using (var context = GetContext())
            {
                var list = context.Workstations.Where(x => x.Regular_UserId == userId).Select(x => new Models.Workstation.Workstation
                {
                    WorkstationId = x.WorkstationId,
                    CreationDate = x.CreationDate,
                    Name = x.Name,
                });
                ObservableCollection<Models.Workstation.Workstation> workstations = new ObservableCollection<Models.Workstation.Workstation>();
                foreach (var item in list)
                {
                    workstations.Add(item);
                }
                return workstations;
            }
        }
    }
}
