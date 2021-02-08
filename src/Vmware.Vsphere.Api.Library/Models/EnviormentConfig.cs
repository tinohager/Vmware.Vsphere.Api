namespace Vmware.Vsphere.Api.Library.Models
{
    public class EnviormentConfig
    {
        /// <summary>
        /// The Datastore on which the machine is created
        /// </summary>
        public string DatastoreName { get; set; }
        /// <summary>
        /// The ESX host on which the machine is created
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// The network to which the machine is connected
        /// </summary>
        public string NetworkName { get; set; }
    }
}
