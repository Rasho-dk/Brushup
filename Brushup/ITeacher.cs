namespace Brushup
{
    public interface ITeacher : IPerson
    {
        int Salary { get; set; }
        List<string> Classes { get; set; }
        void ValidateClasses();
        void ValidateSalary();
        void Validate();
        string ToString();
        bool Equals(object? obj);
        int GetHashCode();
    }
}
