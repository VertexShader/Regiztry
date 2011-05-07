using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private static OpenIdRelyingParty openid = new OpenIdRelyingParty();

        public ViewResult GetUpOnIt()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Authenticate(string returnUrl)
        {
            var response = openid.GetResponse();
            if (response == null)
            {
                // Stage 2: user submitting Identifier  
                Identifier id;
                if (Identifier.TryParse(Request.Form["openid_identifier"], out id))
                {
                    try
                    {
                        var request = openid.CreateRequest(Request.Form["openid_identifier"]);

                        //Ask user for their email address  
                        ClaimsRequest fields = new ClaimsRequest();
                        fields.Email = DemandLevel.Request;
                        request.AddExtension(fields);

                        return request.RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        ViewData["Message"] = ex.Message;
                        return View("GetUpOnIt");
                    }
                }

                ViewData["Message"] = "Invalid identifier";
                return View("GetUpOnIt");
            }

            // Stage 3: OpenID Provider sending assertion response  
            switch (response.Status)
            {
                case AuthenticationStatus.Authenticated:
                    //MembershipUser user = MembershipService.GetUser(response.ClaimedIdentifier);
                    //if (user == null)
                    //{
                    //    MembershipCreateStatus membershipCreateStatus;

                    //    //Get custom fields for user  
                    //    var sreg = response.GetExtension<ClaimsResponse>();
                    //    if (sreg != null)
                    //        membershipCreateStatus = MembershipService.CreateUser(response.ClaimedIdentifier, "12345", sreg.Email);
                    //    else
                    //        membershipCreateStatus = MembershipService.CreateUser(response.ClaimedIdentifier, "12345", "john@doe.com");

                    //    if (membershipCreateStatus == MembershipCreateStatus.Success)
                    //    {
                    //        FormsService.SignIn(response.ClaimedIdentifier, false /* createPersistentCookie */);
                    //        return RedirectToAction("Index", "home");
                    //    }
                    //    ViewData["Message"] = "Error creating new user";
                    //    return View("LogOn");
                    //}

                    //FormsAuthentication.SetAuthCookie(user.UserName, false);
                    //if (!string.IsNullOrEmpty(returnUrl))
                    //{
                    //    return Redirect(returnUrl);
                    //}

                    return RedirectToAction("Index", "Home");
                case AuthenticationStatus.Canceled:
                    ViewData["Message"] = "Canceled at provider";
                    return View("GetUpOnIt");
                case AuthenticationStatus.Failed:
                    ViewData["Message"] = response.Exception.Message;
                    return View("GetUpOnIt");
            }

            return new EmptyResult();
        }  

    }
}
