using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SQLite;
using System.Data;
using System.IO;
using UnityEngine.Networking;

namespace Assets.GameManager.DB
{
    public class DBManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(DBCreate_Index());
        }

        // Update is called once per frame
        void Update()
        {

        }

        private string DBName_Index
        {
            get
            {
                return "Index.db";
            }
        }

        private string DBName_User
        {
            get
            {
                return "User.db";
            }
        }

        IEnumerator DBCreate_Index()
        {
            Debug.Log("Insert DB Create");
            var filePath = string.Empty;
            if (Application.platform == RuntimePlatform.Android)
            {
                filePath = Path.Combine(Application.persistentDataPath, DBName_Index);
                if (!File.Exists(filePath))
                {
                    var unityWebRequest = UnityWebRequest.Get("jar:file//" + Application.dataPath + "!/assets/Index.db");
                    unityWebRequest.downloadedBytes.ToString();
                    yield return unityWebRequest.SendWebRequest().isDone;
                    File.WriteAllBytes(filePath, unityWebRequest.downloadHandler.data);
                }
                else
                {
                    Debug.Log("Find DB");
                }
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {

            }
            else
            {
                filePath = Path.Combine(Application.dataPath, DBName_Index);
                if (!File.Exists(filePath))
                {
                    File.Copy(Path.Combine(Application.streamingAssetsPath, DBName_Index), filePath);
                }
                else
                {
                    Debug.Log("Find DB");
                }
            }

            StartCoroutine(DBCreate_User());
        }

        IEnumerator DBCreate_User()
        {
            Debug.Log("Insert DB Create");
            var filePath = string.Empty;
            if (Application.platform == RuntimePlatform.Android)
            {
                filePath = Path.Combine(Application.persistentDataPath, DBName_User);
                if (!File.Exists(filePath))
                {
                    var unityWebRequest = UnityWebRequest.Get("jar:file//" + Application.dataPath + "!/assets/User.db");
                    unityWebRequest.downloadedBytes.ToString();
                    yield return unityWebRequest.SendWebRequest().isDone;
                    File.WriteAllBytes(filePath, unityWebRequest.downloadHandler.data);
                }
                else
                {
                    Debug.Log("Find DB");
                }
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {

            }
            else
            {
                filePath = Path.Combine(Application.dataPath, DBName_User);
                if (!File.Exists(filePath))
                {
                    File.Copy(Path.Combine(Application.streamingAssetsPath, DBName_User), filePath);
                }
                else
                {
                    Debug.Log("Find DB");
                }
            }
        }

        public string DBFilePath_Index
        {
            get
            {
                var path = string.Empty;
                if (Application.platform == RuntimePlatform.Android)
                {
                    path = "URI=file:" + Path.Combine(Application.persistentDataPath, DBName_Index);
                }
                else if (Application.platform == RuntimePlatform.IPhonePlayer)
                {

                }
                else
                {
                    path = "URI=file:" + Path.Combine(Application.dataPath, DBName_Index);
                }

                return path;
            }
        }

        public string DBFilePath_User
        {
            get
            {
                var path = string.Empty;
                if (Application.platform == RuntimePlatform.Android)
                {
                    path = "URI=file:" + Path.Combine(Application.persistentDataPath, DBName_User);
                }
                else if (Application.platform == RuntimePlatform.IPhonePlayer)
                {

                }
                else
                {
                    path = "URI=file:" + Path.Combine(Application.dataPath, DBName_User);
                }

                return path;
            }
        }

        private List<DataBase_TDoll> DataBaseRead_TDoll(string query)
        {
            var result = new List<DataBase_TDoll>();

            var dbConnection = new SQLiteConnection(DBFilePath_Index);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            var dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                
            }

            dataReader.Dispose();
            dataReader = null;
            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;

            return result;
        }

        private List<DataBase_UserTDoll> DataBaseRead_UserTDoll(string query)
        {
            var result = new List<DataBase_UserTDoll>();

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            var dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {

            }

            dataReader.Dispose();
            dataReader = null;
            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;

            return result;
        }

        private List<DataBase_Equipment> DataBaseRead_Equipment(string query)
        {
            var result = new List<DataBase_Equipment>();

            var dbConnection = new SQLiteConnection(DBFilePath_Index);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            var dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {

            }

            dataReader.Dispose();
            dataReader = null;
            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;

            return result;
        }

        private List<DataBase_Equipment> DataBaseRead_UserEquipment(string query)
        {
            var result = new List<DataBase_Equipment>();

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            var dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {

            }

            dataReader.Dispose();
            dataReader = null;
            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;

            return result;
        }

        private void InsertUserDataBase(List<DataBase_TDoll> data)
        {
            var query = string.Empty;

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            foreach (var item in data)
            {
                query = string.Empty;
                query = "Insert Into T-Doll(UniqueNumber, Level, DummyLink, EquipmentOwnerShipNumber0, EquipmentOwnerShipNumber1, EquipmentOwnerShipNumber2) VALUES("
                    + item.UniqueNumber.ToString()
                    + "1"
                    + "1"
                    + "0"
                    + "0"
                    + "0"
                    + ")";

                dbCommand.CommandText = query;
                dbCommand.ExecuteNonQuery();
            }

            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;
        }

        private void InsertUserDataBase(List<DataBase_Equipment> data)
        {
            var query = string.Empty;

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            foreach (var item in data)
            {
                query = string.Empty;
               query = "Insert Into T-Doll(UniqueNumber, Level, LimitedPower) VALUES("
                    + item.UniqueNumber.ToString()
                    + "1"
                    + "50.0"
                    + ")";

                dbCommand.CommandText = query;
                dbCommand.ExecuteNonQuery();
            }

            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;
        }
    }
}
