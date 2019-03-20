using Models.Workstation;
using Services.Interface;
using System;
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
                ObservableCollection<Models.Workstation.Workstation> workstations = new ObservableCollection<Models.Workstation.Workstation>();
                try
                {
                    var list = context.Workstations.Where(x => x.Regular_UserId == userId).Select(x => new Models.Workstation.Workstation
                    {
                        WorkstationId = x.WorkstationId,
                        CreationDate = x.CreationDate,
                        Name = x.Name,
                    });
                    foreach (var item in list)
                    {
                        workstations.Add(item);
                    }
                }
                catch (System.Exception)
                {
                }
                return workstations;
            }
        }

        public void RemoveWorkstation(Models.Workstation.Workstation workstation)
        {
            using (var context = GetContext())
            {
                try
                {
                    var workstationDB = context.Workstations.Where(x => x.WorkstationId == workstation.WorkstationId).Single();
                    context.Workstations.Remove(workstationDB);
                    context.SaveChanges();
                }
                catch (System.Exception)
                {
                }
            }
        }

        public bool SaveWorkstation(Models.Workstation.Workstation workstation, int userId)
        {
            using (var context = GetContext())
            {
                try
                {
                    if(!context.Workstations.Where(x => x.Regular_UserId == userId).Any(x => x.Name.ToLower() == workstation.Name.ToLower()))
                    {
                        var workstationId = context.Workstations.Any() ? context.Workstations.Max(x => x.WorkstationId) + 1 : 1;
                        workstation.CreationDate = DateTime.Now.Date;
                        context.Workstations.Add(new DataBase.Workstation
                        {
                            WorkstationId = workstationId,
                            Regular_UserId = userId,
                            CreationDate = workstation.CreationDate,
                            Name = workstation.Name,
                        });
                        context.SaveChanges();
                        workstation.WorkstationId = workstationId;
                        return true;
                    }
                }
                catch (System.Exception)
                {
                }
            }
            return false;
        }
    }
}
