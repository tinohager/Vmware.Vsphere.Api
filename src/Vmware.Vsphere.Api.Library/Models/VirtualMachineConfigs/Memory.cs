using Newtonsoft.Json;

namespace Vmware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class Memory
    {
        public bool HotAddEnabled { get; set; }
        [JsonProperty("size_MiB")]
        public int SizeMiB { get; set; }
    }
}
