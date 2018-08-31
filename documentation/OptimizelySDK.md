# OptimizelySDK #

#### Field Bucketing.Bucketer.HASH_SEED

 Seed to be used in bucketing hash 



---
#### Field Bucketing.Bucketer.MAX_TRAFFIC_VALUE

 Maximum traffic allocation value 



---
#### Field Bucketing.Bucketer.MAX_HASH_VALUE

 Maximum possible hash value 



---
#### Method Bucketing.Bucketer.GenerateHashCode(System.String)

 Generate a hash value to be used in determining which variation the user will be put in 

|Name | Description |
|-----|------|
|bucketingKey: |string value used for the key of the murmur hash.|
**Returns**: integer Unsigned value denoting the hash value for the user



---
#### Method Bucketing.Bucketer.GenerateBucketValue(System.String)

 Generate an integer to be used in bucketing user to a particular variation 

|Name | Description |
|-----|------|
|bucketingKey: |string Value used for the key of the murmur hash.|
**Returns**: integer Value in the closed range [0, 9999] denoting the bucket the user belongs to



---
#### Method Bucketing.Bucketer.FindBucket(System.String,System.String,System.String,System.Collections.Generic.IEnumerable{OptimizelySDK.Entity.TrafficAllocation})

 Find the bucket for the user and group/experiment given traffic allocations 

|Name | Description |
|-----|------|
|bucketingId: |A customer-assigned value used to create the key for the murmur hash.|
|userId: |string ID for user|
|parentId: |mixed ID representing Experiment or Group|
|trafficAllocations: |array Traffic allocations for variation or experiment|
**Returns**: string ID representing experiment or variation, returns null if not found



---
#### Method Bucketing.Bucketer.Bucket(OptimizelySDK.ProjectConfig,OptimizelySDK.Entity.Experiment,System.String,System.String)

 Determine variation the user should be put in. 

|Name | Description |
|-----|------|
|config: |ProjectConfig Configuration for the project|
|experiment: |Experiment Experiment in which user is to be bucketed|
|bucketingId: |A customer-assigned value used to create the key for the murmur hash.|
|userId: |User identifier|
**Returns**: Variation which will be shown to the user



---
#### Property Bucketing.Decision.VariationId

 The ID of the Variation into which the user was bucketed. 



---
#### Method Bucketing.Decision.#ctor(System.String)

 Initialize a Decision object. 

|Name | Description |
|-----|------|
|variationId: |The ID of the variation into which the user was bucketed.|


---
#### Field Bucketing.UserProfile.USER_ID_KEY

 The key for the user ID. Returns a String. 



---
#### Field Bucketing.UserProfile.VARIATION_ID_KEY

 The key for the variation Id within a decision Map. 

---
#### Property Bucketing.UserProfile.UserId

 A user's ID. 



---
#### Field Bucketing.UserProfile.ExperimentBucketMap

 Map ExperimentId to Decision for the User. 



---
#### Method Bucketing.UserProfile.#ctor(System.String,System.Collections.Generic.Dictionary{System.String,OptimizelySDK.Bucketing.Decision})

 Construct a User Profile instance from explicit components. 

|Name | Description |
|-----|------|
|userId: |The ID of the user.|
|experimentBucketMap: |The bucketing experimentBucketMap of the user.|


---
#### Method Bucketing.UserProfile.ToMap

 Convert a User Profile instance to a Map. 

**Returns**: A map representation of the user profile instance.



---
#### Method Bucketing.UserProfileUtil.ConvertMapToUserProfile(System.Collections.Generic.Dictionary{System.String,System.Object})

 Convert a Map to a UserProfile instance. 

|Name | Description |
|-----|------|
|map: |The map to construct the UserProfile|
**Returns**: A UserProfile instance.



---
## Type Bucketing.UserProfileService

 Class encapsulating user profile service functionality. Override with your own implementation for storing and retrieving the user profile. 



---
## Type Bucketing.DecisionService

 Optimizely's decision service that determines which variation of an experiment the user will be allocated to. The decision service contains all logic around how a user decision is made. This includes the following: 1. Checking experiment status 2. Checking whitelisting 3. Checking sticky bucketing 4. Checking audience targeting 5. Using Murmurhash3 to bucket the user. 



---
#### Method Bucketing.DecisionService.GetWhitelistedVariation(OptimizelySDK.Entity.Experiment,System.String)

 Get the variation the user has been whitelisted into. 

|Name | Description |
|-----|------|
|experiment: |in which user is to be bucketed.|
|userId: | User Identifier|
**Returns**: if the user is not whitelisted into any variation {@link Variation} the user is bucketed into if the user has a specified whitelisted variation.



