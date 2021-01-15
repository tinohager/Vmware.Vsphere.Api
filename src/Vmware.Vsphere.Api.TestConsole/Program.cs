using System.Threading.Tasks;
using Vmware.Vsphere.Api.Library;

namespace Vmware.Vsphere.Api.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Run(async () =>
            {
                var vcenterUrl = "https://vcenter01.domain.local";
                var vcenterUser = "administrator@vsphere.local";
                var vcenterPassword = "";
                var datastoreName = "MyDatastoreName";
                var hostName = "MyEsxHost";

                var client = new VsphereClient(vcenterUrl);
                await client.LoginAsync(vcenterUser, vcenterPassword);

                await client.CreateVirtualMachineAsync(datastoreName, hostName);

                await client.LogoutAsync();
            });

            task.Wait();
        }
    }
}
