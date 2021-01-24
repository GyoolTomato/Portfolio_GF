using System.Collections;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;
using Assets.Common.DB.Common;

namespace Assets.Common.DB.User
{
    public class UserDBManager
    {
        public enum E_Table
        {
            TDoll,
            Equipment,
            WorkResource,
            End,
        }

        private GameManager m_gameManager;
        private DBController_User m_dBController;
        private string m_dBFilePath;

        public UserDBManager()
        {

        }

        public void Initailize(GameManager gameManager)
        {
            m_gameManager = gameManager;
            m_gameManager.StartCoroutine(DBCreate());
            m_dBController = new DBController_User();
            m_dBController.Initialize(this);
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
                var tempData_WorkResource = new CommonDataBase_WorkResource();

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
                            tempData_Equipment.LimitedPower = dataReader.GetFloat(3);
                            result.Add(tempData_Equipment);
                            break;
                        case E_Table.WorkResource:
                            tempData_WorkResource = new CommonDataBase_WorkResource();
                            tempData_WorkResource.Index = dataReader.GetInt32(0);
                            tempData_WorkResource.Name = dataReader.GetString(1);
                            tempData_WorkResource.Value = dataReader.GetInt32(2);
                            result.Add(tempData_WorkResource);
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

                Debug.Log("ReadDataBase Success");
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

                Debug.Log("SQL Success");
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

                Debug.Log("SQL Success");
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

        public DBController_User DBController
        {
            get
            {
                return m_dBController;
            }
        }
    }
}
