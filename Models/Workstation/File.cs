using Common.Enums;
using Common.Helpers;
using System;
using System.Text.RegularExpressions;

namespace Models.Workstation
{
    public class File : ValidationBase
    {
        public int FileId { get; set; }
        public int WorkstationId { get; set; }
        private string name;
        private string urlName;
        private string description;
        private DateTime creationDate;
        private string extension;

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

        public string UrlName
        {
            get { return urlName; }
            set
            {
                if (urlName != value)
                {
                    urlName = value;
                    OnPropertyChanged("UrlName");
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
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
        public string Extension
        {
            get { return extension; }
            set
            {
                if (extension != value)
                {
                    extension = value;
                    OnPropertyChanged("Extension");
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
