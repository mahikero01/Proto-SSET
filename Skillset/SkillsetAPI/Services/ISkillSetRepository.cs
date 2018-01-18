using SkillsetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsetAPI.Services
{
    public interface ISkillSetRepository
    {
        IEnumerable<SetUser> GetSetUsers();

        void AddSetUser(SetUser setUser);
    }
}
