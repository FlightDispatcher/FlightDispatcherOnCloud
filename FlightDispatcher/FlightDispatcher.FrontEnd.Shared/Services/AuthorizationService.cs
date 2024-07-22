using FlightDispatcher.FrontEnd.Shared.Enums;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Shared.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private string accessToken { get; set; }
        private string idToken { get; set; }
        private IList<Claim> accessClaims { get; set; }
        private IList<Claim> idClaims { get; set; }


        public string AccessToken
        {
            get { return accessToken; }
        }

        public string IdToken
        {
            get { return idToken; }
        }

        public IList<Claim> AccessClaims
        {
            get { return accessClaims; }
        }

        public IList<Claim> IDClaims
        {
            get { return idClaims; }
        }

        public void LoginFailed()
        {
            ClearJWToken();
        }

        public void LoginSuccessful(string AccessToken, string IdToken)
        {
            if (AccessToken != null && AccessToken.Length > 0 && IdToken != null && IdToken.Length > 0)
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken securityAccessToken = (JwtSecurityToken)tokenHandler.ReadToken(AccessToken);
                JwtSecurityToken securityIdToken = (JwtSecurityToken)tokenHandler.ReadToken(IdToken);

                if (securityAccessToken != null && securityIdToken != null)
                {
                    accessToken = AccessToken;
                    accessClaims = securityAccessToken.Claims.ToList();

                    idToken = IdToken;
                    idClaims = securityIdToken.Claims.ToList();
                }
                else
                {
                    ClearJWToken();
                }

            }
            else
            {
                ClearJWToken();
            }
        }

        private void ClearJWToken()
        {
            accessToken = null;
            accessClaims = null;

            idToken = null;
            idClaims = null;
        }

        public bool IsLoggedIn()
        {
            return (AccessToken != null && AccessToken.Length > 0 && AccessClaims != null && AccessClaims.Count > 0);
        }

        // read only property
        // return the user name inside the JWT
        public string UserName
        {
            get
            {
                // prepare the default value
                string Value = null;

                // check if we already have the claim list
                if (idClaims != null && idClaims.Count > 0)
                {
                    // looking for "unique_name" claim
                    var nameClaim = idClaims.FirstOrDefault(c => c.Type == "name");
                    if (nameClaim != null)
                    {
                        // we have a valid claim object
                        Value = nameClaim.Value;
                    }
                }

                // return the value
                return Value;
            }
        }

        // read only property
        // return the role inside the JWT
        public UserType Role
        {
            get
            {
                // prepare the default value
                UserType Value = UserType.ClientUser;

                // check if we already have the claim list
                if (idClaims != null && idClaims.Count > 0)
                {
                    // looking for "role" claim
                    var roleClaim = idClaims.FirstOrDefault(c => c.Type == "role");
                    if (roleClaim != null)
                    {
                        // we have a valid claim object
                        Value = Enum.Parse<UserType>(roleClaim.Value);
                    }
                }

                // return the value
                return Value;
            }
        }

        public string UserPicture
        {
            get
            {
                // prepare the default value
                string Value = null;

                // check if we already have the claim list
                if (idClaims != null && idClaims.Count > 0)
                {
                    // looking for "unique_name" claim
                    var pictureClaim = idClaims.FirstOrDefault(c => c.Type == "picture");
                    if (pictureClaim != null)
                    {
                        // we have a valid claim object
                        Value = pictureClaim.Value;
                    }
                }

                // return the value
                return Value;
            }
        }

        public Guid UserID
        {
            get
            {
                // prepare the default value
                Guid Value = Guid.Empty;

                // check if we already have the claim list
                if (idClaims != null && idClaims.Count > 0)
                {
                    // looking for "unique_name" claim
                    var nameClaim = idClaims.FirstOrDefault(c => c.Type == "sub");
                    if (nameClaim != null)
                    {
                        // we have a valid claim object
                        Value = Guid.Parse(nameClaim.Value.Replace("auth0|", ""));
                    }
                }

                // return the value
                return Value;
            }
        }
    }
}
