## `IOptimizely`

```csharp
public interface OptimizelySDK.IOptimizely

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsValid |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Variation` | Activate(`String` experimentKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `List<String>` | GetEnabledFeatures(`String` userId, `UserAttributes` userAttributes = null) |  | 
| `Nullable<Boolean>` | GetFeatureVariableBoolean(`String` featureKey, `String` variableKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `Nullable<Double>` | GetFeatureVariableDouble(`String` featureKey, `String` variableKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `Nullable<Int32>` | GetFeatureVariableInteger(`String` featureKey, `String` variableKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `String` | GetFeatureVariableString(`String` featureKey, `String` variableKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `Variation` | GetForcedVariation(`String` experimentKey, `String` userId) |  | 
| `Variation` | GetVariation(`String` experimentKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `Boolean` | IsFeatureEnabled(`String` featureKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `Boolean` | SetForcedVariation(`String` experimentKey, `String` userId, `String` variationKey) |  | 
| `void` | Track(`String` eventKey, `String` userId, `UserAttributes` userAttributes = null, `EventTags` eventTags = null) |  | 


## `Optimizely`

```csharp
public class OptimizelySDK.Optimizely
    : IOptimizely

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `NotificationCenter` | NotificationCenter |  | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsValid |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Variation` | Activate(`String` experimentKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `List<String>` | GetEnabledFeatures(`String` userId, `UserAttributes` userAttributes = null) |  | 
| `Nullable<Boolean>` | GetFeatureVariableBoolean(`String` featureKey, `String` variableKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `Nullable<Double>` | GetFeatureVariableDouble(`String` featureKey, `String` variableKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `Nullable<Int32>` | GetFeatureVariableInteger(`String` featureKey, `String` variableKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `String` | GetFeatureVariableString(`String` featureKey, `String` variableKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `String` | GetFeatureVariableValueForType(`String` featureKey, `String` variableKey, `String` userId, `UserAttributes` userAttributes, `VariableType` variableType) |  | 
| `Variation` | GetForcedVariation(`String` experimentKey, `String` userId) |  | 
| `Variation` | GetVariation(`String` experimentKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `Boolean` | IsFeatureEnabled(`String` featureKey, `String` userId, `UserAttributes` userAttributes = null) |  | 
| `Boolean` | SetForcedVariation(`String` experimentKey, `String` userId, `String` variationKey) |  | 
| `void` | Track(`String` eventKey, `String` userId, `UserAttributes` userAttributes = null, `EventTags` eventTags = null) |  | 


Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | EVENT_KEY |  | 
| `String` | EXPERIMENT_KEY |  | 
| `String` | USER_ID |  | 


Static Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | SDK_TYPE |  | 
| `String` | SDK_VERSION |  | 


## `ProjectConfig`

```csharp
public class OptimizelySDK.ProjectConfig

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | AccountId |  | 
| `Boolean` | AnonymizeIP |  | 
| `Dictionary<String, Attribute>` | AttributeKeyMap |  | 
| `Attribute[]` | Attributes |  | 
| `Dictionary<String, Audience>` | AudienceIdMap |  | 
| `Audience[]` | Audiences |  | 
| `Nullable<Boolean>` | BotFiltering |  | 
| `IErrorHandler` | ErrorHandler |  | 
| `Dictionary<String, Event>` | EventKeyMap |  | 
| `Event[]` | Events |  | 
| `Dictionary<String, Experiment>` | ExperimentIdMap |  | 
| `Dictionary<String, Experiment>` | ExperimentKeyMap |  | 
| `Experiment[]` | Experiments |  | 
| `FeatureFlag[]` | FeatureFlags |  | 
| `Dictionary<String, FeatureFlag>` | FeatureKeyMap |  | 
| `Dictionary<String, Dictionary<String, String>>` | ForcedVariationMap |  | 
| `Dictionary<String, Group>` | GroupIdMap |  | 
| `Group[]` | Groups |  | 
| `ILogger` | Logger |  | 
| `String` | ProjectId |  | 
| `String` | Revision |  | 
| `Dictionary<String, Rollout>` | RolloutIdMap |  | 
| `Rollout[]` | Rollouts |  | 
| `Dictionary<String, Dictionary<String, Variation>>` | VariationIdMap |  | 
| `Dictionary<String, Dictionary<String, Variation>>` | VariationKeyMap |  | 
| `String` | Version |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Attribute` | GetAttribute(`String` attributeKey) |  | 
| `String` | GetAttributeId(`String` attributeKey) |  | 
| `Audience` | GetAudience(`String` audienceId) |  | 
| `Event` | GetEvent(`String` eventKey) |  | 
| `Experiment` | GetExperimentFromId(`String` experimentId) |  | 
| `Experiment` | GetExperimentFromKey(`String` experimentKey) |  | 
| `FeatureFlag` | GetFeatureFlagFromKey(`String` featureKey) |  | 
| `Variation` | GetForcedVariation(`String` experimentKey, `String` userId) |  | 
| `Group` | GetGroup(`String` groupId) |  | 
| `Rollout` | GetRolloutFromId(`String` rolloutId) |  | 
| `Variation` | GetVariationFromId(`String` experimentKey, `String` variationId) |  | 
| `Variation` | GetVariationFromKey(`String` experimentKey, `String` variationKey) |  | 
| `Boolean` | SetForcedVariation(`String` experimentKey, `String` userId, `String` variationKey) |  | 


Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | RESERVED_ATTRIBUTE_PREFIX |  | 


Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `ProjectConfig` | Create(`String` content, `ILogger` logger, `IErrorHandler` errorHandler) |  | 


