﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Forms.Integrations.Crm.ActiveCampaign.Configuration;
using Umbraco.Forms.Integrations.Crm.ActiveCampaign.Models.Dtos;
using Umbraco.Forms.Integrations.Crm.ActiveCampaign.Services;

namespace Umbraco.Forms.Integrations.Crm.ActiveCampaign.Api.Management.Controllers.Contacts
{
    [Authorize(Policy = AuthorizationPolicies.BackOfficeAccess)]
    public class GetCustomFieldsController : ContactControllerBase
    {
        public GetCustomFieldsController(IOptions<ActiveCampaignSettings> options, IContactService contactService) : base(options, contactService)
        {
        }

        [HttpGet("custom")]
        [ProducesResponseType(typeof(CustomFieldCollectionResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomFields() =>
            Ok(await _contactService.GetCustomFields().ConfigureAwait(false));
    }
}
