namespace Vmware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class Floppy
    {
        public bool AllowGuestControl { get; set; }
        public FloppyBacking Backing { get; set; }
        public bool StartConnected { get; set; }
    }
}
