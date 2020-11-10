using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoemInk.Models.Entities
{
    public class Poet
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }  // navigation property
        public string PenName { get; set; }
        public List<Poem> Poems { get; set; }
    }
}
