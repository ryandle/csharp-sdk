## `DefaultLogger`

```csharp
public class OptimizelySDK.Logger.DefaultLogger
    : ILogger

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Log(`LogLevel` level, `String` message) |  | 


## `ILogger`

```csharp
public interface OptimizelySDK.Logger.ILogger

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Log(`LogLevel` level, `String` message) |  | 


## `LogLevel`

```csharp
public enum OptimizelySDK.Logger.LogLevel
    : Enum, IComparable, IFormattable, IConvertible

```

Enum

| Value | Name | Summary | 
| --- | --- | --- | 
| `0` | DEBUG |  | 
| `1` | INFO |  | 
| `2` | WARN |  | 
| `3` | ERROR |  | 


## `NoOpLogger`

```csharp
public class OptimizelySDK.Logger.NoOpLogger
    : ILogger

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Log(`LogLevel` level, `String` message) |  | 


