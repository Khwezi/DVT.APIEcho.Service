using System.Collections.Generic;

namespace DVT.APIEcho.Service.Models
{
    internal class SampleData
    {
        public List<Comment> Comments { get; set; }

        public List<Post> Posts { get; set; }

        public SampleData()
        {
            Comments = new List<Comment>();
            Posts = new List<Post>();
            InitialiseData();
        }

        private void InitialiseData()
        {
            Comments.Clear();

            for (int a = 0; a < 10; a++)
            {
                Comments.Add(new Comment()
                {
                    Id = a,
                    Title = "foo",
                    Message = "pah"
                });

                Posts.Add(new Post()
                {
                    Id = a,
                    Title = "foo",
                    EMail = "foo@email.net",
                    Body = "oihig igu iyfudkytdytds dtu jhf kdjf ljdfjfd ljfdud ljh jd jdjd ddd dhtshhd jd"
                });
            }
        }
    }
}