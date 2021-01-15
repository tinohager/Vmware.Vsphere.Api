using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VMware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class Spec
    {
        public Boot Boot { get; set; }
        public BootDevices[] BootDevices { get; set; }
        public Cdrom[] Cdroms { get; set; }
        public Cpu Cpu { get; set; }
        public Disk[] Disks { get; set; }
        public Floppy[] Floppies { get; set; }
        [JsonProperty("guest_OS")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GuestOs GuestOs { get; set; }
        public string HardwareVersion { get; set; }
        public Memory Memory { get; set; }
        public string Name { get; set; }
        public Nic[] Nics { get; set; }
        public ParallelPorts[] ParallelPorts { get; set; }
        public Placement Placement { get; set; }
        public SataAdapters[] SataAdapters { get; set; }
        public ScsiAdapters[] ScsiAdapters { get; set; }
        public SerialPorts[] SerialPorts { get; set; }
        public StoragePolicy StoragePolicy { get; set; }
    }
}
