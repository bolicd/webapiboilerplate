using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2OwinBoilerplate.DTO
{
    public class TweetResultDto
    {
        public string Tweet { get; set; }
        public DateTime DateAdded { get; set; }

    }
}