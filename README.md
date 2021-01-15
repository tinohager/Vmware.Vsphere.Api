# Vmware.Vsphere.Api
VMware vSphere 7 - Create Virtual Machine over the vSphere API

```cs
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
```
