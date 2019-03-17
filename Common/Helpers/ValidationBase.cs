using Common.Enums;

namespace Common.Helpers
{
    public abstract class ValidationBase : BaseModel
    {
        public ValidationErrors ValidationErrors { get; set; }
        public bool IsValid { get; private set; }

        protected ValidationBase()
        {
            this.ValidationErrors = new ValidationErrors();
        }

        protected abstract void ValidateSelf(EPages type);

        public void Validate(EPages type)
        {
            this.ValidationErrors.Clear();
            this.ValidateSelf(type);
            this.IsValid = this.ValidationErrors.IsValid;
            this.OnPropertyChanged("IsValid");
            this.OnPropertyChanged("ValidationErrors");
        }

        public void ValidationPropertyChange()
        {
            this.OnPropertyChanged("ValidationErrors");
        }
    }
}
