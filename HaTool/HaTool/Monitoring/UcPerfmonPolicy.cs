﻿using System;
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
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using HaTool.Server;

namespace HaTool.Monitoring
{
    public partial class UcPerfmonPolicy : UserControl
    {
        private static readonly Lazy<UcPerfmonPolicy> lazy =
            new Lazy<UcPerfmonPolicy>(() => new UcPerfmonPolicy(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static UcPerfmonPolicy Instance { get { return lazy.Value; } }

        LogClient.Config logClientConfig = LogClient.Config.Instance;
        DataManager dataManager = DataManager.Instance;
        FileDb fileDb = FileDb.Instance;

        public UcPerfmonPolicy()
        {
            InitializeComponent();
            InitDgv();

        }

        List<serverInstance> serverInstances = new List<serverInstance>();

        DataGridViewCheckBoxColumn ColumnServerCheckBox;
        DataGridViewTextBoxColumn ColumnServerName;
        DataGridViewTextBoxColumn ColumnServerZoneNo;
        DataGridViewTextBoxColumn ColumnServerInstanceNo;
        DataGridViewTextBoxColumn ColumnServerPublicIp;
        DataGridViewTextBoxColumn ColumnServerPrivateIp;
        DataGridViewTextBoxColumn ColumnServerStatus;
        DataGridViewTextBoxColumn ColumnServerOperation;

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

            ColumnServerCheckBox.HeaderText = "CheckBox";
            ColumnServerName.HeaderText = "Name";
            ColumnServerZoneNo.HeaderText = "Zone";
            ColumnServerInstanceNo.HeaderText = "InstanceNo";
            ColumnServerPublicIp.HeaderText = "PublicIp";
            ColumnServerPrivateIp.HeaderText = "PrivateIp";
            ColumnServerStatus.HeaderText = "Status";
            ColumnServerOperation.HeaderText = "Operation";

            ColumnServerCheckBox.Name = "CheckBox";
            ColumnServerName.Name = "Name";
            ColumnServerZoneNo.Name = "ZoneNo";
            ColumnServerInstanceNo.Name = "InstanceNo";
            ColumnServerPublicIp.Name = "PublicIp";
            ColumnServerPrivateIp.Name = "PrivateIp";
            ColumnServerStatus.Name = "Status";
            ColumnServerOperation.Name = "Operation";


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
            dgvServerList.CellContentClick += new DataGridViewCellEventHandler(ControlHelpers.dgvSingleCheckBox);
            dgvServerList.CellContentClick += new DataGridViewCellEventHandler(ControlHelpers.dgvLineColorChange);
        }
        private async void LoadData(object sender, EventArgs e)
        {
            try
            {
                textBox00Comment.ReadOnly = true;
                textBox00Comment.BorderStyle = 0;
                textBox00Comment.BackColor = this.BackColor;
                textBox00Comment.TabStop = false;
                textBox00Comment.Text = "Enter the perfmon probe interval seconds" + Environment.NewLine + "Recommended value 10 seconds";

                textBox01Comment.ReadOnly = true;
                textBox01Comment.BorderStyle = 0;
                textBox01Comment.BackColor = this.BackColor;
                textBox01Comment.TabStop = false;
                textBox01Comment.Text = "Can be stored for at least 3 minutes to 3 days(4320 minutes)" + Environment.NewLine + "Recommended value 1440 minutes";

                textBox02Comment.ReadOnly = true;
                textBox02Comment.BorderStyle = 0;
                textBox02Comment.BackColor = this.BackColor;
                textBox02Comment.TabStop = false;
                textBox02Comment.Text = "Synchronize measured data with Cloud Insight. After synchronizing the data, you can see the data in graphs in the NCP console." + Environment.NewLine + "Recommended value Y";

                lastMessage.ReadOnly = true;
                lastMessage.BorderStyle = 0;
                lastMessage.BackColor = this.BackColor;
                lastMessage.TabStop = false;
                lastMessage.Text = "If the collection interval is 0, no data action is taken.";

                dataManager.LoadUserData();
                List<Task> tasks = new List<Task>();
                tasks.Add(ServerListLoad());
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async Task ServerListLoad()
        {
            try
            {
                ControlHelpers.ButtonStatusChange(buttonServerListReload, "Requested");
                List<string> instanceNoList = new List<string>();
                List<string> deleteServerNameList = new List<string>();

                foreach (var a in fileDb.TBL_SERVER.Data)
                {
                    if (a.Value.serverInstanceNo != "NULL")
                        instanceNoList.Add(a.Value.serverInstanceNo);
                }

                //await GetServerInstanceList(instanceNoList);
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

                await fileDb.ReadTable(FileDb.TableName.TBL_SERVER);
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


        //private async Task GetServerInstanceList(List<string> instanceNoList)
        //{
        //    try
        //    {
        //        string endpoint = dataManager.GetValue(DataManager.Category.ApiGateway, DataManager.Key.Endpoint);
        //        string action = @"/vserver/v2/getServerInstanceList";
        //        List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
        //        parameters.Add(new KeyValuePair<string, string>("responseFormatType", "json"));

        //        int i = 0;
        //        foreach (var instanceNo in instanceNoList)
        //        {
        //            i++;
        //            string serverInstanceNoListKey = "serverInstanceNoList." + i;
        //            string serverInstanceNoListValue = instanceNo;
        //            parameters.Add(new KeyValuePair<string, string>(serverInstanceNoListKey, serverInstanceNoListValue));
        //        }

        //        SoaCall soaCall = new SoaCall();
        //        var task = soaCall.WebApiCall(endpoint, RequestType.POST, action, parameters, LogClient.Config.Instance.GetValue(Category.Api, Key.AccessKey), LogClient.Config.Instance.GetValue(Category.Api, Key.SecretKey));
        //        string response = await task;

        //        JsonSerializerSettings options = new JsonSerializerSettings
        //        {
        //            NullValueHandling = NullValueHandling.Ignore,
        //            MissingMemberHandling = MissingMemberHandling.Ignore
        //        };

        //        if (response.Contains("responseError"))
        //        {
        //            hasError hasError = JsonConvert.DeserializeObject<hasError>(response, options);
        //            throw new Exception(hasError.responseError.returnMessage);
        //        }
        //        else
        //        {
        //            getServerInstanceList getServerInstanceList = JsonConvert.DeserializeObject<getServerInstanceList>(response, options);
        //            if (getServerInstanceList.getServerInstanceListResponse.returnCode.Equals("0"))
        //            {
        //                serverInstances.Clear();
        //                foreach (var a in getServerInstanceList.getServerInstanceListResponse.serverInstanceList)
        //                {
        //                    var item = new serverInstance
        //                    {
        //                        serverInstanceNo = a.serverInstanceNo,
        //                        serverName = a.serverName,
        //                        publicIp = a.publicIp,
        //                        privateIp = a.privateIp,
        //                        serverInstanceStatus = a.serverInstanceStatus,
        //                        serverInstanceOperation = a.serverInstanceOperation
        //                    };
        //                    serverInstances.Add(item);
        //                }
        //                if (getServerInstanceList.getServerInstanceListResponse.totalRows == 0)
        //                {
        //                    MessageBox.Show("server not founds");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        private string GetPublicIp(string serverName)
        {
            string serverPublicIp = "";
            foreach (var a in fileDb.TBL_SERVER.Data)
            {
                if (a.Key.serverName.Equals(serverName, StringComparison.OrdinalIgnoreCase))
                    serverPublicIp = a.Value.serverPublicIp;
            }
            return serverPublicIp;
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

        private async void buttonLoadPolicy_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelpers.ButtonStatusChange(buttonLoadPolicy, "Requested");

                if (ControlHelpers.CheckBoxCheckedCnt(dgvServerList) != 1)
                    throw new Exception("Please select one server");

                string ip = string.Empty;

                foreach (DataGridViewRow item in dgvServerList.Rows)
                {
                    if (bool.Parse(item.Cells["CheckBox"].Value.ToString()))
                    {
                        ip = item.Cells["PublicIp"].Value.ToString();
                        if (
                                !(
                                item.Cells["Status"].Value.ToString().Equals("RUN", StringComparison.OrdinalIgnoreCase) &&
                                item.Cells["Operation"].Value.ToString().Equals("NULL", StringComparison.OrdinalIgnoreCase)
                                )
                            )
                        {
                            throw new Exception("The server is not running. Please use after changing the server running state.");
                        }
                    }
                }

                if (ip.Length == 0)
                    throw new Exception("check public ip");

                List<string> TypeConfigReads = new List<string>();
                List<Task<string>> Tasks = new List<Task<string>>();
                string cmdText = string.Empty;

                var typeConfigRead = new TypeConfigRead
                {
                    ConfigFile = "LazylogConfig.txt",
                    Category = "Perfmon",
                    Key = "ProbeIntervalSec"
                };
                cmdText = JsonConvert.SerializeObject(typeConfigRead);
                Task<string> ProbeIntervalSec = dataManager.Execute
                    ("ExecuterRest"
                    , "TypeConfigRead"
                    , cmdText
                    , CsLib.RequestType.POST
                    , $"https://{ip}:9090"
                    , @"/LazyServer/LazyCommand/PostCmd"
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey)
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey));
                Tasks.Add(ProbeIntervalSec);

                typeConfigRead = new TypeConfigRead
                {
                    ConfigFile = "LazylogConfig.txt",
                    Category = "Perfmon",
                    Key = "TableSlideMin"
                };
                cmdText = JsonConvert.SerializeObject(typeConfigRead);
                Task<string> TableSlideMin = dataManager.Execute
                    ("ExecuterRest"
                    , "TypeConfigRead"
                    , cmdText
                    , CsLib.RequestType.POST
                    , $"https://{ip}:9090"
                    , @"/LazyServer/LazyCommand/PostCmd"
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey)
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey));
                Tasks.Add(TableSlideMin);

                typeConfigRead = new TypeConfigRead
                {
                    ConfigFile = "LazylogConfig.txt",
                    Category = "Perfmon",
                    Key = "CounterDataRemainTableCnt"
                };
                cmdText = JsonConvert.SerializeObject(typeConfigRead);
                Task<string> CounterDataRemainTableCnt = dataManager.Execute
                    ("ExecuterRest"
                    , "TypeConfigRead"
                    , cmdText
                    , CsLib.RequestType.POST
                    , $"https://{ip}:9090"
                    , @"/LazyServer/LazyCommand/PostCmd"
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey)
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey));
                Tasks.Add(CounterDataRemainTableCnt);

