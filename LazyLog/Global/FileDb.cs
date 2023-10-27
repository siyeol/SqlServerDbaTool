﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;
//using CsLib;
//using lazylog.Model;
//using System.IO;
//using Newtonsoft.Json;
//using LogClient;


//namespace lazylog
//{
//    class FileDb
//    {
//        object lockObj = new object();
//        public enum TableName { TBL_CLUSTER, TBL_SERVER, TBL_CLUSTER_SERVER }

//        private static readonly Lazy<FileDb> lazy =
//            new Lazy<FileDb>(() => new FileDb(), LazyThreadSafetyMode.ExecutionAndPublication);

//        public static FileDb Instance { get { return lazy.Value; } }

//        Config data = Config.Instance;

//        FileDb() { }

//        public DicWrapper<TBL_CLUSTER_KEY, TBL_CLUSTER_VALUE> TBL_CLUSTER { get; } = new DicWrapper<TBL_CLUSTER_KEY, TBL_CLUSTER_VALUE>();
//        public DicWrapper<TBL_SERVER_KEY, TBL_SERVER_VALUE> TBL_SERVER { get; } = new DicWrapper<TBL_SERVER_KEY, TBL_SERVER_VALUE>();
//        public DicWrapper<TBL_CLUSTER_SERVER_KEY, TBL_CLUSTER_SERVER_VALUE> TBL_CLUSTER_SERVER { get; } = new DicWrapper<TBL_CLUSTER_SERVER_KEY, TBL_CLUSTER_SERVER_VALUE>();

//        public async Task ReadTable(TableName tableName)
//        {
//            await IfNotExistsCreateTableInObject(tableName);
//            await DownloadFileFromObject(tableName);

//            string json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"));
//            switch (tableName)
//            {
//                case TableName.TBL_CLUSTER:
//                    foreach (var a in JsonConvert.DeserializeObject<List<KeyValuePair<TBL_CLUSTER_KEY, TBL_CLUSTER_VALUE>>>(json))
//                    {
//                        TBL_CLUSTER.Insert(
//                            new TBL_CLUSTER_KEY { clusterName = a.Key.clusterName },
//                            new TBL_CLUSTER_VALUE
//                            {
//                                clusterNo = a.Value.clusterNo,
//                                domainName = a.Value.domainName,
//                                clusterPort = a.Value.clusterPort
//                            });
//                    }
//                    break;
//                case TableName.TBL_SERVER:
//                    foreach (var a in JsonConvert.DeserializeObject<List<KeyValuePair<TBL_SERVER_KEY, TBL_SERVER_VALUE>>>(json))
//                    {
//                        TBL_SERVER.Insert(
//                            new TBL_SERVER_KEY { serverName = a.Key.serverName },
//                            new TBL_SERVER_VALUE
//                            {
//                                serverInstanceNo = a.Value.serverInstanceNo,
//                                serverPublicIp = a.Value.serverPublicIp,
//                                serverPrivateIp = a.Value.serverPrivateIp,
//                                serverPort = a.Value.serverPort,
//                                serverUserId = a.Value.serverUserId,
//                                serverPassword = a.Value.serverPassword,
//                                serverAliasName = a.Value.serverAliasName,
//                                regionNo = a.Value.regionNo,
//                                zoneNo = a.Value.zoneNo,
//                                serverImageProductCode = a.Value.serverImageProductCode,
//                                serverProductCode = a.Value.serverProductCode,
//                                feeSystemTypeCode = a.Value.feeSystemTypeCode,
//                                loginKeyName = a.Value.loginKeyName,
//                                accessControlGroupConfigurationNoList_1 = a.Value.accessControlGroupConfigurationNoList_1,
//                                accessControlGroupConfigurationNoList_2 = a.Value.accessControlGroupConfigurationNoList_2,
//                                accessControlGroupConfigurationNoList_3 = a.Value.accessControlGroupConfigurationNoList_3,
//                                accessControlGroupConfigurationNoList_4 = a.Value.accessControlGroupConfigurationNoList_4,
//                                accessControlGroupConfigurationNoList_5 = a.Value.accessControlGroupConfigurationNoList_5
//                            });
//                    }
//                    break;
//                case TableName.TBL_CLUSTER_SERVER:
//                    foreach (var a in JsonConvert.DeserializeObject<List<KeyValuePair<TBL_CLUSTER_SERVER_KEY, TBL_CLUSTER_SERVER_VALUE>>>(json))
//                    {
//                        TBL_CLUSTER_SERVER.Insert(
//                            new TBL_CLUSTER_SERVER_KEY
//                            {
//                                clusterName = a.Key.clusterName,
//                                serverName = a.Key.serverName
//                            },
//                            new TBL_CLUSTER_SERVER_VALUE
//                            {
//                                serverRole = a.Value.serverRole
//                            });
//                    }
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException("unknown table");
//            }
//        }

