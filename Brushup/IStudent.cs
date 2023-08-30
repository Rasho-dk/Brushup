namespace Brushup
{
    public interface IStudent : IPerson
    {
        int Semester { get; set; }
        string ToString();
        void ValidateSemester();
        void Validate();
        bool Equals(object? obj);
        int GetHashCode();

    }
}
