using System.Collections.Generic;
using System;

namespace OnlineStoresManager.WebApp.Components.Dialog
{
    public class OSMDialogShowEventArgs : EventArgs
    {
        public IDictionary<string, object> Parameters { get; }
        public Type Type { get; }

        public OSMDialogShowEventArgs(Type type, IDictionary<string, object> parameters)
        {
            Parameters = parameters;
            Type = type;
        }
    }
}
