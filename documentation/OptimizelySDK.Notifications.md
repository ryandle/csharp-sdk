## `NotificationCenter`

```csharp
public class OptimizelySDK.Notifications.NotificationCenter

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | NotificationId |  | 
| `Int32` | NotificationsCount |  | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | AddNotification(`NotificationType` notificationType, `ActivateCallback` activateCallback) |  | 
| `Int32` | AddNotification(`NotificationType` notificationType, `TrackCallback` trackCallback) |  | 
| `void` | ClearAllNotifications() |  | 
| `void` | ClearNotifications(`NotificationType` notificationType) |  | 
| `Boolean` | RemoveNotification(`Int32` notificationId) |  | 
| `void` | SendNotifications(`NotificationType` notificationType, `Object[]` args) |  | 


