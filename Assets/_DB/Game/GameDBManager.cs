using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;

namespace Assets.DB.Game
{
    public class GameDBManager
    {
        private DbManager m_dbManager;
        private string m_dBFilePath;

        public GameDBManager()
        {

        }

        public void Initailize(DbManager dbManager)
        {
            m_dbManager = dbManager;
            m_dbManager.StartCoroutine(DBCreate());
        }

        private IEnumerator DBCreate()
        {
            m_dBFilePath = "URI=file:";

            if (Application.platform == RuntimePlatform.Android)
                m_dBFilePath += DbFile.GameDBPath_Android;
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
                m_dBFilePath += string.Empty;
            else
                m_dBFilePath += DbFile.GameDBPath_PC;

            if (File.Exists(m_dBFilePath))
                File.Delete(m_dBFilePath);

            var webClient = new WebClient();
            webClient.DownloadFileAsync(Server.GameDBUrl, m_dBFilePath);
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            yield return !webClient.IsBusy;
            webClient.Dispose();
        }

        private void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Debug.Log("GameDB Download Complete");
        }

        // StreamingAssets에서 복사
        //private IEnumerator DBCreate()
        //{
        //    var sourceFilePath = Path.Combine(Application.streamingAssetsPath, DBName);
        //    var filePath = string.Empty;
        //    if (Application.platform == RuntimePlatform.Android)
        //    {
        //        filePath = Path.Combine(Application.persistentDataPath, DBName);
        //        if (File.Exists(filePath))
        //            File.Delete(filePath);

        //        var unityWebRequest = UnityWebRequest.Get(sourceFilePath);
        //        unityWebRequest.downloadedBytes.ToString();
        //        yield return unityWebRequest.SendWebRequest().isDone;
        //        File.WriteAllBytes(filePath, unityWebRequest.downloadHandler.data);

        //        Debug.Log("*sourceFile : " + sourceFilePath);
        //        Debug.Log("Create Index DB");
        //        Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
        //        Debug.Log("*Download Size : " + unityWebRequest.downloadHandler.data.Length);
        //    }
        //    else if (Application.platform == RuntimePlatform.IPhonePlayer)
        //    {

        //    }
        //    else
        //    {
        //        filePath = Path.Combine(Application.dataPath, DBName);
        //        if (File.Exists(filePath))
        //            File.Delete(filePath);

        //        File.Copy(sourceFilePath, filePath);

        //        Debug.Log("Create Index DB");
        //        Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
        //    }

        //    m_dBFilePath = filePath;
        //}      

        public List<GameDataBase_ProbabilityEquipment> Read_ProbabilityEquipment(string query)
        {
            var result = new List<GameDataBase_ProbabilityEquipment>();

            try
            {
                var tempData = new GameDataBase_ProbabilityEquipment();

                var dbConnection = new SqliteConnection(m_dBFilePath);
                dbConnection.Open();
                var dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = query;
                var dataReader = dbCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    tempData = new GameDataBase_ProbabilityEquipment();
                    tempData.Index = dataReader.GetInt32(0);
                    tempData.Star = dataReader.GetInt32(1);
                    tempData.Probability = dataReader.GetInt32(2);
                    result.Add(tempData);
                }

                dataReader.Dispose();
                dataReader = null;
                dbCommand.Dispose();
                dbCommand = null;
                dbConnection.Close();
                dbConnection = null;

                Debug.Log("GameDataBase_ProbabilityEquipment Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("GameDataBase_ProbabilityEquipment Fail");
                Debug.Log("*Exception : " + e.ToString());
            }

            return result;
        }

        public List<GameDataBase_ProbabilityTDoll> Read_ProbabilityTDoll(string query)
        {
            var result = new List<GameDataBase_ProbabilityTDoll>();

            try
            {
                var tempData = new GameDataBase_ProbabilityTDoll();

                var dbConnection = new SqliteConnection(m_dBFilePath);
                dbConnection.Open();
                var dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = query;
                var dataReader = dbCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    tempData = new GameDataBase_ProbabilityTDoll();
                    tempData.Index = dataReader.GetInt32(0);
                    tempData.Star = dataReader.GetInt32(1);
                    tempData.Probability = dataReader.GetInt32(2);
                    result.Add(tempData);
                }

                dataReader.Dispose();
                dataReader = null;
                dbCommand.Dispose();
                dbCommand = null;
                dbConnection.Close();
                dbConnection = null;

                Debug.Log("GameDataBase_ProbabilityTDoll Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("GameDataBase_ProbabilityTDoll Fail");
                Debug.Log("*Exception : " + e.ToString());
            }

            return result;
        }
    }
}
