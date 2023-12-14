using System.Collections.Generic;
using System;

namespace OnlineStoresManager.WebApp.Components.Dialog
{
    public class OnlineStoresManagerDialogShowEventArgs : EventArgs
    {
        public IDictionary<string, object> Parameters { get; }
        public Type Type { get; }

        public OnlineStoresManagerDialogShowEventArgs(Type type, IDictionary<string, object> parameters)
        {
            Parameters = parameters;
            Type = type;
        }
    }
}