//        public async Task DeleteTable(TableName tableName, List<KeyValuePair<string, string>> parameters)
//        {
//            await ReadTable(tableName);
//            string clusterName = string.Empty;
//            string serverName = string.Empty;
//            string json = string.Empty;

//            switch (tableName)
//            {
//                case TableName.TBL_CLUSTER:
//                    foreach (var a in parameters)
//                    {
//                        if (a.Key.Equals("clusterName", StringComparison.OrdinalIgnoreCase))
//                            clusterName = a.Value;
//                    }
//                    TBL_CLUSTER.Delete(new TBL_CLUSTER_KEY { clusterName = clusterName });
//                    json = TBL_CLUSTER.GetJson();
//                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"), json);
//                    break;
//                case TableName.TBL_SERVER:
//                    foreach (var a in parameters)
//                    {
//                        if (a.Key.Equals("serverName", StringComparison.OrdinalIgnoreCase))
//                            serverName = a.Value;
//                    }
//                    TBL_SERVER.Delete(new TBL_SERVER_KEY { serverName = serverName });
//                    json = TBL_SERVER.GetJson();
//                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"), json);
//                    break;
//                case TableName.TBL_CLUSTER_SERVER:
//                    foreach (var a in parameters)
//                    {
//                        if (a.Key.Equals("clusterName", StringComparison.OrdinalIgnoreCase))
//                            clusterName = a.Value;
//                        if (a.Key.Equals("serverName", StringComparison.OrdinalIgnoreCase))
//                            serverName = a.Value;
//                    }
//                    TBL_CLUSTER_SERVER.Delete(new TBL_CLUSTER_SERVER_KEY { clusterName = clusterName, serverName = serverName });
//                    json = TBL_CLUSTER_SERVER.GetJson();
//                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"), json);
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException("unknown table");
//            }
//            await UploadFileToObject(tableName);

//        }

//        public async Task UpSertTable(TableName tableName, List<KeyValuePair<string, string>> parameters)
//        {
//            await ReadTable(tableName);
//            string clusterName = "NULL";
//            string serverName = "NULL";
//            string clusterNo = "NULL";
//            string domainName = "NULL";
//            string clusterPort = "NULL";
//            string serverInstanceNo = "NULL";
//            string serverPublicIp = "NULL";
//            string serverPrivateIp = "NULL";
//            string serverPort = "NULL";
//            string serverUserId = "NULL";
//            string serverPassword = "NULL";
//            string serverAliasName = "NULL";
//            string regionNo = "NULL";
//            string zoneNo = "NULL";
//            string serverImageProductCode = "NULL";
//            string serverProductCode = "NULL";
//            string feeSystemTypeCode = "NULL";
//            string loginKeyName = "NULL";
//            string accessControlGroupConfigurationNoList_1 = "NULL";
//            string accessControlGroupConfigurationNoList_2 = "NULL";
//            string accessControlGroupConfigurationNoList_3 = "NULL";
//            string accessControlGroupConfigurationNoList_4 = "NULL";
//            string accessControlGroupConfigurationNoList_5 = "NULL";
//            string serverRole = "NULL";

//            string json = string.Empty;

//            switch (tableName)
//            {
//                case TableName.TBL_CLUSTER:
//                    foreach (var a in parameters)
//                    {
//                        if (a.Key.Equals("clusterName", StringComparison.OrdinalIgnoreCase))
//                            clusterName = a.Value;
//                        if (a.Key.Equals("clusterNo", StringComparison.OrdinalIgnoreCase))
//                            clusterNo = a.Value;
//                        if (a.Key.Equals("domainName", StringComparison.OrdinalIgnoreCase))
//                            domainName = a.Value;
//                        if (a.Key.Equals("clusterPort", StringComparison.OrdinalIgnoreCase))
//                            clusterPort = a.Value;
//                    }
//                    TBL_CLUSTER.Insert(
//                        new TBL_CLUSTER_KEY { clusterName = clusterName }
//                        , new TBL_CLUSTER_VALUE { clusterNo = clusterNo, domainName = domainName, clusterPort = clusterPort });

//                    json = TBL_CLUSTER.GetJson();
//                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"), json);

