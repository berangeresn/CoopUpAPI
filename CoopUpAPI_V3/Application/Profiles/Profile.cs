using System.Collections.Generic;
using System.Text.Json.Serialization;
using Domain;

namespace Application.Profiles
{
    public class Profile
    {
        public string DisplayName { get; set; } 
        public string UserName { get; set; }    
        public string Image { get; set; }
        public string Bio { get; set; }
        public string Skill { get; set; }
        public string Degree { get; set; }
        public string Experience { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}