namespace Vmware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class Disk
    {
        public DiskBacking Backing { get; set; }
        public Ide Ide { get; set; }
        public NewVmdk NewVmdk { get; set; }
        public Sata Sata { get; set; }
        public Scsi Scsi { get; set; }
        public string Type { get; set; }
    }
}
