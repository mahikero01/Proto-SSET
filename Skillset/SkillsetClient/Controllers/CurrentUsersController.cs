using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillsetClient.Models;

namespace SkillsetClient.Controllers
{
    [Produces("application/json")]
    [Route("api/CurrentUsers")]
    public class CurrentUsersController : Controller
    {
        // GET: api/CurrentUsers
        [HttpGet]
        public CurrentUser Get()
        {
            CurrentUser currentUser = new CurrentUser();
            var username = Environment.UserName;
            var setUsersController = new SetUsersController();
            var setUserAccessController = new SetUserAccessesController();
            var setGroupsController = new SetGroupsController();
            //determine if the user is available 

            var users =setUsersController.Get().Result;
            var groups = setGroupsController.Get().Result;
            var userAccesses = setUserAccessController.Get().Result;
            var user = users.Where(x => x.user_name == username).First();

            if (user != null)
            {
                currentUser.FirstName = user.user_first_name;
                currentUser.LastName = user.user_last_name;

                var userAccess = userAccesses.Where(x => x.user_id == user.user_id).FirstOrDefault();

                if(userAccess != null)
                {
                    var group = groups.Where(x => x.grp_id == userAccess.grp_id).FirstOrDefault();

                    currentUser.Role = group.grp_name;
                }
            }

            return currentUser;
        }
    }
}
