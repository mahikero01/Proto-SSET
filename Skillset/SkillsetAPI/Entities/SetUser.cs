using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsetAPI.Entities
{
    public class SetUser
    {
        [Key]
        [MaxLength(25)]
        public string user_id { get; set; }
    }
}
