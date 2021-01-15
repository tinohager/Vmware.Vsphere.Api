namespace VMware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class ParallelPorts
    {
        public bool AllowGuestControl { get; set; }
        public ParallelPortsBacking Backing { get; set; }
        public bool StartConnected { get; set; }
    }
}
