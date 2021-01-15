namespace VMware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class SerialPortBacking
    {
        public string File { get; set; }
        public string HostDevice { get; set; }
        public string NetworkLocation { get; set; }
        public bool NoRxLoss { get; set; }
        public string Pipe { get; set; }
        public string Proxy { get; set; }
        public string Type { get; set; }
    }
}
