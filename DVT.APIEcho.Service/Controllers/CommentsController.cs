using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DVT.APIEcho.Service.Controllers
{
    public class CommentsController : ApiController
    {
        private Models.SampleData Content { get; set; }

        public CommentsController() => Content = new Models.SampleData();

        public List<Models.Comment> Get() => Content.Comments;

        public Models.Comment Get(int id) => Content.Comments.First(c => c.Id == id);

        public Models.Comment Post([FromBody]Models.Comment value) => value;

        public bool Put(int id, [FromBody]Models.Comment value) => Content.Comments.Count(c => c.Id == id) > 0 ? true : false;

        public bool Delete(int id) => Content.Comments.Count(c => c.Id == id) > 0 ? true : false;
    }
}