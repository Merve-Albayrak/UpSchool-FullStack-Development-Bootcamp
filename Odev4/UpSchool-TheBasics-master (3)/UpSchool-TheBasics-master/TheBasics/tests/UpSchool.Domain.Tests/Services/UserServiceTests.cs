using FakeItEasy;
using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Services;

namespace UpSchool.Domain.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUser_ShouldGetUserWithCorrectId()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId
            };

            A.CallTo(() =>  userRepositoryMock.GetByIdAsync(userId, cancellationSource.Token))
                .Returns(Task.FromResult(expectedUser));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.GetByIdAsync(userId, cancellationSource.Token);

            Assert.Equal(expectedUser, user);
        }

        [Fact]
        public async Task AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            IUserService userService = new UserManager(userRepositoryMock);

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "merve",
                LastName = "albayrak",
                Age = 24,
                Email = "" // Boş e-posta adresi
            };
            var cancellationSource = new CancellationTokenSource();

            await Assert.ThrowsAsync<ArgumentException>(() => userService.AddAsync(user.FirstName,user.LastName,user.Age,user.Email, cancellationSource.Token));
        }


        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenUserExists()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            IUserService userService = new UserManager(userRepositoryMock);

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "merve",
                LastName = "albayrak",
                Age = 24,
                Email = "merve@gmail.com" // Boş e-posta adresi
            };
            var cancellationSource = new CancellationTokenSource();

            A.CallTo(() => userRepositoryMock.AddAsync(user, cancellationSource.Token));
            //  .Returns(Task.FromResult(expectedUser));
            //    userService.AddAsync(user.FirstName, user.LastName, user.Age, user.Email, cancellationSource.Token);

             Assert.True( userService.DeleteAsync(user.Id, cancellationSource.Token).Result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowException_WhenUserDoesntExist()
        {


            var userRepositoryMock = A.Fake<IUserRepository>();
            IUserService userService = new UserManager(userRepositoryMock);

            var user = new User
            {
                Id = Guid.Empty,
                FirstName = "merve",
                LastName = "albayrak",
                Age = 24,
                Email = "" // Boş e-posta adresi
            };
            var cancellationSource = new CancellationTokenSource();

            await Assert.ThrowsAsync<ArgumentException>(() => userService.DeleteAsync(user.Id, cancellationSource.Token));

        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenUserEmailEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            IUserService userService = new UserManager(userRepositoryMock);

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "merve",
                LastName = "albayrak",
                Age = 24,
                Email = null// Boş e-posta adresi
            };
            var cancellationSource = new CancellationTokenSource();

            await Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(user, cancellationSource.Token));



        }
        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            IUserService userService = new UserManager(userRepositoryMock);

            var user = new User
            {
                Id = Guid.Empty,
                FirstName = "merve",
                LastName = "albayrak",
                Age = 24,
                Email = "merve@gmail.com"
            };
            var cancellationSource = new CancellationTokenSource();

            await Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(user, cancellationSource.Token));



        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn_UserListWithAtLeastTwoRecords()

        {
            var userRepositoryMock = A.Fake<IUserRepository>();
            IUserService userService = new UserManager(userRepositoryMock);
            var cancellationSource = new CancellationTokenSource();
            var list = (userService.GetAllAsync(cancellationSource.Token));
            Assert.True(list.Result.Count>=2,"minumum uzunluk 2 olmalıdır");

        }
    }
}
