using Brushup;

namespace BrushupTest
{
    [TestClass]
    public class Teacher_test
    {
        private ITeacher _teacher = new Teacher { Id = 1, Name = "Shero", Classes = new List<string> { "design", "programming" }, Gender = Person.GenderType.Male, Salary = 1000 };
        private ITeacher _teacherNeative = new Teacher { Id = 2, Name = "S", Classes = null, Gender = Person.GenderType.None, Salary = -1 };
        private ITeacher _teacherNull = new Teacher { Id = 3, Name = null, Classes = new List<string> { "design, programming" }, Salary = 1000 };
        private ITeacher _teacherEmpty = new Teacher { Id = 4, Name = "", Classes = new List<string> { "design, programming" }, Salary = 1000 };
        private ITeacher _teacherEquals = new Teacher { Id = 1, Name = "Shero", Classes = new List<string> { "design", "programming" }, Gender = Person.GenderType.Male, Salary = 1000 };

        [TestMethod]
        public void TestTostring()
        {
            //* Kun for at teste om ToString() virker
            string str = _teacher.ToString(); // act 
            //Assert.AreEqual("{Id=1, Name=Shero, Salary=1000}", str); // assertD
            Assert.AreEqual("{Id=1, Name=Shero, Gender=Male, Classes=design,programming, Salary=1000}", str); // assert
        }
        [TestMethod]
        public void ValidateGender()
        {
            _teacher.ValidateGender(); //Tjekker om den kan validere korekte
            Assert.ThrowsException<ArgumentException>(() => _teacherNeative.ValidateGender()); // tjek om den can kaste en exception
        }
        [TestMethod]
        public void ValidatePriceTest()
        {
            _teacher.ValidateSalary(); //Tjekker om den kan validere korekte  
            Assert.ThrowsException<ArgumentException>(() => _teacherNeative.ValidateSalary()); // tjek om den can kaste en exception
        }
        [TestMethod]
        public void ValidateNameTest()
        {
            _teacher.ValidateName(); //Tjekker om den kan validere korekte  
            Assert.ThrowsException<ArgumentException>(() => _teacherNull.ValidateName()); // tjek om den can kaste en exception
            Assert.ThrowsException<ArgumentException>(() => _teacherEmpty.ValidateName()); // tjek om den can kaste en exception
        }
        [TestMethod]
        public void ValidateTest()
        {
            _teacher.Validate(); //Tjekker om den kan validere korekte
            Assert.ThrowsException<ArgumentException>(() => _teacherNull.Validate()); // tjek om den can kaste en exception
            Assert.ThrowsException<ArgumentException>(() => _teacherEmpty.Validate()); // tjek om den can kaste en exception
            Assert.ThrowsException<ArgumentException>(() => _teacherNeative.Validate()); // tjek om den can kaste en exception
        }

        [TestMethod]
        [DataRow(10)]
        [DataRow(200)]
        [DataRow(1000)]
        public void ValdidateSalaryTest(int salary)
        {
            _teacher.Salary = salary;
            _teacher.ValidateSalary();
        }
        [TestMethod]
        public void ValidateEqualsAndGetHashCodeTest()
        {
            Assert.IsTrue(_teacher.Equals(_teacherEquals));
            Assert.AreEqual(_teacher.GetHashCode(), _teacherEquals.GetHashCode());
        }
    }
}