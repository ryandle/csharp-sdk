## `Attribute`

```csharp
public class OptimizelySDK.Entity.Attribute
    : IdKeyEntity, ICloneable, IEquatable<Object>

```

## `Audience`

```csharp
public class OptimizelySDK.Entity.Audience
    : Entity, ICloneable

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `JToken` | ConditionList |  | 
| `String` | Conditions |  | 
| `String` | Id |  | 
| `String` | Name |  | 


## `Entity`

```csharp
public abstract class OptimizelySDK.Entity.Entity
    : ICloneable

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Object` | Clone() |  | 


## `Event`

```csharp
public class OptimizelySDK.Entity.Event
    : IdKeyEntity, ICloneable, IEquatable<Object>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String[]` | ExperimentIds |  | 


## `EventTags`

```csharp
public class OptimizelySDK.Entity.EventTags
    : Dictionary<String, Object>, IDictionary<String, Object>, ICollection<KeyValuePair<String, Object>>, IEnumerable<KeyValuePair<String, Object>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<String, Object>, IReadOnlyCollection<KeyValuePair<String, Object>>, ISerializable, IDeserializationCallback

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `EventTags` | FilterNullValues(`ILogger` logger) |  | 


## `Experiment`

```csharp
public class OptimizelySDK.Entity.Experiment
    : IdKeyEntity, ICloneable, IEquatable<Object>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String[]` | AudienceIds |  | 
| `Dictionary<String, String>` | ForcedVariations |  | 
| `String` | GroupId |  | 
| `String` | GroupPolicy |  | 
| `Boolean` | IsExperimentRunning |  | 
| `Boolean` | IsInMutexGroup |  | 
| `String` | LayerId |  | 
| `String` | Status |  | 
| `TrafficAllocation[]` | TrafficAllocation |  | 
| `Dictionary<String, String>` | UserIdToKeyVariations |  | 
| `Dictionary<String, Variation>` | VariationIdToVariationMap |  | 
| `Dictionary<String, Variation>` | VariationKeyToVariationMap |  | 
| `Variation[]` | Variations |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | GenerateVariationKeyMap() |  | 
| `Boolean` | IsUserInForcedVariation(`String` userId) |  | 


## `FeatureDecision`

```csharp
public class OptimizelySDK.Entity.FeatureDecision

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Experiment` | Experiment |  | 
| `String` | Source |  | 
| `Variation` | Variation |  | 


Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | DECISION_SOURCE_EXPERIMENT |  | 
| `String` | DECISION_SOURCE_ROLLOUT |  | 


## `FeatureFlag`

```csharp
public class OptimizelySDK.Entity.FeatureFlag
    : IdKeyEntity, ICloneable, IEquatable<Object>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `List<String>` | ExperimentIds |  | 
| `String` | RolloutId |  | 
| `Dictionary<String, FeatureVariable>` | VariableKeyToFeatureVariableMap |  | 
| `List<FeatureVariable>` | Variables |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `FeatureVariable` | GetFeatureVariableFromKey(`String` variableKey) |  | 


## `FeatureVariable`

```csharp
public class OptimizelySDK.Entity.FeatureVariable
    : IdKeyEntity, ICloneable, IEquatable<Object>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | DefaultValue |  | 
| `VariableStatus` | Status |  | 
| `VariableType` | Type |  | 


## `FeatureVariableUsage`

```csharp
public class OptimizelySDK.Entity.FeatureVariableUsage
    : Entity, ICloneable

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Id |  | 
| `String` | Value |  | 


## `ForcedVariation`

```csharp
public class OptimizelySDK.Entity.ForcedVariation
    : IdKeyEntity, ICloneable, IEquatable<Object>

```

## `Group`

```csharp
public class OptimizelySDK.Entity.Group
    : Entity, ICloneable

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Experiment[]` | Experiments |  | 
| `String` | Id |  | 
| `String` | Policy |  | 
| `TrafficAllocation[]` | TrafficAllocation |  | 


## `IdKeyEntity`

```csharp
public abstract class OptimizelySDK.Entity.IdKeyEntity
    : Entity, ICloneable, IEquatable<Object>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `String` | Id |  | 
| `String` | Key |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | Equals(`Object` other) |  | 
| `Int32` | GetHashCode() |  | 


## `Rollout`

```csharp
public class OptimizelySDK.Entity.Rollout
    : IdKeyEntity, ICloneable, IEquatable<Object>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `List<Experiment>` | Experiments |  | 


## `TrafficAllocation`

```csharp
public class OptimizelySDK.Entity.TrafficAllocation
    : Entity, ICloneable

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | EndOfRange |  | 
| `String` | EntityId |  | 


## `UserAttributes`

```csharp
public class OptimizelySDK.Entity.UserAttributes
    : Dictionary<String, String>, IDictionary<String, String>, ICollection<KeyValuePair<String, String>>, IEnumerable<KeyValuePair<String, String>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<String, String>, IReadOnlyCollection<KeyValuePair<String, String>>, ISerializable, IDeserializationCallback

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `UserAttributes` | FilterNullValues(`ILogger` logger) |  | 


## `Variation`

```csharp
public class OptimizelySDK.Entity.Variation
    : IdKeyEntity, ICloneable, IEquatable<Object>

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Nullable<Boolean>` | FeatureEnabled |  | 
| `List<FeatureVariableUsage>` | FeatureVariableUsageInstances |  | 
| `Boolean` | IsFeatureEnabled |  | 
| `Dictionary<String, FeatureVariableUsage>` | VariableIdToVariableUsageInstanceMap |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `FeatureVariableUsage` | GetFeatureVariableUsageFromId(`String` variableId) |  | 


