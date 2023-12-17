using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using OnlineStoresManager.Abstractions;
using System.Threading.Tasks;

namespace OnlineStoresManager.WebApp.Components
{
    public partial class OSMGridTopBar : OSMComponent
    {
        [Parameter]
        public EventCallback OnCreate { get; set; }

        [Parameter]
        public EventCallback<FileType> OnExport { get; set; }

        [Parameter]
        public string SearchText { get; set; } = string.Empty;

        [Parameter]
        public EventCallback<string> SearchTextChanged { get; set; }

        [Parameter]
        public string? Title { get; set; }

        protected Task Export(FileType fileType)
        {
            return OnExport.InvokeAsync(fileType);
        }

        protected Task Create()
        {
            return OnCreate.InvokeAsync();
        }

        protected void OnSearchTextBoxKeyPress(KeyboardEventArgs args)
        {
            if (args.Key == KeyboardKeys.Enter)
            {
                SearchTextChanged.InvokeAsync(SearchText);
            }
        }
    }
}
