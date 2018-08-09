using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2OwinBoilerplate.Models
{
    public class Follower
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FolowerId { get; set; }
    }
}