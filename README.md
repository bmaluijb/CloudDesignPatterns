# CloudDesignPatterns

![enter image description here](https://www.pluralsight.com/content/dam/pluralsight/newsroom/brand-assets/logos/pluralsight-logo-vrt-color-2.png)  

Hi! 

Welcome to the GitHub repository of the cloud design patterns.
This repository contains the examples for the Pluralsight course series: [Cloud Design Patterns for Azure](https://app.pluralsight.com/profile/author/barry-luijbregts).

The repository will keep growing until all of the courses of the series are released.

The solution consists of:

- AutomaticScalingPattern
 	- .NET 4.5.2 Console Application
  - The pattern is implemented in
    - Program.cs
- CacheAsidePattern
 	- .NET 4.5.2 Console Application
  - The pattern is implemented in
    - CacheService.cs
    - FakeDataSource.cs
    - Program.cs    
- CircuitBreakerPattern
 	- .NET 4.5.2 Console Application
  - The pattern is implemented in
    - All classes in the CircuitBreaker folder
    - Program.cs
- CQRSPattern
 	- .NET 4.5.2 Console Application
  - The pattern is implemented in
    - All classes in the DataStores, Models and Services folders
    - Program.cs    
- EventSourcingPattern
 	- .NET 4.5.2 Console Application
  - The pattern is implemented in
    - All classes in the Commands and EventStore folders
    - Program.cs        
 - QueueBasedLoadLevelingPatternApplication    
 	- .NET 4.5.2 Console Application
	- One of the QueueBasedLoadLevelingPattern applications, this one acts as the application calling a service
	- The pattern is implemented in
	  - Program.cs
 - QueueBasedLoadLevelingPatternLibary    
 	- .NET 4.5.2 Console Application
	- One of the QueueBasedLoadLevelingPattern applications, this is a library containing a service that talks to Azure Storage
 - QueueBasedLoadLevelingPatternService    
 	- .NET 4.5.2 Console Application
	- One of the QueueBasedLoadLevelingPattern applications, this is the application that picks up messages from the Azure queue and processes them
	- The pattern is implemented in
	  - Program.cs
 - QueueBasedLoadLevelingPatternWebJob    
 	- An Azure WebJob project
	- One of the QueueBasedLoadLevelingPattern applications, this is the application that picks up messages from the Azure queue and processes them, showing a trigger that is triggered by new messages on the queue
	- The pattern is implemented in
	  - Functions.cs	  
 - RetryPattern    
 	- .NET 4.5.2 Console Application
	- The pattern is implemented in
	  - StorageService.cs
 - RuntimeReconfigurationPattern
	 - ASP.NET Core MVC 1.1 Web Application
   - The pattern is implemented in
      - Startup.cs class
      - HomeController.cs
- ShardingPattern
 	- .NET 4.5.2 Console Application
  - This is a sample application that can also be found at https://code.msdn.microsoft.com/windowsapps/Elastic-Scale-with-Azure-a80d8dc6        
 - ValetKeyPattern
	 - ASP.NET Core MVC 1.1 Web Application
   - The pattern is implemented in 
      - AzureStorage/CORSConfigurator.cs
      - Controllers/SasController.cs
      - Views/Upload.cshtml	  

All of the projects can be run independently.

The QueueBasedLoadLevelingPattern projects make no sense can be run independently, but serve little purpose doing so.
Please watch the Queue-based loadleveling pattern module for more information.

Getting started
---------------

**Step 1**

Make sure that you have the following:

 - Visual Studio 2017
 - Azure subscription ([Try for free](https://azure.microsoft.com/en-us/free/))
 - [Azure SDK](https://azure.microsoft.com/en-us/downloads/), if you didn't indicate it it the Visual Studio 2017 setup

**Step 2**

Download a copy of the code and build it.
Select the example that you want to run and set it as the startup project.

**Running the AutomaticScalingPattern project**

To run the AutomaticScalingPattern project, you need to create a Service Principal in Azure.
Find out here to to create one: https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal. 
Insert the ClientId, ClientSecret (AAD application token) and AAD TenantId into the Authenticate method in program.cs

**Running the CacheAsidePattern project**

To run the CacheAsidePattern project, you need an Azure Redis Cache. Once you've created one, you need to put the Redis Cache connectionstring in the APp.Config file. 

**Running the EventSourcingPattern project**

To run the EventSourcingPattern project, you need a SQL Server. This can be a SQL Server Local DB, SQL Server Express, other SQL Server versions on-premises or in the cloud. Put the SQL Server connectionstring in the App.config file.

**Running the QueueBasedLoadLevelingPattern projects**

To run these projects, you need to indicate an Azure Storage account where in which a queue will be created.
When you have an Azure Storage Account, you need to put the connectionstring for the storage account in the App.config files of the following projects:
  - QueueBasedLoadLevelingPatternApplication
  - QueueBasedLoadLevelingPatternService
  - QueueBasedLoadLevelingPatternWebJob
  
The connectionstring should look like this:
"DefaultEndpointsProtocol=https;AccountName=saspluralsight;AccountKey=WCxWWe1q6w0EHByo+==;"  
  
**Running the RetryPattern project**

To run the RetryPattern project, you need an Azure Storage account. Find out more [here](https://www.youtube.com/watch?v=tSGSfOAiNrw).
When you have one, you need to put the connectionstring for the storage account in the App.config file.

The connectionstring should look like this:
"DefaultEndpointsProtocol=https;AccountName=saspluralsight;AccountKey=WCxWWe1q6w0EHByo+==;"

**Running the ShardingPattern project**

To run the EventSourcingPattern project, you need an Azure SQL Server. 
In the App.config file:
 - ServerName:	Put in the servername (YOURSQLSERVERNAME.database.windows.net)
 - UserName: 	SQL Server user username (user should be able to create and delete databases)
 - Password: 	SQL Server user password  

**Running the ValetKeyPattern project**

To run the ValetKeyPattern project, you need an Azure Storage account. Find out more [here](https://www.youtube.com/watch?v=tSGSfOAiNrw).
When you have one, you need to put the connectionstring for the storage account in either the **appsettings.json** or **appsettings.development.json** file, in the **AzureStorageConnection** setting.

The connectionstring should look like this:
"DefaultEndpointsProtocol=https;AccountName=saspluralsight;AccountKey=WCxWWe1q6w0EHByo+==;"
