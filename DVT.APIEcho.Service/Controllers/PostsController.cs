using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DVT.APIEcho.Service.Controllers
{
    public class PostsController : ApiController
    {
        private Models.SampleData Content { get; set; }

        public PostsController() => Content = new Models.SampleData();

        public List<Models.Post> Get() => Content.Posts;

        public Models.Post Get(int id) => Content.Posts.First(c => c.Id == id);

        public Models.Post Post([FromBody]Models.Post value)
        {
            if(Content.Posts.Count(p => p.Id == value.Id) == 0)
            {
                Content.Posts.Add(value);
            }
            return value;
        }

        public bool Put(int id, [FromBody]Models.Post value)
        {
            if (Content.Posts.Count(c => c.Id == id) > 0)
            {
                Content.Posts[id] = value;
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (Content.Posts.Count(c => c.Id == id) > 0)
            {
                Content.Posts.RemoveAt(id);
                return true;
            }

            return false;
        }
    }
}