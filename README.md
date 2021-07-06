SoftToyShop

    A .Net 5 implementation of a simple online shop management system. Project was created for learning programming in ASP.NET Core for .NET 5, Entity Framework Core 5 and publish it to Azure portal.

Table of Contents

    General Info
    Technologies Used
    Programming tricks
    Contact

General Information

    My goal was to design and meet with the philosophies of creating a MVC.

Technologies Used

    .NET 5.0
    Razor pages
    twitter-bootstrap@3.3.7
    jquery@3.4.1
    Entity Framework Core 5.0.6
    Identity.IU 5.0.7
    NLog.Web.AspNetCore 4.12.0
    MS SQL v2014 (Azure)

Programming tricks

    Used MVC software design pattern
    Low level of coupling, modules depend on abstractions (interfaces). Business logic of controllers are located in repositories which are registered into the dependency injection container.
    Added middleware to catch a long time processing requests
    nlog is used to log information about application operation
    Used tag helpers, partial views, view components
    

Acknowledgements

    This project was based on pluralsight ASP.NET Core path.

Contact

Created by Tomasz.Caban@gmail.com - feel free to contact me!
