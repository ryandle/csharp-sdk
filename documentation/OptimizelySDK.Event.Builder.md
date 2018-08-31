## `EventBuilder`

```csharp
public class OptimizelySDK.Event.Builder.EventBuilder

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Dictionary<String, Object>` | EventParams |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `LogEvent` | CreateConversionEvent(`ProjectConfig` config, `String` eventKey, `Dictionary<String, Variation>` experimentIdVariationMap, `String` userId, `UserAttributes` userAttributes, `EventTags` eventTags) |  | 
| `LogEvent` | CreateImpressionEvent(`ProjectConfig` config, `Experiment` experiment, `String` variationId, `String` userId, `UserAttributes` userAttributes) |  | 
| `void` | ResetParams() |  | 


## `Params`

```csharp
public static class OptimizelySDK.Event.Builder.Params

```

Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | ACCOUNT_ID |  | 
| `String` | ANONYMIZE_IP |  | 
| `String` | CAMPAIGN_ID |  | 
| `String` | CLIENT_ENGINE |  | 
| `String` | CLIENT_VERSION |  | 
| `String` | DECISIONS |  | 
| `String` | ENTITY_ID |  | 
| `String` | EVENT_FEATURES |  | 
| `String` | EVENT_ID |  | 
| `String` | EVENT_METRICS |  | 
| `String` | EVENT_NAME |  | 
| `String` | EVENTS |  | 
| `String` | EXPERIMENT_ID |  | 
| `String` | IS_LAYER_HOLDBACK |  | 
| `String` | PROJECT_ID |  | 
| `String` | REVISION |  | 
| `String` | TIME |  | 
| `String` | TIMESTAMP |  | 
| `String` | USER_FEATURES |  | 
| `String` | VARIATION_ID |  | 
| `String` | VISITOR_ID |  | 
| `String` | VISITORS |  | 


