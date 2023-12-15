using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System;

namespace OnlineStoresManager.WebApp.Components.Dialog
{
    public partial class OSMDialogRenderer : OSMComponent
    {
        [Inject]
        protected OSMDialogService Service { get; set; } = null!;

        private readonly Stack<OSMDialogShowEventArgs> _dialogStack;
        protected IDictionary<string, object>? DialogParameters;
        protected Type? DialogType;

        public OSMDialogRenderer()
        {
            _dialogStack = new Stack<OSMDialogShowEventArgs>();
            Visible = false;
        }

        protected override void OnInitialized()
        {
            Service.OnClose = EventCallback.Factory.Create(this, Close);
            Service.OnShow = EventCallback.Factory.Create<OSMDialogShowEventArgs>(this, Show);
        }

        private void Close()
        {
            if (_dialogStack.Count >= 2)
            {
                _dialogStack.Pop();
                OSMDialogShowEventArgs args = _dialogStack.Peek();
                ShowDialog(args);
            }
            else
            {
                _dialogStack.Clear();
                Visible = false;
            }

            StateHasChanged();
        }

        private void Show(OSMDialogShowEventArgs args)
        {
            _dialogStack.Push(args);
            ShowDialog(args);
            StateHasChanged();
        }

        private void ShowDialog(OSMDialogShowEventArgs args)
        {
            DialogParameters = args.Parameters;
            DialogType = args.Type;
            Visible = true;
        }

        protected override void Dispose(bool disposing)
        {
            Service.OnClose = EventCallback.Empty;
            Service.OnShow = EventCallback<OSMDialogShowEventArgs>.Empty;

            base.Dispose(disposing);
        }
    }
}
