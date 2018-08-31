## `Bucketer`

```csharp
public class OptimizelySDK.Bucketing.Bucketer

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Variation` | Bucket(`ProjectConfig` config, `Experiment` experiment, `String` bucketingId, `String` userId) |  | 
| `Int32` | GenerateBucketValue(`String` bucketingKey) |  | 


## `Decision`

```csharp
public class OptimizelySDK.Bucketing.Decision

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | VariationId |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Dictionary<String, String>` | ToMap() |  | 


## `DecisionService`

```csharp
public class OptimizelySDK.Bucketing.DecisionService

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Variation` | GetStoredVariation(`Experiment` experiment, `UserProfile` userProfile) |  | 
| `Variation` | GetVariation(`Experiment` experiment, `String` userId, `UserAttributes` filteredAttributes) |  | 
| `FeatureDecision` | GetVariationForFeature(`FeatureFlag` featureFlag, `String` userId, `UserAttributes` filteredAttributes) |  | 
| `FeatureDecision` | GetVariationForFeatureExperiment(`FeatureFlag` featureFlag, `String` userId, `UserAttributes` filteredAttributes) |  | 
| `FeatureDecision` | GetVariationForFeatureRollout(`FeatureFlag` featureFlag, `String` userId, `UserAttributes` filteredAttributes) |  | 
| `Variation` | GetWhitelistedVariation(`Experiment` experiment, `String` userId) |  | 
| `void` | SaveVariation(`Experiment` experiment, `Variation` variation, `UserProfile` userProfile) |  | 


## `UserProfile`

```csharp
public class OptimizelySDK.Bucketing.UserProfile

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Dictionary<String, Decision>` | ExperimentBucketMap |  | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | UserId |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Dictionary<String, Object>` | ToMap() |  | 


Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | EXPERIMENT_BUCKET_MAP_KEY |  | 
| `String` | USER_ID_KEY |  | 
| `String` | VARIATION_ID_KEY |  | 


## `UserProfileService`

```csharp
public interface OptimizelySDK.Bucketing.UserProfileService

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Dictionary<String, Object>` | Lookup(`String` userId) |  | 
| `void` | Save(`Dictionary<String, Object>` userProfile) |  | 


## `UserProfileUtil`

```csharp
public class OptimizelySDK.Bucketing.UserProfileUtil

```

Static Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `UserProfile` | ConvertMapToUserProfile(`Dictionary<String, Object>` map) |  | 
| `Boolean` | IsValidUserProfileMap(`Dictionary<String, Object>` map) |  | 


