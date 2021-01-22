using System.Collections;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;

namespace Assets.Common.DB.Index
{
    public class IndexDBManager
    {
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

        public List<IndexDataBase_TDoll> ReadIndexDataBase_TDoll(string query)
        {
            var result = new List<IndexDataBase_TDoll>();

            try
            {
                var tempData = new IndexDataBase_TDoll();

                var dbConnection = new SqliteConnection(ReadDBFilePath);
                dbConnection.Open();
                var dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = query;
                var dataReader = dbCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    tempData = new IndexDataBase_TDoll();
                    tempData.DataCode = dataReader.GetInt32(0);
                    tempData.Name = dataReader.GetString(1);
                    tempData.Type = dataReader.GetString(2);
                    tempData.Star = dataReader.GetInt32(3);
                    tempData.Hp = dataReader.GetInt32(4);
                    tempData.FirePower = dataReader.GetInt32(5);
                    tempData.AttackRange = dataReader.GetFloat(6);
                    tempData.AttackSpeed = dataReader.GetFloat(7);
                    tempData.Critical = dataReader.GetFloat(8);
                    tempData.Focus = dataReader.GetInt32(9);
                    tempData.Armor = dataReader.GetInt32(10);
                    tempData.Avoidance = dataReader.GetInt32(11);
                    tempData.MoveSpeed = dataReader.GetFloat(12);
                    tempData.ManufacturingTime = dataReader.GetFloat(13);
                    result.Add(tempData);
                }

                dataReader.Dispose();
                dataReader = null;
                dbCommand.Dispose();
                dbCommand = null;
                dbConnection.Close();
                dbConnection = null;

                Debug.Log("ReadIndexDataBase_TDoll Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("ReadIndexDataBase_TDoll Fail");
                Debug.Log("*Exception : " + e.ToString());
            }

            return result;
        }

        public List<IndexDataBase_Equipment> ReadIndexDataBase_Equipment(string query)
        {
            var result = new List<IndexDataBase_Equipment>();

            try
            {
                var tempData = new IndexDataBase_Equipment();

                var dbConnection = new SqliteConnection(ReadDBFilePath);
                dbConnection.Open();
                var dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = query;
                var dataReader = dbCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    tempData = new IndexDataBase_Equipment();
                    tempData.DataCode = dataReader.GetInt32(0);
                    tempData.Name = dataReader.GetString(1);
                    tempData.Type = dataReader.GetString(2);
                    tempData.Star = dataReader.GetInt32(3);
                    tempData.UserCode = dataReader.GetInt32(4);
                    tempData.FirePower = dataReader.GetInt32(5);
                    tempData.Focus = dataReader.GetInt32(6);
                    tempData.Armor = dataReader.GetInt32(7);
                    tempData.Critical = dataReader.GetInt32(8);
                    tempData.ManufacturingTime = dataReader.GetFloat(9);
                    result.Add(tempData);
                }

                dataReader.Dispose();
                dataReader = null;
                dbCommand.Dispose();
                dbCommand = null;
                dbConnection.Close();
                dbConnection = null;

                Debug.Log("ReadIndexDataBase_Equipment Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("ReadIndexDataBase_Equipment Fail");
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