namespace VMware.Vsphere.Api.Library.Models.VirtualMachineConfigs
{
    public class Placement
    {
        public string Cluster { get; set; }
        public string Datastore { get; set; }
        public string Folder { get; set; }
        public string Host { get; set; }
        public string ResourcePool { get; set; }
    }
}