---
#### Method Bucketing.DecisionService.GetStoredVariation(OptimizelySDK.Entity.Experiment,OptimizelySDK.Bucketing.UserProfile)

 Get the { @link Variation } that has been stored for the user in the { @link UserProfileService } implementation. 

|Name | Description |
|-----|------|
|experiment: | which the user was bucketed|
|userProfile: | User profile of the user|
**Returns**: The user was previously bucketed into.



---
#### Method Bucketing.DecisionService.SaveVariation(OptimizelySDK.Entity.Experiment,OptimizelySDK.Entity.Variation,OptimizelySDK.Bucketing.UserProfile)

 Save a { @link Variation } of an { @link Experiment } for a user in the {@link UserProfileService}. 

|Name | Description |
|-----|------|
|experiment: | The experiment the user was buck|
|variation: | The Variation to save.|
|userProfile: | instance of the user information.|


---
#### Method Bucketing.DecisionService.GetVariationForFeatureRollout(OptimizelySDK.Entity.FeatureFlag,System.String,OptimizelySDK.Entity.UserAttributes)

 Try to bucket the user into a rollout rule. Evaluate the user for rules in priority order by seeing if the user satisfies the audience. Fall back onto the everyone else rule if the user is ever excluded from a rule due to traffic allocation. 

|Name | Description |
|-----|------|
|featureFlag: |The feature flag the user wants to access.|
|userId: |User Identifier|
|filteredAttributes: |The user's attributes. This should be filtered to just attributes in the Datafile.|
**Returns**: null if the user is not bucketed into the rollout or if the feature flag was not attached to a rollout. otherwise the FeatureDecision entity



---
#### Method Bucketing.DecisionService.GetVariationForFeatureExperiment(OptimizelySDK.Entity.FeatureFlag,System.String,OptimizelySDK.Entity.UserAttributes)

 Get the variation if the user is bucketed for one of the experiments on this feature flag. 

|Name | Description |
|-----|------|
|featureFlag: |The feature flag the user wants to access.|
|userId: |User Identifier|
|filteredAttributes: |The user's attributes. This should be filtered to just attributes in the Datafile.|
**Returns**: null if the user is not bucketed into the rollout or if the feature flag was not attached to a rollout. Otherwise the FeatureDecision entity



---
#### Method Bucketing.DecisionService.GetVariationForFeature(OptimizelySDK.Entity.FeatureFlag,System.String,OptimizelySDK.Entity.UserAttributes)

 Get the variation the user is bucketed into for the FeatureFlag 

|Name | Description |
|-----|------|
|featureFlag: |The feature flag the user wants to access.|
|userId: |User Identifier|
|filteredAttributes: |The user's attributes. This should be filtered to just attributes in the Datafile.|
**Returns**: null if the user is not bucketed into any variation or the FeatureDecision entity if the user is successfully bucketed.



---
#### Method Bucketing.DecisionService.GetBucketingId(System.String,OptimizelySDK.Entity.UserAttributes)

 Get Bucketing ID from user attributes. 

|Name | Description |
|-----|------|
|userId: |User Identifier|
|filteredAttributes: |The user's attributes.|
**Returns**: User ID if bucketing Id is not provided in user attributes, bucketing Id otherwise.



---
#### Property Entity.Audience.Id

 Audience ID 



---
#### Property Entity.Audience.Name

 Audience Name 



---
#### Property Entity.Audience.Conditions

 Audience Conditions 



---
#### Property Entity.Audience.ConditionList

 De-serialized audience conditions 



---
#### Property Entity.Event.ExperimentIds

 Associated Experiment with this Event 



---
#### Property Entity.Experiment.Status

 Experiment Status 



---
#### Property Entity.Experiment.LayerId

 Layer ID for the experiment 



---
#### Property Entity.Experiment.GroupId

 Group ID for the experiment 



---
#### Property Entity.Experiment.Variations

 Variations for the experiment 



---
#### Property Entity.Experiment.ForcedVariations

 ForcedVariations for the experiment 



---
#### Property Entity.Experiment.UserIdToKeyVariations

 ForcedVariations for the experiment 



---
#### Property Entity.Experiment.GroupPolicy

 Policy of the experiment group 



---
#### Property Entity.Experiment.AudienceIds

 ID(s) of audience(s) the experiment is targeted to 



---
#### Property Entity.Experiment.TrafficAllocation

 Traffic allocation of variations in the experiment 



---
#### Property Entity.Experiment.IsInMutexGroup

 Determine if experiment is in a mutually exclusive group 



---
#### Property Entity.Experiment.IsExperimentRunning

 Determine if experiment is running or not 



---
#### Method Entity.Experiment.IsUserInForcedVariation(System.String)

 Determin if user is forced variation of experiment 

