using System.Collections.Generic;
using System;

namespace OnlineStoresManager.WebApp.Components.Dialog
{
    public class HyOPTDialogShowEventArgs : EventArgs
    {
        public IDictionary<string, object> Parameters { get; }
        public Type Type { get; }

        public HyOPTDialogShowEventArgs(Type type, IDictionary<string, object> parameters)
        {
            Parameters = parameters;
            Type = type;
        }
    }
}
