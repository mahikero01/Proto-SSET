using SkillsetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsetAPI
{
    public static class SkillSetExtensions
    {
        public static void EnsureSeedDataForContext(this SkillSetContext ctx)
        {
            if (ctx.SetUsers.Any())
            {
                return;
            }

            var setUsers = new List<SetUser>()
                    {
                        new SetUser()
                        {
                            user_id = "USER-20150428-001",
                            user_name = "sarmife",
                            user_last_name = "Sarmiento",
                            user_first_name = "Federico",
                            user_middle_name = "Paras",
                            can_PROD = false,
                            can_UAT = false,
                            can_PEER = false,
                            can_DEV = false,
                            created_date = new DateTime(2015,04,28,19,05,40)
                        },
                        new SetUser()
                        {
                            user_id = "USER-20171128-002",
                            user_name = "alvarer",
                            user_last_name = "Alvarez",
                            user_first_name = "Eros",
                            user_middle_name = "K",
                            can_PROD = false,
                            can_UAT = false,
                            can_PEER = false,
                            can_DEV = false,
                            created_date = new DateTime(2017,11,28,19,05,40)
                        }
                    };

            ctx.SetUsers.AddRange(setUsers);
            ctx.SaveChanges();
        }
    }
}
