using OnlineStoresManager.Abstractions;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace OnlineStoresManager.Web.App.Components
{
    public partial class OnlineStoresManagerGridTopBar : OnlineStoresManagerComponent
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

        protected void OnSearchTextBoxKeyPress(KeyboardEventArgs args)
        {
            if (args.Key == KeyboardKeys.Enter)
            {
                SearchTextChanged.InvokeAsync(SearchText);
            }
        }
    }
}
