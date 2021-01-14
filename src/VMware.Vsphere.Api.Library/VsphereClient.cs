using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VMware.Vsphere.Api.Library.Models;

namespace VMware.Vsphere.Api.Library
{
    public class VsphereClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public VsphereClient(string vcenterUrl)
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            this._jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            httpClientHandler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
            {
                return true;
            };

            var loggingHandler = new LoggingHandler(httpClientHandler);

            var httpClient = new HttpClient(loggingHandler);
            httpClient.BaseAddress = new Uri($"{vcenterUrl}/rest/");
            this._httpClient = httpClient;
        }

        public async Task<bool> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            var authToken = Encoding.ASCII.GetBytes($"{username}:{password}");
            var authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
            this._httpClient.DefaultRequestHeaders.Authorization = authHeader;

            var responseMessage = await this._httpClient.PostAsync($"com/vmware/cis/session", null, cancellationToken);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return false;
            }

            this._httpClient.DefaultRequestHeaders.Authorization = null;

            var json = await responseMessage.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<SessionTokenResponse>(json, this._jsonSerializerSettings);

            this._httpClient.DefaultRequestHeaders.Add("vmware-api-session-id", item.Value);
            return true;
        }

        public async Task<bool> LogoutAsync(CancellationToken cancellationToken = default)
        {
            var responseMessage = await this._httpClient.DeleteAsync($"com/vmware/cis/session", cancellationToken);
            return responseMessage.IsSuccessStatusCode;
        }

        private async Task<string> GetFolderAsync(CancellationToken cancellationToken = default)
        {
            var responseMessage = await this._httpClient.GetAsync($"vcenter/folder?filter.type=VIRTUAL_MACHINE", cancellationToken);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await responseMessage.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<FolderResponse>(json, this._jsonSerializerSettings);

            if (item.Value.Length == 0)
            {
                return null;
            }

            return item.Value[0].Folder;
        }

        private async Task<string> GetDatastoreAsync(string datastore, CancellationToken cancellationToken = default)
        {
            var responseMessage = await this._httpClient.GetAsync($"vcenter/datastore?filter.names={datastore}", cancellationToken);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await responseMessage.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<DatastoreResponse>(json, this._jsonSerializerSettings);

            if (item.Value.Length == 0)
            {
                return null;
            }

            return item.Value[0].Datastore;
        }

        private async Task<string> GetHostAsync(string host, CancellationToken cancellationToken = default)
        {
            var responseMessage = await this._httpClient.GetAsync($"vcenter/host?filter.names={host}", cancellationToken);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await responseMessage.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<HostResponse>(json, this._jsonSerializerSettings);

            if (item.Value.Length == 0)
            {
                return null;
            }

            return item.Value[0].Host;
        }

        public async Task<CreateVirtualMachineResponse> CreateVirtualMachineAsync(
            string datastoreName,
            string hostName,
            CancellationToken cancellationToken = default)
        {
            var folder = await this.GetFolderAsync(cancellationToken);
            if (folder == null)
            {
                return null;
            }

            var datastore = await this.GetDatastoreAsync(datastoreName, cancellationToken);
            var host = await this.GetHostAsync(hostName, cancellationToken);

            var virtualMachineConfig = new VirtualMachineConfig
            {
                Spec = new Spec
                {
                    GuestOs = "OTHER",
                    Cpu = new Cpu
                    {
                        CoresPerSocket = 2,
                        Count = 2,
                        HotAddEnabled = true
                    },
                    Placement = new Placement
                    {
                        Datastore = datastore,
                        Folder = folder,
                        Host = host
                    }
                }
            };

            var json = JsonConvert.SerializeObject(virtualMachineConfig, this._jsonSerializerSettings);

            var responseMessage = await this._httpClient.PostAsync($"vcenter/vm", new StringContent(json, Encoding.UTF8, "application/json"), cancellationToken);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            json = await responseMessage.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<CreateVirtualMachineResponse>(json, this._jsonSerializerSettings);

            return item;
        }
    }
}
