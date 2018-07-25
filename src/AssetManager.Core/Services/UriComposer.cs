using AssetManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManager.Core.Services
{
    public class UriComposer : IUriComposer
    {
        private readonly CatalogSettings _catalogSettings;
        public UriComposer(CatalogSettings catalogSettings) => _catalogSettings = catalogSettings;
        public string ComposePicUri(string uriTemplate)
        {
            return uriTemplate.Replace("http://catalogbaseurltobereplaced", _catalogSettings.CatalogBaseUrl);
        }
    }
}