|Name | Description |
|-----|------|
|userId: |User ID of the user|
**Returns**: True iff user is in forced variation of experiment



---
#### Property Entity.FeatureVariableUsage.Id

 Audience ID 



---
#### Property Entity.FeatureVariableUsage.Value

 Audience Name 



---
#### Property Entity.Group.Id

 Group ID 



---
#### Property Entity.Group.Policy

 Group policy 



---
#### Property Entity.Group.Experiments

 List of Experiments in the group 



---
#### Property Entity.Group.TrafficAllocation

 List of Traffic allocation of experiments in the group 



---
## Type Entity.IdKeyEntity

 Base class for Entities that have an ID and Key 



---
#### Property Entity.IdKeyEntity.Id

 Entity ID 



---
#### Property Entity.IdKeyEntity.Key

 Entity Key 



---
#### Property Entity.TrafficAllocation.EntityId

 String ID representing experiment or variation depending on parent 



---
#### Property Entity.TrafficAllocation.EndOfRange

 Last bucket number for the experiment or variation 



---
#### Method ErrorHandler.DefaultErrorHandler.#ctor(OptimizelySDK.Logger.ILogger,System.Boolean)

 Create a DefaultErrorHandler 

|Name | Description |
|-----|------|
|logger: |Optional logger to be used to include exception message in the log|
|throwExceptions: |Whether or not to actaully throw the exceptions, true by default|


---
#### Field ErrorHandler.DefaultErrorHandler.Logger

 An optional Logger include exceptions in your log 



---
#### Method Event.Builder.EventBuilder.ResetParams

 Reset the Event Parameters 



---
#### Property Event.Builder.EventBuilder.SecondsSince1970

 Helper to compute Unix time (i.e. since Jan 1, 1970) 



---
#### Method Event.Builder.EventBuilder.GetCommonParams(OptimizelySDK.ProjectConfig,System.String,OptimizelySDK.Entity.UserAttributes)

 Helper function to set parameters common to impression and conversion event 

|Name | Description |
|-----|------|
|config: |ProjectConfig Configuration for the project|
|userId: |string ID of user|
|userAttributes: |associative array of Attributes for the user|


---
#### Method Event.Builder.EventBuilder.CreateImpressionEvent(OptimizelySDK.ProjectConfig,OptimizelySDK.Entity.Experiment,System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Create impression event to be sent to the logging endpoint. 

|Name | Description |
|-----|------|
|config: |ProjectConfig Configuration for the project|
|experiment: |Experiment being activated|
|variationId: |Variation Id|
|userId: |User Id|
|userAttributes: |associative array of attributes for the user|
**Returns**: LogEvent object to be sent to dispatcher



---
#### Method Event.Builder.EventBuilder.CreateConversionEvent(OptimizelySDK.ProjectConfig,System.String,System.Collections.Generic.Dictionary{System.String,OptimizelySDK.Entity.Variation},System.String,OptimizelySDK.Entity.UserAttributes,OptimizelySDK.Entity.EventTags)

 Create conversion event to be sent to the logging endpoint. 

|Name | Description |
|-----|------|
|config: |ProjectConfig Configuration for the project.|
|eventKey: |Event Key representing the event|
|experimentIdVariationMap: |Map of experiment ID to the variation that the user is bucketed into.|
|userId: |ID of user|
|userAttributes: |associative array of Attributes for the user|
|eventTags: |Dict representing metadata associated with the event.|
**Returns**: LogEvent object to be sent to dispatcher



---
## Type Event.Dispatcher.DefaultEventDispatcher

 Default Event Dispatcher Selects the appropriate dispatcher based on the .Net Framework version 



---
#### Field Event.Dispatcher.HttpClientEventDispatcher45.Client

 HTTP client object. 



---
#### Method Event.Dispatcher.HttpClientEventDispatcher45.#cctor

 Constructor for initializing static members. 



---
#### Method Event.Dispatcher.HttpClientEventDispatcher45.DispatchEventAsync(OptimizelySDK.Event.LogEvent)

 Dispatch an Event asynchronously 



---
#### Method Event.Dispatcher.HttpClientEventDispatcher45.DispatchEvent(OptimizelySDK.Event.LogEvent)

 Dispatch an event Asynchronously by creating a new task and calls the Async version of DispatchEvent This is a "Fire and Forget" option 



---
#### Property Event.LogEvent.Url

 string URL to dispatch log event to 



---
#### Property Event.LogEvent.Params

 Parameters to be set in the log event 



---
#### Property Event.LogEvent.HttpVerb

 HTTP verb to be used when dispatching the log event 



---
#### Property Event.LogEvent.Headers

 Headers to be set when sending the request 



