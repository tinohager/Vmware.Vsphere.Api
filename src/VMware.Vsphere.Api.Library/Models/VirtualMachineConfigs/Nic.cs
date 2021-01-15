using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VMware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class Nic
    {
        public bool AllowGuestControl { get; set; }
        public NicBacking Backing { get; set; }
        public string MacAddress { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MacAddressType MacType { get; set; }
        public int PciSlotNumber { get; set; }
        public bool StartConnected { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EthernetAdapterEmulationType Type { get; set; }
        public bool UptCompatibilityEnabled { get; set; }
        public bool WakeOnLanEnabled { get; set; }
    }
}