//                    break;
//                case TableName.TBL_SERVER:
//                    foreach (var a in parameters)
//                    {
//                        if (a.Key.Equals("serverName", StringComparison.OrdinalIgnoreCase))
//                            serverName = a.Value;
//                        if (a.Key.Equals("serverInstanceNo", StringComparison.OrdinalIgnoreCase))
//                            serverInstanceNo = a.Value;
//                        if (a.Key.Equals("serverPublicIp", StringComparison.OrdinalIgnoreCase))
//                            serverPublicIp = a.Value;
//                        if (a.Key.Equals("serverPrivateIp", StringComparison.OrdinalIgnoreCase))
//                            serverPrivateIp = a.Value;
//                        if (a.Key.Equals("serverPort", StringComparison.OrdinalIgnoreCase))
//                            serverPort = a.Value;
//                        if (a.Key.Equals("serverUserId", StringComparison.OrdinalIgnoreCase))
//                            serverUserId = a.Value;
//                        if (a.Key.Equals("serverPassword", StringComparison.OrdinalIgnoreCase))
//                            serverPassword = a.Value;
//                        if (a.Key.Equals("serverAliasName", StringComparison.OrdinalIgnoreCase))
//                            serverAliasName = a.Value;
//                        if (a.Key.Equals("regionNo", StringComparison.OrdinalIgnoreCase))
//                            regionNo = a.Value;
//                        if (a.Key.Equals("zoneNo", StringComparison.OrdinalIgnoreCase))
//                            zoneNo = a.Value;
//                        if (a.Key.Equals("serverImageProductCode", StringComparison.OrdinalIgnoreCase))
//                            serverImageProductCode = a.Value;
//                        if (a.Key.Equals("serverProductCode", StringComparison.OrdinalIgnoreCase))
//                            serverProductCode = a.Value;
//                        if (a.Key.Equals("feeSystemTypeCode", StringComparison.OrdinalIgnoreCase))
//                            feeSystemTypeCode = a.Value;
//                        if (a.Key.Equals("loginKeyName", StringComparison.OrdinalIgnoreCase))
//                            loginKeyName = a.Value;
//                        if (a.Key.Equals("accessControlGroupConfigurationNoList_1", StringComparison.OrdinalIgnoreCase))
//                            accessControlGroupConfigurationNoList_1 = a.Value;
//                        if (a.Key.Equals("accessControlGroupConfigurationNoList_2", StringComparison.OrdinalIgnoreCase))
//                            accessControlGroupConfigurationNoList_2 = a.Value;
//                        if (a.Key.Equals("accessControlGroupConfigurationNoList_3", StringComparison.OrdinalIgnoreCase))
//                            accessControlGroupConfigurationNoList_3 = a.Value;
//                        if (a.Key.Equals("accessControlGroupConfigurationNoList_4", StringComparison.OrdinalIgnoreCase))
//                            accessControlGroupConfigurationNoList_4 = a.Value;
//                        if (a.Key.Equals("accessControlGroupConfigurationNoList_5", StringComparison.OrdinalIgnoreCase))
//                            accessControlGroupConfigurationNoList_5 = a.Value;
//                    }


//                    TBL_SERVER.Insert(
//                        new TBL_SERVER_KEY { serverName = serverName },
//                        new TBL_SERVER_VALUE
//                        {
//                            serverInstanceNo = serverInstanceNo,
//                            serverPublicIp = serverPublicIp,
//                            serverPrivateIp = serverPrivateIp,
//                            serverPort = serverPort,
//                            serverUserId = serverUserId,
//                            serverPassword = serverPassword,
//                            serverAliasName = serverAliasName,
//                            regionNo = regionNo,
//                            zoneNo = zoneNo,
//                            serverImageProductCode = serverImageProductCode,
//                            serverProductCode = serverProductCode,
//                            feeSystemTypeCode = feeSystemTypeCode,
//                            loginKeyName = loginKeyName,
//                            accessControlGroupConfigurationNoList_1 = accessControlGroupConfigurationNoList_1,
//                            accessControlGroupConfigurationNoList_2 = accessControlGroupConfigurationNoList_2,
//                            accessControlGroupConfigurationNoList_3 = accessControlGroupConfigurationNoList_3,
//                            accessControlGroupConfigurationNoList_4 = accessControlGroupConfigurationNoList_4,
//                            accessControlGroupConfigurationNoList_5 = accessControlGroupConfigurationNoList_5
//                        });

//                    json = TBL_SERVER.GetJson();
//                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"), json);

