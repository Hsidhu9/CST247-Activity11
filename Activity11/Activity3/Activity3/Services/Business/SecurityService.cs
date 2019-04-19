using Activity3.Models;
using Activity3.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity3.Services.Business
{
    public class SecurityService
    {
        //passes user model from controller to authenticate to a DAO that cross checks 
        //the input and whether it matches something in the database
        public bool Authenticate(UserModel user)
        {

            SecurityDAO service = new SecurityDAO();
            return service.FindByUser(user);
        }
    }
}