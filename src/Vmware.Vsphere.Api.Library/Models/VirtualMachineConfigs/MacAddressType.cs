namespace VMware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public enum MacAddressType
    {
        /// <summary>
        /// MAC address is assigned statically
        /// </summary>
        MANUAL,
        /// <summary>
        /// MAC address is generated automatically
        /// </summary>
        GENERATED,
        /// <summary>
        /// MAC address is assigned by vCenter Server
        /// </summary>
        ASSIGNED
    }
}
