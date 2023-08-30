using Brushup;

namespace BrushupTest
{
    [TestClass]
    public class Student__test
    {
        private IStudent _student = new Student { Id = 1, Name = "Shero",Gender = Person.GenderType.Male, Semester = 2 };
        private IStudent _studentNeative = new Student { Id = 2, Name = "S", Gender= Person.GenderType.None, Semester = -1 };
        private IStudent _studentNull = new Student { Id = 3, Name = null, Semester = 3 };
        private IStudent _studentEmpty = new Student { Id = 4, Name = "", Semester = 4 };
        private IStudent _studentEquals = new Student { Id = 1, Name = "Shero", Gender = Person.GenderType.Male, Semester = 2 };

        [TestMethod]
        public void TestTostring()
        {
            //* Kun for at teste om ToString() virker
            string str = _student.ToString(); // act 
            Assert.AreEqual("{Id=1, Name=Shero, Gender=Male, Semester=2}", str); // assert
        }
        [TestMethod]
        public void ValidateGender()
        {
            _student.ValidateGender(); //Tjekker om den kan validere korekte
            Assert.ThrowsException<ArgumentException>(() => _studentNeative.ValidateGender()); // tjek om den can kaste en exception
        }
        [TestMethod]
        public void ValidateSemesterTest()
        {
            _student.ValidateSemester(); //Tjekker om den kan validere korekte  
            Assert.ThrowsException<ArgumentException>(() => _studentNeative.ValidateSemester()); // tjek om den can kaste en exception
        }
        [TestMethod]
        public void ValidateNameTest()
        {
            _student.ValidateName(); //Tjekker om den kan validere korekte
            Assert.ThrowsException<ArgumentException>(() => _studentNull.ValidateName()); // tjek om den can kaste en exception
            Assert.ThrowsException<ArgumentException>(() => _studentEmpty.ValidateName()); // tjek om den can kaste en exception
        }
        [TestMethod]
        public void ValidateTest()
        {
            _student.Validate(); //Tjekker om den kan validere korekte
            Assert.ThrowsException<ArgumentException>(() => _studentNull.Validate()); // tjek om den can kaste en exception
            Assert.ThrowsException<ArgumentException>(() => _studentEmpty.Validate()); // tjek om den can kaste en exception
            Assert.ThrowsException<ArgumentException>(() => _studentNeative.Validate()); // tjek om den can kaste en exception
        }
        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(8)]
        public void ValdidateSemesterTest(int semester)
        {
            _student.Semester = semester;
            _student.ValidateSemester();
        }
        [TestMethod]
        public void ValidatEqualsAndGetHashCode()
        {
            Assert.IsTrue(_studentEquals.Equals(_student));
            Assert.IsTrue(_studentEquals.GetHashCode() == _student.GetHashCode());
        }

    }
}
