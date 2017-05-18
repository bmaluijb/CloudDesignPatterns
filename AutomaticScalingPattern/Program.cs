using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using System;
using System.Linq;

namespace AutomaticScalingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IAzure azure = Authenticate();

            //get the first plan in the list (I assume that there is one plan)
            var plan = azure.AppServices.AppServicePlans.List().First();

            //scale back to "Basic" on the weekend
            if (plan.PricingTier.SkuDescription.Tier != "Basic" &&
                (DateTime.Now.DayOfWeek == DayOfWeek.Saturday ||
                DateTime.Now.DayOfWeek == DayOfWeek.Sunday))
            {
                plan.Update()
                .WithPricingTier(new PricingTier("Basic", "B1"))
                .Apply();
            }
            //otherwise scale up to Standard
            else if (plan.PricingTier.SkuDescription.Tier != "Standard")
            {
                plan.Update()
                .WithPricingTier(new PricingTier("Standard", "S1"))
                .Apply();
            }

            plan.Update()
                .WithCapacity(plan.Capacity * 2)
                .Apply();
        }

        private static IAzure Authenticate()
        {         
         //https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal

            var servicePrincipal = new ServicePrincipalLoginInformation();
            servicePrincipal.ClientId = "c60c8d66-caab-4359-9e1d-27e3b73fa42c";
            servicePrincipal.ClientSecret = "dBB45loRs1uc0yZjiXfIrMXPm3CvL5tOEMWv10MH5Hc=";

            AzureCredentials credentials = 
                new AzureCredentials(servicePrincipal, "f988fbf0-6866-43df-8926-e451715257e8"
                , AzureEnvironment.AzureGlobalCloud);

            IAzure azure = Azure.Authenticate(credentials).WithDefaultSubscription();
            return azure;
        }
    }
}
