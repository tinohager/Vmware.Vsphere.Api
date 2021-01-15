using Vmware.Vsphere.Api.Library.Models.VirtualMachineConfigs;

namespace Vmware.Vsphere.Api.Library.Models
{
    public class SimpleVirtualMachineConfig
    {
        public string Name { get; set; }
        public GuestOs GuestOs { get; set; }

        public int Cpus { get; set; }

        public int MemorySizeGB { get; set; }
        public int DiskSizeGB { get; set; }
        /// <summary>
        /// Location of the ISO Image requires the following format
        /// `[DatastoreName] Folder/IsoFile`
        /// e.g. `[Raid-ESX2] ISO/ubuntu-20.04.1-live-server-amd64.iso`
        /// </summary>
        public string IsoFile { get; set; }
        public string NetworkName { get; set; }
    }
}
