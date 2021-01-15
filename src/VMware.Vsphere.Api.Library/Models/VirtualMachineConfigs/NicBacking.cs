namespace VMware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class NicBacking
    {
        public string DistributedPort { get; set; }
        public string Network { get; set; }
        public string NetworkName { get; set; }
        /// <summary>
        /// STANDARD_PORTGROUP, HOST_DEVICE, DISTRIBUTED_PORTGROUP, OPAQUE_NETWORK
        /// http://vmware.github.io/vsphere-automation-sdk-rest/6.5/operations/com/vmware/vcenter/vm/hardware/ethernet.get-operation.html
        /// </summary>
        public string Type { get; set; }
    }
}
