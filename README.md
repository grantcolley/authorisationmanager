![Alt text](/README-images/component_diagram.png?raw=true "Component Diagram")

#### Table of Contents
* [User Interface](#user-interface)
  * [WPF](#wpf)
  * [Web App](#web-app)
* [Service Interface](#service-interface)
  * [WCF Client](#wcf-client)
  * [WebApi Client](#wcf-client)

## User Interface
#### WPF
The WPF GUI uses the [Origin](https://github.com/grantcolley/origin) framework.
![Alt text](/README-images/wpf_ui.png?raw=true "WPF GUI")

#### Web App
Development in progress...


## Service Interface
The service interface is managed by the [Service library](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Service).

The UI has a reference (dependency injected) to an instance of the [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs).
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
