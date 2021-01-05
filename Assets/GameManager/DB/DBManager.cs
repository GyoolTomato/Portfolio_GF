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

        private string DBFilePath_Index
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

        private string DBFilePath_User
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

        private IEnumerator DBCreate_Index()
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

        private IEnumerator DBCreate_User()
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

        public List<DataBase_TDoll> DataBaseRead_TDoll(string query)
        {
            var result = new List<DataBase_TDoll>();
            var tempData = new DataBase_TDoll();

            var dbConnection = new SQLiteConnection(DBFilePath_Index);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            var dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                tempData = new DataBase_TDoll();
                tempData.Id = dataReader.GetInt32(0);
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

            return result;
        }

        private List<DataBase_Equipment> DataBaseRead_Equipment(string query)
        {
            var result = new List<DataBase_Equipment>();
            var tempData = new DataBase_Equipment();

            var dbConnection = new SQLiteConnection(DBFilePath_Index);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            var dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                tempData = new DataBase_Equipment();
                tempData.Id = dataReader.GetInt32(0);
                tempData.Name = dataReader.GetString(1);
                tempData.Type = dataReader.GetString(2);
                tempData.Star = dataReader.GetInt32(3);
                tempData.FirePower = dataReader.GetInt32(4);
                tempData.Focus = dataReader.GetInt32(5);
                tempData.Armor = dataReader.GetInt32(6);
                tempData.Avoidance = dataReader.GetInt32(7);
                tempData.ManufacturingTime = dataReader.GetFloat(8);
                result.Add(tempData);
            }

            dataReader.Dispose();
            dataReader = null;
            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;

            return result;
        }

        public List<DataBase_UserTDoll> DataBaseRead_UserTDoll(string query)
        {
            var result = new List<DataBase_UserTDoll>();
            var tempData = new DataBase_UserTDoll();

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            var dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                tempData = new DataBase_UserTDoll();
                tempData.OwnerShipNumber = dataReader.GetInt32(0);
                tempData.Id = dataReader.GetInt32(1);
                tempData.Level = dataReader.GetInt32(2);
                tempData.DummyLink = dataReader.GetInt32(3);
                tempData.EquipmentOwnerShipNumber0 = dataReader.GetInt32(4);
                tempData.EquipmentOwnerShipNumber1 = dataReader.GetInt32(5);
                tempData.EquipmentOwnerShipNumber2 = dataReader.GetInt32(6);
                result.Add(tempData);
            }

            dataReader.Dispose();
            dataReader = null;
            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;

            return result;
        }

        private List<DataBase_UserEquipment> DataBaseRead_UserEquipment(string query)
        {
            var result = new List<DataBase_UserEquipment>();
            var tempData = new DataBase_UserEquipment();

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            var dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                tempData = new DataBase_UserEquipment();
                tempData.OwnerShipNumber = dataReader.GetInt32(0);
                tempData.Id = dataReader.GetInt32(1);
                tempData.Level = dataReader.GetInt32(2);
                tempData.LimitedPower = dataReader.GetFloat(3);
                result.Add(tempData);
            }

            dataReader.Dispose();
            dataReader = null;
            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;

            return result;
        }

        public void InsertUserDataBase(List<DataBase_UserTDoll> data)
        {
            var query = string.Empty;

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            foreach (var item in data)
        {
                query = string.Empty;
                query = "Insert Into T-Doll(Id, Level, DummyLink, EquipmentOwnerShipNumber0, EquipmentOwnerShipNumber1, EquipmentOwnerShipNumber2) VALUES("
                    + item.Id.ToString()
                    + item.Level.ToString()
                    + item.DummyLink.ToString()
                    + item.EquipmentOwnerShipNumber0.ToString()
                    + item.EquipmentOwnerShipNumber1.ToString()
                    + item.EquipmentOwnerShipNumber2.ToString()
                    + ")";

                dbCommand.CommandText = query;
                dbCommand.ExecuteNonQuery();
            }

            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;
        }

        public void InsertUserDataBase(List<DataBase_UserEquipment> data)
        {
            var query = string.Empty;

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            foreach (var item in data)
            {
                query = string.Empty;
               query = "Insert Into T-Doll(Id, Level, LimitedPower) VALUES("
                    + item.Id.ToString()
                    + item.Level.ToString()
                    + item.LimitedPower.ToString()
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
