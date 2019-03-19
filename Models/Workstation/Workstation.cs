using Common.Enums;
using Common.Helpers;
using System;
using System.Text.RegularExpressions;

namespace Models.Workstation
{
    public class Workstation : ValidationBase
    {
        public int WorkstationId { get; set; }
        private string name;
        private DateTime creationDate;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set
            {
                if (creationDate != value)
                {
                    creationDate = value;
                    OnPropertyChanged("CreationDate");
                }
            }
        }
        protected override void ValidateSelf(EPages type)
        {
            if (string.IsNullOrEmpty(this.name) || !Regex.IsMatch(this.name, "^.{1,50}$"))
            {
                this.ValidationErrors["Name"] = "Name can be between 1 and 50 characters.";
            }
        }
    }
}