//                    break;
//                case TableName.TBL_CLUSTER_SERVER:
//                    foreach (var a in parameters)
//                    {
//                        if (a.Key.Equals("clusterName", StringComparison.OrdinalIgnoreCase))
//                            clusterName = a.Value;
//                        if (a.Key.Equals("serverName", StringComparison.OrdinalIgnoreCase))
//                            serverName = a.Value;
//                        if (a.Key.Equals("serverRole", StringComparison.OrdinalIgnoreCase))
//                            serverRole = a.Value;
//                    }
//                    TBL_CLUSTER_SERVER.Insert(
//                        new TBL_CLUSTER_SERVER_KEY
//                        {
//                            clusterName = clusterName,
//                            serverName = serverName
//                        },
//                        new TBL_CLUSTER_SERVER_VALUE
//                        {
//                            serverRole = serverRole
//                        });

//                    json = TBL_CLUSTER_SERVER.GetJson();
//                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"), json);

//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException("unknown table");
//            }

//            await UploadFileToObject(tableName);
//        }

//        async Task IfNotExistsCreateTableInObject(TableName tableName)
//        {
//            string bucketName = data.GetValue(Category.Backup, Key.BucketName);

//            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//            ObjectStorage o = new ObjectStorage(
//                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey),
//                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey),
//                data.GetValue(Category.Backup, Key.ObjectStorageServiceUrl));

//            var fileListTask = o.List(bucketName, tableName.ToString());
//            List<ObjectStorageFile> lists = await fileListTask;

//            if (lists.Count() == 0)
//            {
//                string json = "[]";
//                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"), json);
//                await o.UploadObjectAsync(bucketName, Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"), tableName.ToString() + ".txt", cancelTokenSource.Token, 0);
//            }
//        }

//        async Task DownloadFileFromObject(TableName tableName)
//        {
//            string bucketName = data.GetValue(Category.Backup, Key.BucketName);

//            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//            ObjectStorage o = new ObjectStorage(
//                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey),
//                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey),
//                data.GetValue(Category.Backup, Key.ObjectStorageServiceUrl));

//            await o.DownloadObjectAsync(bucketName, Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"), tableName.ToString() + ".txt", cancelTokenSource.Token, 0);
//        }

//        async Task UploadFileToObject(TableName tableName)
//        {
//            string bucketName = data.GetValue(Category.Backup, Key.BucketName);

//            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//            ObjectStorage o = new ObjectStorage(
//                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey),
//                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey),
//                data.GetValue(Category.Backup, Key.ObjectStorageServiceUrl));

//            await o.UploadObjectAsync(bucketName, Path.Combine(AppDomain.CurrentDomain.BaseDirectory + tableName.ToString() + ".txt"), tableName.ToString() + ".txt", cancelTokenSource.Token, 0);
//        }
//    }
//}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CsLib;
using lazylog.Model;
using System.IO;
using Newtonsoft.Json;
using LogClient;


namespace lazylog
{
    class FileDb
    {
        object lockObj = new object();
        public enum TableName { TBL_CLUSTER, TBL_SERVER, TBL_CLUSTER_SERVER , TBL_HEALTH_INFO}