---
#### Method Event.LogEvent.#ctor(System.String,System.Collections.Generic.Dictionary{System.String,System.Object},System.String,System.Collections.Generic.Dictionary{System.String,System.String})

 LogEvent Construtor 



---
#### Property IOptimizely.IsValid

 Returns true if the IOptimizely instance was initialized with a valid datafile 



---
#### Method IOptimizely.Activate(System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Buckets visitor and sends impression event to Optimizely. 

|Name | Description |
|-----|------|
|experimentKey: |experimentKey string Key identifying the experiment|
|userId: |string ID for user|
|userAttributes: |associative array of Attributes for the user|
**Returns**: null|Variation Representing variation



---
#### Method IOptimizely.Track(System.String,System.String,OptimizelySDK.Entity.UserAttributes,OptimizelySDK.Entity.EventTags)

 Sends conversion event to Optimizely. 

|Name | Description |
|-----|------|
|eventKey: |Event key representing the event which needs to be recorded|
|userId: |ID for user|
|userAttributes: |Attributes of the user|
|eventTags: |eventTags array Hash representing metadata associated with the event.|


---
#### Method IOptimizely.GetVariation(System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Get variation where user will be bucketed 

|Name | Description |
|-----|------|
|experimentKey: |experimentKey string Key identifying the experiment|
|userId: |ID for the user|
|userAttributes: |Attributes for the users|
**Returns**: null|Variation Representing variation



---
#### Method IOptimizely.SetForcedVariation(System.String,System.String,System.String)

 Force a user into a variation for a given experiment. 

|Name | Description |
|-----|------|
|experimentKey: |The experiment key|
|userId: |The user ID|
|variationKey: |The variation key specifies the variation which the user will be forced into. If null, then clear the existing experiment-to-variation mapping.|
**Returns**: A boolean value that indicates if the set completed successfully.



---
#### Method IOptimizely.GetForcedVariation(System.String,System.String)

 Gets the forced variation key for the given user and experiment. 

|Name | Description |
|-----|------|
|experimentKey: |The experiment key|
|userId: |The user ID|
**Returns**: null|string The variation key.



---
#### Method IOptimizely.IsFeatureEnabled(System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Determine whether a feature is enabled. Send an impression event if the user is bucketed into an experiment using the feature. 

|Name | Description |
|-----|------|
|featureKey: |The feature key|
|userId: |The user ID|
|userAttributes: |The user's attributes.|
**Returns**: True if feature is enabled, false or null otherwise



---
#### Method IOptimizely.GetFeatureVariableBoolean(System.String,System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Gets boolean feature variable value. 

|Name | Description |
|-----|------|
|featureKey: |The feature flag key|
|variableKey: |The variable key|
|userId: |The user ID|
|userAttributes: |The user's attributes|
**Returns**: bool | Feature variable value or null



---
#### Method IOptimizely.GetFeatureVariableDouble(System.String,System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Gets double feature variable value. 

|Name | Description |
|-----|------|
|featureKey: |The feature flag key|
|variableKey: |The variable key|
|userId: |The user ID|
|userAttributes: |The user's attributes|
**Returns**: double | Feature variable value or null



---
#### Method IOptimizely.GetFeatureVariableInteger(System.String,System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Gets integer feature variable value. 

|Name | Description |
|-----|------|
|featureKey: |The feature flag key|
|variableKey: |The variable key|
|userId: |The user ID|
|userAttributes: |The user's attributes|
**Returns**: int | Feature variable value or null



---
#### Method IOptimizely.GetFeatureVariableString(System.String,System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Gets string feature variable value. 

|Name | Description |
|-----|------|
|featureKey: |The feature flag key|
|variableKey: |The variable key|
|userId: |The user ID|
|userAttributes: |The user's attributes|
**Returns**: string | Feature variable value or null



---
#### Method IOptimizely.GetEnabledFeatures(System.String,OptimizelySDK.Entity.UserAttributes)

 Get the list of features that are enabled for the user. 

|Name | Description |
|-----|------|
|userId: |The user Id|
|userAttributes: |The user's attributes|
**Returns**: List of the feature keys that are enabled for the user.



---
## Type Logger.DefaultLogger

 TODO: use Log4Net as the default logger? 



---
## Type Notifications.NotificationCenter

 NotificationCenter class for sending notifications. 



---
## Type Notifications.NotificationCenter.NotificationType

 Enum representing notification types. 



---
## Type Notifications.NotificationCenter.ActivateCallback

 Delegate for activate notifcations. 

|Name | Description |
|-----|------|
|experiment: |The experiment entity|
|userId: |The user identifier|
|userAttributes: |Associative array of attributes for the user|
|variation: |The variation entity|
|logEvent: |The impression event|


---
## Type Notifications.NotificationCenter.TrackCallback

 Delegate for track notifcations. 

