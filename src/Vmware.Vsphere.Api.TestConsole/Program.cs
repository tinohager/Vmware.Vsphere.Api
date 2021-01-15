using System.Threading.Tasks;
using Vmware.Vsphere.Api.Library;
using Vmware.Vsphere.Api.Library.Models;
using Vmware.Vsphere.Api.Library.Models.VirtualMachineConfigs;

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
                var esxDatastoreName = "MyDatastoreName";
                var esxHostName = "MyEsxHost";

                var client = new VsphereClient(vcenterUrl);
                await client.LoginAsync(vcenterUser, vcenterPassword);

                var virtualMachineConfig = new SimpleVirtualMachineConfig
                {
                    Name = "MyUbuntuServer1",
                    GuestOs = GuestOs.UBUNTU_64,
                    Cpus = 2,
                    DiskSizeGB = 40,
                    MemorySizeGB = 4,
                    NetworkName = "NetworkName",
                    IsoFile = "[Raid-ESX2] ISO/ubuntu-20.04.1-live-server-amd64.iso",
                };

                await client.CreateVirtualMachineAsync(esxDatastoreName, esxHostName, virtualMachineConfig);

                await client.LogoutAsync();
            });

            task.Wait();
        }
    }
}
