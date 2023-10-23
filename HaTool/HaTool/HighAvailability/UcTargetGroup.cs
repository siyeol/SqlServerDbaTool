using CsLib;
using HaTool.Config;
using HaTool.Global;
using HaTool.Model.NCloud;
using HaTool.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogClient;


namespace HaTool.HighAvailability
{
    public partial class UcTargetGroup : UserControl
    {
        private static readonly Lazy<UcTargetGroup> lazy =
            new Lazy<UcTargetGroup>(() => new UcTargetGroup(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static UcTargetGroup Instance { get { return lazy.Value; } }

        LogClient.Config logClientConfig = LogClient.Config.Instance;
        DataManager dataManager = DataManager.Instance;
        FileDb fileDb = FileDb.Instance;

        public UcTargetGroup()
        {
            InitializeComponent();
            InitDgv();
        }

        DataGridViewCheckBoxColumn ColumnMasterCheckBox;
        DataGridViewCheckBoxColumn ColumnSlaveCheckBox;
        DataGridViewTextBoxColumn ColumnServerName;
        DataGridViewTextBoxColumn ColumnServerZoneNo;
        DataGridViewTextBoxColumn ColumnServerInstanceNo;
        DataGridViewTextBoxColumn ColumnServerPublicIp;
        DataGridViewTextBoxColumn ColumnServerPrivateIp;
        DataGridViewTextBoxColumn ColumnServerStatus;
        DataGridViewTextBoxColumn ColumnServerOperation;

        DataGridViewCheckBoxColumn colTargetGroupCheckBox;
        DataGridViewTextBoxColumn colTargetGroupName;
        DataGridViewTextBoxColumn colTargetGroupNo;
        DataGridViewTextBoxColumn colProtocol;
        DataGridViewTextBoxColumn colPort;
        DataGridViewTextBoxColumn colTargetType;
        DataGridViewTextBoxColumn colLoadBalancer;
        DataGridViewTextBoxColumn colVpc;

        private void InitDgv()
        {
            ColumnMasterCheckBox = new DataGridViewCheckBoxColumn();
            ColumnSlaveCheckBox = new DataGridViewCheckBoxColumn();
            ColumnServerName = new DataGridViewTextBoxColumn();
            ColumnServerZoneNo = new DataGridViewTextBoxColumn();
            ColumnServerInstanceNo = new DataGridViewTextBoxColumn();
            ColumnServerPublicIp = new DataGridViewTextBoxColumn();
            ColumnServerPrivateIp = new DataGridViewTextBoxColumn();
            ColumnServerStatus = new DataGridViewTextBoxColumn();
            ColumnServerOperation = new DataGridViewTextBoxColumn();

            colTargetGroupCheckBox = new DataGridViewCheckBoxColumn();
            colTargetGroupName = new DataGridViewTextBoxColumn();
            colTargetGroupNo = new DataGridViewTextBoxColumn();
            colProtocol = new DataGridViewTextBoxColumn();
            colPort = new DataGridViewTextBoxColumn();
            colTargetType = new DataGridViewTextBoxColumn();
            colLoadBalancer = new DataGridViewTextBoxColumn();
            colVpc = new DataGridViewTextBoxColumn();

            ColumnMasterCheckBox.HeaderText = "Master";
            ColumnSlaveCheckBox.HeaderText = "Slave";
            ColumnServerName.HeaderText = "Name";
            ColumnServerZoneNo.HeaderText = "Zone";
            ColumnServerInstanceNo.HeaderText = "InstanceNo";
            ColumnServerPublicIp.HeaderText = "PublicIp";
            ColumnServerPrivateIp.HeaderText = "PrivateIp";
            ColumnServerStatus.HeaderText = "Status";
            ColumnServerOperation.HeaderText = "Operation";

            colTargetGroupCheckBox.HeaderText = "CheckBox";
            colTargetGroupName.HeaderText = "Target Group Name";
            colTargetGroupNo.HeaderText = "Target Group Number";
            colProtocol.HeaderText = "Protocol";
            colPort.HeaderText = "Port";
            colTargetType.HeaderText = "Target Type";
            colLoadBalancer.HeaderText = "Connected Load Balancer";
            colVpc.HeaderText = "VPC";

            ColumnMasterCheckBox.Name = "Master";
            ColumnSlaveCheckBox.Name = "Slave";
            ColumnServerName.Name = "Name";
            ColumnServerZoneNo.Name = "ZoneNo";
            ColumnServerInstanceNo.Name = "InstanceNo";
            ColumnServerPublicIp.Name = "PublicIp";
            ColumnServerPrivateIp.Name = "PrivateIp";
            ColumnServerStatus.Name = "Status";
            ColumnServerOperation.Name = "Operation";

            colTargetGroupCheckBox.Name = "CheckBox";
            colTargetGroupName.Name = "TargetGroupName";
            colTargetGroupNo.Name = "TargetGroupNo";
            colProtocol.Name = "Protocol";
            colPort.Name = "Port";
            colTargetType.Name = "TargetType";
            colLoadBalancer.Name = "LoadBalancer";
            colVpc.Name = "Vpc";

            dgvServerList.Columns.AddRange(new DataGridViewColumn[]
            {
                ColumnMasterCheckBox   ,
                ColumnSlaveCheckBox    ,
                ColumnServerName       ,
                ColumnServerZoneNo     ,
                ColumnServerInstanceNo ,
                ColumnServerPublicIp   ,
                ColumnServerPrivateIp  ,
                ColumnServerStatus     ,
                ColumnServerOperation
            });


            dgvServerList.AllowUserToAddRows = false;
            dgvServerList.RowHeadersVisible = false;
            dgvServerList.BackgroundColor = Color.White;
            dgvServerList.AutoResizeColumns();
            dgvServerList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvServerList.Columns["Operation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvServerList.AllowUserToResizeRows = false;

            ControlHelpers.dgvDesign(dgvServerList);
            dgvServerList.CellContentClick += new DataGridViewCellEventHandler(ControlHelpers.dgvSingleCheckBox);
            dgvServerList.CellContentClick += new DataGridViewCellEventHandler(ControlHelpers.dgvLineColorChange);


            dgvTargetGroup.Columns.AddRange(new DataGridViewColumn[]
            {
                colTargetGroupCheckBox,
                colTargetGroupName,
                colTargetGroupNo,
                colProtocol,
                colPort,
                colTargetType,
                colLoadBalancer,
                colVpc
            });

            dgvTargetGroup.AllowUserToAddRows = false;
            dgvTargetGroup.RowHeadersVisible = false;
            dgvTargetGroup.BackgroundColor = Color.White;
            dgvTargetGroup.AutoResizeColumns();
            dgvTargetGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTargetGroup.Columns["Vpc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTargetGroup.AllowUserToResizeRows = false;

            ControlHelpers.dgvDesign(dgvTargetGroup);
            dgvTargetGroup.CellContentClick += new DataGridViewCellEventHandler(ControlHelpers.dgvLineColorChange);

            comboBoxTargetGroupProtocol.Items.Clear();
            comboBoxTargetGroupProtocol.Items.Add("TCP");
            comboBoxTargetGroupProtocol.SelectedItem = "TCP";
        }
        private async void LoadData(object sender, EventArgs e)
        {
            try
            {
                dataManager.LoadUserData();
                LoadTextData();
                List<Task> tasks = new List<Task>();
                tasks.Add(ServerListLoad());
                tasks.Add(GetRegionList());
                tasks.Add(GetSubnetList());
                tasks.Add(GetVpcList());
                tasks.Add(GetTargetGroup());
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LoadTextData()
        {
            try
            {
                comboBoxProtocol.Text = dataManager.GetValue(DataManager.Category.LoadBalancer, DataManager.Key.Protocol).Trim();
                textBoxLoadBalancerName.Text = dataManager.GetValue(DataManager.Category.LoadBalancer, DataManager.Key.Name).Trim();
                textBoxPort.Text = dataManager.GetValue(DataManager.Category.SetSql, DataManager.Key.Port).Trim();
            }
            catch (Exception)
            {
                throw;
            }

        }

        private async Task GetRegionList()
        {
            try
            {
                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vserver/v2/getRegionList";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));
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
                    getRegionList getRegionList = JsonConvert.DeserializeObject<getRegionList>(response, options);
                    if (getRegionList.getRegionListResponse.returnCode.Equals("0"))
                    {
                        comboBoxRegion.Items.Clear();
                        foreach (var a in getRegionList.getRegionListResponse.regionList)
                        {
                            var item = new region
                            {
                                regionNo = a.regionNo,
                                regionCode = a.regionCode,
                                regionName = a.regionName
                            };
                            // regionNo 1 Korea
                            comboBoxRegion.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            comboBoxRegion.SelectedIndex = 0;
        }

        private async Task GetSubnetList()
        {
            try
            {
                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vpc/v2/getSubnetList";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));
                //parameters.Add(new KeyValuePair<string, string>("vpcNo", vpcNo));
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
                    hasError errorResponse = JsonConvert.DeserializeObject<hasError>(response, options);
                    throw new Exception(errorResponse.responseError.returnMessage);
                }
                else
                {
                    getSubnetList getSubnetList = JsonConvert.DeserializeObject<getSubnetList>(response, options);
                    if (getSubnetList.getSubnetListResponse.returnCode.Equals("0"))
                    {
                        comboBoxSubnet.Items.Clear();
                        foreach (var subnet in getSubnetList.getSubnetListResponse.subnetList)
                        {
                            var item = new subnetInstance
                            {
                                subnetNo = subnet.subnetNo,
                                subnetName = subnet.subnetName
                            };
                            comboBoxSubnet.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            comboBoxSubnet.SelectedIndex = 0;
        }


        private async Task ServerListLoad()
        {
            try
            {
                ControlHelpers.ButtonStatusChange(buttonServerListReload, "Requested");
                await fileDb.ReadTable(FileDb.TableName.TBL_SERVER);

                List<string> instanceNoList = new List<string>();
                List<string> deleteServerNameList = new List<string>();

                foreach (var a in fileDb.TBL_SERVER.Data)
                {
                    if (a.Value.serverInstanceNo != "NULL")
                        instanceNoList.Add(a.Value.serverInstanceNo);
                }


                List<serverInstance> serverInstances = new List<serverInstance>();

                try
                {
                    serverInstances = await ServerOperation.GetServerInstanceList(instanceNoList);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("server not found"))
                    {
                        // 
                    }
                    else
                        throw new Exception(ex.Message);
                }

                dgvServerList.InvokeIfRequired(async s =>
                {
                    try
                    {
                        s.Rows.Clear();
                        foreach (var a in fileDb.TBL_SERVER.Data)
                        {

                            var serverInstance = serverInstances.Find(x => x.serverName == a.Key.serverName);

                            if (serverInstance != null)
                            {
                                int n = s.Rows.Add();
                                s.Rows[n].Cells["Master"].Value = false;
                                s.Rows[n].Cells["Slave"].Value = false;
                                s.Rows[n].Cells["Name"].Value = a.Key.serverName;
                                s.Rows[n].Cells["ZoneNo"].Value = a.Value.zoneCode;
                                s.Rows[n].Cells["InstanceNo"].Value = a.Value.serverInstanceNo;
                                s.Rows[n].Cells["PublicIp"].Value = a.Value.serverPublicIp;
                                s.Rows[n].Cells["PrivateIp"].Value = a.Value.serverPrivateIp;
                                s.Rows[n].Cells["Status"].Value = serverInstance.serverInstanceStatus.code;
                                s.Rows[n].Cells["Operation"].Value = serverInstance.serverInstanceOperation.code;
                            }
                            else
                            {
                                deleteServerNameList.Add(a.Key.serverName);
                            }
                        }

                        foreach (var a in deleteServerNameList)
                        {
                            var p = new List<KeyValuePair<string, string>>();
                            p.Add(new KeyValuePair<string, string>("serverName", a));
                            await fileDb.DeleteTable(FileDb.TableName.TBL_SERVER, p);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonServerListReload, "Reload");
            }
        }

        private async Task GetVpcList()
        {
            try
            {
                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vpc/v2/getVpcList";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));
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
                    hasError errorResponse = JsonConvert.DeserializeObject<hasError>(response, options);
                    throw new Exception(errorResponse.responseError.returnMessage);
                }
                else
                {
                    getVpcList getVpcList = JsonConvert.DeserializeObject<getVpcList>(response, options);
                    if (getVpcList.getVpcListResponse.returnCode.Equals("0"))
                    {
                        foreach (var vpc in getVpcList.getVpcListResponse.vpcList)
                        {
                            var item = new vpcInstance
                            {
                                vpcNo = vpc.vpcNo,
                                vpcName = vpc.vpcName,
                            };
                            comboBoxVPC.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            comboBoxVPC.SelectedIndex = 0;
        }

        private List<Tuple<string, string, string>> GetSelectedServerInstanceNos()
        {
            List<Tuple<string, string, string>> selectedServers = new List<Tuple<string, string, string>>();

            foreach (DataGridViewRow row in dgvServerList.Rows)
            {
                bool isMasterChecked = Convert.ToBoolean(row.Cells["Master"].Value);
                bool isSlaveChecked = Convert.ToBoolean(row.Cells["Slave"].Value);
                string instanceNo = row.Cells["InstanceNo"].Value.ToString();
                string name = row.Cells["Name"].Value.ToString();

                if (isMasterChecked)
                {
                    selectedServers.Add(new Tuple<string, string, string>(instanceNo, name, "MASTER"));
                }
                else if (isSlaveChecked)
                {
                    selectedServers.Add(new Tuple<string, string, string>(instanceNo, name, "SLAVE"));
                }
            }

            return selectedServers;
        }

        private async Task CreateTargetGroup()
        {
            try
            {
                List<Tuple<string, string, string>> selectedServers = GetSelectedServerInstanceNos();

                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vloadbalancer/v2/createTargetGroup";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));
                parameters.Add(new KeyValuePair<string, string>("targetGroupProtocolTypeCode", comboBoxTargetGroupProtocol.SelectedItem.ToString()));
                parameters.Add(new KeyValuePair<string, string>("healthCheckProtocolTypeCode", comboBoxTargetGroupProtocol.SelectedItem.ToString()));
                parameters.Add(new KeyValuePair<string, string>("vpcNo", (comboBoxVPC.SelectedItem as vpcInstance).vpcNo));
                parameters.Add(new KeyValuePair<string, string>("targetGroupName", textBoxTargetGroupName.Text));
                parameters.Add(new KeyValuePair<string, string>("targetGroupPort", textBoxPort.Text));
                parameters.Add(new KeyValuePair<string, string>("healthCheckPort", textBoxPort.Text));

                for (int i = 0; i < selectedServers.Count; i++)
                {
                    if (selectedServers[i].Item3 == "MASTER")
                    {
                        parameters.Add(new KeyValuePair<string, string>("targetNoList.1", selectedServers[i].Item1));
                    }
                }

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
                    createTargetGroup createTargetGroup = JsonConvert.DeserializeObject<createTargetGroup>(response, options);
                    if (createTargetGroup.createTargetGroupResponse.Equals("0"))
                    {
                        foreach (var _targetGroup in createTargetGroup.createTargetGroupResponse.targetGroupInstanceList)
                        {
                            dataManager.SetValue(DataManager.Category.LoadBalancer, DataManager.Key.targetGroupNo, _targetGroup.targetGroupNo.ToString());
                        }
                    }
                }
                await GetTargetGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private async Task GetTargetGroup()
        {
            try
            {
                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vloadbalancer/v2/getTargetGroupList";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));

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
                    getTargetGroupList getTargetGroupList = JsonConvert.DeserializeObject<getTargetGroupList>(response, options);
                    if (getTargetGroupList.getTargetGroupListResponse.returnCode.Equals("0"))
                    {
                        dgvTargetGroup.InvokeIfRequired(s =>
                        {
                            s.Rows.Clear();
                            foreach (var item in getTargetGroupList.getTargetGroupListResponse.targetGroupList)
                            {
                                int n = s.Rows.Add();
                                s.Rows[n].Cells["CheckBox"].Value = false;
                                s.Rows[n].Cells["TargetGroupName"].Value = item.targetGroupName;
                                s.Rows[n].Cells["TargetGroupNo"].Value = item.targetGroupNo;
                                s.Rows[n].Cells["Protocol"].Value = item.targetGroupProtocolType.code;
                                s.Rows[n].Cells["Port"].Value = item.targetGroupPort;
                                s.Rows[n].Cells["TargetType"].Value = item.targetType.code;
                                s.Rows[n].Cells["LoadBalancer"].Value = item.loadBalancerInstanceNo;
                                s.Rows[n].Cells["Vpc"].Value = item.vpcNo;
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private async Task<string> getLoadBalancerNameFromNo(string instanceNo)
        {
            string loadBalancerName = string.Empty;

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
                            loadBalancerName = lbi.loadBalancerName;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return loadBalancerName;
        }


        private async Task SaveClusterServerInfo(string loadBalancerName)
        {
            try
            {
                await fileDb.ReadTable(FileDb.TableName.TBL_CLUSTER_SERVER);
                List<Tuple<string, string, string>> selectedServers = GetSelectedServerInstanceNos();

                // Delete existing entries for the given loadBalancerName
                foreach (var entry in fileDb.TBL_CLUSTER_SERVER.Data)
                {
                    if (entry.Key.clusterName.Equals(loadBalancerName, StringComparison.OrdinalIgnoreCase))
                    {
                        var p = new List<KeyValuePair<string, string>>();
                        p.Add(new KeyValuePair<string, string>("clusterName", entry.Key.clusterName));
                        p.Add(new KeyValuePair<string, string>("serverName", entry.Key.serverName));
                        await fileDb.DeleteTable(FileDb.TableName.TBL_CLUSTER_SERVER, p);
                    }
                }

                // Upsert the new entries
                foreach (var server in selectedServers)
                {
                    var clusterServerInfo = new List<KeyValuePair<string, string>>();
                    clusterServerInfo.Add(new KeyValuePair<string, string>("clusterName", loadBalancerName));
                    clusterServerInfo.Add(new KeyValuePair<string, string>("serverName", server.Item2));
                    clusterServerInfo.Add(new KeyValuePair<string, string>("serverRole", server.Item3));

                    await fileDb.UpSertTable(FileDb.TableName.TBL_CLUSTER_SERVER, clusterServerInfo);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void buttonServerListReload_Click(object sender, EventArgs e)
        {
            try
            {
                await ServerListLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void buttonCreateTargetGroup_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                ControlHelpers.ButtonStatusChange(buttonCreateTargetGroup, "Requested");
                await CreateTargetGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonCreateTargetGroup, "Create");
            }

        }

        private async void buttonReloadTargetGroup_Click(object sender, EventArgs e)
        {
            try
            {
                await GetTargetGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetSelectedTargetGroupNo()
        {
            foreach (DataGridViewRow row in dgvTargetGroup.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["CheckBox"].Value);  // Replace with the actual checkbox column name
                if (isChecked)
                {
                    return row.Cells["TargetGroupNo"].Value.ToString();
                }
            }
            return null;
        }


        private async void buttonCreateLoadBalancer_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelpers.ButtonStatusChange(buttonCreateLoadBalancer, "Requested");
                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vloadbalancer/v2/createLoadBalancerInstance";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));
                parameters.Add(new KeyValuePair<string, string>("loadBalancerTypeCode", "NETWORK")); //Restricting to L4 LB
                parameters.Add(new KeyValuePair<string, string>("loadBalancerName", textBoxLoadBalancerName.Text.Trim()));
                parameters.Add(new KeyValuePair<string, string>("loadBalancerListenerList.1.protocolTypeCode", comboBoxProtocol.Text.Trim()));
                parameters.Add(new KeyValuePair<string, string>("loadBalancerListenerList.1.port", textBoxPort.Text));
                parameters.Add(new KeyValuePair<string, string>("subnetNoList.1", (comboBoxSubnet.SelectedItem as subnetInstance).subnetNo));
                //parameters.Add(new KeyValuePair<string, string>("loadBalancerRuleList.1.serverPort", textBoxServerPort.Text.Trim()));
                parameters.Add(new KeyValuePair<string, string>("regionCode", (comboBoxRegion.SelectedItem as region).regionCode));
                parameters.Add(new KeyValuePair<string, string>("vpcNo", (comboBoxVPC.SelectedItem as vpcInstance).vpcNo));
                parameters.Add(new KeyValuePair<string, string>("loadBalancerListenerList.1.targetGroupNo", GetSelectedTargetGroupNo()));
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

                createLoadBalancerInstance createLoadBalancerInstance = JsonConvert.DeserializeObject<createLoadBalancerInstance>(response, options);
                if (createLoadBalancerInstance.createLoadBalancerInstanceResponse.returnCode.Equals("0"))
                {
                    var _lbInstance = createLoadBalancerInstance.createLoadBalancerInstanceResponse.loadBalancerInstanceList[0];
                    string loadBalancerInstanceNo = _lbInstance.loadBalancerInstanceNo;
                    string loadBalancerDomain = _lbInstance.loadBalancerDomain;

                    var p = new List<KeyValuePair<string, string>>();
                    p.Add(new KeyValuePair<string, string>("clusterName", textBoxLoadBalancerName.Text.Trim()));
                    p.Add(new KeyValuePair<string, string>("clusterNo", loadBalancerInstanceNo)); 
                    p.Add(new KeyValuePair<string, string>("domainName", loadBalancerDomain)); 
                    p.Add(new KeyValuePair<string, string>("clusterPort", textBoxPort.Text.Trim()));
                    p.Add(new KeyValuePair<string, string>("targetGroupNo", GetSelectedTargetGroupNo()));

                    await fileDb.UpSertTable(FileDb.TableName.TBL_CLUSTER, p);

                    MessageBox.Show("create requested");
                }

                string selectedLoadBalancerName = textBoxLoadBalancerName.Text.Trim();
                await SaveClusterServerInfo(selectedLoadBalancerName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonCreateLoadBalancer, "Create");
            }

        }


        private async void buttonDeleteTargetGroup_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want to run?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                    return;

                ControlHelpers.ButtonStatusChange(buttonDeleteTargetGroup, "Requested");
                string checkedTargetGroupNo = string.Empty;

                int checkBoxCount = 0;
                foreach (DataGridViewRow item in dgvTargetGroup.Rows)
                {
                    if (bool.Parse(item.Cells["CheckBox"].Value.ToString()))
                    {
                        checkBoxCount++;
                        checkedTargetGroupNo = item.Cells["TargetGroupNo"].Value.ToString().Trim();
                        if (item.Cells["LoadBalancer"].Value != null && !string.IsNullOrWhiteSpace(item.Cells["LoadBalancer"].Value.ToString()))
                        {
                            throw new Exception("Disconnect connected LoadBalancer first");
                        }
                    }
                }
                if (checkBoxCount != 1)
                    throw new Exception("check one target group");


                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vloadbalancer/v2/deleteTargetGroups";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));
                parameters.Add(new KeyValuePair<string, string>("targetGroupNoList.1", checkedTargetGroupNo));

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
                    deleteTargetGroups deleteTargetGroups = JsonConvert.DeserializeObject<deleteTargetGroups>(response, options);
                    if (deleteTargetGroups.deleteTargetGroupsResponse.returnCode.Equals("0"))
                    {
                    }
                    else
                    {
                        throw new Exception("delete Target Group error");
                    }

                }
                await GetTargetGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonDeleteTargetGroup, "Delete");
            }
        }

        private async void buttonDeleteLoadBalancer_Click(object sender, EventArgs e)
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
                foreach (DataGridViewRow item in dgvTargetGroup.Rows)
                {
                    if (bool.Parse(item.Cells["CheckBox"].Value.ToString()))
                    {
                        checkBoxCount++;
                        checkedLoadBalancerInstanceNo = item.Cells["LoadBalancer"].Value.ToString().Trim();
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
                checkedLoadBalancerName = await getLoadBalancerNameFromNo(checkedLoadBalancerInstanceNo);
                await DbDelete(checkedLoadBalancerName);
                await GetTargetGroup();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonDeleteLoadBalancer, "Disconnect");
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

                List<Tuple<string, string>> tempClusterServers = new List<Tuple<string, string>>();
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
    }
}