|Name | Description |
|-----|------|
|eventKey: |The event key|
|userId: |The user identifier|
|userAttributes: |Associative array of attributes for the user|
|eventTags: |Associative array of EventTags representing metadata associated with the event|
|logEvent: |The conversion event|


---
#### Property Notifications.NotificationCenter.NotificationsCount

 Property representing total notifications count. 



---
#### Method Notifications.NotificationCenter.#ctor(OptimizelySDK.Logger.ILogger)

 NotificationCenter constructor 

|Name | Description |
|-----|------|
|logger: |The logger object|


---
#### Method Notifications.NotificationCenter.AddNotification(OptimizelySDK.Notifications.NotificationCenter.NotificationType,OptimizelySDK.Notifications.NotificationCenter.ActivateCallback)

 Add a notification callback of decision type to the notification center. 

|Name | Description |
|-----|------|
|notificationType: |Notification type|
|decisionCallBack: |Callback function to call when event gets triggered|
**Returns**: int | 0 for invalid notification type, -1 for adding existing notification or the notification id of newly added notification.



---
#### Method Notifications.NotificationCenter.AddNotification(OptimizelySDK.Notifications.NotificationCenter.NotificationType,OptimizelySDK.Notifications.NotificationCenter.TrackCallback)

 Add a notification callback of track type to the notification center. 

|Name | Description |
|-----|------|
|notificationType: |Notification type|
|trackCallback: |Callback function to call when event gets triggered|
**Returns**: int | 0 for invalid notification type, -1 for adding existing notification or the notification id of newly added notification.



---
#### Method Notifications.NotificationCenter.IsNotificationTypeValid(OptimizelySDK.Notifications.NotificationCenter.NotificationType,OptimizelySDK.Notifications.NotificationCenter.NotificationType)

 Validate notification type. 

|Name | Description |
|-----|------|
|providedNotificationType: |Provided notification type|
|expectedNotificationType: |expected notification type|
**Returns**: true if notification type is valid, false otherwise



---
#### Method Notifications.NotificationCenter.AddNotification(OptimizelySDK.Notifications.NotificationCenter.NotificationType,System.Object)

 Add a notification callback to the notification center. 

|Name | Description |
|-----|------|
|notificationType: |Notification type|
|notificationCallback: |Callback function to call when event gets triggered|
**Returns**:  -1 for adding existing notification or the notification id of newly added notification.



---
#### Method Notifications.NotificationCenter.RemoveNotification(System.Int32)

 Remove a previously added notification callback. 

|Name | Description |
|-----|------|
|notificationId: |Id of notification|
**Returns**: Returns true if found and removed, false otherwise.



---
#### Method Notifications.NotificationCenter.ClearNotifications(OptimizelySDK.Notifications.NotificationCenter.NotificationType)

 Remove all notifications for the specified notification type. 

|Name | Description |
|-----|------|
|notificationType: |The notification type|


---
#### Method Notifications.NotificationCenter.ClearAllNotifications

 Removes all notifications. 



---
#### Method Notifications.NotificationCenter.SendNotifications(OptimizelySDK.Notifications.NotificationCenter.NotificationType,System.Object[])

 Fire notifications of specified notification type when the event gets triggered. 

|Name | Description |
|-----|------|
|notificationType: |The notification type|
|args: |Arguments to pass in notification callbacks|


---
#### Method Optimizely.#ctor(System.String,OptimizelySDK.Event.Dispatcher.IEventDispatcher,OptimizelySDK.Logger.ILogger,OptimizelySDK.ErrorHandler.IErrorHandler,OptimizelySDK.Bucketing.UserProfileService,System.Boolean)

 Optimizely constructor for managing Full Stack .NET projects. 

|Name | Description |
|-----|------|
|datafile: |string JSON string representing the project|
|eventDispatcher: |EventDispatcherInterface|
|logger: |LoggerInterface|
|errorHandler: |ErrorHandlerInterface|
|skipJsonValidation: |boolean representing whether JSON schema validation needs to be performed|


---
#### Method Optimizely.ValidatePreconditions(OptimizelySDK.Entity.Experiment,System.String,OptimizelySDK.Entity.UserAttributes)

 Helper function to validate all required conditions before performing activate or track. 

|Name | Description |
|-----|------|
|experiment: |Experiment Object representing experiment|
|userId: |string ID for user|
|userAttributes: |associative array of Attributes for the user|


---
#### Method Optimizely.Activate(System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Buckets visitor and sends impression event to Optimizely. 

|Name | Description |
|-----|------|
|experimentKey: |experimentKey string Key identifying the experiment|
|userId: |string ID for user|
|userAttributes: |associative array of Attributes for the user|
**Returns**: null|Variation Representing variation



