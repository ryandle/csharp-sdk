## `ConditionEvaluator`

```csharp
public class OptimizelySDK.Utils.ConditionEvaluator

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Evaluate(`JToken` conditions, `UserAttributes` userAttributes) |  | 
| `Boolean` | Evaluate(`Object[]` conditions, `UserAttributes` userAttributes) |  | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `JToken` | DecodeConditions(`String` conditions) |  | 


## `ConfigParser<T>`

```csharp
public static class OptimizelySDK.Utils.ConfigParser<T>

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Dictionary<String, T>` | GenerateMap(`IEnumerable<T>` entities, `Func<T, String>` getKey, `Boolean` clone) |  | 


## `ControlAttributes`

```csharp
public class OptimizelySDK.Utils.ControlAttributes

```

Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | BOT_FILTERING_ATTRIBUTE |  | 
| `String` | BUCKETING_ID_ATTRIBUTE |  | 
| `String` | USER_AGENT_ATTRIBUTE |  | 


## `EventTagUtils`

```csharp
public class OptimizelySDK.Utils.EventTagUtils

```

Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | REVENUE_EVENT_METRIC_NAME |  | 
| `String` | VALUE_EVENT_METRIC_NAME |  | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | GetNumericValue(`Dictionary<String, Object>` eventTags, `ILogger` logger = null) |  | 
| `Object` | GetRevenueValue(`Dictionary<String, Object>` eventTags, `ILogger` logger) |  | 


## `ExperimentUtils`

```csharp
public class OptimizelySDK.Utils.ExperimentUtils

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsExperimentActive(`Experiment` experiment, `ILogger` logger) |  | 
| `Boolean` | IsUserInExperiment(`ProjectConfig` config, `Experiment` experiment, `UserAttributes` userAttributes) |  | 


## `Validator`

```csharp
public static class OptimizelySDK.Utils.Validator

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | AreAttributesValid(`IEnumerable<Attribute>` attributes) |  | 
| `Boolean` | AreEventTagsValid(`Dictionary<String, Object>` eventTags) |  | 
| `Boolean` | IsAttributeValid(`Attribute` attribute) |  | 
| `Boolean` | IsFeatureFlagValid(`ProjectConfig` projectConfig, `FeatureFlag` featureFlag) |  | 
| `Boolean` | ValidateJSONSchema(`String` configJson, `String` schemaJson = null) |  | 


