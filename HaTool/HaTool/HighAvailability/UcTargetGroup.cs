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

        DataGridViewCheckBoxColumn ColumnServerCheckBox;
        DataGridViewTextBoxColumn ColumnServerName;
        DataGridViewTextBoxColumn ColumnServerZoneNo;
        DataGridViewTextBoxColumn ColumnServerInstanceNo;
        DataGridViewTextBoxColumn ColumnServerPublicIp;
        DataGridViewTextBoxColumn ColumnServerPrivateIp;
        DataGridViewTextBoxColumn ColumnServerStatus;
        DataGridViewTextBoxColumn ColumnServerOperation;

        DataGridViewCheckBoxColumn colTargetGroupCheckBox;
        DataGridViewTextBoxColumn colTargetGroupName;
        DataGridViewTextBoxColumn colProtocol;
        DataGridViewTextBoxColumn colPort;
        DataGridViewTextBoxColumn colTargetType;
        DataGridViewTextBoxColumn colLoadBalancer;
        DataGridViewTextBoxColumn colVpc;

        private void InitDgv()
        {
            ColumnServerCheckBox = new DataGridViewCheckBoxColumn();
            ColumnServerName = new DataGridViewTextBoxColumn();
            ColumnServerZoneNo = new DataGridViewTextBoxColumn();
            ColumnServerInstanceNo = new DataGridViewTextBoxColumn();
            ColumnServerPublicIp = new DataGridViewTextBoxColumn();
            ColumnServerPrivateIp = new DataGridViewTextBoxColumn();
            ColumnServerStatus = new DataGridViewTextBoxColumn();
            ColumnServerOperation = new DataGridViewTextBoxColumn();

            colTargetGroupCheckBox = new DataGridViewCheckBoxColumn();
            colTargetGroupName = new DataGridViewTextBoxColumn();
            colProtocol = new DataGridViewTextBoxColumn();
            colPort = new DataGridViewTextBoxColumn();
            colTargetType = new DataGridViewTextBoxColumn();
            colLoadBalancer = new DataGridViewTextBoxColumn();
            colVpc = new DataGridViewTextBoxColumn();

            ColumnServerCheckBox.HeaderText = "CheckBox";
            ColumnServerName.HeaderText = "Name";
            ColumnServerZoneNo.HeaderText = "ZoneNo";
            ColumnServerInstanceNo.HeaderText = "InstanceNo";
            ColumnServerPublicIp.HeaderText = "PublicIp";
            ColumnServerPrivateIp.HeaderText = "PrivateIp";
            ColumnServerStatus.HeaderText = "Status";
            ColumnServerOperation.HeaderText = "Operation";

            colTargetGroupCheckBox.HeaderText = "CheckBox";
            colTargetGroupName.HeaderText = "Target Group Name";
            colProtocol.HeaderText = "Protocol";
            colPort.HeaderText = "Port";
            colTargetType.HeaderText = "Target Type";
            colLoadBalancer.HeaderText = "Connected Load Balancer";
            colVpc.HeaderText = "VPC";

            ColumnServerCheckBox.Name = "CheckBox";
            ColumnServerName.Name = "Name";
            ColumnServerZoneNo.Name = "ZoneNo";
            ColumnServerInstanceNo.Name = "InstanceNo";
            ColumnServerPublicIp.Name = "PublicIp";
            ColumnServerPrivateIp.Name = "PrivateIp";
            ColumnServerStatus.Name = "Status";
            ColumnServerOperation.Name = "Operation";

            colTargetGroupCheckBox.Name = "CheckBox";
            colTargetGroupName.Name = "TargetGroupName";
            colProtocol.Name = "Protocol";
            colPort.Name = "Port";
            colTargetType.Name = "TargetType";
            colLoadBalancer.Name = "LoadBalancer";
            colVpc.Name = "Vpc";

            dgvServerList.Columns.AddRange(new DataGridViewColumn[]
            {
                ColumnServerCheckBox   ,
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
            dgvServerList.CellContentClick += new DataGridViewCellEventHandler(ControlHelpers.dgvLineColorChange);


            dgvTargetGroup.Columns.AddRange(new DataGridViewColumn[]
            {
                colTargetGroupCheckBox,
                colTargetGroupName,
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


            SetDefaultOptionsForTargetGroupProtocol();
            comboBoxTargetGroupProtocol.SelectedIndexChanged += comboBoxTargetGroupProtocol_SelectedIndexChanged;
        }
        private async void LoadData(object sender, EventArgs e)
        {
            try
            {
                dataManager.LoadUserData();
                List<Task> tasks = new List<Task>();
                tasks.Add(ServerListLoad());
                tasks.Add(GetVpcList());
                tasks.Add(GetTargetGroup());
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SetDefaultOptionsForTargetGroupProtocol()
        {
            comboBoxTargetGroupProtocol.Items.Clear();
            comboBoxTargetGroupProtocol.Items.Add("TCP");
            comboBoxTargetGroupProtocol.Items.Add("UDP");
            comboBoxTargetGroupProtocol.Items.Add("PROXY_TCP");
            comboBoxTargetGroupProtocol.Items.Add("HTTP");
            comboBoxTargetGroupProtocol.Items.Add("HTTPS");

            comboBoxTargetGroupProtocol.SelectedItem = "TCP";
        }

        private void SetDefaultOptionsForHealthCheckProtocol(string targetGroupProtocol)
        {
            comboBoxHealthCheckProtocol.Items.Clear();
            switch (targetGroupProtocol)
            {
                case "TCP":
                case "PROXY_TCP":
                    comboBoxHealthCheckProtocol.Items.Add("TCP");
                    break;
                case "HTTP":
                case "HTTPS":
                    comboBoxHealthCheckProtocol.Items.Add("HTTP");
                    comboBoxHealthCheckProtocol.Items.Add("HTTPS");
                    break;
            }

            if (targetGroupProtocol == "TCP" || targetGroupProtocol == "PROXY_TCP")
            {
                comboBoxHealthCheckProtocol.SelectedItem = "TCP";
            }
            else
            {
                comboBoxHealthCheckProtocol.SelectedItem = "HTTP"; // Default to HTTP for Application Load Balancer
            }
        }

        private void comboBoxTargetGroupProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDefaultOptionsForHealthCheckProtocol(comboBoxTargetGroupProtocol.SelectedItem.ToString());
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
                                s.Rows[n].Cells["CheckBox"].Value = false;
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
                            comboBoxVPC.Items.Add(vpc.vpcNo.ToString());
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

        private List<string> GetSelectedServerInstanceNos()
        {
            List<string> selectedServerInstanceNos = new List<string>();

            foreach (DataGridViewRow row in dgvServerList.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["CheckBox"].Value);
                if (isChecked)
                {
                    string instanceNo = row.Cells["InstanceNo"].Value.ToString();
                    selectedServerInstanceNos.Add(instanceNo);
                }
            }

            return selectedServerInstanceNos;
        }

        private async Task CreateTargetGroup()
        {
            try
            {
                List<string> selectedServerInstanceNos = GetSelectedServerInstanceNos();

                string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
                string action = @"/vloadbalancer/v2/createTargetGroup";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));
                parameters.Add(new KeyValuePair<string, string>("targetGroupProtocolTypeCode", comboBoxTargetGroupProtocol.SelectedItem.ToString()));
                parameters.Add(new KeyValuePair<string, string>("healthCheckProtocolTypeCode", comboBoxHealthCheckProtocol.SelectedItem.ToString()));
                parameters.Add(new KeyValuePair<string, string>("vpcNo", comboBoxVPC.SelectedItem.ToString()));
                parameters.Add(new KeyValuePair<string, string>("targetGroupName", textBoxTargetGroupName.Text));

                for (int i = 0; i < selectedServerInstanceNos.Count; i++)
                {
                    string paramName = $"targetNoList.{i + 1}";
                    parameters.Add(new KeyValuePair<string, string>(paramName, selectedServerInstanceNos[i]));
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
    }
}
