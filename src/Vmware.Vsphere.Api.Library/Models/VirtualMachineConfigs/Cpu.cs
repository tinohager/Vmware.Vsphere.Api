namespace Vmware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class Cpu
    {
        public int CoresPerSocket { get; set; }
        public int Count { get; set; }
        public bool HotAddEnabled { get; set; }
        public bool HotRemoveEnabled { get; set; }
    }
}
