using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Components.Dialog
{
    public class HyOPTDialogService
    {
        internal EventCallback OnClose;
        internal EventCallback<HyOPTDialogShowEventArgs> OnShow;

        public Task Close()
        {
            return OnClose.InvokeAsync();
        }

        public Task Show<TComponent>(IDictionary<string, object> parameters)
            where TComponent : HyOPTComponent
        {
            HyOPTDialogShowEventArgs args = new HyOPTDialogShowEventArgs(typeof(TComponent), parameters);

            return OnShow.InvokeAsync(args);
        }
    }
}
