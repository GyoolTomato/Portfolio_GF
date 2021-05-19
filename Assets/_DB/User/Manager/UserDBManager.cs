using System.Collections;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;
using Assets.DB.Common;

namespace Assets.DB.User.Manager
{
    public class UserDBManager
    {
        public enum E_Table
        {
            TDoll,
            Equipment,
            Resource,
            Produce,
            Platoon,
            Stage,
            End,
        }

        private DbManager m_dbManager;
        private string m_dBFilePath;

        public UserDBManager()
        {

        }

        public void Initailize(DbManager dbManager)
        {
            m_dbManager = dbManager;
            m_dbManager.StartCoroutine(DBCreate());
        }

        private string DBName
        {
            get
            {
                return "User.db";
            }
        }

        private string ReadDBFilePath
        {
            get
            {
                return "URI=file:" + m_dBFilePath;
            }
        }

        private IEnumerator DBCreate()
        {
            var sourceFilePath = Path.Combine(Application.streamingAssetsPath, DBName);
            var filePath = string.Empty;
            if (Application.platform == RuntimePlatform.Android)
            {
                filePath = Path.Combine(Application.persistentDataPath, DBName);
                if (!File.Exists(filePath))
                {
                    var unityWebRequest = UnityWebRequest.Get(sourceFilePath);
                    unityWebRequest.downloadedBytes.ToString();
                    yield return unityWebRequest.SendWebRequest().isDone;
                    File.WriteAllBytes(filePath, unityWebRequest.downloadHandler.data);

                    Debug.Log("Create User DB");
                    Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
                }
                else
                {
                    Debug.Log("Find User DB");
                }
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {

            }
            else
            {
                filePath = Path.Combine(Application.dataPath, DBName);
                if (!File.Exists(filePath))
                {
                    File.Copy(sourceFilePath, filePath);

                    Debug.Log("Create User DB");
                    Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
                }
                else
                {
                    Debug.Log("Find DB");
                }
            }

            m_dBFilePath = filePath;
        }

        public ArrayList ReadDataBase(E_Table table, string query)
        {
            var result = new ArrayList();

            try
            {
                var tempData_TDoll = new UserDataBase_TDoll();
                var tempData_Equipment = new UserDataBase_Equipment();
                var tempData_Resource = new CommonDataBase_Resource();
                var tempData_Produce = new UserDataBase_Produce();
                var tempData_Platoon = new UserDataBase_Platoon();
                var tempData_Stage = new UserDataBase_Stage();

                var dbConnection = new SqliteConnection(ReadDBFilePath);
                dbConnection.Open();
                var dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = query;
                var dataReader = dbCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    switch (table)
                    {
                        case E_Table.TDoll:
                            tempData_TDoll = new UserDataBase_TDoll();
                            tempData_TDoll.OwnershipCode = dataReader.GetInt32(0);
                            tempData_TDoll.DataCode = dataReader.GetInt32(1);
                            tempData_TDoll.Level = dataReader.GetInt32(2);
                            tempData_TDoll.DummyLink = dataReader.GetInt32(3);
                            tempData_TDoll.Platoon = dataReader.GetInt32(4);
                            tempData_TDoll.EquipmentOwnershipNumber0 = dataReader.GetInt32(5);
                            tempData_TDoll.EquipmentOwnershipNumber1 = dataReader.GetInt32(6);
                            tempData_TDoll.EquipmentOwnershipNumber2 = dataReader.GetInt32(7);
                            result.Add(tempData_TDoll);
                            break;
                        case E_Table.Equipment:
                            tempData_Equipment = new UserDataBase_Equipment();
                            tempData_Equipment.OwnershipCode = dataReader.GetInt32(0);
                            tempData_Equipment.DataCode = dataReader.GetInt32(1);
                            tempData_Equipment.Level = dataReader.GetInt32(2);
                            tempData_Equipment.LimitedPower = dataReader.GetInt32(3);
                            result.Add(tempData_Equipment);
                            break;
                        case E_Table.Resource:
                            tempData_Resource = new CommonDataBase_Resource();
                            tempData_Resource.Index = dataReader.GetInt32(0);
                            tempData_Resource.Name = dataReader.GetString(1);
                            tempData_Resource.Value = dataReader.GetInt32(2);
                            result.Add(tempData_Resource);
                            break;
                        case E_Table.Produce:
                            tempData_Produce = new UserDataBase_Produce();
                            tempData_Produce.Index = dataReader.GetInt32(0);
                            tempData_Produce.Slot = dataReader.GetInt32(1);
                            tempData_Produce.Active = dataReader.GetString(2);
                            tempData_Produce.CompleteTime = dataReader.GetString(3);
                            tempData_Produce.DataCode = dataReader.GetInt32(4);
                            result.Add(tempData_Produce);
                            break;
                        case E_Table.Platoon:
                            tempData_Platoon = new UserDataBase_Platoon();
                            tempData_Platoon.Number = dataReader.GetInt32(0);
                            tempData_Platoon.Member1 = dataReader.GetInt32(1);
                            tempData_Platoon.Member2 = dataReader.GetInt32(2);
                            tempData_Platoon.Member3 = dataReader.GetInt32(3);
                            tempData_Platoon.Member4 = dataReader.GetInt32(4);                                                  
                            result.Add(tempData_Platoon);
                            break;
                        case E_Table.Stage:
                            tempData_Stage = new UserDataBase_Stage();
                            tempData_Stage.Index = dataReader.GetInt32(0);
                            tempData_Stage.StageNumber = dataReader.GetInt32(1);
                            tempData_Stage.InnerNumber = dataReader.GetInt32(2);
                            tempData_Stage.Name = dataReader.GetString(3);
                            tempData_Stage.Challenge = dataReader.GetInt32(4);
                            result.Add(tempData_Stage);
                            break;
                        default:
                            break;
                    }
                }

                dataReader.Dispose();
                dataReader = null;
                dbCommand.Dispose();
                dbCommand = null;
                dbConnection.Close();
                dbConnection = null;
            }
            catch (System.Exception e)
            {
                Debug.Log("ReadDataBase Fail");
                Debug.Log("*Exception : " + e.ToString());
                Debug.Log("*URL : " + ReadDBFilePath);
                Debug.Log("*Path : " + m_dBFilePath);
                Debug.Log("*Exist : " + File.Exists(m_dBFilePath).ToString());
                if (File.Exists(m_dBFilePath))
                {
                    Debug.Log("*Size : " + File.ReadAllBytes(m_dBFilePath).Length);
                }
            }

            return result;
        }