---
#### Method Optimizely.ValidateInputs(System.String,System.Boolean)

 Validate datafile 

|Name | Description |
|-----|------|
|datafile: |string JSON string representing the project.|
|skipJsonValidation: |whether JSON schema validation needs to be performed|
**Returns**: true iff all provided inputs are valid



---
#### Method Optimizely.Track(System.String,System.String,OptimizelySDK.Entity.UserAttributes,OptimizelySDK.Entity.EventTags)

 Sends conversion event to Optimizely. 

|Name | Description |
|-----|------|
|eventKey: |Event key representing the event which needs to be recorded|
|userId: |ID for user|
|userAttributes: |Attributes of the user|
|eventTags: |eventTags array Hash representing metadata associated with the event.|


---
#### Method Optimizely.GetVariation(System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Get variation where user will be bucketed 

|Name | Description |
|-----|------|
|experimentKey: |experimentKey string Key identifying the experiment|
|userId: |ID for the user|
|userAttributes: |Attributes for the users|
**Returns**: null|Variation Representing variation



---
#### Method Optimizely.SetForcedVariation(System.String,System.String,System.String)

 Force a user into a variation for a given experiment. 

|Name | Description |
|-----|------|
|experimentKey: |The experiment key|
|userId: |The user ID|
|variationKey: |The variation key specifies the variation which the user will be forced into. If null, then clear the existing experiment-to-variation mapping.|
**Returns**: A boolean value that indicates if the set completed successfully.



---
#### Method Optimizely.GetForcedVariation(System.String,System.String)

 Gets the forced variation key for the given user and experiment. 

|Name | Description |
|-----|------|
|experimentKey: |The experiment key|
|userId: |The user ID|
**Returns**: null|string The variation key.



---
#### Method Optimizely.IsFeatureEnabled(System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Determine whether a feature is enabled. Send an impression event if the user is bucketed into an experiment using the feature. 

|Name | Description |
|-----|------|
|featureKey: |The feature key|
|userId: |The user ID|
|userAttributes: |The user's attributes.|
**Returns**: True if feature is enabled, false or null otherwise



---
#### Method Optimizely.GetFeatureVariableValueForType(System.String,System.String,System.String,OptimizelySDK.Entity.UserAttributes,OptimizelySDK.Entity.FeatureVariable.VariableType)

 Gets the feature variable value for given type. 

|Name | Description |
|-----|------|
|featureKey: |The feature flag key|
|variableKey: |The variable key|
|userId: |The user ID|
|userAttributes: |The user's attributes|
|variableType: |Variable type|
**Returns**: string | null Feature variable value



---
#### Method Optimizely.GetFeatureVariableBoolean(System.String,System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Gets boolean feature variable value. 

|Name | Description |
|-----|------|
|featureKey: |The feature flag key|
|variableKey: |The variable key|
|userId: |The user ID|
|userAttributes: |The user's attributes|
**Returns**: bool | Feature variable value or null



---
#### Method Optimizely.GetFeatureVariableDouble(System.String,System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Gets double feature variable value. 

|Name | Description |
|-----|------|
|featureKey: |The feature flag key|
|variableKey: |The variable key|
|userId: |The user ID|
|userAttributes: |The user's attributes|
**Returns**: double | Feature variable value or null



---
#### Method Optimizely.GetFeatureVariableInteger(System.String,System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Gets integer feature variable value. 

|Name | Description |
|-----|------|
|featureKey: |The feature flag key|
|variableKey: |The variable key|
|userId: |The user ID|
|userAttributes: |The user's attributes|
**Returns**: int | Feature variable value or null



---
#### Method Optimizely.GetFeatureVariableString(System.String,System.String,System.String,OptimizelySDK.Entity.UserAttributes)

 Gets string feature variable value. 

|Name | Description |
|-----|------|
|featureKey: |The feature flag key|
|variableKey: |The variable key|
|userId: |The user ID|
|userAttributes: |The user's attributes|
**Returns**: string | Feature variable value or null



---
#### Method Optimizely.SendImpressionEvent(OptimizelySDK.Entity.Experiment,OptimizelySDK.Entity.Variation,System.String,OptimizelySDK.Entity.UserAttributes)

 Sends impression event. 

|Name | Description |
|-----|------|
|experiment: |The experiment|
|variationId: |The variation entity|
|userId: |The user ID|
|userAttributes: |The user's attributes|


---
#### Method Optimizely.GetEnabledFeatures(System.String,OptimizelySDK.Entity.UserAttributes)

 Get the list of features that are enabled for the user. 

|Name | Description |
|-----|------|
|userId: |The user Id|
|userAttributes: |The user's attributes|
**Returns**: List of the feature keys that are enabled for the user.



