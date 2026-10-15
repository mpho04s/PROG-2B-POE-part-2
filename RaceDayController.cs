using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Controllers;
using RaceDayAPI.Models;

namespace RaceDayAPI.Tests
{
    public class RaceDayControllerTests
    {
        [Fact]
        public void GetEvents_ReturnsAllEvents()
        {
            var controller = new EventsController();

            var result = controller.GetEvents();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var events = Assert.IsAssignableFrom<IEnumerable<Event>>(
                okResult.Value);

            Assert.NotEmpty(events);
        }

        [Fact]
        public void GetEvent_ReturnsEvent_WhenExists()
        {
            var controller = new EventsController();

            var result = controller.GetEvent(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var eventItem = Assert.IsType<Event>(okResult.Value);

            Assert.Equal("Soweto Marathon", eventItem.EventName);
        }

        [Fact]
        public void GetEvent_ReturnsNotFound_WhenMissing()
        {
            var controller = new EventsController();

            var result = controller.GetEvent(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostEvent_CreatesEvent()
        {
            var controller = new EventsController();

            var eventItem = new Event
            {
                EventID = 9001,
                OrganiserID = 2,
                EventName = "Test Marathon",
                Description = "Test event",
                EventDate = 20261201,
                StartLocation = "FNB Stadium",
                City = "Johannesburg",
                Province = "Gauteng"
            };

            var result = controller.AddEvent(eventItem);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var savedEvent = Assert.IsType<Event>(okResult.Value);

            Assert.Equal("Test Marathon", savedEvent.EventName);

            var getResult = controller.GetEvent(9001);
            var getOkResult = Assert.IsType<OkObjectResult>(getResult);

            Assert.NotNull(getOkResult.Value);

            controller.DeleteEvent(9001);
        }

        [Fact]
        public void PutEvent_UpdatesEvent_WhenExists()
        {
            var controller = new EventsController();

            var updatedEvent = new Event
            {
                EventID = 1,
                OrganiserID = 2,
                EventName = "Updated Soweto Marathon",
                Description = "Updated event",
                EventDate = 20261201,
                StartLocation = "FNB Stadium",
                City = "Johannesburg",
                Province = "Gauteng"
            };

            var result = controller.UpdateEvent(1, updatedEvent);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var eventItem = Assert.IsType<Event>(okResult.Value);

            Assert.Equal("Updated Soweto Marathon", eventItem.EventName);

            updatedEvent.EventName = "Soweto Marathon";
            updatedEvent.Description =
                "Annual marathon event in Soweto.";
            updatedEvent.EventDate = 20261101;

            controller.UpdateEvent(1, updatedEvent);
        }

        [Fact]
        public void PutEvent_ReturnsNotFound_WhenMissing()
        {
            var controller = new EventsController();

            var updatedEvent = new Event
            {
                EventID = 999,
                EventName = "Missing Event"
            };

            var result = controller.UpdateEvent(999, updatedEvent);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void DeleteEvent_RemovesEvent()
        {
            var controller = new EventsController();

            var eventItem = new Event
            {
                EventID = 9002,
                OrganiserID = 2,
                EventName = "Delete Test Event",
                Description = "Event for deletion",
                EventDate = 20261201,
                StartLocation = "Johannesburg",
                City = "Johannesburg",
                Province = "Gauteng"
            };

            controller.AddEvent(eventItem);

            var result = controller.DeleteEvent(9002);

            Assert.IsType<OkObjectResult>(result);

            var getResult = controller.GetEvent(9002);

            Assert.IsType<NotFoundObjectResult>(getResult);
        }

        [Fact]
        public void DeleteEvent_ReturnsNotFound_WhenMissing()
        {
            var controller = new EventsController();

            var result = controller.DeleteEvent(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public void GetCategories_ReturnsAllCategories()
        {
            var controller = new EventCategoriesController();

            var result = controller.GetCategories();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var categories =
                Assert.IsAssignableFrom<IEnumerable<EventCategory>>(
                    okResult.Value);

            Assert.NotEmpty(categories);
        }

        [Fact]
        public void GetCategory_ReturnsCategory_WhenExists()
        {
            var controller = new EventCategoriesController();

            var result = controller.GetCategory(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var category = Assert.IsType<EventCategory>(okResult.Value);

            Assert.Equal("42.2 km Marathon", category.CategoryName);
        }

        [Fact]
        public void GetCategory_ReturnsNotFound_WhenMissing()
        {
            var controller = new EventCategoriesController();

            var result = controller.GetCategory(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostCategory_CreatesCategory()
        {
            var controller = new EventCategoriesController();

            var category = new EventCategory
            {
                CategoryID = 9001,
                EventID = 1,
                CategoryName = "5 km Fun Run",
                DistanceKm = 5,
                EntryFee = 50
            };

            var result = controller.AddCategory(category);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var savedCategory =
                Assert.IsType<EventCategory>(okResult.Value);

            Assert.Equal("5 km Fun Run", savedCategory.CategoryName);

            var getResult = controller.GetCategory(9001);

            Assert.IsType<OkObjectResult>(getResult);

            controller.DeleteCategory(9001);
        }

        [Fact]
        public void PutCategory_UpdatesCategory_WhenExists()
        {
            var controller = new EventCategoriesController();

            var updatedCategory = new EventCategory
            {
                CategoryID = 1,
                EventID = 1,
                CategoryName = "Updated Marathon",
                DistanceKm = 42,
                EntryFee = 350
            };

            var result = controller.UpdateCategory(1, updatedCategory);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var category =
                Assert.IsType<EventCategory>(okResult.Value);

            Assert.Equal("Updated Marathon", category.CategoryName);
            Assert.Equal(350, category.EntryFee);

            updatedCategory.CategoryName = "42.2 km Marathon";
            updatedCategory.EntryFee = 300;

            controller.UpdateCategory(1, updatedCategory);
        }

        [Fact]
        public void PutCategory_ReturnsNotFound_WhenMissing()
        {
            var controller = new EventCategoriesController();

            var category = new EventCategory
            {
                CategoryID = 999,
                CategoryName = "Missing Category"
            };

            var result = controller.UpdateCategory(999, category);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void DeleteCategory_RemovesCategory()
        {
            var controller = new EventCategoriesController();

            var category = new EventCategory
            {
                CategoryID = 9002,
                EventID = 1,
                CategoryName = "Delete Test Category",
                DistanceKm = 3,
                EntryFee = 30
            };

            controller.AddCategory(category);

            var result = controller.DeleteCategory(9002);

            Assert.IsType<OkObjectResult>(result);

            Assert.IsType<NotFoundObjectResult>(
                controller.GetCategory(9002));
        }

        [Fact]
        public void DeleteCategory_ReturnsNotFound_WhenMissing()
        {
            var controller = new EventCategoriesController();

            var result = controller.DeleteCategory(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public void GetEnrolments_ReturnsAllEnrolments()
        {
            var controller = new EnrolmentsController();

            var result = controller.GetEnrolments();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var enrolments = Assert.IsAssignableFrom<IEnumerable<Enrolment>>(
                okResult.Value);

            Assert.NotEmpty(enrolments);
        }

        [Fact]
        public void GetEnrolment_ReturnsEnrolment_WhenExists()
        {
            var controller = new EnrolmentsController();

            var result = controller.GetEnrolment(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var enrolment = Assert.IsType<Enrolment>(okResult.Value);

            Assert.Equal(101, enrolment.RaceNumber);
        }

        [Fact]
        public void GetEnrolment_ReturnsNotFound_WhenMissing()
        {
            var controller = new EnrolmentsController();

            var result = controller.GetEnrolment(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostEnrolment_CreatesEnrolment()
        {
            var controller = new EnrolmentsController();

            var enrolment = new Enrolment
            {
                EnrolmentID = 9001,
                CategoryID = 1,
                ParticipantID = 1,
                RaceNumber = 9001,
                EnrolmentDate = 20261009,
                Status = "Confirmed",
                Pending = "No"
            };

            var result = controller.AddEnrolment(enrolment);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var savedEnrolment =
                Assert.IsType<Enrolment>(okResult.Value);

            Assert.Equal(9001, savedEnrolment.RaceNumber);

            Assert.IsType<OkObjectResult>(
                controller.GetEnrolment(9001));

            controller.DeleteEnrolment(9001);
        }

        [Fact]
        public void PutEnrolment_UpdatesEnrolment_WhenExists()
        {
            var controller = new EnrolmentsController();

            var updatedEnrolment = new Enrolment
            {
                EnrolmentID = 1,
                CategoryID = 1,
                ParticipantID = 1,
                RaceNumber = 101,
                EnrolmentDate = 20260910,
                Status = "Updated",
                Pending = "Yes"
            };

            var result = controller.UpdateEnrolment(1, updatedEnrolment);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var enrolment = Assert.IsType<Enrolment>(okResult.Value);

            Assert.Equal("Updated", enrolment.Status);
            Assert.Equal("Yes", enrolment.Pending);

            updatedEnrolment.Status = "Confirmed";
            updatedEnrolment.Pending = "No";

            controller.UpdateEnrolment(1, updatedEnrolment);
        }

        [Fact]
        public void PutEnrolment_ReturnsNotFound_WhenMissing()
        {
            var controller = new EnrolmentsController();

            var enrolment = new Enrolment
            {
                EnrolmentID = 999,
                Status = "Updated"
            };

            var result = controller.UpdateEnrolment(999, enrolment);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void DeleteEnrolment_RemovesEnrolment()
        {
            var controller = new EnrolmentsController();

            var enrolment = new Enrolment
            {
                EnrolmentID = 9002,
                CategoryID = 1,
                ParticipantID = 1,
                RaceNumber = 9002,
                EnrolmentDate = 20261009,
                Status = "Confirmed",
                Pending = "No"
            };

            controller.AddEnrolment(enrolment);

            var result = controller.DeleteEnrolment(9002);

            Assert.IsType<OkObjectResult>(result);

            Assert.IsType<NotFoundObjectResult>(
                controller.GetEnrolment(9002));
        }

        [Fact]
        public void DeleteEnrolment_ReturnsNotFound_WhenMissing()
        {
            var controller = new EnrolmentsController();

            var result = controller.DeleteEnrolment(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public void GetProfiles_ReturnsAllProfiles()
        {
            var controller = new ParticipantProfilesController();

            var result = controller.GetProfiles();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var profiles =
                Assert.IsAssignableFrom<IEnumerable<ParticipantProfile>>(
                    okResult.Value);

            Assert.NotEmpty(profiles);
        }

        [Fact]
        public void GetProfile_ReturnsProfile_WhenExists()
        {
            var controller = new ParticipantProfilesController();

            var result = controller.GetProfile("P001");

            var okResult = Assert.IsType<OkObjectResult>(result);
            var profile =
                Assert.IsType<ParticipantProfile>(okResult.Value);

            Assert.Equal("P001", profile.ProfileID);
            Assert.Equal("Jane Smith", profile.EmergencyContactName);
        }

        [Fact]
        public void GetProfile_ReturnsNotFound_WhenMissing()
        {
            var controller = new ParticipantProfilesController();

            var result = controller.GetProfile("INVALID");

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostProfile_CreatesProfile()
        {
            var controller = new ParticipantProfilesController();

            var profile = new ParticipantProfile
            {
                ProfileID = "TEST9001",
                UserID = "1",
                EmergencyContactName = "Test Contact",
                EmergencyContactPhone = "0820000000",
                ClubName = "Test Running Club",
                AsaLicenceNumber = "ASA9001"
            };

            var result = controller.AddProfile(profile);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var savedProfile =
                Assert.IsType<ParticipantProfile>(okResult.Value);

            Assert.Equal("TEST9001", savedProfile.ProfileID);
            Assert.Equal("Test Contact", savedProfile.EmergencyContactName);

            Assert.IsType<OkObjectResult>(
                controller.GetProfile("TEST9001"));

            controller.DeleteProfile("TEST9001");
        }

        [Fact]
        public void PutProfile_UpdatesProfile_WhenExists()
        {
            var controller = new ParticipantProfilesController();

            var updatedProfile = new ParticipantProfile
            {
                ProfileID = "P001",
                UserID = "1",
                EmergencyContactName = "Updated Contact",
                EmergencyContactPhone = "0821234567",
                ClubName = "Updated Running Club",
                AsaLicenceNumber = "ASA001"
            };

            var result = controller.UpdateProfile("P001", updatedProfile);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var profile =
                Assert.IsType<ParticipantProfile>(okResult.Value);

            Assert.Equal("Updated Contact", profile.EmergencyContactName);
            Assert.Equal("Updated Running Club", profile.ClubName);

            updatedProfile.EmergencyContactName = "Jane Smith";
            updatedProfile.ClubName = "Soweto Running Club";

            controller.UpdateProfile("P001", updatedProfile);
        }

        [Fact]
        public void PutProfile_ReturnsNotFound_WhenMissing()
        {
            var controller = new ParticipantProfilesController();

            var profile = new ParticipantProfile
            {
                ProfileID = "INVALID",
                UserID = "1",
                EmergencyContactName = "Test Contact"
            };

            var result = controller.UpdateProfile("INVALID", profile);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void DeleteProfile_RemovesProfile()
        {
            var controller = new ParticipantProfilesController();

            var profile = new ParticipantProfile
            {
                ProfileID = "TEST9002",
                UserID = "1",
                EmergencyContactName = "Delete Test",
                EmergencyContactPhone = "0820000000",
                ClubName = "Test Club",
                AsaLicenceNumber = "ASA9002"
            };

            controller.AddProfile(profile);

            var result = controller.DeleteProfile("TEST9002");

            Assert.IsType<OkObjectResult>(result);

            Assert.IsType<NotFoundObjectResult>(
                controller.GetProfile("TEST9002"));
        }

        [Fact]
        public void DeleteProfile_ReturnsNotFound_WhenMissing()
        {
            var controller = new ParticipantProfilesController();

            var result = controller.DeleteProfile("INVALID");

            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public void GetResults_ReturnsAllResults()
        {
            var controller = new ResultsController();

            var result = controller.GetResults();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var results = Assert.IsAssignableFrom<IEnumerable<Result>>(
                okResult.Value);

            Assert.NotEmpty(results);
        }

        [Fact]
        public void GetResult_ReturnsResult_WhenExists()
        {
            var controller = new ResultsController();

            var result = controller.GetResult(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var raceResult = Assert.IsType<Result>(okResult.Value);

            Assert.Equal("03:45:20", raceResult.OfficialTime);
            Assert.Equal(25, raceResult.OverallPosition);
        }

        [Fact]
        public void GetResult_ReturnsNotFound_WhenMissing()
        {
            var controller = new ResultsController();

            var result = controller.GetResult(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostResult_CreatesResult()
        {
            var controller = new ResultsController();

            var raceResult = new Result
            {
                ResultID = 9001,
                EnrolmentID = 1,
                OfficialTime = "00:30:00",
                OverallPosition = 100,
                CategoryPosition = 20,
                PacePerKm = "06:00"
            };

            var result = controller.AddResult(raceResult);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var savedResult = Assert.IsType<Result>(okResult.Value);

            Assert.Equal("00:30:00", savedResult.OfficialTime);

            Assert.IsType<OkObjectResult>(
                controller.GetResult(9001));

            controller.DeleteResult(9001);
        }

        [Fact]
        public void PutResult_UpdatesResult_WhenExists()
        {
            var controller = new ResultsController();

            var updatedResult = new Result
            {
                ResultID = 1,
                EnrolmentID = 1,
                OfficialTime = "03:40:00",
                OverallPosition = 20,
                CategoryPosition = 8,
                PacePerKm = "05:10"
            };

            var result = controller.UpdateResult(1, updatedResult);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var raceResult = Assert.IsType<Result>(okResult.Value);

            Assert.Equal("03:40:00", raceResult.OfficialTime);
            Assert.Equal(20, raceResult.OverallPosition);

            updatedResult.OfficialTime = "03:45:20";
            updatedResult.OverallPosition = 25;
            updatedResult.CategoryPosition = 10;
            updatedResult.PacePerKm = "05:20";

            controller.UpdateResult(1, updatedResult);
        }

        [Fact]
        public void PutResult_ReturnsNotFound_WhenMissing()
        {
            var controller = new ResultsController();

            var raceResult = new Result
            {
                ResultID = 999,
                OfficialTime = "00:30:00"
            };

            var result = controller.UpdateResult(999, raceResult);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void DeleteResult_RemovesResult()
        {
            var controller = new ResultsController();

            var raceResult = new Result
            {
                ResultID = 9002,
                EnrolmentID = 1,
                OfficialTime = "00:30:00",
                OverallPosition = 100,
                CategoryPosition = 20,
                PacePerKm = "06:00"
            };

            controller.AddResult(raceResult);

            var result = controller.DeleteResult(9002);

            Assert.IsType<OkObjectResult>(result);

            Assert.IsType<NotFoundObjectResult>(
                controller.GetResult(9002));
        }

        [Fact]
        public void DeleteResult_ReturnsNotFound_WhenMissing()
        {
            var controller = new ResultsController();

            var result = controller.DeleteResult(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public void GetUsers_ReturnsAllUsers()
        {
            var controller = new UsersController();

            var result = controller.GetUsers();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var users = Assert.IsAssignableFrom<IEnumerable<Users>>(
                okResult.Value);

            Assert.NotEmpty(users);
        }

        [Fact]
        public void GetUser_ReturnsUser_WhenExists()
        {
            var controller = new UsersController();

            var result = controller.GetUser(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsType<Users>(okResult.Value);

            Assert.Equal("John Smith", user.FullName);
            Assert.Equal("john@example.com", user.Email);
        }

        [Fact]
        public void GetUser_ReturnsNotFound_WhenMissing()
        {
            var controller = new UsersController();

            var result = controller.GetUser(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void PostUser_CreatesUser()
        {
            var controller = new UsersController();

            var user = new Users
            {
                UserID = 9001,
                FullName = "Peter Adams",
                Email = "peter9001@example.com",
                PasswordHash = "test-password",
                Role = "Participant",
                CreatedAt = "2026-10-09"
            };

            var result = controller.AddUser(user);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var savedUser = Assert.IsType<Users>(okResult.Value);

            Assert.Equal("Peter Adams", savedUser.FullName);
            Assert.Equal("peter9001@example.com", savedUser.Email);

            Assert.IsType<OkObjectResult>(
                controller.GetUser(9001));

            controller.DeleteUser(9001);
        }

        [Fact]
        public void PutUser_UpdatesUser_WhenExists()
        {
            var controller = new UsersController();

            var updatedUser = new Users
            {
                UserID = 1,
                FullName = "Updated John Smith",
                Email = "john@example.com",
                PasswordHash = "password123",
                Role = "Participant",
                CreatedAt = "2026-09-10"
            };

            var result = controller.UpdateUser(1, updatedUser);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsType<Users>(okResult.Value);

            Assert.Equal("Updated John Smith", user.FullName);

            updatedUser.FullName = "John Smith";

            controller.UpdateUser(1, updatedUser);
        }

        [Fact]
        public void PutUser_ReturnsNotFound_WhenMissing()
        {
            var controller = new UsersController();

            var user = new Users
            {
                UserID = 999,
                FullName = "Missing User"
            };

            var result = controller.UpdateUser(999, user);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void DeleteUser_RemovesUser()
        {
            var controller = new UsersController();

            var user = new Users
            {
                UserID = 9002,
                FullName = "Delete Test User",
                Email = "delete9002@example.com",
                PasswordHash = "test-password",
                Role = "Participant",
                CreatedAt = "2026-10-09"
            };

            controller.AddUser(user);

            var result = controller.DeleteUser(9002);

            Assert.IsType<OkObjectResult>(result);

            Assert.IsType<NotFoundObjectResult>(
                controller.GetUser(9002));
        }

        [Fact]
        public void DeleteUser_ReturnsNotFound_WhenMissing()
        {
            var controller = new UsersController();

            var result = controller.DeleteUser(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public void Login_ReturnsUser_WhenCredentialsAreValid()
        {
            var controller = new AuthenticationController();

            var result = controller.Login(
                "john@gmail.com", "12345");

            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);

            var userID = okResult.Value.GetType()
                .GetProperty("UserID");

            Assert.NotNull(userID);
            Assert.Equal(1, userID.GetValue(okResult.Value));
        }

        [Fact]
        public void Login_ReturnsUnauthorized_WhenCredentialsAreInvalid()
        {
            var controller = new AuthenticationController();

            var result = controller.Login(
                "wrong@gmail.com", "wrong-password");

            Assert.IsType<UnauthorizedObjectResult>(result);
        }

        [Fact]
        public void Register_CreatesUser_WhenEmailIsNew()
        {
            var controller = new AuthenticationController();

            var email = $"test{Guid.NewGuid():N}@example.com";

            var user = new Users
            {
                FullName = "Test Registration",
                Email = email,
                PasswordHash = "test-password",
                Role = "Participant"
            };

            var result = controller.Register(user);

            Assert.IsType<OkObjectResult>(result);

            var loginResult = controller.Login(
                email, "test-password");

            Assert.IsType<OkObjectResult>(loginResult);
        }

        [Fact]
        public void Register_ReturnsBadRequest_WhenEmailAlreadyExists()
        {
            var controller = new AuthenticationController();

            var user = new Users
            {
                FullName = "Duplicate User",
                Email = "john@gmail.com",
                PasswordHash = "another-password",
                Role = "Participant"
            };

            var result = controller.Register(user);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}