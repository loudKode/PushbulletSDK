## PushbulletSDK

`Download:`[https://github.com/loudKode/PushbulletSDK/releases](https://github.com/loudKode/PushbulletSDK/releases)<br>
`Help:`[https://github.com/loudKode/PushbulletSDK/wiki](https://github.com/loudKode/PushbulletSDK/wiki)<br>
`NuGet:`
[![NuGet](https://img.shields.io/nuget/v/DeQmaTech.PushbulletSDK.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/DeQmaTech.PushbulletSDK)<br>

<table>
<tr>
<td>
<a href="https://visualstudio.microsoft.com/vs/older-downloads/"><img src="https://i.postimg.cc/3wXQcjjG/VS2017-Banner.png"></a>
<br />
<a href="https://visualstudio.microsoft.com/vs/older-downloads/">Visual Studio 2017</a>
</td>
<td><a href="https://www.nuget.org/packages/DeQmaTech.PushbulletSDK"><img src="https://i.postimg.cc/gjYM286f/Nuget-logo1.png"></a>
<br />
<a href="https://www.nuget.org/packages/DeQmaTech.PushbulletSDK">nuget</a>
</td>
<td><a href="https://github.com/loudKode/PushbulletSDK/releases"><img src="https://i.postimg.cc/TPXsYk57/dot-net-png-7.png"></a>
<br />
<a href="https://github.com/loudKode/PushbulletSDK/releases">4.5.2 / 2.0 / 2.1</a>
</td>
</table>


# Features
* Assemblies for .NET 4.5.2 and .NET Standard 2.0 and .NET Core 2.1
* Just one external reference (Newtonsoft.Json)
* Easy installation using NuGet
* Upload/Download tracking support
* Proxy Support
* Upload/Download cancellation support

# List of functions:
> **Token**
> * GetToken

> **Device**	
> * Delete
> * Create
> * Update
> * List

> **Channel**
> * Mute
> * Leave
> * Join
> * List

> **Push**
> * Upload
> * List
> * SendToDevice
> * SendToEmail
> * SendToChannel
> * SendToAllAppUsers
> * MarkedAsSeen
> * Delete
> * Clear


# Code simple:
**get access token**
```vb.net
Dim rslt = PushbulletSDK.Authentication.GetToken("ClientID", "RedirectUrl")
```

**set client**
```vb.net
Dim cLENT As PushbulletSDK.IClient = New PushbulletSDK.PClient("token")
```

**set client with proxy**
```vb.net
Dim roxy = New BackBlazeSDK.ProxyConfig With {.ProxyIP = "172.0.0.0", .ProxyPort = 80, .ProxyUsername = "myname", .ProxyPassword = "myPass", .SetProxy = true}
Dim cLENT As PushbulletSDK.IClient = New PushbulletSDK.PClient("token",roxy)
```
# Device #

----------

**List Devices**
```vb.net
Dim RSLT = Await cLENT.Device.List()
For Each dev In RSLT.devices
    DataGridView1.Rows.Add(dev.isExists, dev.iden, dev.manufacturer, dev.model)
Next
```

**create new Device**
```vb.net
Dim RSLT = Await cLENT.Device.Create("name", "win10", "micro", "1.0.0", iconEnum.desktop, Nothing)
```

**update Device**
```vb.net
Dim RSLT = Await cLENT.Device.Update("device ID", "name", "win10", "micro", "1.0.0", iconEnum.desktop, Nothing)
```

**delete Device**
```vb.net
Dim RSLT = Await cLENT.Device.Delete("device ID")
```
# Channel #

----------

**List Channels**
```vb.net
Dim RSLT = Await cLENT.Channel.List
For Each chnl In RSLT.subscriptions
    DataGridView1.Rows.Add(chnl.isExists, chnl.iden, chnl.channel.name, chnl.channel.description, chnl.channel.tag, chnl.channel.iden)
Next
```

**Join/UnJoin/Mute/UnMute Channel**
```vb.net
Dim join_A_channel = Await cLENT.Channel.Join("channel tag")
Dim unjoin_A_channel = Await cLENT.Channel.Leave("channel ID")
Dim mute_unmute_channel = Await cLENT.Channel.Mute("channel ID", True)
```
# Push #

----------

**Send Push To Device**
```vb.net
Dim psend = New PushbulletSDK.Pushes With {.note_push = New PushbulletSDK.Pushes._Note With {.title = "test titel", .body = "this is test body first time."}}
Dim RSLT = Await cLENT.Push.SendToDevice("device ID", PushTypesEnum.note, psend)
DataGridView1.Rows.Add(RSLT.isExists)
```

**Send Push To All App Users**
```vb.net
Dim psend = New PushbulletSDK.Pushes With {.note_push = New PushbulletSDK.Pushes._Note With {.title = "test titel", .body = "this is test body first time."}}
Dim RSLT = Await cLENT.SendToAllAppUsers("APP CLIENT ID", PushTypesEnum.note, psend)
DataGridView1.Rows.Add(RSLT.title)
```

**Send Push To Mail**
```vb.net
Dim psend = New PushbulletSDK.Pushes With {.note_push = New PushbulletSDK.Pushes._Note With {.title = "test titel", .body = "this is test body first time."}}
Dim RSLT = Await cLENT.Push.SendToDevice("xxxx@gmail.com", PushTypesEnum.note, psend)
DataGridView1.Rows.Add(RSLT.isExists)

Dim psend = New PushbulletSDK.Pushes With {.link_push = New PushbulletSDK.Pushes._Link With {.title = "test titel", .type = PushTypesEnum.link, .body = "look at this", .url = "https://www.youtube.com/watch?v=7b_EgKWYn5c"}}
Dim RSLT = Await cLENT.Push.SendToEmail("unlimitedillegal.tk@gmail.com", PushTypesEnum.link, psend)
DataGridView1.Rows.Add(RSLT.title, RSLT.CreatedDate)
```

**Send Push To channel**
```vb.net
Dim RSLT = Await cLENT.Push.SendToChannel("channel tag", PushTypesEnum.link, psend)
```

**List Pushs**
```vb.net
Dim RSLT = Await cLENT.Push.List(20)
For Each fold In RSLT.pushes
    DataGridView1.Rows.Add(fold.isExists, fold.iden, fold.body, fold.sender_name, fold.title, fold.type.ToString)
Next

If RSLT.HasMore Then
    Dim RSLT2 = Await cLENT.Push.ListContinue(RSLT.cursor, 20)
    For Each fold In RSLT2.pushes
        DataGridView1.Rows.Add(fold.isExists, fold.iden, fold.body, fold.sender_name, fold.title, fold.type.ToString)
    Next
End If
```

**delete/clear/markedSeen Push**
```vb.net
Dim RSLT = Await cLENT.Push.Delete("push id")
Dim RSLT = Await cLENT.Push.Clear()
Dim RSLT = Await cLENT.Push.Marked("push id", True)
```

**Upload a file and get the link**
```vb.net
Try
Dim UploadCancellationToken As New Threading.CancellationTokenSource()
Dim prog_Report As New Progress(Of PushbulletSDK.ReportStatus)(Sub(ReportClass As PushbulletSDK.ReportStatus)
         Label1.Text = String.Format("{0}/{1}", (ReportClass.BytesTransferred), (ReportClass.TotalBytes))
         ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
         Label2.Text = If(CStr(ReportClass.TextStatus) Is Nothing, "Uploading...", CStr(ReportClass.TextStatus))
         End Sub)
Dim RSLT = Await cLENT.Push.Upload("J:\New.jpg", UploadTypes.FilePath, "New.jpg", prog_Report, Nothing, UploadCancellationToken.Token)
DataGridView1.Rows.Add(RSLT)
End If
Catch ex As PushbulletSDK.PushbulletException
  MsgBox(ex.Message)
End Try
```
