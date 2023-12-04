using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;

//1. Azure Authorization
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

//2. Get the resource group
string rgName = "myRG";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);

//3. Get the disk collection from the resource group
ManagedDiskCollection diskCollection = resourceGroup.GetManagedDisks();

//4. Get a list of the disks
await foreach (ManagedDiskResource disk in diskCollection.GetAllAsync())
{
    Console.WriteLine(disk.Data.Name);
}

