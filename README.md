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

#### Web App
Development in progress...


## Service Interface
The service interface is managed by the [Service library](https://github.com/grantcolley/authorisationmanager/tree/master/Service/DevelopmentInProgress.AuthorisationManager.Service).

The UI has a reference (dependency injected) to an instance of the [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs).
The [AuthorisationManagerServiceProxy](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/AuthorisationManagerServiceProxy.cs) has a reference (dependency injected) to [IAuthorisationManagerServiceAsync](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/IAuthorisationManagerServiceAsync.cs).

The implementation of [IAuthorisationManagerServiceAsync](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/IAuthorisationManagerServiceAsync.cs) is determined by the [Service.Unity.config](https://github.com/grantcolley/authorisationmanager/blob/master/Service/DevelopmentInProgress.AuthorisationManager.Service/Configuration/DevelopmentInProgress.AuthorisationManager.Service.Unity.config).

#### WCF Client

#### WebApi Client