---
#### Method Optimizely.ValidateStringInputs(System.Collections.Generic.Dictionary{System.String,System.String})

 Validate all string inputs are not null or empty. 

|Name | Description |
|-----|------|
|inputs: |Array Hash input types and values|
**Returns**: True if all values are valid, false otherwise



---
#### Property ProjectConfig.Version

 Version of the datafile. 



---
#### Property ProjectConfig.AccountId

 Account ID of the account using the SDK. 



---
#### Property ProjectConfig.ProjectId

 Project ID of the Full Stack project. 



---
#### Property ProjectConfig.Revision

 Revision of the dataflie. 



---
#### Property ProjectConfig.AnonymizeIP

 Allow Anonymize IP by truncating the last block of visitors' IP address. 



---
#### Property ProjectConfig.BotFiltering

 Bot filtering flag. 



---
#### Field ProjectConfig._GroupIdMap

 Associative array of group ID to Group(s) in the datafile 



---
#### Field ProjectConfig._ExperimentKeyMap

 Associative array of experiment key to Experiment(s) in the datafile 



---
#### Field ProjectConfig._ExperimentIdMap

 Associative array of experiment ID to Experiment(s) in the datafile 



---
#### Field ProjectConfig._VariationKeyMap

 Associative array of experiment key to associative array of variation key to variations 



---
#### Field ProjectConfig._VariationIdMap

 Associative array of experiment key to associative array of variation ID to variations 



---
#### Field ProjectConfig._EventKeyMap

 Associative array of event key to Event(s) in the datafile 



---
#### Field ProjectConfig._AttributeKeyMap

 Associative array of attribute key to Attribute(s) in the datafile 



---
#### Field ProjectConfig._AudienceIdMap

 Associative array of audience ID to Audience(s) in the datafile 



---
#### Field ProjectConfig._ForcedVariationMap

 Associative array of user IDs to an associative array of experiments to variations.This contains all the forced variations set by the user by calling setForcedVariation (it is not the same as the whitelisting forcedVariations data structure in the Experiments class). 



---
#### Field ProjectConfig._FeatureKeyMap

 Associative array of Feature Key to Feature(s) in the datafile 



---
#### Field ProjectConfig._RolloutIdMap

 Associative array of Rollout ID to Rollout(s) in the datafile 



---
#### Property ProjectConfig.Logger

 Logger for logging 



---
#### Property ProjectConfig.ErrorHandler

 ErrorHandler callback 



---
#### Property ProjectConfig.Groups

 Associative list of groups to Group(s) in the datafile 



---
#### Property ProjectConfig.Experiments

 Associative list of experiments to Experiment(s) in the datafile. 



---
#### Property ProjectConfig.Events

 Associative list of events. 



---
#### Property ProjectConfig.Attributes

 Associative list of Attributes. 



---
#### Property ProjectConfig.Audiences

 Associative list of Audiences. 



---
#### Property ProjectConfig.FeatureFlags

 Associative list of FeatureFlags. 



---
#### Property ProjectConfig.Rollouts

 Associative list of Rollouts. 



---
#### Method ProjectConfig.#ctor

 Constructor (private) 



---
#### Method ProjectConfig.Initialize

 Initialize the arrays and mappings This can't be done in the constructor because the object is created via serialization 



---
#### Method ProjectConfig.GetGroup(System.String)

 Get the group associated with groupId 

|Name | Description |
|-----|------|
|groupId: |string ID of the group|
**Returns**: Group Entity corresponding to the ID or a dummy entity if groupId is invalid



---
#### Method ProjectConfig.GetExperimentFromKey(System.String)

 Get the experiment from the key 

|Name | Description |
|-----|------|
|experimentKey: |Key of the experiment|
**Returns**: Experiment Entity corresponding to the key or a dummy entity if key is invalid



---
#### Method ProjectConfig.GetExperimentFromId(System.String)

 Get the experiment from the ID 

|Name | Description |
|-----|------|
|experimentId: |ID of the experiment|
**Returns**: Experiment Entity corresponding to the IDkey or a dummy entity if ID is invalid



---
#### Method ProjectConfig.GetEvent(System.String)

 Get the Event from the key 

|Name | Description |
|-----|------|
|eventKey: |Key of the event|
**Returns**: Event Entity corresponding to the key or a dummy entity if key is invalid



---
#### Method ProjectConfig.GetAudience(System.String)

 Get the Audience from the ID 

|Name | Description |
|-----|------|
|audienceId: |ID of the Audience|
**Returns**: Audience Entity corresponding to the ID or a dummy entity if ID is invalid



---
#### Method ProjectConfig.GetAttribute(System.String)

 Get the Attribute from the key 

