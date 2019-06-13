using System;
using System.Collections.Generic;

namespace Web_API.EntityModels
{
    public partial class Authors
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? UserId { get; set; }

        public Users User { get; set; }
    }
}
