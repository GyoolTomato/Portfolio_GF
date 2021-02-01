using System.Collections;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;

namespace Assets.Common.DB.Index.Manager
{
    public class IndexDBManager
    {
        public enum E_Table
        {
            TDoll,
            Equipment,
            End,
        }

        private GameManager m_gameManager;
        private DBController_Index m_dBController;
        private string m_dBFilePath;

        public IndexDBManager()
        {
        }

        public void Initailize(GameManager gameManager)
        {
            m_gameManager = gameManager;
            m_gameManager.StartCoroutine(DBCreate());
            m_dBController = new DBController_Index();
            m_dBController.Initialize(this);
        }

        private string DBName
        {
            get
            {
                return "Index.db";
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
                if (File.Exists(filePath))
                    File.Delete(filePath);

                var unityWebRequest = UnityWebRequest.Get(sourceFilePath);
                unityWebRequest.downloadedBytes.ToString();
                yield return unityWebRequest.SendWebRequest().isDone;
                File.WriteAllBytes(filePath, unityWebRequest.downloadHandler.data);

                Debug.Log("*sourceFile : " + sourceFilePath);
                Debug.Log("*sourceFile2 : " + "jar:file//" + Application.dataPath + "!/assets/Index.db");
                Debug.Log("Create Index DB");
                Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
                Debug.Log("*Download Size : " + unityWebRequest.downloadHandler.data.Length);
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {

            }
            else
            {
                filePath = Path.Combine(Application.dataPath, DBName);
                if (File.Exists(filePath))
                    File.Delete(filePath);

                File.Copy(sourceFilePath, filePath);

                Debug.Log("Create Index DB");
                Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
            }

            m_dBFilePath = filePath;
        }  

        public ArrayList ReadDataBase(E_Table table, string query)
        {
            var result = new ArrayList();

            try
            {
                var tempData_TDoll = new IndexDataBase_TDoll();
                var tempData_Equipment = new IndexDataBase_Equipment();

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
                            tempData_TDoll = new IndexDataBase_TDoll();
                            tempData_TDoll.DataCode = dataReader.GetInt32(0);
                            tempData_TDoll.Name = dataReader.GetString(1);
                            tempData_TDoll.Type = dataReader.GetString(2);
                            tempData_TDoll.Star = dataReader.GetInt32(3);
                            tempData_TDoll.Hp = dataReader.GetInt32(4);
                            tempData_TDoll.FirePower = dataReader.GetInt32(5);
                            tempData_TDoll.AttackRange = dataReader.GetFloat(6);
                            tempData_TDoll.AttackSpeed = dataReader.GetFloat(7);
                            tempData_TDoll.Critical = dataReader.GetFloat(8);
                            tempData_TDoll.Focus = dataReader.GetInt32(9);
                            tempData_TDoll.Armor = dataReader.GetInt32(10);
                            tempData_TDoll.Avoidance = dataReader.GetInt32(11);
                            tempData_TDoll.MoveSpeed = dataReader.GetFloat(12);
                            tempData_TDoll.ManufacturingTime = dataReader.GetFloat(13);
                            result.Add(tempData_TDoll);
                            break;
                        case E_Table.Equipment:
                            tempData_Equipment = new IndexDataBase_Equipment();
                            tempData_Equipment.DataCode = dataReader.GetInt32(0);
                            tempData_Equipment.Name = dataReader.GetString(1);
                            tempData_Equipment.Type = dataReader.GetString(2);
                            tempData_Equipment.Star = dataReader.GetInt32(3);
                            tempData_Equipment.UserCode = dataReader.GetInt32(4);
                            tempData_Equipment.FirePower = dataReader.GetInt32(5);
                            tempData_Equipment.Focus = dataReader.GetInt32(6);
                            tempData_Equipment.Armor = dataReader.GetInt32(7);
                            tempData_Equipment.Critical = dataReader.GetInt32(8);
                            tempData_Equipment.ManufacturingTime = dataReader.GetFloat(9);
                            result.Add(tempData_Equipment);
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
            }

            return result;
        }        

        public DBController_Index DBController
        {
            get
            {
                return m_dBController;
            }
        }
    }
}