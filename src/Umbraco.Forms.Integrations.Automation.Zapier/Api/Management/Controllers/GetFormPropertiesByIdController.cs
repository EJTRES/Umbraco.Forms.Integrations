﻿using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Forms.Integrations.Automation.Zapier.Extensions;
using Umbraco.Forms.Integrations.Automation.Zapier.Services;

namespace Umbraco.Forms.Integrations.Automation.Zapier.Api.Management.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = Constants.ManagementApi.GroupName)]
    public class GetFormPropertiesByIdController : FormsControllerBase
    {
        public GetFormPropertiesByIdController(IUserValidationService userValidationService, ZapierFormService zapierFormService) 
            : base(userValidationService, zapierFormService)
        {
        }

        [HttpGet("forms/{id}")]
        [ProducesResponseType(typeof(List<Dictionary<string, string>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetFormPropertiesById(string id)
        {
            var emptyList = new List<Dictionary<string, string>>();

            if (!IsAccessValid())
                return Unauthorized();

            var form = ZapierFormService.GetById(id);

            if (form == null) return Ok(emptyList);

            return Ok(new List<Dictionary<string, string>> { form.ToEmptyFormDictionary() });
        }
    }
}
