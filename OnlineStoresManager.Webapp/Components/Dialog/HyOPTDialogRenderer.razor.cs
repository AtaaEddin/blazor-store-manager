using Microsoft.AspNetCore.Components;
using OnlineStoresManager.WebApp.Components.Abstractions;
using System.Collections.Generic;
using System;

namespace OnlineStoresManager.WebApp
{
    public partial class HyOPTDialogRenderer : HyOPTComponent
    {
        [Inject]
        protected HyOPTDialogService Service { get; set; } = null!;

        private readonly Stack<HyOPTDialogShowEventArgs> _dialogStack;
        protected IDictionary<string, object>? DialogParameters;
        protected Type? DialogType;

        public HyOPTDialogRenderer()
        {
            _dialogStack = new Stack<HyOPTDialogShowEventArgs>();
            Visible = false;
        }

        protected override void OnInitialized()
        {
            Service.OnClose = EventCallback.Factory.Create(this, Close);
            Service.OnShow = EventCallback.Factory.Create<HyOPTDialogShowEventArgs>(this, Show);
        }

        private void Close()
        {
            if (_dialogStack.Count >= 2)
            {
                _dialogStack.Pop();
                HyOPTDialogShowEventArgs args = _dialogStack.Peek();
                ShowDialog(args);
            }
            else
            {
                _dialogStack.Clear();
                Visible = false;
            }

            StateHasChanged();
        }

        private void Show(HyOPTDialogShowEventArgs args)
        {
            _dialogStack.Push(args);
            ShowDialog(args);
            StateHasChanged();
        }

        private void ShowDialog(HyOPTDialogShowEventArgs args)
        {
            DialogParameters = args.Parameters;
            DialogType = args.Type;
            Visible = true;
        }

        protected override void Dispose(bool disposing)
        {
            Service.OnClose = EventCallback.Empty;
            Service.OnShow = EventCallback<HyOPTDialogShowEventArgs>.Empty;

            base.Dispose(disposing);
        }
    }
}