        public void SQL(List<string> query)
        {
            try
            {
                var dbConnection = new SqliteConnection(ReadDBFilePath);
                dbConnection.Open();
                var dbCommand = dbConnection.CreateCommand();

                foreach (var item in query)
                {
                    dbCommand.CommandText = item;
                    dbCommand.ExecuteNonQuery();
                }

                dbCommand.Dispose();
                dbCommand = null;
                dbConnection.Close();
                dbConnection = null;
            }
            catch (System.Exception e)
            {
                Debug.Log("SQL Fail");
                Debug.Log("*Exception : " + e.ToString());
                Debug.Log("*URL : " + ReadDBFilePath);
                Debug.Log("*Path : " + m_dBFilePath);
                Debug.Log("*Exist : " + File.Exists(m_dBFilePath).ToString());
                if (File.Exists(m_dBFilePath))
                {
                    Debug.Log("*Size : " + File.ReadAllBytes(m_dBFilePath).Length);
                }
            }
        }

        public void SQL(string query)
        {
            try
            {
                var dbConnection = new SqliteConnection(ReadDBFilePath);
                dbConnection.Open();
                var dbCommand = dbConnection.CreateCommand();

                dbCommand.CommandText = query;
                dbCommand.ExecuteNonQuery();

                dbCommand.Dispose();
                dbCommand = null;
                dbConnection.Close();
                dbConnection = null;
            }
            catch (System.Exception e)
            {
                Debug.Log("SQL Fail");
                Debug.Log("*Exception : " + e.ToString());
                Debug.Log("*URL : " + ReadDBFilePath);
                Debug.Log("*Path : " + m_dBFilePath);
                Debug.Log("*Exist : " + File.Exists(m_dBFilePath).ToString());
                if (File.Exists(m_dBFilePath))
                {
                    Debug.Log("*Size : " + File.ReadAllBytes(m_dBFilePath).Length);
                }
            }
        }
    }
}