using System;

namespace VertexAssessmentApp.Models
{
    public class UserDetails : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
    }
}
