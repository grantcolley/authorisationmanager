The Authorisation Manager system comprises several decoupled configurable application layers: [user interface](#user-interface), [service layer](#service-layer), [server](#server), [data access layer](#data-access-layer) and [database](#database).

##### Technologies
###### WPF, Prism, Unity, WebApi 2.2, WCF
#####  

![Alt text](/README-images/component_diagram.png?raw=true "Component Diagram")

#### Table of Contents
* [User Interface](#user-interface)
  * [WPF](#wpf)
  * [Web App](#web-app)
* [Service Layer](#service-layer)
  * [WCF Service](#wcf-service)
  * [WebApi Client](#webapi)
* [Server](#server)
* [Data Access Layer](#data-access-layer)
  * [MS SQL Server Data Access Library](#ms-sql-server-data-access-library)
  * [Oracle Data Access Library](#oracle-data-access-library)
  * [MySql Data Access Library](#mysql-data-access-library)
* [Database](#database)
  * [MS SQL Server](#ms-sql-server)
  * [Oracle](#oracle)
  * [MySql](#mysql)

## User Interface
#### WPF
###### WPF, Prism, Unity, Origin framework.
The [WPF UI](https://github.com/grantcolley/authorisationmanager/tree/master/UI/WPF) uses the [Origin](https://github.com/grantcolley/origin) framework which is a WPF shell application implementing MVVM, Prism and Unity for hosting line-of-business modules in a document style layout.

The UI contains presentation only logic and relies on the [service layer](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Service) for operational functionality via an instance of the [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs).

![Alt text](/README-images/wpf_ui.PNG?raw=true "WPF GUI")

#### Web App
Development in progress...


## Service Layer
The [service layer](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Service) takes requests from the UI via the [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs) and is responsible for routing it to the configured service.

The service can be [configured](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/Configuration/DevelopmentInProgress.AuthorisationManager.Service.Unity.config) to send requests via either the [WCF Client](https://github.com/grantcolley/authorisationmanager/tree/master/Service/WCFClient) or the [WebApi Client](https://github.com/grantcolley/authorisationmanager/tree/master/Service/WebApiClient), both of which implement [IAuthorisationManagerServiceAsync](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/IAuthorisationManagerServiceAsync.cs) and is injected into the constructor of [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs).

```C#

<unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
    <alias alias="AuthorisationManagerServiceProxy" type="DevelopmentInProgress.AuthorisationManager.Service.AuthorisationManagerServiceProxy, DevelopmentInProgress.AuthorisationManager.Service" />
    <alias alias="IAuthorisationManagerServiceProxy" type="DevelopmentInProgress.AuthorisationManager.Service.IAuthorisationManagerServiceProxy, DevelopmentInProgress.AuthorisationManager.Service" />
    <alias alias="IAuthorisationManagerServiceAsync" type="DevelopmentInProgress.AuthorisationManager.Service.IAuthorisationManagerServiceAsync, DevelopmentInProgress.AuthorisationManager.Service" />    
    <alias alias="AuthorisationManagerWCFClient" type="DevelopmentInProgress.AuthorisationManager.WCFClient.AuthorisationManagerWCFClient, DevelopmentInProgress.AuthorisationManager.WCFClient" />
    <!--<alias alias="AuthorisationManagerWebApiClient" type="DevelopmentInProgress.AuthorisationManager.WebApiClient.AuthorisationManagerWebApiClient, DevelopmentInProgress.AuthorisationManager.WebApiClient" />-->

    <container>
      <register type="IAuthorisationManagerServiceProxy" mapTo="AuthorisationManagerServiceProxy"/>

<register type="IAuthorisationManagerServiceAsync" mapTo="AuthorisationManagerWCFClient"/>
      <!--<register type="IAuthorisationManagerServiceAsync" mapTo="AuthorisationManagerWebApiClient"/>-->
    </container>

  </unity>
```
#### WebApi
###### WebApi 2.2, Unity
The [WebApi Client](https://github.com/grantcolley/authorisationmanager/tree/master/Service/WebApiClient) forwards the request onto the [WebApi](https://github.com/grantcolley/authorisationmanager/tree/master/Service/WebAPI), which is simply host for the [Server](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Server).

#### WCF Service
###### WCF, Unity
The [WCF Client](https://github.com/grantcolley/authorisationmanager/tree/master/Service/WCFClient) forwards the request onto the [WCF Service Host](https://github.com/grantcolley/authorisationmanager/tree/master/Service/WCFServiceHost), which is simply host for the [Server](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Server).

## Server
The [server](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Server) is for business logic and access to the [data access layer](https://github.com/grantcolley/authorisationmanager/tree/master/Data/DevelopmentInProgress.AuthorisationManager.Data) via the [IAuthorisationManagerDataProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Data/DevelopmentInProgress.AuthorisationManager.Data/IAuthorisationManagerDataProxy.cs).  

## Data Access Layer
The [Data](https://github.com/grantcolley/authorisationmanager/tree/master/Data/DevelopmentInProgress.AuthorisationManager.Data) library provides the interface to the data access layer through [IAuthorisationManagerData](https://github.com/grantcolley/authorisationmanager/blob/master/Data/DevelopmentInProgress.AuthorisationManager.Data/IAuthorisationManagerData.cs).
The data access implementation can be [configured](https://github.com/grantcolley/authorisationmanager/blob/master/Data/DevelopmentInProgress.AuthorisationManager.Data/ServerConfiguration/DevelopmentInProgress.AuthorisationManager.Data.Unity.config) for access to MS SQL Server, Oracle or MySql.

```C#
  <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
    
    <alias alias="AuthorisationManagerDataProxy" type="DevelopmentInProgress.AuthorisationManager.Data.AuthorisationManagerDataProxy, DevelopmentInProgress.AuthorisationManager.Data" />
    <alias alias="IAuthorisationManagerDataProxy" type="DevelopmentInProgress.AuthorisationManager.Data.IAuthorisationManagerDataProxy, DevelopmentInProgress.AuthorisationManager.Data" />
    <alias alias="IAuthorisationManagerData" type="DevelopmentInProgress.AuthorisationManager.Data.IAuthorisationManagerData, DevelopmentInProgress.AuthorisationManager.Data" />
    <!--<alias alias="AuthorisationManagerData" type="DevelopmentInProgress.AuthorisationManager.Data.SQL.AuthorisationManagerData, DevelopmentInProgress.AuthorisationManager.Data.Oracle" />-->
    <!--<alias alias="AuthorisationManagerData" type="DevelopmentInProgress.AuthorisationManager.Data.SQL.AuthorisationManagerData, DevelopmentInProgress.AuthorisationManager.Data.MySql" />-->
    <alias alias="AuthorisationManagerData" type="DevelopmentInProgress.AuthorisationManager.Data.SQL.AuthorisationManagerData, DevelopmentInProgress.AuthorisationManager.Data.SQL" />
    
    <container>
      <register type="IAuthorisationManagerDataProxy" mapTo="AuthorisationManagerDataProxy"/>
      <register type="IAuthorisationManagerData" mapTo="AuthorisationManagerData"/>
    </container>

  </unity>
```

#### MS SQL Server Data Access Library
The [MS SQL Server data access library](https://github.com/grantcolley/authorisationmanager/tree/master/Data/DevelopmentInProgress.AuthorisationManager.Data.SQL) uses [DipMapper](https://github.com/grantcolley/dipmapper) for easy, fast and efficient access to MS SQL Server.

#### Oracle Data Access Library
Development in progress...

#### MySql Data Access Library
Development in progress...

## Database
#### MS SQL Server
[Installation script](https://github.com/grantcolley/authorisationmanager/blob/master/Data/DevelopmentInProgress.AuthorisationManager.Data.SQL/MSSQLServer_AuthorisationManager.sql).

#### Oracle
Development in progress...

#### MySql
Development in progress...
