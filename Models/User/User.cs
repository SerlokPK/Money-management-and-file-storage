using Common.Enums;
using Common.Helpers;
using System.Text.RegularExpressions;

namespace Models.User
{
    public class User : ValidationBase
    {
        public int UserId { get; set; }

        private string email;
        private string firstName;
        private string lastName;
        private string password;
        private string confirmPassword;

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (confirmPassword != value)
                {
                    confirmPassword = value;
                    OnPropertyChanged("ConfirmPassword");
                }
            }
        }

        protected override void ValidateSelf(EPages type)
        {
            if (type != EPages.ACC && (string.IsNullOrEmpty(this.email) || !Regex.IsMatch(this.email, "^.{1,50}$")))
            {
                this.ValidationErrors["Email"] = "Email can be between 1 and 50 characters.";
            }
            if (string.IsNullOrEmpty(this.password) || !Regex.IsMatch(this.password, "^.{1,50}$"))
            {
                this.ValidationErrors["Password"] = "Password can be between 1 and 50 characters.";
            }
            if (type.Equals(EPages.REG) || type.Equals(EPages.ACC))
            {
                if (string.IsNullOrEmpty(this.firstName) || !Regex.IsMatch(this.firstName, "^.{1,50}$"))
                {
                    this.ValidationErrors["FirstName"] = "First name can be between 1 and 50 characters.";
                }
                if (string.IsNullOrEmpty(this.lastName) || !Regex.IsMatch(this.lastName, "^.{1,50}$"))
                {
                    this.ValidationErrors["LastName"] = "Last name can be between 1 and 50 characters.";
                }
                if (type != EPages.ACC && (string.IsNullOrEmpty(this.email) || !Regex.IsMatch(this.email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")))
                {
                    this.ValidationErrors["Email"] = "Email format isn't valid.";
                }
                if ((string.IsNullOrEmpty(this.password) && string.IsNullOrEmpty(this.confirmPassword)) || !this.password.Equals(this.confirmPassword))
                {
                    this.ValidationErrors["ConfirmPassword"] = "Confirm password need to be same as password";
                }
            }
        }
    }
}
