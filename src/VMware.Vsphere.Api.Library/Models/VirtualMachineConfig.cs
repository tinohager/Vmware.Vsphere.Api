using Newtonsoft.Json;

namespace VMware.Vsphere.Api.Library.Models
{
    public class VirtualMachineConfig
    {
        public Spec Spec { get; set; }
    }

    public class Spec
    {
        public Boot Boot { get; set; }
        public Boot_Devices[] BootDevices { get; set; }
        public Cdrom[] Cdroms { get; set; }
        public Cpu Cpu { get; set; }
        public Disk[] Disks { get; set; }
        public Floppy[] Floppies { get; set; }
        [JsonProperty("guest_OS")]
        public string GuestOs { get; set; }
        public string HardwareVersion { get; set; }
        public Memory Memory { get; set; }
        public string Name { get; set; }
        public Nic[] Nics { get; set; }
        public Parallel_Ports[] ParallelPorts { get; set; }
        public Placement Placement { get; set; }
        public Sata_Adapters[] SataAdapters { get; set; }
        public Scsi_Adapters[] ScsiAdapters { get; set; }
        public Serial_Ports[] SerialPorts { get; set; }
        public Storage_Policy StoragePolicy { get; set; }
    }

    public class Boot
    {
        /// <summary>
        /// Delay (Optional)
        /// </summary>
        public int Delay { get; set; }
        /// <summary>
        /// Optional
        /// </summary>
        public bool EfiLegacyBoot { get; set; }
        public bool EnterSetupMode { get; set; }
        public string NetworkProtocol { get; set; }
        public bool Retry { get; set; }
        public int RetryDelay { get; set; }
        public string Type { get; set; }
    }

    public class Cpu
    {
        public int CoresPerSocket { get; set; }
        public int Count { get; set; }
        public bool HotAddEnabled { get; set; }
        public bool HotRemoveEnabled { get; set; }
    }

    public class Memory
    {
        public bool HotAddEnabled { get; set; }
        [JsonProperty("size_MiB")]
        public int SizeMiB { get; set; }
    }

    public class Placement
    {
        public string Cluster { get; set; }
        public string Datastore { get; set; }
        public string Folder { get; set; }
        public string Host { get; set; }
        public string ResourcePool { get; set; }
    }

    public class Storage_Policy
    {
        public string Policy { get; set; }
    }

    public class Boot_Devices
    {
        public string Type { get; set; }
    }

    public class Cdrom
    {
        public bool allow_guest_control { get; set; }
        public Backing backing { get; set; }
        public Ide ide { get; set; }
        public Sata sata { get; set; }
        public bool start_connected { get; set; }
        public string type { get; set; }
    }

    public class Backing
    {
        public string device_access_type { get; set; }
        public string host_device { get; set; }
        public string iso_file { get; set; }
        public string type { get; set; }
    }

    public class Ide
    {
        public bool master { get; set; }
        public bool primary { get; set; }
    }

    public class Sata
    {
        public int bus { get; set; }
        public int unit { get; set; }
    }

    public class Disk
    {
        public Backing1 backing { get; set; }
        public Ide1 ide { get; set; }
        public New_Vmdk new_vmdk { get; set; }
        public Sata1 sata { get; set; }
        public Scsi scsi { get; set; }
        public string type { get; set; }
    }

    public class Backing1
    {
        public string type { get; set; }
        public string vmdk_file { get; set; }
    }

    public class Ide1
    {
        public bool master { get; set; }
        public bool primary { get; set; }
    }

    public class New_Vmdk
    {
        public int capacity { get; set; }
        public string name { get; set; }
        public Storage_Policy1 storage_policy { get; set; }
    }

    public class Storage_Policy1
    {
        public string policy { get; set; }
    }

    public class Sata1
    {
        public int bus { get; set; }
        public int unit { get; set; }
    }

    public class Scsi
    {
        public int bus { get; set; }
        public int unit { get; set; }
    }

    public class Floppy
    {
        public bool allow_guest_control { get; set; }
        public Backing2 backing { get; set; }
        public bool start_connected { get; set; }
    }

    public class Backing2
    {
        public string host_device { get; set; }
        public string image_file { get; set; }
        public string type { get; set; }
    }

    public class Nic
    {
        public bool allow_guest_control { get; set; }
        public Backing3 backing { get; set; }
        public string mac_address { get; set; }
        public string mac_type { get; set; }
        public int pci_slot_number { get; set; }
        public bool start_connected { get; set; }
        public string type { get; set; }
        public bool upt_compatibility_enabled { get; set; }
        public bool wake_on_lan_enabled { get; set; }
    }

    public class Backing3
    {
        public string distributed_port { get; set; }
        public string network { get; set; }
        public string type { get; set; }
    }

    public class Parallel_Ports
    {
        public bool allow_guest_control { get; set; }
        public Backing4 backing { get; set; }
        public bool start_connected { get; set; }
    }

    public class Backing4
    {
        public string file { get; set; }
        public string host_device { get; set; }
        public string type { get; set; }
    }

    public class Sata_Adapters
    {
        public int bus { get; set; }
        public int pci_slot_number { get; set; }
        public string type { get; set; }
    }

    public class Scsi_Adapters
    {
        public int bus { get; set; }
        public int pci_slot_number { get; set; }
        public string sharing { get; set; }
        public string type { get; set; }
    }

    public class Serial_Ports
    {
        public bool allow_guest_control { get; set; }
        public Backing5 backing { get; set; }
        public bool start_connected { get; set; }
        public bool yield_on_poll { get; set; }
    }

    public class Backing5
    {
        public string file { get; set; }
        public string host_device { get; set; }
        public string network_location { get; set; }
        public bool no_rx_loss { get; set; }
        public string pipe { get; set; }
        public string proxy { get; set; }
        public string type { get; set; }
    }
}
