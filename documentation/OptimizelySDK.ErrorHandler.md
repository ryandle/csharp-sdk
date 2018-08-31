## `DefaultErrorHandler`

```csharp
public class OptimizelySDK.ErrorHandler.DefaultErrorHandler
    : IErrorHandler

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | HandleError(`Exception` exception) |  | 


## `IErrorHandler`

```csharp
public interface OptimizelySDK.ErrorHandler.IErrorHandler

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | HandleError(`Exception` exception) |  | 


## `NoOpErrorHandler`

```csharp
public class OptimizelySDK.ErrorHandler.NoOpErrorHandler
    : DefaultErrorHandler, IErrorHandler

```

