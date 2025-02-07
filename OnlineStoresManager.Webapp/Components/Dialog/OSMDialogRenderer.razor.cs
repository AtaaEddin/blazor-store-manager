﻿using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;

namespace OnlineStoresManager.WebApp.Components.Dialog
{
    public partial class OSMDialogRenderer : OSMComponent
    {
        [Inject]
        protected OSMDialogService Service { get; set; } = null!;

        protected IDictionary<string, object>? DialogParameters;
        protected Type? DialogType;

        public OSMDialogRenderer()
        {
            Visible = false;
        }

        protected override void OnInitialized()
        {
            Service.OnClose = EventCallback.Factory.Create(this, Close);
            Service.OnShow = EventCallback.Factory.Create<OSMDialogShowEventArgs>(this, Show);
        }

        private void Close()
        {
           
            Visible = false;
            StateHasChanged();
        }

        private void Show(OSMDialogShowEventArgs args)
        {
            ShowDialog(args);
            StateHasChanged();
        }

        private void ShowDialog(OSMDialogShowEventArgs args)
        {
            DialogParameters = args.Parameters;
            DialogType = args.Type;
            var parameters = new DialogParameters();
            foreach( var parameter in DialogParameters )
            {
                parameters.Add(parameter.Key, parameter.Value);
            }
            var options = new DialogOptions
            {
                MaxWidth = MaxWidth.ExtraLarge,
                NoHeader = false,
            };
            Visible = true;
            DialogService.Show(DialogType, null, parameters, options);
        }

        protected override void Dispose(bool disposing)
        {
            Service.OnClose = EventCallback.Empty;
            Service.OnShow = EventCallback<OSMDialogShowEventArgs>.Empty;

            base.Dispose(disposing);
        }
    }
}
