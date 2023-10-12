using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using HaTool.Config;
using HaTool.Global;
using CsLib;
using Newtonsoft.Json;
using HaTool.Model.NCloud;
using LogClient;
using Newtonsoft.Json.Linq;
using HaTool.Model;
using System.Text.RegularExpressions;
using HaTool.Server;

namespace HaTool.HighAvailability
{
    public partial class UcLoadBalancer : UserControl
    {
        private static readonly Lazy<UcLoadBalancer> lazy =
            new Lazy<UcLoadBalancer>(() => new UcLoadBalancer(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static UcLoadBalancer Instance { get { return lazy.Value; } }

        LogClient.Config logClientConfig = LogClient.Config.Instance;
        DataManager dataManager = DataManager.Instance;
        FileDb fileDb = FileDb.Instance;
        string checkedDomainName = string.Empty;
        string checkedLBName = string.Empty; 

        List<loadBalancerInstance> loadBalancerInstances = new List<loadBalancerInstance>();
        

        DataGridViewCheckBoxColumn ColumnLbCheckBox;
        DataGridViewTextBoxColumn  ColumnLbName;
        DataGridViewTextBoxColumn  ColumnLbZoneNo;
        DataGridViewTextBoxColumn  ColumnLbInstanceNo;
        DataGridViewTextBoxColumn  ColumnLbProtocol;
        DataGridViewTextBoxColumn  ColumnLbDomainName;
        DataGridViewTextBoxColumn  ColumnLbStatus;
        DataGridViewTextBoxColumn  ColumnLbOperation;

        FormPreview formPreview = FormPreview.Instance;

        public string Sp_configure { get; set; }

        public string PsTemplate { get; set; }
        public string psTemplateChanged { get; set; }

        private loadBalancerInstance checkedLoadBalancerInstance;
        string checkedLoadBalancerInstanceNo = string.Empty; 
        private void InitDgv()
        {
            ColumnLbCheckBox      = new DataGridViewCheckBoxColumn();
            ColumnLbName          = new DataGridViewTextBoxColumn();
            ColumnLbZoneNo        = new DataGridViewTextBoxColumn();
            ColumnLbInstanceNo    = new DataGridViewTextBoxColumn();
            ColumnLbProtocol      = new DataGridViewTextBoxColumn();
            ColumnLbDomainName     = new DataGridViewTextBoxColumn();
            ColumnLbStatus        = new DataGridViewTextBoxColumn();
            ColumnLbOperation     = new DataGridViewTextBoxColumn();

            ColumnLbCheckBox.HeaderText   = "CheckBox";
            ColumnLbName.HeaderText       = "Name";
            ColumnLbZoneNo.HeaderText     = "ZoneNo";
            ColumnLbInstanceNo.HeaderText = "InstanceNo";
            ColumnLbProtocol.HeaderText   = "Protocol";
            ColumnLbDomainName.HeaderText  = "DomainName";
            ColumnLbStatus.HeaderText     = "Status";
            ColumnLbOperation.HeaderText  = "Operation";
            
            ColumnLbCheckBox.Name     = "CheckBox";
            ColumnLbName.Name         = "Name";
            ColumnLbZoneNo.Name       = "ZoneNo";
            ColumnLbInstanceNo.Name   = "InstanceNo";
            ColumnLbProtocol.Name     = "Protocol";
            ColumnLbDomainName.Name    = "DomainName";
            ColumnLbStatus.Name       = "Status";
            ColumnLbOperation.Name    = "Operation";


            dgvloadBalancerList.Columns.AddRange(new DataGridViewColumn[]
            {
                ColumnLbCheckBox,
                ColumnLbName,
                ColumnLbZoneNo,
                ColumnLbInstanceNo,
                ColumnLbProtocol,
                ColumnLbDomainName,
                ColumnLbStatus,
                ColumnLbOperation
            });



            dgvloadBalancerList.AllowUserToAddRows = false;
            dgvloadBalancerList.RowHeadersVisible = false;
            dgvloadBalancerList.BackgroundColor = Color.White;
            dgvloadBalancerList.AutoResizeColumns();
            dgvloadBalancerList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvloadBalancerList.Columns["Operation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvloadBalancerList.AllowUserToResizeRows = false;

            ControlHelpers.dgvDesign(dgvloadBalancerList);
            dgvloadBalancerList.CellContentClick += new DataGridViewCellEventHandler(ControlHelpers.dgvSingleCheckBox);
            dgvloadBalancerList.CellContentClick += new DataGridViewCellEventHandler(ControlHelpers.dgvLineColorChange);

        }

        public UcLoadBalancer()
        {
            InitializeComponent();
            InitDgv();
        }


        private async Task loadBalancerListLoad()
        {
            
            
            try
            {
                ControlHelpers.ButtonStatusChange(buttonLoadBalancerListReload, "Requested");
                await fileDb.ReadTable(FileDb.TableName.TBL_CLUSTER);
                List<string> instanceNoList = new List<string>();
                List<string> deleteLbNameList = new List<string>();

                foreach (var a in fileDb.TBL_CLUSTER.Data)
                {
                    if (a.Value.clusterNo != "NULL")
                        instanceNoList.Add(a.Value.clusterNo);
                }

                await GetLoadBalancerInstanceList(instanceNoList);
                dgvloadBalancerList.InvokeIfRequired(async s =>
                {
                    try
                    {

                        s.Rows.Clear();
                        foreach (var a in fileDb.TBL_CLUSTER.Data)
                        {

                            var lbInstance = loadBalancerInstances.Find(x => x.loadBalancerName == a.Key.clusterName);
                            if (lbInstance != null)
                            {
                                string zones = string.Empty;
                                string comma = string.Empty;
                                /*
                                foreach (var z in lbInstance.zoneList)
                                {
                                    if (zones.Length == 0)
                                        comma = "";
                                    else
                                        comma = ",";

                                    zones = zones + comma + $"{z.zoneNo}({z.zoneCode})";
                                }
                                
                                string protocols = string.Empty;

                                foreach (var p in lbInstance.loadBalancerRuleList)
                                {
                                    if (protocols.Length == 0)
                                        comma = "";
                                    else
                                        comma = ",";

                                    protocols = protocols + comma + p.protocolType.code;
                                }
                                */
                                
                                int n = s.Rows.Add();
                                s.Rows[n].Cells["CheckBox"].Value = false;
                                s.Rows[n].Cells["Name"].Value = a.Key.clusterName;
                                s.Rows[n].Cells["ZoneNo"].Value = lbInstance.regionCode;
                                s.Rows[n].Cells["InstanceNo"].Value = lbInstance.loadBalancerInstanceNo;
                                s.Rows[n].Cells["Protocol"].Value = "TCP"; // force L4 LB only - TCP inline
                                s.Rows[n].Cells["DomainName"].Value = lbInstance.loadBalancerDomain;
                                s.Rows[n].Cells["Status"].Value = lbInstance.loadBalancerInstanceStatus.code;
                                s.Rows[n].Cells["Operation"].Value = lbInstance.loadBalancerInstanceOperation.code;
                            }
                            else
                            {
                                deleteLbNameList.Add(a.Key.clusterName);
                            }
                        }

                        foreach (var a in deleteLbNameList)
                        {
                            var p = new List<KeyValuePair<string, string>>();
                            p.Add(new KeyValuePair<string, string>("clusterName", a));
                            await fileDb.DeleteTable(FileDb.TableName.TBL_CLUSTER, p);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
            catch (Exception)
            {
                throw; 
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonLoadBalancerListReload, "Reload");
            }
        }

        private async Task GetLoadBalancerInstanceList(List<string> instanceNoList)
        {
            try
            {
                //if (instanceNoList.Count == 0)
                //    return;

                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vloadbalancer/v2/getLoadBalancerInstanceList";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));

                int i = 0; 
                /*
                foreach (var instanceNo in instanceNoList)
                {
                    i++;
                    string loadBalancerInstanceNoListKey = "loadBalancerInstanceNoList." + i;
                    string loadBalancerInstanceNoListValue = instanceNo;
                    parameters.Add(new KeyValuePair<string, string>(loadBalancerInstanceNoListKey, loadBalancerInstanceNoListValue));
                }
                */
                
                SoaCall soaCall = new SoaCall();
                var task = soaCall.WebApiCall(endpoint, RequestType.POST, action, parameters, LogClient.Config.Instance.GetValue(Category.Api, Key.AccessKey), LogClient.Config.Instance.GetValue(Category.Api, Key.SecretKey));
                string response = await task;

                JsonSerializerSettings options = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                if (response.Contains("responseError"))
                {
                    hasError hasError = JsonConvert.DeserializeObject<hasError>(response, options);
                    throw new Exception(hasError.responseError.returnMessage);
                }
                else
                {
                    getLoadBalancerInstanceList getLoadBalancerInstanceList = JsonConvert.DeserializeObject<getLoadBalancerInstanceList>(response, options);
                    if (getLoadBalancerInstanceList.getLoadBalancerInstanceListResponse.returnCode.Equals("0"))
                    {
                        loadBalancerInstances.Clear();
                        foreach (var a in getLoadBalancerInstanceList.getLoadBalancerInstanceListResponse.loadBalancerInstanceList)
                        {
                            var item = new loadBalancerInstance
                            {
                                loadBalancerName = a.loadBalancerName,
                                regionCode = a.regionCode,
                                loadBalancerInstanceNo = a.loadBalancerInstanceNo,
                                //loadBalancerRuleList = a.loadBalancerRuleList,
                                loadBalancerDomain = a.loadBalancerDomain,
                                loadBalancerInstanceStatus = a.loadBalancerInstanceStatus,
                                loadBalancerInstanceOperation = a.loadBalancerInstanceOperation
                            };
                            loadBalancerInstances.Add(item);
                        }
                        if (getLoadBalancerInstanceList.getLoadBalancerInstanceListResponse.totalRows == 0)
                        {
                            MessageBox.Show("loadbalancer not founds");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void ComboBoxRegionChanged(object sender, EventArgs e)
        {
            //deprecated
        }


        private async void LoadData(object sender, EventArgs e)
        {
            try
            {
                dataManager.LoadUserData();
                List<Task> tasks = new List<Task>();
                tasks.Add(loadBalancerListLoad());
                await Task.WhenAll(tasks);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static Dictionary<string, string> ReadPowerShell(string queryAll)
        {
            Dictionary<string, string> querys = new Dictionary<string, string>();
            try
            {

                string query = string.Empty;
                string cmd = string.Empty;
                string[] lines = Regex.Split(queryAll, Environment.NewLine);
                foreach (string line in lines)
                {

                    if (line.Trim().StartsWith("###"))
                    {
                        if (query.Trim() != "")
                        {
                            querys.Add(cmd, query);
                        }
                        cmd = line;
                        query = string.Empty;
                    }
                    else
                    {
                        if (line != "")
                        {
                            query = query + Environment.NewLine + line;
                        }
                    }
                }
                if (query.Trim() != "")
                    querys.Add(cmd, query);
            }
            catch (Exception)
            {
                throw;
            }
            return querys;
        }


        private async Task<WcfResponse> Execute(string psSubject, string psCmd, string serverIp)
        {
            StringBuilder resultMessageBackup = new StringBuilder();
            WcfResponse wcfResponse = new WcfResponse();
            try
            {

                var task = Execute
                ("ExecuterPs"
                , "out-string"
                , psCmd
                , CsLib.RequestType.POST
                , $"https://{serverIp}:9090"
                , @"/LazyServer/LazyCommand/PostCmd"
                , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey)
                , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey));
                string response = await task;
                wcfResponse = JsonConvert.DeserializeObject<WcfResponse>(response);
            }
            catch (Exception)
            {
                throw; 
            }
            return wcfResponse;
        }

        private async Task<string> Execute(string cmd, string cmdType, string cmdText, CsLib.RequestType type, string endPoint, string action, string accessKey, string secretKey)
        {
            var json = new 
            {
                cmd,
                cmdType,
                cmdText = TranString.EncodeBase64Unicode(cmdText)
            };

            string responseString = string.Empty;
            try
            {
                string jsonCmd = JsonConvert.SerializeObject(json);
                Task<string> response = new SoaCall().WebApiCall(
                    endPoint,
                    type,
                    action,
                    jsonCmd,
                    accessKey,
                    secretKey
                    );
                string temp = await response;
                if (temp.Length > 0)
                {
                    JToken jt = JToken.Parse(temp);
                    responseString = jt.ToString(Newtonsoft.Json.Formatting.Indented);
                }
                else
                    responseString = "response is empty...";
            }
            catch (Exception ex)
            {
                responseString = ex.Message;
            }
            return responseString;
        }
        
        private async void buttonLoadBalancerListReload_Click(object sender, EventArgs e)
        {
            try
            {
                await loadBalancerListLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task<string> GetLoadBalancerInfo(string instanceNo)
        {
            string loadBalancerInstanceInfo = string.Empty;
            
            try
            {
                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vloadbalancer/v2/getLoadBalancerInstanceDetail";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));
                parameters.Add(new KeyValuePair<string, string>("loadBalancerInstanceNo", instanceNo));

                SoaCall soaCall = new SoaCall();
                var task = soaCall.WebApiCall(endpoint, RequestType.POST, action, parameters, LogClient.Config.Instance.GetValue(Category.Api, Key.AccessKey), LogClient.Config.Instance.GetValue(Category.Api, Key.SecretKey));
                string response = await task;

                JsonSerializerSettings options = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                if (response.Contains("responseError"))
                {
                    hasError hasError = JsonConvert.DeserializeObject<hasError>(response, options);
                    throw new Exception(hasError.responseError.returnMessage);
                }
                else
                {
                    getLoadBalancerInstanceList getLoadBalancerInstanceList = JsonConvert.DeserializeObject<getLoadBalancerInstanceList>(response, options);
                    if (getLoadBalancerInstanceList.getLoadBalancerInstanceListResponse.returnCode.Equals("0"))
                    {
                        foreach (var lbi in getLoadBalancerInstanceList.getLoadBalancerInstanceListResponse.loadBalancerInstanceList)
                        {
                            loadBalancerInstanceInfo = JsonConvert.SerializeObject(lbi);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return loadBalancerInstanceInfo;
        }


        private async void buttonShowLBDetail_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelpers.ButtonStatusChange(buttonShowLBDetail, "Requested");
                string checkedLoadBalancerInstanceNo = string.Empty;
                int checkBoxCount = 0;
                foreach (DataGridViewRow item in dgvloadBalancerList.Rows)
                {
                    if (bool.Parse(item.Cells["CheckBox"].Value.ToString()))
                    {
                        checkBoxCount++;
                        checkedLoadBalancerInstanceNo = item.Cells["InstanceNo"].Value.ToString().Trim();
                    }
                }
                if (checkBoxCount != 1)
                    throw new Exception("select load balancer");

                formPreview.GroupBoxText = "Load Balancer Info";

                Task<string> task = GetLoadBalancerInfo(checkedLoadBalancerInstanceNo);

                JToken jt = JToken.Parse(await task);
                formPreview.Script = jt.ToString(Newtonsoft.Json.Formatting.Indented);
                formPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonShowLBDetail, "Show Detail");
            }
        }


        private async void buttonServerListReload_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelpers.ButtonStatusChange(buttonServerListReload, "Requested");
                await ServerListReload();
                string selectedLoadBalancerName = CheckedLoadBalancerName();
                await LoadClusterServerInfo(selectedLoadBalancerName);
                MessageBox.Show("HA Allocation Server Info Loaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonServerListReload, "Load HA Info");
            }
        }

        private async Task LoadClusterServerInfo(string loadBalancerName)
        {
            try
            {
                string masterServerName = "";
                string slaveServerName = "";

                await fileDb.ReadTable(FileDb.TableName.TBL_CLUSTER_SERVER);
                foreach (var a in fileDb.TBL_CLUSTER_SERVER.Data)
                {
                    if (a.Key.clusterName.Equals(loadBalancerName, StringComparison.OrdinalIgnoreCase) && a.Value.serverRole.Equals("MASTER", StringComparison.OrdinalIgnoreCase))
                        masterServerName = a.Key.serverName;
                    if (a.Key.clusterName.Equals(loadBalancerName, StringComparison.OrdinalIgnoreCase) && a.Value.serverRole.Equals("SLAVE", StringComparison.OrdinalIgnoreCase))
                        slaveServerName = a.Key.serverName;
                }

                comboBoxMasterServer.Text = masterServerName;
                comboBoxSlaveServer.Text = slaveServerName;

            }
            catch (Exception)
            {
                throw; 
            }
        }

        private async Task ServerListReload()
        {
            try
            {
                await fileDb.ReadTable(FileDb.TableName.TBL_SERVER);
                await fileDb.ReadTable(FileDb.TableName.TBL_CLUSTER_SERVER);
                comboBoxMasterServer.Items.Clear();
                comboBoxSlaveServer.Items.Clear();
                foreach (var a in fileDb.TBL_SERVER.Data)
                {
                    var item = new serverInstance
                    {
                        serverName = a.Key.serverName,
                        serverInstanceNo = a.Value.serverInstanceNo,
                        publicIp = a.Value.serverPublicIp,
                        privateIp = a.Value.serverPrivateIp
                    };
                    comboBoxMasterServer.Items.Add(item);
                    comboBoxSlaveServer.Items.Add(item);

                }
                if (comboBoxMasterServer.Items.Count > 0)
                    comboBoxMasterServer.SelectedIndex = 0;
                if (comboBoxMasterServer.Items.Count > 2)
                    comboBoxSlaveServer.SelectedIndex = 1;
            }
            catch (Exception)
            {
                throw;
            }
        }



        private async Task SaveClusterServerInfo(string loadBalancerName)
        {
            try
            {
                await fileDb.ReadTable(FileDb.TableName.TBL_CLUSTER_SERVER);
                List<Tuple<string, string>> tempClusterServer = new List<Tuple<string, string>>();

                foreach (var a in fileDb.TBL_CLUSTER_SERVER.Data)
                    tempClusterServer.Add(new Tuple<string, string>(a.Key.clusterName, a.Key.serverName));

                foreach (var a in tempClusterServer)
                {
                    if (a.Item1.Equals(loadBalancerName, StringComparison.OrdinalIgnoreCase))
                    {
                        var p = new List<KeyValuePair<string, string>>();
                        p.Add(new KeyValuePair<string, string>("clusterName", a.Item1));
                        p.Add(new KeyValuePair<string, string>("serverName", a.Item2));
                        await fileDb.DeleteTable(FileDb.TableName.TBL_CLUSTER_SERVER, p);
                    }
                }

                if (comboBoxMasterServer.Text.Length > 0)
                {
                    var clusterServerInfo = new List<KeyValuePair<string, string>>();
                    clusterServerInfo.Add(new KeyValuePair<string, string>("clusterName", loadBalancerName));
                    clusterServerInfo.Add(new KeyValuePair<string, string>("serverName", comboBoxMasterServer.Text.Trim()));
                    clusterServerInfo.Add(new KeyValuePair<string, string>("serverRole", "MASTER"));
                    await fileDb.UpSertTable(FileDb.TableName.TBL_CLUSTER_SERVER, clusterServerInfo);
                }

                if (comboBoxSlaveServer.Text.Length > 0)
                {
                    var clusterServerInfo = new List<KeyValuePair<string, string>>();
                    clusterServerInfo.Add(new KeyValuePair<string, string>("clusterName", loadBalancerName));
                    clusterServerInfo.Add(new KeyValuePair<string, string>("serverName", comboBoxSlaveServer.Text.Trim()));
                    clusterServerInfo.Add(new KeyValuePair<string, string>("serverRole", "SLAVE"));
                    await fileDb.UpSertTable(FileDb.TableName.TBL_CLUSTER_SERVER, clusterServerInfo);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string CheckedLoadBalancerName()
        {
            string loadBalancerName = string.Empty; 
            try
            {
                int checkBoxCount = 0; 
                foreach (DataGridViewRow item in dgvloadBalancerList.Rows)
                {
                    if (bool.Parse(item.Cells["CheckBox"].Value.ToString()))
                    {
                        checkBoxCount++;
                        loadBalancerName = item.Cells["Name"].Value.ToString().Trim();
                    }
                }
                if (checkBoxCount != 1)
                    throw new Exception("check one load balancer");
            }
            catch (Exception)
            {
                throw;
            }
            return loadBalancerName;
        }

        private string CheckedLoadBalancerInstanceNo()
        {
            string loadBalancerName = string.Empty;
            try
            {
                int checkBoxCount = 0;
                foreach (DataGridViewRow item in dgvloadBalancerList.Rows)
                {
                    if (bool.Parse(item.Cells["CheckBox"].Value.ToString()))
                    {
                        checkBoxCount++;
                        loadBalancerName = item.Cells["InstanceNo"].Value.ToString().Trim();
                    }
                }
                if (checkBoxCount != 1)
                    throw new Exception("check one load balancer");
            }
            catch (Exception)
            {
                throw;
            }
            return loadBalancerName;
        }

        private string IsOneCheckedLoadBalancerListReturnLBInstanceNo()
        {
            string loadBalancerInstanceNo = string.Empty;
            try
            {
                int checkBoxCount = 0;
                foreach (DataGridViewRow item in dgvloadBalancerList.Rows)
                {
                    if (bool.Parse(item.Cells["CheckBox"].Value.ToString()))
                    {
                        checkBoxCount++;
                        loadBalancerInstanceNo = item.Cells["InstanceNo"].Value.ToString().Trim();
                    }
                }
                if (checkBoxCount != 1)
                    throw new Exception("check one load balancer");
            }
            catch (Exception)
            {
                throw;
            }
            return loadBalancerInstanceNo;
        }

        private async Task DeleteClusterServerInfo(string loadBalancerName)
        {
            await fileDb.ReadTable(FileDb.TableName.TBL_CLUSTER_SERVER);
            List<Tuple<string, string>> tempClusterServer = new List<Tuple<string, string>>();

            foreach (var a in fileDb.TBL_CLUSTER_SERVER.Data)
                tempClusterServer.Add(new Tuple<string, string>(a.Key.clusterName, a.Key.serverName));

            foreach (var a in tempClusterServer)
            {
                if (a.Item1.Equals(loadBalancerName, StringComparison.OrdinalIgnoreCase))
                {
                    var p = new List<KeyValuePair<string, string>>();
                    p.Add(new KeyValuePair<string, string>("clusterName", a.Item1));
                    p.Add(new KeyValuePair<string, string>("serverName", a.Item2));
                    await fileDb.DeleteTable(FileDb.TableName.TBL_CLUSTER_SERVER, p);
                }
            }
        }


        private async Task DbDelete(string loadBalancerName)
        {
            try
            {
                await fileDb.ReadTable(FileDb.TableName.TBL_CLUSTER_SERVER);
                await fileDb.ReadTable(FileDb.TableName.TBL_CLUSTER);

                List<string> tempClusters = new List<string>();

                foreach (var a in fileDb.TBL_CLUSTER.Data)
                    tempClusters.Add(a.Key.clusterName);

                foreach (var a in tempClusters)
                {
                    if (a.Equals(loadBalancerName, StringComparison.OrdinalIgnoreCase))
                    {
                        var p = new List<KeyValuePair<string, string>>();
                        p.Add(new KeyValuePair<string, string>("clusterName", a));
                        await fileDb.DeleteTable(FileDb.TableName.TBL_CLUSTER, p);
                    }
                }

                List<Tuple<string,string>> tempClusterServers = new List<Tuple<string, string>>();
                foreach (var a in fileDb.TBL_CLUSTER_SERVER.Data)
                {
                    tempClusterServers.Add(new Tuple<string, string>(a.Key.clusterName, a.Key.serverName));
                }

                foreach (var a in tempClusterServers)
                {
                    if (a.Item1.Equals(loadBalancerName, StringComparison.OrdinalIgnoreCase))
                    {
                        var p = new List<KeyValuePair<string, string>>();
                        p.Add(new KeyValuePair<string, string>("clusterName", a.Item1));
                        p.Add(new KeyValuePair<string, string>("serverName", a.Item2));
                        await fileDb.DeleteTable(FileDb.TableName.TBL_CLUSTER_SERVER, p);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private async void buttonDeleteLoadBalancerInstance_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show("Do you really want to run?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                    return;

                ControlHelpers.ButtonStatusChange(buttonDeleteLoadBalancer, "Requested");
                string checkedLoadBalancerInstanceNo = string.Empty;
                string checkedLoadBalancerName = string.Empty;

                int checkBoxCount = 0;
                foreach (DataGridViewRow item in dgvloadBalancerList.Rows)
                {
                    if (bool.Parse(item.Cells["CheckBox"].Value.ToString()))
                    {
                        checkBoxCount++;
                        checkedLoadBalancerName = item.Cells["Name"].Value.ToString().Trim();
                        checkedLoadBalancerInstanceNo = item.Cells["InstanceNo"].Value.ToString().Trim();
                    }
                }
                if (checkBoxCount != 1)
                    throw new Exception("check one load balancer");


                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vloadbalancer/v2/deleteLoadBalancerInstances";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));
                parameters.Add(new KeyValuePair<string, string>("loadBalancerInstanceNoList.1", checkedLoadBalancerInstanceNo));

                SoaCall soaCall = new SoaCall();
                var task = soaCall.WebApiCall(endpoint, RequestType.POST, action, parameters, LogClient.Config.Instance.GetValue(Category.Api, Key.AccessKey), LogClient.Config.Instance.GetValue(Category.Api, Key.SecretKey));
                string response = await task;

                JsonSerializerSettings options = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                if (response.Contains("responseError"))
                {
                    hasError hasError = JsonConvert.DeserializeObject<hasError>(response, options);
                    throw new Exception(hasError.responseError.returnMessage);
                }
                else
                {
                    deleteLoadBalancerInstances deleteLoadBalancerInstances = JsonConvert.DeserializeObject<deleteLoadBalancerInstances>(response, options);
                    if (deleteLoadBalancerInstances.deleteLoadBalancerInstancesResponse.returnCode.Equals("0"))
                    {
                    }
                    else
                    {
                        throw new Exception("delete loadbalancer error");
                    }

                }
                await DbDelete(checkedLoadBalancerName);
                await loadBalancerListLoad();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonDeleteLoadBalancer, "Delete");
                comboBoxMasterServer.Text = "";
                comboBoxSlaveServer.Text = "";
            }
        }


        private async void buttonDbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string checkedLoadBalancerInstanceNo = string.Empty;
                string checkedLoadBalancerName = string.Empty;

                int checkBoxCount = 0;
                foreach (DataGridViewRow item in dgvloadBalancerList.Rows)
                {
                    if (bool.Parse(item.Cells["CheckBox"].Value.ToString()))
                    {
                        checkBoxCount++;
                        checkedLoadBalancerName = item.Cells["Name"].Value.ToString().Trim();
                        checkedLoadBalancerInstanceNo = item.Cells["InstanceNo"].Value.ToString().Trim();
                    }
                }
                if (checkBoxCount != 1)
                    throw new Exception("check one load balancer");

                await DbDelete(checkedLoadBalancerName);
                await loadBalancerListLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void buttonShowCheckedLBDetailInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // textBoxLoadBalancerName

                //if (!checkedLBName.Equals(textBoxLoadBalancerName.Text, StringComparison.OrdinalIgnoreCase))
                //    throw new Exception ("load balancer name check first");

                if (checkedLoadBalancerInstance != null)
                {
                    formPreview.GroupBoxText = "Checked Load Balancer Info";
                    JToken jt = JToken.Parse(JsonConvert.SerializeObject(checkedLoadBalancerInstance));
                    formPreview.Script = jt.ToString(Newtonsoft.Json.Formatting.Indented);
                    formPreview.ShowDialog();
                }
                else
                {
                    MessageBox.Show("load balancer name check first");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }
}
