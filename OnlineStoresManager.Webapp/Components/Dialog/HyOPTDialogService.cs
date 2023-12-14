using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Components.Dialog
{
    public class OnlineStoresManagerDialogService
    {
        internal EventCallback OnClose;
        internal EventCallback<OnlineStoresManagerDialogShowEventArgs> OnShow;

        public Task Close()
        {
            return OnClose.InvokeAsync();
        }

        public Task Show<TComponent>(IDictionary<string, object> parameters)
            where TComponent : OnlineStoresManagerComponent
        {
            OnlineStoresManagerDialogShowEventArgs args = new OnlineStoresManagerDialogShowEventArgs(typeof(TComponent), parameters);

            return OnShow.InvokeAsync(args);
        }
    }
}
