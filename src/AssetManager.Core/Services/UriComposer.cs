using AssetManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManager.Core.Services
{
    public class UriComposer : IUriComposer
    {
        private readonly ListSettings _listSettings;
        public UriComposer(ListSettings listSettings) => _listSettings = listSettings;
        public string ComposePicUri(string uriTemplate)
        {
            return uriTemplate.Replace("http://listbaseurltobereplaced", _listSettings.ListBaseUrl);
        }
    }
}
