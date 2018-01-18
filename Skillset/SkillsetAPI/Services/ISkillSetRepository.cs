using SkillsetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsetAPI.Services
{
    public interface ISkillSetRepository
    {
        IEnumerable<SetUser> ReadSetUsers();

        SetUser ReadSetUser(string userId);

        IEnumerable<SetGroup> ReadSetGroups();

        SetGroup ReadSetGroup(string groupId);

        IEnumerable<SetUserAccess> ReadSetUserAccesses();

        SetUserAccess ReadSetUserAccess(int accessId);
    }
}
