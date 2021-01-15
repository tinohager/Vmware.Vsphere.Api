namespace VMware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class Cdrom
    {
        public bool AllowGuestControl { get; set; }
        public CdromBacking Backing { get; set; }
        public Ide Ide { get; set; }
        public Sata Sata { get; set; }
        public bool StartConnected { get; set; }
        public string Type { get; set; }
    }
}
