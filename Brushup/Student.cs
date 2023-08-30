namespace Brushup
{
    public class Student : Person , IStudent
    {
        public int Semester { get; set; }
        public override string ToString()
        {
            //base.ToString() er en metode fra vores base class, som vi kan bruge i vores subklasser
            return $"{{{base.ToString()}, {nameof(Semester)}={Semester.ToString()}}}";
        }
        public void ValidateSemester()
        {
            if (Semester < 1)
            {
                throw new ArgumentException("Semester is less then 1" + Semester);
            }
            if(Semester > 8)
            {
                throw new ArgumentException("Semester is bigger then 8" + Semester);

            }
        }
        //Når man laver en override metode, så skal man skrive override foran da vi overrider en metode fra en base class
        public override void Validate()
        {
            ValidateName();
            ValidateGender();
            ValidateSemester();
        }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   base.Equals(obj) &&                 
                   Semester == student.Semester;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id, Name, Gender, Semester);
        }
    }



}

