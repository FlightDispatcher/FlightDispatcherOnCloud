using FlightDispatcher.FrontEnd.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Shared.Services
{
    public interface IAuthorizationService
    {
        public string AccessToken { get; }

        public IList<Claim> AccessClaims { get; }

        public void LoginSuccessful(string AccessToken, string IdToken);

        public void LoginFailed();

        public string UserName { get; }

        public UserType Role { get; }

        public string UserPicture { get; }

        public bool IsLoggedIn();

        public Guid UserID { get; }
    }
}