        private static readonly Lazy<FileDb> lazy =
            new Lazy<FileDb>(() => new FileDb(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static FileDb Instance { get { return lazy.Value; } }

        Config data = Config.Instance;

        FileDb() { }

        public DicWrapper<TBL_CLUSTER_KEY, TBL_CLUSTER_VALUE> TBL_CLUSTER { get; } = new DicWrapper<TBL_CLUSTER_KEY, TBL_CLUSTER_VALUE>();
        public DicWrapper<TBL_SERVER_KEY, TBL_SERVER_VALUE> TBL_SERVER { get; } = new DicWrapper<TBL_SERVER_KEY, TBL_SERVER_VALUE>();
        public DicWrapper<TBL_CLUSTER_SERVER_KEY, TBL_CLUSTER_SERVER_VALUE> TBL_CLUSTER_SERVER { get; } = new DicWrapper<TBL_CLUSTER_SERVER_KEY, TBL_CLUSTER_SERVER_VALUE>();
        public DicWrapper<TBL_HEALTH_INFO_KEY, TBL_HEALTH_INFO_VALUE> TBL_HEALTH_INFO { get; } = new DicWrapper<TBL_HEALTH_INFO_KEY, TBL_HEALTH_INFO_VALUE>();

        public async Task ReadTable(TableName tableName, string filePath ="")
        {
            await IfNotExistsCreateTableInObject(tableName, filePath);
            await DownloadFileFromObject(tableName, filePath);
            string key = string.Empty; 
            if (filePath.Trim().Length > 0)
            {
                key = filePath + @"\"+ tableName.ToString();
            }
            else
            {
                key = tableName.ToString();
            }

            string json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"));
            switch (tableName)
            {
                case TableName.TBL_CLUSTER:
                    TBL_CLUSTER.Truncate();
                    foreach (var a in JsonConvert.DeserializeObject<List<KeyValuePair<TBL_CLUSTER_KEY, TBL_CLUSTER_VALUE>>>(json))
                    {
                        TBL_CLUSTER.Insert(
                            new TBL_CLUSTER_KEY { clusterName = a.Key.clusterName },
                            new TBL_CLUSTER_VALUE
                            {
                                clusterNo = a.Value.clusterNo,
                                domainName = a.Value.domainName,
                                clusterPort = a.Value.clusterPort,
                                targetGroupNo = a.Value.targetGroupNo
                            });
                    }
                    break;
                case TableName.TBL_SERVER:
                    TBL_SERVER.Truncate();
                    foreach (var a in JsonConvert.DeserializeObject<List<KeyValuePair<TBL_SERVER_KEY, TBL_SERVER_VALUE>>>(json))
                    {
                        TBL_SERVER.Insert(
                            new TBL_SERVER_KEY { serverName = a.Key.serverName },
                            new TBL_SERVER_VALUE
                            {
                                serverInstanceNo = a.Value.serverInstanceNo,
                                serverPublicIp = a.Value.serverPublicIp,
                                serverPrivateIp = a.Value.serverPrivateIp,
                                serverPort = a.Value.serverPort,
                                serverUserId = a.Value.serverUserId,
                                serverPassword = a.Value.serverPassword,
                                serverAliasName = a.Value.serverAliasName,
                                regionNo = a.Value.regionNo,
                                zoneNo = a.Value.zoneNo,
                                serverImageProductCode = a.Value.serverImageProductCode,
                                serverProductCode = a.Value.serverProductCode,
                                feeSystemTypeCode = a.Value.feeSystemTypeCode,
                                loginKeyName = a.Value.loginKeyName,
                                accessControlGroupConfigurationNoList_1 = a.Value.accessControlGroupConfigurationNoList_1,
                                accessControlGroupConfigurationNoList_2 = a.Value.accessControlGroupConfigurationNoList_2,
                                accessControlGroupConfigurationNoList_3 = a.Value.accessControlGroupConfigurationNoList_3,
                                accessControlGroupConfigurationNoList_4 = a.Value.accessControlGroupConfigurationNoList_4,
                                accessControlGroupConfigurationNoList_5 = a.Value.accessControlGroupConfigurationNoList_5
                            });
                    }
                    break;
                case TableName.TBL_CLUSTER_SERVER:
                    TBL_CLUSTER_SERVER.Truncate();
                    foreach (var a in JsonConvert.DeserializeObject<List<KeyValuePair<TBL_CLUSTER_SERVER_KEY, TBL_CLUSTER_SERVER_VALUE>>>(json))
                    {
                        TBL_CLUSTER_SERVER.Insert(
                            new TBL_CLUSTER_SERVER_KEY
                            {
                                clusterName = a.Key.clusterName,
                                serverName = a.Key.serverName
                            },
                            new TBL_CLUSTER_SERVER_VALUE
                            {
                                serverRole = a.Value.serverRole
                            });
                    }
                    break;
                case TableName.TBL_HEALTH_INFO:
                    TBL_HEALTH_INFO.Truncate();
                    foreach (var a in JsonConvert.DeserializeObject<List<KeyValuePair<TBL_HEALTH_INFO_KEY, TBL_HEALTH_INFO_VALUE>>>(json))
                    {
                        TBL_HEALTH_INFO.Insert(
                            new TBL_HEALTH_INFO_KEY
                            {
                                serverName = a.Key.serverName,
                                time = a.Key.time

                            },
                            new TBL_HEALTH_INFO_VALUE
                            {
                                healthInfo = a.Value.healthInfo
                            });
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("unknown table");
            }
        }

        public async Task DeleteTable(TableName tableName, List<KeyValuePair<string, string>> parameters, string filePath = "")
        {
            await ReadTable(tableName, filePath);
            string clusterName = string.Empty;
            string serverName = string.Empty;
            string time = string.Empty; 
            string json = string.Empty;

            string key = string.Empty;
            if (filePath.Trim().Length > 0)
            {
                key = filePath + @"\" + tableName.ToString();
            }
            else
            {
                key = tableName.ToString();
            }

            switch (tableName)
            {
                case TableName.TBL_CLUSTER:
                    foreach (var a in parameters)
                    {
                        if (a.Key.Equals("clusterName", StringComparison.OrdinalIgnoreCase))
                            clusterName = a.Value;
                    }
                    TBL_CLUSTER.Delete(new TBL_CLUSTER_KEY { clusterName = clusterName });
                    json = TBL_CLUSTER.GetJson();
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), json);
                    break;
                case TableName.TBL_SERVER:
                    foreach (var a in parameters)
                    {
                        if (a.Key.Equals("serverName", StringComparison.OrdinalIgnoreCase))
                            serverName = a.Value;
                    }
                    TBL_SERVER.Delete(new TBL_SERVER_KEY { serverName = serverName });
                    json = TBL_SERVER.GetJson();
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), json);
                    break;
                case TableName.TBL_CLUSTER_SERVER:
                    foreach (var a in parameters)
                    {
                        if (a.Key.Equals("clusterName", StringComparison.OrdinalIgnoreCase))
                            clusterName = a.Value;
                        if (a.Key.Equals("serverName", StringComparison.OrdinalIgnoreCase))
                            serverName = a.Value;
                    }
                    TBL_CLUSTER_SERVER.Delete(new TBL_CLUSTER_SERVER_KEY { clusterName = clusterName, serverName = serverName });
                    json = TBL_CLUSTER_SERVER.GetJson();
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), json);
                    break;
                case TableName.TBL_HEALTH_INFO:
                    foreach (var a in parameters)
                    {
                        if (a.Key.Equals("serverName", StringComparison.OrdinalIgnoreCase))
                            serverName = a.Value;
                        if (a.Key.Equals("time", StringComparison.OrdinalIgnoreCase))
                            time = a.Value;
                    }
                    TBL_HEALTH_INFO.Delete(new TBL_HEALTH_INFO_KEY { serverName = serverName, time = time });
                    json = TBL_HEALTH_INFO.GetJson();
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), json);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("unknown table");
            }
            await UploadFileToObject(tableName, filePath);

        }

        public async Task UpSertTable(TableName tableName, List<KeyValuePair<string, string>> parameters, string filePath = "")
        {
            await ReadTable(tableName, filePath);
            string clusterName = "NULL";
            string serverName = "NULL";
            string clusterNo = "NULL";
            string domainName = "NULL";
            string clusterPort = "NULL";
            string targetGroupNo = "NULL";
            string serverInstanceNo = "NULL";
            string serverPublicIp = "NULL";
            string serverPrivateIp = "NULL";
            string serverPort = "NULL";
            string serverUserId = "NULL";
            string serverPassword = "NULL";
            string serverAliasName = "NULL";
            string regionNo = "NULL";
            string zoneNo = "NULL";
            string serverImageProductCode = "NULL";
            string serverProductCode = "NULL";
            string feeSystemTypeCode = "NULL";
            string loginKeyName = "NULL";
            string accessControlGroupConfigurationNoList_1 = "NULL";
            string accessControlGroupConfigurationNoList_2 = "NULL";
            string accessControlGroupConfigurationNoList_3 = "NULL";
            string accessControlGroupConfigurationNoList_4 = "NULL";
            string accessControlGroupConfigurationNoList_5 = "NULL";
            string serverRole = "NULL";
            string time = "NULL";
            string healthInfo = "NULL";

            string json = string.Empty;

            string key = string.Empty;
            if (filePath.Trim().Length > 0)
            {
                key = filePath + @"\" + tableName.ToString();
            }
            else
            {
                key = tableName.ToString();
            }

            switch (tableName)
            {
                case TableName.TBL_CLUSTER:
                    foreach (var a in parameters)
                    {
                        if (a.Key.Equals("clusterName", StringComparison.OrdinalIgnoreCase))
                            clusterName = a.Value;
                        if (a.Key.Equals("clusterNo", StringComparison.OrdinalIgnoreCase))
                            clusterNo = a.Value;
                        if (a.Key.Equals("domainName", StringComparison.OrdinalIgnoreCase))
                            domainName = a.Value;
                        if (a.Key.Equals("clusterPort", StringComparison.OrdinalIgnoreCase))
                            clusterPort = a.Value;
                        if (a.Key.Equals("targetGroupNo", StringComparison.OrdinalIgnoreCase))
                            targetGroupNo = a.Value;
                    }
                    TBL_CLUSTER.Insert(
                        new TBL_CLUSTER_KEY { clusterName = clusterName }
                        , new TBL_CLUSTER_VALUE { clusterNo = clusterNo, domainName = domainName, clusterPort = clusterPort, targetGroupNo = targetGroupNo });

                    json = TBL_CLUSTER.GetJson();
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), json);

                    break;
                case TableName.TBL_SERVER:
                    foreach (var a in parameters)
                    {
                        if (a.Key.Equals("serverName", StringComparison.OrdinalIgnoreCase))
                            serverName = a.Value;
                        if (a.Key.Equals("serverInstanceNo", StringComparison.OrdinalIgnoreCase))
                            serverInstanceNo = a.Value;
                        if (a.Key.Equals("serverPublicIp", StringComparison.OrdinalIgnoreCase))
                            serverPublicIp = a.Value;
                        if (a.Key.Equals("serverPrivateIp", StringComparison.OrdinalIgnoreCase))
                            serverPrivateIp = a.Value;
                        if (a.Key.Equals("serverPort", StringComparison.OrdinalIgnoreCase))
                            serverPort = a.Value;
                        if (a.Key.Equals("serverUserId", StringComparison.OrdinalIgnoreCase))
                            serverUserId = a.Value;
                        if (a.Key.Equals("serverPassword", StringComparison.OrdinalIgnoreCase))
                            serverPassword = a.Value;
                        if (a.Key.Equals("serverAliasName", StringComparison.OrdinalIgnoreCase))
                            serverAliasName = a.Value;
                        if (a.Key.Equals("regionNo", StringComparison.OrdinalIgnoreCase))
                            regionNo = a.Value;
                        if (a.Key.Equals("zoneNo", StringComparison.OrdinalIgnoreCase))
                            zoneNo = a.Value;
                        if (a.Key.Equals("serverImageProductCode", StringComparison.OrdinalIgnoreCase))
                            serverImageProductCode = a.Value;
                        if (a.Key.Equals("serverProductCode", StringComparison.OrdinalIgnoreCase))
                            serverProductCode = a.Value;
                        if (a.Key.Equals("feeSystemTypeCode", StringComparison.OrdinalIgnoreCase))
                            feeSystemTypeCode = a.Value;
                        if (a.Key.Equals("loginKeyName", StringComparison.OrdinalIgnoreCase))
                            loginKeyName = a.Value;
                        if (a.Key.Equals("accessControlGroupConfigurationNoList_1", StringComparison.OrdinalIgnoreCase))
                            accessControlGroupConfigurationNoList_1 = a.Value;
                        if (a.Key.Equals("accessControlGroupConfigurationNoList_2", StringComparison.OrdinalIgnoreCase))
                            accessControlGroupConfigurationNoList_2 = a.Value;
                        if (a.Key.Equals("accessControlGroupConfigurationNoList_3", StringComparison.OrdinalIgnoreCase))
                            accessControlGroupConfigurationNoList_3 = a.Value;
                        if (a.Key.Equals("accessControlGroupConfigurationNoList_4", StringComparison.OrdinalIgnoreCase))
                            accessControlGroupConfigurationNoList_4 = a.Value;
                        if (a.Key.Equals("accessControlGroupConfigurationNoList_5", StringComparison.OrdinalIgnoreCase))
                            accessControlGroupConfigurationNoList_5 = a.Value;
                    }


                    TBL_SERVER.Insert(
                        new TBL_SERVER_KEY { serverName = serverName },
                        new TBL_SERVER_VALUE
                        {
                            serverInstanceNo = serverInstanceNo,
                            serverPublicIp = serverPublicIp,
                            serverPrivateIp = serverPrivateIp,
                            serverPort = serverPort,
                            serverUserId = serverUserId,
                            serverPassword = serverPassword,
                            serverAliasName = serverAliasName,
                            regionNo = regionNo,
                            zoneNo = zoneNo,
                            serverImageProductCode = serverImageProductCode,
                            serverProductCode = serverProductCode,
                            feeSystemTypeCode = feeSystemTypeCode,
                            loginKeyName = loginKeyName,
                            accessControlGroupConfigurationNoList_1 = accessControlGroupConfigurationNoList_1,
                            accessControlGroupConfigurationNoList_2 = accessControlGroupConfigurationNoList_2,
                            accessControlGroupConfigurationNoList_3 = accessControlGroupConfigurationNoList_3,
                            accessControlGroupConfigurationNoList_4 = accessControlGroupConfigurationNoList_4,
                            accessControlGroupConfigurationNoList_5 = accessControlGroupConfigurationNoList_5
                        });

                    json = TBL_SERVER.GetJson();
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), json);

                    break;
                case TableName.TBL_CLUSTER_SERVER:
                    foreach (var a in parameters)
                    {
                        if (a.Key.Equals("clusterName", StringComparison.OrdinalIgnoreCase))
                            clusterName = a.Value;
                        if (a.Key.Equals("serverName", StringComparison.OrdinalIgnoreCase))
                            serverName = a.Value;
                        if (a.Key.Equals("serverRole", StringComparison.OrdinalIgnoreCase))
                            serverRole = a.Value;
                    }
                    TBL_CLUSTER_SERVER.Insert(
                        new TBL_CLUSTER_SERVER_KEY
                        {
                            clusterName = clusterName,
                            serverName = serverName
                        },
                        new TBL_CLUSTER_SERVER_VALUE
                        {
                            serverRole = serverRole
                        });

                    json = TBL_CLUSTER_SERVER.GetJson();
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), json);
                    break;
                case TableName.TBL_HEALTH_INFO:
                    foreach (var a in parameters)
                    {
                        if (a.Key.Equals("serverName", StringComparison.OrdinalIgnoreCase))
                            serverName = a.Value;
                        if (a.Key.Equals("time", StringComparison.OrdinalIgnoreCase))
                            time = a.Value;
                        if (a.Key.Equals("healthInfo", StringComparison.OrdinalIgnoreCase))
                            healthInfo = a.Value;
                    }
                    TBL_HEALTH_INFO.Insert(
                        new TBL_HEALTH_INFO_KEY
                        {
                            serverName = serverName,
                            time = time
                        },
                        new TBL_HEALTH_INFO_VALUE
                        {
                            healthInfo = healthInfo
                        });

                    json = TBL_HEALTH_INFO.GetJson();
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), json);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("unknown table");
            }

            await UploadFileToObject(tableName, filePath);
        }

        async Task IfNotExistsCreateTableInObject(TableName tableName, string filePath = "")
        {
            string bucketName = data.GetValue(Category.Backup, Key.BucketName);

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            ObjectStorage o = new ObjectStorage(
                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey),
                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey),
                data.GetValue(Category.Backup, Key.ObjectStorageServiceUrl));

            string key = string.Empty; 

            if (filePath.Trim().Length > 0)
            {
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + filePath))
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + filePath);

                key = filePath + @"/" + tableName.ToString(); 
            }
            else
            {
                key = tableName.ToString();
            }


            var fileListTask = o.List(bucketName, key+".txt");
            List<ObjectStorageFile> lists = await fileListTask;


            bool isFileEmpty = false; 

            foreach (var a in lists)
            {
                if (a.Length == 0)
                {
                    isFileEmpty = true;
                }
            }

            if (lists.Count() == 0 || isFileEmpty)
            {
                string json = "[]";
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), json);
                await o.UploadObjectAsync(bucketName, Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), key + ".txt", cancelTokenSource.Token, 0);
            }
        }

        async Task DownloadFileFromObject(TableName tableName, string filePath="")
        {
            string bucketName = data.GetValue(Category.Backup, Key.BucketName);

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            ObjectStorage o = new ObjectStorage(
                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey),
                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey),
                data.GetValue(Category.Backup, Key.ObjectStorageServiceUrl));


            string key = string.Empty;
            
            if (filePath.Trim().Length > 0)
            {
                key = filePath + @"/" + tableName.ToString();
            }
            else
            {
                key = tableName.ToString();
            }
            
            await o.DownloadObjectAsync(bucketName, Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), key + ".txt", cancelTokenSource.Token, 0);
        }

        async Task UploadFileToObject(TableName tableName, string filePath="")
        {
            string bucketName = data.GetValue(Category.Backup, Key.BucketName);

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            ObjectStorage o = new ObjectStorage(
                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.AccessKey),
                LogClient.Config.Instance.GetValue(LogClient.Category.Api, LogClient.Key.SecretKey),
                data.GetValue(Category.Backup, Key.ObjectStorageServiceUrl));


            string key = string.Empty;

            if (filePath.Trim().Length > 0)
            {
                key = filePath + @"/" + tableName.ToString();
            }
            else
            {
                key = tableName.ToString();
            }

            await o.UploadObjectAsync(bucketName, Path.Combine(AppDomain.CurrentDomain.BaseDirectory + key + ".txt"), key + ".txt", cancelTokenSource.Token, 0);
        }
    }
}