|Name | Description |
|-----|------|
|attributeKey: |Key of the Attribute|
**Returns**: Attribute Entity corresponding to the key or a dummy entity if key is invalid



---
#### Method ProjectConfig.GetVariationFromKey(System.String,System.String)

 Get the Variation from the keys 

|Name | Description |
|-----|------|
|experimentKey: |key for Experiment|
|variationKey: |key for Variation|
**Returns**: Variation Entity corresponding to the provided experiment key and variation key or a dummy entity if keys are invalid



---
#### Method ProjectConfig.GetVariationFromId(System.String,System.String)

 Get the Variation from the Key/ID 

|Name | Description |
|-----|------|
|experimentKey: |key for Experiment|
|variationId: |ID for Variation|
**Returns**: Variation Entity corresponding to the provided experiment key and variation ID or a dummy entity if key or ID is invalid



---
#### Method ProjectConfig.GetForcedVariation(System.String,System.String)

 Gets the forced variation for the given user and experiment. 

|Name | Description |
|-----|------|
|experimentKey: |The experiment key|
|userId: |The user ID|
**Returns**: Variation entity which the given user and experiment should be forced into.



---
#### Method ProjectConfig.SetForcedVariation(System.String,System.String,System.String)

 Sets an associative array of user IDs to an associative array of experiments to forced variations. 

|Name | Description |
|-----|------|
|experimentKey: |The experiment key|
|userId: |The user ID|
|variationKey: |The variation key|
**Returns**: A boolean value that indicates if the set completed successfully.



---
#### Method ProjectConfig.GetFeatureFlagFromKey(System.String)

 Get the feature from the key 

|Name | Description |
|-----|------|
|featureKey: |Key of the feature|
**Returns**: Feature Flag Entity corresponding to the key or a dummy entity if key is invalid



---
#### Method ProjectConfig.GetRolloutFromId(System.String)

 Get the rollout from the ID 

|Name | Description |
|-----|------|
|rolloutId: |ID for rollout|
**Returns**: Rollout Entity corresponding to the rollout ID or a dummy entity if ID is invalid



---
#### Method ProjectConfig.GetAttributeId(System.String)

 Get attribute ID for the provided attribute key 

|Name | Description |
|-----|------|
|attributeKey: |Key of the Attribute|
**Returns**: Attribute ID corresponding to the provided attribute key. Attribute key if it is a reserved attribute



---
#### Field Utils.ConditionEvaluator.AND_OPERATOR

 const string Representing AND operator. 



---
#### Field Utils.ConditionEvaluator.OR_OPERATOR

 const string Representing OR operator. 



---
#### Field Utils.ConditionEvaluator.NOT_OPERATOR

 const string Representing NOT operator. 



---
#### Method Utils.ExperimentUtils.IsUserInExperiment(OptimizelySDK.ProjectConfig,OptimizelySDK.Entity.Experiment,OptimizelySDK.Entity.UserAttributes)

 Representing whether user meets audience conditions to be in experiment or not 

|Name | Description |
|-----|------|
|config: |ProjectConfig Configuration for the project|
|experiment: |Experiment Entity representing the experiment|
|userAttributes: |array Attributes of the user|
**Returns**: whether user meets audience conditions to be in experiment or not



---
#### Method Utils.Validator.ValidateJSONSchema(System.String,System.String)

 Validate the ProjectConfig JSON 

|Name | Description |
|-----|------|
|configJson: |ProjectConfig JSON|
|schemaJson: |Schema JSON for ProjectConfig. If none is provided, use the one already in the project|
**Returns**: Whether the ProjectConfig is valid



---
#### Method Utils.Validator.AreAttributesValid(System.Collections.Generic.IEnumerable{OptimizelySDK.Entity.Attribute})

 Determines whether all attributes in an array are valid. 

|Name | Description |
|-----|------|
|attributes: |Mixed attributes of the user|
**Returns**: true iff all attributes are valid.



---
#### Method Utils.Validator.IsFeatureFlagValid(OptimizelySDK.ProjectConfig,OptimizelySDK.Entity.FeatureFlag)

 Determines whether all the experiments in the feature flag belongs to the same mutex group 

|Name | Description |
|-----|------|
|projectConfig: |The project config object|
|featureFlag: |Feature flag to validate|
**Returns**: true if feature flag is valid.



---
#### Method Utils.ConfigParser`1.GenerateMap(System.Collections.Generic.IEnumerable{`0},System.Func{`0,System.String},System.Boolean)

 Creates a map (associative array) that maps to a list of entities 

|Name | Description |
|-----|------|
|entities: |The list of entities which will be the "values" of the associative array|
|getKey: |A function to return the key value from the entity|
|clone: |Whether or not to clone the original entity|
**Returns**: associative array of key => entity



---


