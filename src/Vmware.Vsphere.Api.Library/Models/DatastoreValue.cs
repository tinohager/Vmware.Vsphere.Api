namespace Vmware.Vsphere.Api.Library.Models
{
    public class DatastoreValue
    {
        public string Datastore { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long FreeSpace { get; set; }
        public long Capacity { get; set; }
    }

}
