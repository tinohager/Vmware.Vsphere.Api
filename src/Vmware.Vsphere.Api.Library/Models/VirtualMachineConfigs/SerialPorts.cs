namespace VMware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class SerialPorts
    {
        public bool AllowGuestControl { get; set; }
        public SerialPortBacking Backing { get; set; }
        public bool StartConnected { get; set; }
        public bool YieldOnPoll { get; set; }
    }
}
