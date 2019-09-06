# PushbulletSDK
.NET API Library for pushbullet.com


`Download:`[https://github.com/loudKode/PushbulletSDK/releases](https://github.com/loudKode/PushbulletSDK/releases)<br>
`NuGet:`
[![NuGet](https://img.shields.io/nuget/v/DeQmaTech.PushbulletSDK.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/DeQmaTech.PushbulletSDK)<br>

# Functions:
[https://github.com/loudKode/PushbulletSDK/blob/master/IClient.cs](https://github.com/loudKode/PushbulletSDK/blob/master/IClient.cs)

# Example:
**get access token**
```vb.net
Dim rslt = PushbulletSDK.GetToken.Get_Token("ClientID", "RedirectUrl")
```

**set client**
```vb.net
Dim rslt = PushbulletSDK.GetToken.Get_Token("ClientID", "RedirectUrl")
```

**List Devices**
```vb.net
Dim RSLT = Await cLENT.ListDevices()
For Each fold In RSLT.devices
   DataGridView1.Rows.Add(fold.isExists, fold.iden, fold.manufacturer, fold.push_token, fold.nickname, fold.model)
Next
```

**Send Push To Device**
```vb.net
Dim psend = New PushbulletSDK.Pushes With {.note_push = New PushbulletSDK.Pushes._Note With {.title = "test titel", .body = "this is test body first time."}}
Dim RSLT = Await cLENT.SendPushToDevice("uj8MVf76", PushbulletSDK.Putilities.PushTypesEnum.note, psend)
DataGridView1.Rows.Add(RSLT.isExists)
```

**Send Push To All App Users**
```vb.net
Dim psend = New PushbulletSDK.Pushes With {.note_push = New PushbulletSDK.Pushes._Note With {.title = "test titel", .body = "this is test body first time."}}
Dim RSLT = Await cLENT.SendPushToAllAppUsers("ujw3x7cG", PushbulletSDK.Putilities.PushTypesEnum.note, psend)
DataGridView1.Rows.Add(RSLT.title)
```
