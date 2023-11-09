﻿using Newtonsoft.Json;

namespace Umbraco.Forms.Integrations.Automation.Zapier.Models.Dtos;

public class SubscriptionDto
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("entityId")]
    public string EntityId { get; set; }

    [JsonProperty("type")]
    public int Type { get; set; }

    [JsonProperty("typeName")] public string TypeName => nameof(Constants.EntityType.Form);
    
    [JsonProperty("hookUrl")]
    public string HookUrl { get; set; }

    [JsonProperty("subscribeHook")]
    public bool SubscribeHook { get; set; }
}
