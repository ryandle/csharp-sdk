## `DefaultEventDispatcher`

```csharp
public class OptimizelySDK.Event.Dispatcher.DefaultEventDispatcher
    : HttpClientEventDispatcher45, IEventDispatcher

```

## `HttpClientEventDispatcher45`

```csharp
public class OptimizelySDK.Event.Dispatcher.HttpClientEventDispatcher45
    : IEventDispatcher

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ILogger` | Logger |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | DispatchEvent(`LogEvent` logEvent) |  | 


## `IEventDispatcher`

```csharp
public interface OptimizelySDK.Event.Dispatcher.IEventDispatcher

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `ILogger` | Logger |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | DispatchEvent(`LogEvent` logEvent) |  | 


