using Models.Workstation;
using Services.Interface;
using System;
using System.Collections.Generic;
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

        public ObservableCollection<File> GetFiles(int workstationId)
        {
            ObservableCollection<File> Files = new ObservableCollection<File>();
            using (var context = GetContext())
            {
                try
                {
                    var list = context.sp_GetFilesForWorkstation(workstationId).Select(x => new File {
                        FileId = x.FileId,
                        Description = x.Description,
                        CreationDate = x.CreationDate,
                        Name = x.Name,
                        UrlName = x.UrlName,
                        Extension = x.Extension,
                    }).ToList();
                    
                    foreach(var item in list)
                    {
                        Files.Add(item);
                    }
                }
                catch (System.Exception)
                {
                }
            }
            return Files;
        }

        public void RemoveFile(File file)
        {
            using (var context = GetContext())
            {
                try
                {
                    var fileDB = context.Files.Where(x => x.FileId == file.FileId).Single();
                    context.Files.Remove(fileDB);
                    context.SaveChanges();
                }
                catch (System.Exception)
                {
                }
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

        public bool SaveFile(Models.Workstation.File file, int workstationId)
        {
            using (var context = GetContext())
            {
                try
                {
                    if (!context.Files.Where(x => x.Workstation_WorkstationId == workstationId).Any(x => x.Name.ToLower() == file.Name.ToLower()))
                    {
                        var fileId = context.Files.Any() ? context.Files.Max(x => x.FileId) + 1 : 1;
                        file.CreationDate = DateTime.Now.Date;
                        context.Files.Add(new DataBase.File
                        {
                            FileId = fileId,
                            Workstation_WorkstationId = workstationId,
                            CreationDate = file.CreationDate,
                            Name = file.Name,
                            Description = file.Description,
                            FileType_TypeId = 1,
                            UrlName = file.UrlName,
                        });
                        context.SaveChanges();
                        file.FileId = fileId;
                        return true;
                    }
                }
                catch (System.Exception)
                {
                }
            }
            return false;
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
