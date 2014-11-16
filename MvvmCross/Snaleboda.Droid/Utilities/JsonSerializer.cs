using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Snaleboda.Library.Interfaces;
using Newtonsoft.Json;

namespace Snaleboda.Droid.Utilities
{
    public class JsonSerializer : ISerializer
    {
        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public string Serialize(object content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}