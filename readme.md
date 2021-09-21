# Quick start

```
./et-dotnet.sh build_em_all
```

### Note: 
You have to provide environment variable:  
- ```REVDEBUG_RECORD_SERVER_ADDRESS``` - IP address for record server

## How to build:

```
./et-dotnet.sh build
``` 

## How to run:

```
./et-dotnet.sh start
```

## Environment variables
You can also provide other environment variables, more informations under our docs:  
[Gitbook C#](https://revdebug.gitbook.io/revdebug/supported-langauges/c)

## How to use
Application runs on port given below (in this case 6015). Every endpoint is listed here:
```YOUR_IP_ADDRESS:6015/links```  
Every endpoint listed there creates recording and it's visible on APM side. 


# Classic pipeline

## Requirements
C# project configuration
Configured & installed RevDebug Server
Visual Studio 

To setup RevDeBug you will need to:
1. Add RevDeBug dependency
2. Configure the connection to RevDeBug Monitor

# Adding RevDeBug dependency
Add RevDeBug NuGet repository to your solution. You can do that globally in Visual Studio settings:
[![N|Solid](https://lh6.googleusercontent.com/eOmATDn_HS1BzY4_RJoTbZZIZqdL5muJcGw8Di1zlzBe8cnFtZeZumJZW8LR_3AEfa2DvFFd6vEh367RYXpq4_Q4SYvwby1xt6ysxiIQcxlt8VsFUPMZebJV6p1tnw)]

Or by adding nuget.config file on solution level:


```sh
dotnet nuget add source https://nexus.revdebug.com/repository/nuget -n rdb_nexus
```
Next use the NuGet package manager to add RevDeBug dependencies by adding the following NuGet packages:
[![Solid](https://lh4.googleusercontent.com/I7IXAA4MGWKPuWqjpEAMcLL8u136nUAfkEk8x7a3z9VEGUcI9di-ZlEVy3sgyn7urIjNPyq8VUqp9d-lSuzNMthJ81VFY6BZ11yMdZIHzlBQdthkG1BADvO60XMs3A)]
After searching for a RevDeBug package, select both:
1. RevDeBug.Net.Compilers.Toolset
2. RevDeBugAPM.Agent.AspNetCore
[![Solid](https://lh5.googleusercontent.com/JIf681vBRDStyZaF3Vz-mhc3D5wNDVEnwfT5hic14AhXsyDGJeCZblFux2GE7AejgsfoVcU4Czb-tSFKhv_W0WtcorrQAmYYFwMCXHzU-hpV93I6-mzwvBy4Q2VXIg)]

# Configure the connection to RevDeBug Monitor
Add Directory.Build.props file on solution level

```sh
<Project>
  <PropertyGroup Condition="'$(RevDeBugDisableNuget)' != 'true'">
    <RevDeBugActive>[REVDEBUG_ACTIVE]</RevDeBugActive>
    <UseRevDeBugOnThisProject>true</UseRevDeBugOnThisProject>
    <RevDeBugStateStorageType>[REVDEBUG_STORAGE_TYPE]</RevDeBugStateStorageType>
    <SendToServer>[REVDEBUG_SEND_TO_SERVER]</SendToServer>
    <RecorderAddress>[REVDEBUD_RECORDER_ADDRESS]</RecorderAddress>
    <RecorderTCPPort>[REVDEBUD_RECORDER_TCP_PORT]</RecorderTCPPort>
    <RevDeBugForceTLS>[REVDEBUG_FORCE_TLS]</RevDeBugForceTLS>
    <ImportGitInfo>true</ImportGitInfo>
  </PropertyGroup>
  <PropertyGroup Condition="'$(TargetFrameworkIdentifier)' != '.NETFramework'">
    <isNetCore>true</isNetCore>
  </PropertyGroup>
</Project>
```
**[REVDEBUG_SEND_TO_SERVER]**- Configure if RevDeBug will send data to server
**[REVDEBUD_RECORDER_ADDRESS]**-Here you have to enter the IP address or hostname of the recording servers (if you are using Docker, use Ifconfig command to get an IP address)
**[REVDEBUD_RECORDER_TCP_PORT]**- Default port to connect to RevDeBug DevOps Monitor.
**[REVDEBUG_FORCE_TLS]**- forces TLS connection with the server. Set this to ```true``` if your RevDeBug DevOps Monitor instance has been configured to work with a SSL certificate.
**[REVDEBUG_ACTIVE]**- Fast and easy way to disable RevDeBug in your solution
**[REVDEBUG_STORAGE_TYPE]**-  this field is crucial for application performance. There are three values that you can use here:
1. **Continuous** - means that your application will be permanently connected to the RevDeBug server. Even if you select standby or emergency recording mode, the application will be connected. It will not stream data, but there will be a slight decrease in performance.
2. **OnEvent** - works on the contrary. The application connects to the RevDeBug server only for a specific event. And this event must come from the application. For example, a failure or a particular method or object you want to record
3. **Noop** - this field is handy when you want to connect to the RevDeBug server only in case of an emergency, or you care about performance. For example, you can build your application with RevDeBug, prepare all events that should be recorded, but until you change this setting, nothing will be recorded.

# Configure tracing
Add **skyapm.json** to startup project and make sure its copied to output directory
```sh
{
  "SkyWalking": {
    "ServiceName": "ServiceName",
    "Namespace": "",
    "HeaderVersions": [
      "sw8"
    ],
    "Sampling": {
      "SamplePer3Secs": -1,
      "Percentage": -1.0
    },
    "Logging": {
      "Level": "Information",
      "FilePath": "logs\\skyapm-{Date}.log"
    },
    "Transport": {
      "Interval": 3000,
      "ProtocolVersion": "v8",
      "QueueSize": 30000,
      "BatchSize": 3000,
      "gRPC": {
        "Servers": "[address]:11800",
        "Timeout": 10000,
        "ConnectTimeout": 10000,
        "ReportTimeout": 600000,
        "ForceTLS": false
      }
    }
  }
}
```
and set ```[address]``` to point to your record server instance.
If your RevDeBug DevOps Monitor instance has been configured to work with a SSL certificate, set 
```ForceTLS``` to ```true```.

# IMPORTANT NOTE
When you run ASP.NET Core application set environment variable ASPNETCORE_HOSTINGSTARTUPASSEMBLIES to RevDeBugAPM.Agent.AspNetCore