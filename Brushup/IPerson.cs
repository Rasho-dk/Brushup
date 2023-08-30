namespace Brushup
{
    public interface IPerson
    {

        int Id { get; set; }
        string Name { get; set; }
        Person.GenderType Gender { get; set; }  
        string ToString();
        void ValidateName();
        void ValidateGender();
        void Validate();
        bool Equals(object? obj);
        int GetHashCode();

    }
}
