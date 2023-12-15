using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Components.Dialog
{
    public class OSMDialogService
    {
        internal EventCallback OnClose;
        internal EventCallback<OSMDialogShowEventArgs> OnShow;

        public Task Close()
        {
            return OnClose.InvokeAsync();
        }

        public Task Show<TComponent>(IDictionary<string, object> parameters)
            where TComponent : OSMComponent
        {
            OSMDialogShowEventArgs args = new OSMDialogShowEventArgs(typeof(TComponent), parameters);

            return OnShow.InvokeAsync(args);
        }
    }
}
