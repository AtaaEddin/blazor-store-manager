using System.Threading.Tasks;
using System;

namespace OnlineStoresManager.WebApp
{
    public class HyOPTAwaitableComponent : HyOPTComponent
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
                await DialogFactory.AlertAsync(ex.ToString());
            }
            finally
            {
                IsLoading = false;
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}
