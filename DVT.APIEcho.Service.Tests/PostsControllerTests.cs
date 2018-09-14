using DVT.APIEcho.Service.Controllers;
using NUnit.Framework;
using System.Linq;

namespace DVT.APIEcho.Service.Tests
{
    [TestFixture]
    public class PostsControllerTests
    {
        private PostsController CreatePostsController()
        {
            return new PostsController();
        }

        [Test]
        public void Get_RetrieveAllPosts_PostList()
        {
            // Arrange
            var unitUnderTest = CreatePostsController();

            // Act
            var result = unitUnderTest.Get();

            // Assert
            Assert.That(result, Is.Not.Null);
            CollectionAssert.IsNotEmpty(result);
            Assert.That(result.First().Id, Is.EqualTo(0));
            Assert.That(result.First().Title, Is.EqualTo("foo"));
            Assert.That(result.First().EMail, Is.EqualTo("foo@email.net"));
            Assert.That(result.First().Body, Is.EqualTo("oihig igu iyfudkytdytds dtu jhf kdjf ljdfjfd ljfdud ljh jd jdjd ddd dhtshhd jd"));
        }

        [Test]
        public void Get_RequestOnePost_ReturnFirstItemInList()
        {
            // Arrange
            var unitUnderTest = CreatePostsController();
            int id = 5;

            // Act
            var result = unitUnderTest.Get(id);

            // Assert
            Assert.That(result.Id, Is.EqualTo(5));
            Assert.That(result.Title, Is.EqualTo("foo"));
            Assert.That(result.EMail, Is.EqualTo("foo@email.net"));
            Assert.That(result.Body, Is.EqualTo("oihig igu iyfudkytdytds dtu jhf kdjf ljdfjfd ljfdud ljh jd jdjd ddd dhtshhd jd"));
        }

        [Test]
        public void Post_NewPost_ReturnAddedPost()
        {
            // Arrange
            var unitUnderTest = CreatePostsController();
            Models.Post value = new Models.Post()
            {
                Id = 98,
                Title = "www",
                EMail = "foo@email.net",
                Body = "erwgwegwegsds sfsssw"
            };

            // Act
            var result = unitUnderTest.Post(value);

            // Assert
            Assert.That(result.Id, Is.EqualTo(value.Id));
            Assert.That(result.Title, Is.EqualTo(value.Title));
            Assert.That(result.EMail, Is.EqualTo(value.EMail));
            Assert.That(result.Body, Is.EqualTo(value.Body));
        }

        [Test]
        public void Put_UpdateExistingPost_ReturnTrueMeansSuccess()
        {
            // Arrange
            var unitUnderTest = CreatePostsController();
            int id = 8;
            Models.Post value = new Models.Post()
            {
                Id = id,
                Title = "eeee",
                EMail = "foo@email.net",
                Body = "drg grg  sw"
            };

            // Act
            var result = unitUnderTest.Put(id, value);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Delete_DeletePost_ReturnTrueMeansSuccess()
        {
            // Arrange
            var unitUnderTest = CreatePostsController();
            int id = 5;

            // Act
            var result = unitUnderTest.Delete(id);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}