The Authorisation Manager system comprises several decoupled configurable application layers: [user interface](#user-interface), [service layer](#service-layer), [server](#server), [data access layer](#data-access-layer) and [database](#database).

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
The [WPF UI](https://github.com/grantcolley/authorisationmanager/tree/master/UI/WPF) uses the [Origin](https://github.com/grantcolley/origin) framework which is a WPF shell application implements Prism and Unity for hosting line-of-business modules in a document style layout.

The UI contains presentation only logic and relies on the [service layer](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Service) for operational functionality via an instance of the [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs).

![Alt text](/README-images/wpf_ui.PNG?raw=true "WPF GUI")

#### Web App
Development in progress...


## Service Layer
The [service layer](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Service) takes requests from the UI via the [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs) and is responsible for routing it to the configured service.

The service can be [configured](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/Configuration/DevelopmentInProgress.AuthorisationManager.Service.Unity.config) to either send requests via either the [WCF Client](https://github.com/grantcolley/authorisationmanager/tree/master/Service/WCFClient) or the [WebApi Client](https://github.com/grantcolley/authorisationmanager/tree/master/Service/WebApiClient), both of which implement [IAuthorisationManagerServiceAsync](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/IAuthorisationManagerServiceAsync.cs) and is injected into the constructor of [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs).

The implementation of  is determined by the [Service.Unity.config]().

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

#### WCF Service

#### WebApi

## Server

## Data Access Layer
#### MS SQL Server Data Access Library
#### Oracle Data Access Library
#### MySql Data Access Library

## Database
#### MS SQL Server
#### Oracle
#### MySql
