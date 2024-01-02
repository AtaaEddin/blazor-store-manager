using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using System;
using OnlineStoresManager.WebApp.Components.Dialog;
using OnlineStoresManager.Abstractions;
using MudBlazor;
using OnlineStoresManager.WebApp.Components.SimpleDialog;
using OnlineStoresManager.WebApp.Localization;

namespace OnlineStoresManager.WebApp
{ 
    public class OSMComponent : ComponentBase, IDisposable
    {
        [Parameter]
        public string ComponentId { get; set; } = Guid.NewGuid().ToString("N");

        [Parameter]
        public bool Visible { get; set; } = true;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        [Inject]
        public OSMDialogService OSMDialogService { get; set; } = null!;

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
                var parameters = new DialogParameters<OSMSimpleDialog>
                {
                    { x => x.ContentText, ex.ToString() },
                    { x => x.ButtonText, Resource.Ok },
                    { x => x.Color, Color.Error }
                };

                DialogService.Show<OSMSimpleDialog>("Error", parameters);
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
                var parameters = new DialogParameters<OSMSimpleDialog>
                {
                    { x => x.ContentText, ex.ToString() },
                    { x => x.ButtonText, Resource.Ok },
                    { x => x.Color, Color.Error }
                };

                DialogService.Show<OSMSimpleDialog>("Error", parameters);
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

        protected async Task<bool> ShowDeleteConfimationDialog(string ContentText)
        {
            var parameters = new DialogParameters<OSMSimpleDialog>
                {
                    { x => x.ContentText, ContentText },
                    { x => x.ButtonText, Resource.Yes },
                    { x => x.Color, Color.Error }
                };

            var dialog = await DialogService.ShowAsync<OSMSimpleDialog>("Error", parameters);
            var result = await dialog.Result;

            if (!result.Canceled)
            {
                bool.TryParse(result.Data.ToString(), out bool deleteConfirmed);
                return deleteConfirmed;
            }

            return false;
        }
    }
}