                await Task.WhenAll(Tasks);
                WcfResponse wcfResponse;

                wcfResponse = JsonConvert.DeserializeObject<WcfResponse>(ProbeIntervalSec.Result);
                if (wcfResponse.IsSuccess)
                {
                    string resultMessage = wcfResponse.ResultMessage;
                    typeConfigRead = JsonConvert.DeserializeObject<TypeConfigRead>(resultMessage);
                    textBoxPerfmonProbeIntervalSec.Text = typeConfigRead.Value;
                }
                else
                    throw new Exception(wcfResponse.ErrorMessage);

                string tableSlideMin = "";
                string remainTableCnt = "";

                wcfResponse = JsonConvert.DeserializeObject<WcfResponse>(TableSlideMin.Result);
                if (wcfResponse.IsSuccess)
                {
                    string resultMessage = wcfResponse.ResultMessage;
                    typeConfigRead = JsonConvert.DeserializeObject<TypeConfigRead>(resultMessage);
                    tableSlideMin = typeConfigRead.Value;
                }
                else
                    throw new Exception(wcfResponse.ErrorMessage);

                wcfResponse = JsonConvert.DeserializeObject<WcfResponse>(CounterDataRemainTableCnt.Result);
                if (wcfResponse.IsSuccess)
                {
                    string resultMessage = wcfResponse.ResultMessage;
                    typeConfigRead = JsonConvert.DeserializeObject<TypeConfigRead>(resultMessage);
                    remainTableCnt = typeConfigRead.Value;
                }
                else
                    throw new Exception(wcfResponse.ErrorMessage);

