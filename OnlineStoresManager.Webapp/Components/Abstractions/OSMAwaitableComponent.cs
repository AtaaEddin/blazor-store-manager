using System.Threading.Tasks;
using System;
using OnlineStoresManager.WebApp;
using OnlineStoresManager.WebApp.Components.SimpleDialog;
using MudBlazor;
using OnlineStoresManager.WebApp.Localization;

namespace OnlineStoresManager.WebApp
{
    public class OSMAwaitableComponent : OSMComponent
    {
        protected bool IsLoading { get; set; }

        protected async Task Await(Func<Task> action)
        {
            try
            {
                IsLoading = true;
                await InvokeAsync(StateHasChanged);
                await action();
            }
            catch (ServiceClientUnauthorizedException)
            {
                Navigator.NavigateToLogin();
            }
            catch (Exception ex)
            {
                var parameters = new DialogParameters<OSMSimpleDialog>
                {
                    { x => x.ContentText, ex.ToString() },
                    { x => x.ButtonText, Resource.Ok },
                    { x => x.Color, Color.Error }
                };

                DialogService.Show<OSMSimpleDialog>("Error", parameters);
            }
            finally
            {
                IsLoading = false;
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}
