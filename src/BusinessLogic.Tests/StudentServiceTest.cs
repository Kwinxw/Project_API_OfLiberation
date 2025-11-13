using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class StudentServiceTest
    {
        private readonly StudentsService service;
        private readonly Mock<IStudentsRepository> studentsRepositoryMoq;

        public StudentServiceTest()
        {
            var repositoryWrapperMog = new Mock<IRepositoryWrapper>();
            studentsRepositoryMoq = new Mock<IStudentsRepository>();
            repositoryWrapperMog.Setup(x => x.Студенты)
                .Returns(studentsRepositoryMoq.Object);
            service = new StudentsService(repositoryWrapperMog.Object);
        }

        [Theory]
        [MemberData(nameof(GetIncorrectStudents))]
        public async Task CreateAsyncNewStudentShouldNotCreateNewStudent(Студенты student)
        {
            // arrange
            var newStudent = student;
            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            //assert
            Assert.IsType<ArgumentNullException>(ex);
            studentsRepositoryMoq.Verify(x => x.Create(It.IsAny<Студенты>()), Times.Never);
        }
        public static IEnumerable<object[]> GetIncorrectStudents()
        {
            return new List<object[]>
            {
                new object[] { new Студенты() { Фамилия = "", Имя = "", Отчество = "", НомерЗачетки = "", Телефон = "", Email = "" } },
                new object[] { new Студенты() { Фамилия = "Test", Имя = "", Отчество = "", НомерЗачетки = "", Телефон = "", Email = "" } },
                new object[] { new Студенты() { Фамилия = "Test", Имя = "Test", Отчество = "", НомерЗачетки = "", Телефон = "", Email = "" } },
            };
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            // arrange
            var newUser = new Студенты()
            {
                Фамилия = "Test",
                Имя = "Test",
                Отчество = "Test",
                НомерЗачетки = "Test",
                Телефон = "Test",
                Email = "test@test.com",
            };

            // act
            await service.Create(newUser);

            // assert
            studentsRepositoryMoq.Verify(x => x.Create(It.IsAny<Студенты>()), Times.Once);
        }
    }
}
