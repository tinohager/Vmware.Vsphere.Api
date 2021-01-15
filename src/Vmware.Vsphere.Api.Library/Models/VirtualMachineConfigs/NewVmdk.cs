namespace Vmware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class NewVmdk
    {
        public long Capacity { get; set; }
        public string Name { get; set; }
        public StoragePolicy StoragePolicy { get; set; }
    }
}
