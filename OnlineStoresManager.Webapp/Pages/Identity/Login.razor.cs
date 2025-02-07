﻿using OnlineStoresManager.Identity;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using MudBlazor;

namespace OnlineStoresManager.WebApp.Pages.Identity
{
    public partial class Login : OSMAwaitableComponent
    {
        [Inject]
        public LoginRequestValidator RequestValidator { get; set; } = null!;

        [Inject]
        public IdentityManager Manager { get; set; } = null!;

        [Parameter]
        [SupplyParameterFromQuery]
        public string? ReturnUrl { get; set; }

        protected LoginRequest? Request { get; set; }
        protected MudForm? FormRef;
        //protected EditContext? RequestContext { get; set; }

        protected override void OnInitialized()
        {
            Request = new LoginRequest();
            //RequestContext = new EditContext(Request);

            base.OnInitialized();
        }

        protected Task SubmitLogin()
        {
            return Await(async () =>
            {
                await FormRef!.Validate();
                if (!FormRef.IsValid)
                {
                    return;
                }

                bool success = await Manager.Login(Request!);
                if (success)
                {
                    Navigator.NavigateTo(string.IsNullOrEmpty(ReturnUrl) ? "/" : ReturnUrl);
                }
            });
        }
    }
}
