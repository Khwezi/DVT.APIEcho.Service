using DVT.APIEcho.Service.Controllers;
using NUnit.Framework;
using System.Linq;

namespace DVT.APIEcho.Service.Tests
{
    [TestFixture]
    public class CommentsControllerTests
    {
        private CommentsController CreateCommentsController()
        {
            return new CommentsController();
        }

        [Test]
        public void Get_RetrieveAllComments_CommentList()
        {
            // Arrange
            var unitUnderTest = CreateCommentsController();

            // Act
            var result = unitUnderTest.Get();

            // Assert
            Assert.That(result, Is.Not.Null);
            CollectionAssert.IsNotEmpty(result);
            Assert.That(result.First().Id, Is.EqualTo(0));
            Assert.That(result.First().Title, Is.EqualTo("foo"));
        }

        [Test]
        public void Get_RequestOneComment_ReturnFirstItemInList()
        {
            // Arrange
            var unitUnderTest = CreateCommentsController();
            int id = 2;

            // Act
            var result = unitUnderTest.Get(id);

            // Assert
            Assert.That(result.Id, Is.EqualTo(2));
            Assert.That(result.Title, Is.EqualTo("foo"));
            Assert.That(result.Message, Is.EqualTo("pah"));
        }

        [Test]
        public void Post_NewComment_ReturnAddedComment()
        {
            // Arrange
            var unitUnderTest = CreateCommentsController();
            Models.Comment value = new Models.Comment()
            {
                Id = 99,
                Title = "aaa",
                Message = "zzzz"
            };

            // Act
            var result = unitUnderTest.Post(value);

            // Assert
            Assert.That(result.Id, Is.EqualTo(value.Id));
            Assert.That(result.Title, Is.EqualTo(value.Title));
            Assert.That(result.Message, Is.EqualTo(value.Message));
        }

        [Test]
        public void Put_UpdateExistinComment_ReturnTrueMeansSuccess()
        {
            // Arrange
            var unitUnderTest = CreateCommentsController();
            int id = 4;
            Models.Comment value = new Models.Comment()
            {
                Id = id,
                Title = "bbb",
                Message = "vvv vvv"
            };

            // Act
            var result = unitUnderTest.Put(id, value);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Delete_DeleteAComment_ReturnTrueMeansSuccess()
        {
            // Arrange
            var unitUnderTest = CreateCommentsController();
            int id = 6;

            // Act
            var result = unitUnderTest.Delete(id);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}