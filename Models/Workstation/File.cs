using Common.Enums;
using Common.Helpers;
using System;

namespace Models.Workstation
{
    public class File : ValidationBase
    {
        public int FileId { get; set; }
        private string name { get; set; }
        private string urlName { get; set; }
        private string description { get; set; }
        private DateTime creationDate { get; set; }

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
        protected override void ValidateSelf(EPages type)
        {
            throw new System.NotImplementedException();
        }
    }
}
