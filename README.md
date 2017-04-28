# CloudDesignPatterns

![enter image description here](https://www.pluralsight.com/content/dam/pluralsight/newsroom/brand-assets/logos/pluralsight-logo-vrt-color-2.png)  

Hi! 

Welcome to the GitHub repository of the cloud design patterns.
This repository contains the examples for the Pluralsight course series: [Cloud Design Patterns for Azure](https://app.pluralsight.com/profile/author/barry-luijbregts).

The repository will keep growing until all of the courses of the series are released.

The solution consists of:

 - RuntimeReconfigurationPattern
	 - ASP.NET Core MVC 1.1 Web Application
   - The pattern is implemented in
      - Startup.cs class
      - HomeController.cs
 - ValetKeyPattern
	 - ASP.NET Core MVC 1.1 Web Application
   - The pattern is implemented in 
      - AzureStorage/CORSConfigurator.cs
      - Controllers/SasController.cs
      - Views/Upload.cshtml
- CircuitBreakerPattern
 	- .NET 4.5.2 Concole Application
  - The pattern is implemented in
    - All classes in the CircuitBreaker folder
    - Program.cs

All of the projects can be run independently. 

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

**Running the ValetKeyPattern project**

To run the ValetKeyPattern project, you need an Azure Storage account. Find out more [here](https://www.youtube.com/watch?v=tSGSfOAiNrw).
When you have one, you need to put the connectionstring for the storage account in either the **appsettings.json** or **appsettings.development.json** file, in the **AzureStorageConnection** setting.

It should look like this: "DefaultEndpointsProtocol=https;AccountName=saspluralsight;AccountKey=WCxWWe1q6w0EHByo+==;"


