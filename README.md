The Authorisation Manager system comprises several decoupled application layers: user interface, service layer, server, data access layer and database. Each layer has its own configurable interface.

![Alt text](/README-images/component_diagram.png?raw=true "Component Diagram")

#### Table of Contents
* [User Interface](#user-interface)
  * [WPF](#wpf)
  * [Web App](#web-app)
* [Service Layer](#service-layer)
  * [WCF Client](#wcf-client)
  * [WebApi Client](#wcf-client)

## User Interface
#### WPF
The [WPF UI](https://github.com/grantcolley/authorisationmanager/tree/master/UI/WPF) uses the [Origin](https://github.com/grantcolley/origin) framework which is a WPF shell application implements Prism and Unity for hosting line-of-business modules in a document style layout.

The UI contains presentation only logic and relies on the [service layer](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Service) for operational functionality via an instance of the [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs).

![Alt text](/README-images/wpf_ui.PNG?raw=true "WPF GUI")

#### Web App
Development in progress...


## Service Layer
The [service layer](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Service) takes requests from the UI via the [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs) which is responsible for routing it to the configured service.

The [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs) has a reference (dependency injected) to [IAuthorisationManagerServiceAsync](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/IAuthorisationManagerServiceAsync.cs).

The implementation of [IAuthorisationManagerServiceAsync](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/IAuthorisationManagerServiceAsync.cs) is determined by the [Service.Unity.config](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/Configuration/DevelopmentInProgress.AuthorisationManager.Service.Unity.config).

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

#### WCF Client

#### WebApi Client
