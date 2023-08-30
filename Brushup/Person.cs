using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brushup
{
    public class Person : IPerson   
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public enum GenderType { None, Male, Female  } 
        //Når Gender typen ikke bliver sat, så er den None som default
        public GenderType Gender { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Gender)}={Gender.ToString()}";
        }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentException("Name is null" + Name);
            }
            if (Name.Length < 1)
            {
                throw new ArgumentException("Name is empty" + Name);
            }
        }
        public void ValidateGender()
        {
            if(Gender.ToString() == "None")
            {
                throw new ArgumentException("Please choose the gender type");
            }
        }
        //Når vi laver en virtual metode, så kan vi override den i vores subklasser
        public virtual void Validate()
        {
            ValidateName();
            ValidateGender();
        }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   Id == person.Id &&
                   Name == person.Name &&
                   Gender == person.Gender;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Gender);
        }
    }
}
