
using StudentWebAPI.Services;
using StudentWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
    /// <summary>   
    /// Authorization for web API class.   
    /// </summary>   
public class AuthorizationHeaderHandler : DelegatingHandler
{
    /// <summary>   
    /// Send method.   
    /// </summary>   
    /// <param name="request">Request parameter</param>   
    /// <param name="cancellationToken">Cancellation token parameter</param>   
    /// <returns>Return HTTP response.</returns>   
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Initialization.   
        IEnumerable<string> apiKeyHeaderValues = null;
        AuthenticationHeaderValue authorization = request.Headers.Authorization;
        // Verification.   
        if (request.Headers.TryGetValues("Authorization", out apiKeyHeaderValues) && !string.IsNullOrEmpty(authorization.Parameter))
        {
            var apiKeyHeaderValue = apiKeyHeaderValues.First();
            // Get the auth token   
            string authToken = authorization.Parameter;
            JwtUtils jwtUtils = new JwtUtils();
            Encoded decoded = jwtUtils.ValidateToken(authToken);
            
            // Verification.
            if (decoded != null)
            {
                if (!((request.Method.Method == "POST" || request.Method.Method == "PUT" ||
                    request.Method.Method == "DELETE") && decoded.Role == 0))
                {
                    var identity = new GenericIdentity(decoded.UserId.ToString());
                    SetPrincipal(new GenericPrincipal(identity, null));
                }
                // var identity = new GenericIdentity(decoded.UserId.ToString());
                //SetPrincipal(new GenericPrincipal(identity, null));
            }
        }
        // Info.   
        return base.SendAsync(request, cancellationToken);
    }
    /// <summary>   
    /// Set principal method.   
    /// </summary>   
    /// <param name="principal">Principal parameter</param>   
    private static void SetPrincipal(IPrincipal principal)
    {
        // setting.   
        Thread.CurrentPrincipal = principal;
        // Verification.   
        if (HttpContext.Current != null)
        {
            // Setting.   
            HttpContext.Current.User = principal;
        }
    }
}