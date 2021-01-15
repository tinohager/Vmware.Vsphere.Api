namespace VMware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
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
}
