using Microsoft.AspNetCore.Components;
using OnlineStoresManager.WebApp.Components.Abstractions;
using System.Collections.Generic;
using System;

namespace OnlineStoresManager.WebApp
{
    public partial class OnlineStoresManagerDialogRenderer : OnlineStoresManagerComponent
    {
        [Inject]
        protected OnlineStoresManagerDialogService Service { get; set; } = null!;

        private readonly Stack<OnlineStoresManagerDialogShowEventArgs> _dialogStack;
        protected IDictionary<string, object>? DialogParameters;
        protected Type? DialogType;

        public OnlineStoresManagerDialogRenderer()
        {
            _dialogStack = new Stack<OnlineStoresManagerDialogShowEventArgs>();
            Visible = false;
        }

        protected override void OnInitialized()
        {
            Service.OnClose = EventCallback.Factory.Create(this, Close);
            Service.OnShow = EventCallback.Factory.Create<OnlineStoresManagerDialogShowEventArgs>(this, Show);
        }

        private void Close()
        {
            if (_dialogStack.Count >= 2)
            {
                _dialogStack.Pop();
                OnlineStoresManagerDialogShowEventArgs args = _dialogStack.Peek();
                ShowDialog(args);
            }
            else
            {
                _dialogStack.Clear();
                Visible = false;
            }

            StateHasChanged();
        }

        private void Show(OnlineStoresManagerDialogShowEventArgs args)
        {
            _dialogStack.Push(args);
            ShowDialog(args);
            StateHasChanged();
        }

        private void ShowDialog(OnlineStoresManagerDialogShowEventArgs args)
        {
            DialogParameters = args.Parameters;
            DialogType = args.Type;
            Visible = true;
        }

        protected override void Dispose(bool disposing)
        {
            Service.OnClose = EventCallback.Empty;
            Service.OnShow = EventCallback<OnlineStoresManagerDialogShowEventArgs>.Empty;

            base.Dispose(disposing);
        }
    }
}
