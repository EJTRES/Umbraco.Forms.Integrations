﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace Umbraco.Forms.Extensions.Crm.Hubspot
{
    [PluginController("FormsExtensions")]
    public class HubspotController : UmbracoAuthorizedJsonController
    {
        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// ~/Umbraco/[YourAreaName]/[YourControllerName]
        /// ~/Umbraco/FormsExtensions/Hubspot/GetAllProperties?apiKey=123
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public List<Property> GetAllProperties(string apiKey)
        {
            var properties = new List<Property>();
            var propertiesApiUrl = new Uri($"https://api.hubapi.com/crm/v3/properties/contacts?hapikey={apiKey}");

            // Map fields we have in settings to these fields/properties in Hubspot
            var propertiesResponse = client.GetAsync(propertiesApiUrl).Result;
            if (propertiesResponse.IsSuccessStatusCode == false)
            {
                // Log error
                Current.Logger.Error<HubspotWorkflow>("Failed to fetch contact properties from HubSpot API for mapping. {StatusCode} {ReasonPhrase}", propertiesResponse.StatusCode, propertiesResponse.ReasonPhrase);
            }

            // Map Properties back to our simplier object
            // Don't need all the fields in the response


            return properties;
        }

        public class Property
        {
            public string Name { get; set; }

            public string Label { get; set; }

            public string Description { get; set; }
        }
    }
}
