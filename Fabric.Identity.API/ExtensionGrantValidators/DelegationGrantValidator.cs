﻿using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace Fabric.Identity.API.ExtensionGrantValidators
{
    public class DelegationGrantValidator : IExtensionGrantValidator
    {
        private readonly ITokenValidator _validator;

        public DelegationGrantValidator(ITokenValidator validator)
        {
            _validator = validator;
        }

        public string GrantType => "delegation";

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var userToken = context.Request.Raw.Get("token");

            if (string.IsNullOrEmpty(userToken))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                return;
            }

            var result = await _validator.ValidateAccessTokenAsync(userToken);
            if (result.IsError)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                return;
            }

            // get user's identity
            var sub = result.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Subject)?.Value;
            var groups = result.Claims.Where(c => c.Type == JwtClaimTypes.Role || c.Type == "groups");
            var identityProvider = result.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.IdentityProvider)?.Value ?? "local";
            context.Result = new GrantValidationResult(sub, "delegation", groups, identityProvider);
        }
    }
}
