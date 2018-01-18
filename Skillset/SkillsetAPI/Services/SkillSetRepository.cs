using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillsetAPI.Entities;

namespace SkillsetAPI.Services
{
    public class SkillSetRepository : ISkillSetRepository
    {
        private SkillSetContext _ctx;

        public SkillSetRepository(SkillSetContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<SetUser> GetSetUsers()
        {
            return _ctx.SetUsers.OrderBy(s => s.user_name).ToList();
        }

        public void AddSetUser(SetUser setUser)
        {
            throw new NotImplementedException();
        }
    }
}
