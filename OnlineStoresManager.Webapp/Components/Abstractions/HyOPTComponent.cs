using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using mudblazor.Abstractions;
using System.Threading.Tasks;
using System;

namespace OnlineStoresManager.WebApp
{ 
    public class OnlineStoresManagerComponent : ComponentBase, IDisposable
    {
        [Parameter]
        public string ComponentId { get; set; } = Guid.NewGuid().ToString("N");

        [Parameter]
        public bool Visible { get; set; } = true;

        [CascadingParameter]
        public DialogFactory DialogFactory { get; set; } = null!;

        [Inject]
        public OnlineStoresManagerDialogService DialogService { get; set; } = null!;

        [Inject]
        protected IJSRuntime Js { get; set; } = null!;

        [Inject]
        internal IStringLocalizer<Localization.Resource> Localizer { get; set; } = null!;

        [Inject]
        public NavigationManager Navigator { get; set; } = null!;

        protected IJSObjectReference? JsModule;

        protected async Task Download(FileBytes file)
        {
            try
            {
                await Js.DownloadFile(file);
            }
            catch (Exception ex)
            {
                await DialogFactory.AlertAsync(ex.ToString());
            }
        }

        protected async Task Download(string fileName, byte[] fileBytes)
        {
            try
            {
                await Js.DownloadFile(fileName, fileBytes);
            }
            catch (Exception ex)
            {
                await DialogFactory.AlertAsync(ex.ToString());
            }
        }

        protected async Task ImportJsFile(string jsFilePath)
        {
            JsModule = await Js.InvokeAsync<IJSObjectReference>("import", jsFilePath);
        }

        protected ValueTask InvokeJsMethod(string identifier, params object?[]? args)
        {
            return Js.InvokeVoidAsync(identifier, args);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async void Dispose(bool disposing)
        {
            if (disposing)
            {
                await (JsModule?.DisposeAsync() ?? ValueTask.CompletedTask);
            }
        }
    }
}