                int.TryParse(tableSlideMin, out int slideMin);
                int.TryParse(remainTableCnt, out int tableCnt);
                textBoxRetentionPeriodMinutes.Text = (slideMin * tableCnt).ToString();

                MessageBox.Show("loaded");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unexpected character encountered while parsing value"))
                {
                    MessageBox.Show("server response error");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                    await ServerListLoad();
                }
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonLoadPolicy, "Load Policy");
            }
        }


        private async void buttonSavePolicy_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelpers.ButtonStatusChange(buttonSavePolicy, "Requested");
                if (ControlHelpers.CheckBoxCheckedCnt(dgvServerList) != 1)
                    throw new Exception("Please select one server");

                string ip = string.Empty;

                foreach (DataGridViewRow item in dgvServerList.Rows)
                {
                    if (bool.Parse(item.Cells["CheckBox"].Value.ToString()))
                    {
                        ip = item.Cells["PublicIp"].Value.ToString();
                        if (
                                !(
                                item.Cells["Status"].Value.ToString().Equals("RUN", StringComparison.OrdinalIgnoreCase) &&
                                item.Cells["Operation"].Value.ToString().Equals("NULL", StringComparison.OrdinalIgnoreCase)
                                )
                            )
                        {
                            throw new Exception("The server is not running. Please use after changing the server running state.");
                        }
                    }
                }

                if (ip.Length == 0)
                    throw new Exception("check public ip");

                if (!long.TryParse(textBoxPerfmonProbeIntervalSec.Text, out long x0))
                    throw new Exception("Error textBoxPerfmonProbeIntervalSec is not numeric value");
                if (x0 < 0)
                    throw new Exception("Error textBoxPerfmonProbeIntervalSec value cannot be negative.");


                List<string> TypeConfigReads = new List<string>();
                List<Task<string>> Tasks = new List<Task<string>>();
                WcfResponse wcfResponse;
                string cmdText = string.Empty;

                var typeConfigSetting = new TypeConfigSetting
                {
                    ConfigFile = "LazylogConfig.txt",
                    Category = "Perfmon",
                    Key = "ProbeIntervalSec",
                    Value = textBoxPerfmonProbeIntervalSec.Text
                };
                cmdText = JsonConvert.SerializeObject(typeConfigSetting);
                Task<string> PerfmonProbeIntervalSec = dataManager.Execute
                    ("ExecuterRest"
                    , "TypeConfigSetting"
                    , cmdText
                    , CsLib.RequestType.POST
                    , $"https://{ip}:9090"
                    , @"/LazyServer/LazyCommand/PostCmd"
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey)
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey));
                Tasks.Add(PerfmonProbeIntervalSec);

                int.TryParse(textBoxRetentionPeriodMinutes.Text.Trim(), out int retentionMinutes);
                int remainTableCnt = 3;
                int slideMin = retentionMinutes / remainTableCnt;

                if (slideMin < 1)
                    slideMin = 1;
                if (remainTableCnt < 2)
                    remainTableCnt = 2; 

                typeConfigSetting = new TypeConfigSetting
                {
                    ConfigFile = "LazylogConfig.txt",
                    Category = "Perfmon",
                    Key = "TableSlideMin",
                    Value = slideMin.ToString()
                };
                cmdText = JsonConvert.SerializeObject(typeConfigSetting);
                Task<string> TableSlideMin = dataManager.Execute
                    ("ExecuterRest"
                    , "TypeConfigSetting"
                    , cmdText
                    , CsLib.RequestType.POST
                    , $"https://{ip}:9090"
                    , @"/LazyServer/LazyCommand/PostCmd"
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey)
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey));
                Tasks.Add(TableSlideMin);

                typeConfigSetting = new TypeConfigSetting
                {
                    ConfigFile = "LazylogConfig.txt",
                    Category = "Perfmon",
                    Key = "CounterDataRemainTableCnt",
                    Value = remainTableCnt.ToString()
                };
                cmdText = JsonConvert.SerializeObject(typeConfigSetting);
                Task<string> CounterDataRemainTableCnt = dataManager.Execute
                    ("ExecuterRest"
                    , "TypeConfigSetting"
                    , cmdText
                    , CsLib.RequestType.POST
                    , $"https://{ip}:9090"
                    , @"/LazyServer/LazyCommand/PostCmd"
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey)
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey));
                Tasks.Add(CounterDataRemainTableCnt);
                //MessageBox.Show($"retentionMinutes : {retentionMinutes}, remainTableCnt : {remainTableCnt}, slideMin : {slideMin}");
                await Task.WhenAll(Tasks);
                
                wcfResponse = JsonConvert.DeserializeObject<WcfResponse>(PerfmonProbeIntervalSec.Result);

                if (!wcfResponse.IsSuccess)
                    throw new Exception(wcfResponse.ErrorMessage);

                Task task = ApplyPolicy(ip);
                await task;

                MessageBox.Show("saved");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unexpected character encountered while parsing value"))
                {
                    MessageBox.Show("server response error");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                    await ServerListLoad();
                }
            }
            finally
            {
                ControlHelpers.ButtonStatusChange(buttonSavePolicy, "Save Policy");
            }
        }

        private async Task ApplyPolicy(string ip)
        {
            try
            {
                string cmdText = string.Empty;
                string response = string.Empty;
                WcfResponse wcfResponse;

                var typeMonController = new TypeMonController
                {
                    MonName = "PerfmonManager",
                    StopStart = "Stop"
                };
                cmdText = JsonConvert.SerializeObject(typeMonController);
                Task<string> BackupMangerStopTask = dataManager.Execute
                    ("ExecuterRest"
                    , "TypeMonController"
                    , cmdText
                    , CsLib.RequestType.POST
                    , $"https://{ip}:9090"
                    , @"/LazyServer/LazyCommand/PostCmd"
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey)
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey));

                response = await BackupMangerStopTask;
                wcfResponse = JsonConvert.DeserializeObject<WcfResponse>(response);

                if (!wcfResponse.IsSuccess)
                    throw new Exception("Perfmon Manager Stop Failed");

                Task task = Task.Delay(3000);
                await task;

                typeMonController = new TypeMonController
                {
                    MonName = "PerfmonManager",
                    StopStart = "Start"
                };
                cmdText = JsonConvert.SerializeObject(typeMonController);
                Task<string> BackupMangerStartTask = dataManager.Execute
                    ("ExecuterRest"
                    , "TypeMonController"
                    , cmdText
                    , CsLib.RequestType.POST
                    , $"https://{ip}:9090"
                    , @"/LazyServer/LazyCommand/PostCmd"
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey)
                    , LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey));

                response = await BackupMangerStartTask;
                wcfResponse = JsonConvert.DeserializeObject<WcfResponse>(response);

                if (!wcfResponse.IsSuccess)
                    throw new Exception("Perfmon Manager Start Failed");

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unexpected character encountered while parsing value"))
                {
                    MessageBox.Show("server response error");
                }
                else
                    MessageBox.Show(ex.Message);
            }
        }
    }
}
