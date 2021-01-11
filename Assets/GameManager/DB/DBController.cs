using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SQLite;
using System.Data;
using System.IO;
using UnityEngine.Networking;

namespace Assets.GameManager.DB
{
    public class DBController
    {
        private GameManager m_gameManager;

        public void Initailize(GameManager gameManager)
        {
            m_gameManager = gameManager;
            m_gameManager.StartCoroutine(DBCreate_Index());
            m_gameManager.StartCoroutine(DBCreate_User());
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
        }

        private IEnumerator DBCreate_User()
        {
            Debug.Log("Insert DB Create");
            var filePath = string.Empty;
            if (Application.platform == RuntimePlatform.Android)
            {
                filePath = Path.Combine(Application.persistentDataPath, DBName_User);
                if (File.Exists(filePath))
                    File.Delete(filePath);

                var unityWebRequest = UnityWebRequest.Get("jar:file//" + Application.dataPath + "!/assets/User.db");
                unityWebRequest.downloadedBytes.ToString();
                yield return unityWebRequest.SendWebRequest().isDone;
                File.WriteAllBytes(filePath, unityWebRequest.downloadHandler.data);
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {

            }
            else
            {
                filePath = Path.Combine(Application.dataPath, DBName_User);
                if (File.Exists(filePath))
                    File.Delete(filePath);
                    
                File.Copy(Path.Combine(Application.streamingAssetsPath, DBName_User), filePath);
            }
        }

        public List<IndexDataBase_TDoll> ReadIndexDataBase_TDoll(string query)
        {
            var result = new List<IndexDataBase_TDoll>();
            var tempData = new IndexDataBase_TDoll();

            var dbConnection = new SQLiteConnection(DBFilePath_Index);
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

            return result;
        }

        public List<IndexDataBase_Equipment> ReadIndexDataBase_Equipment(string query)
        {
            var result = new List<IndexDataBase_Equipment>();
            var tempData = new IndexDataBase_Equipment();

            var dbConnection = new SQLiteConnection(DBFilePath_Index);
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

        public List<UserDataBase_TDoll> ReadUserDataBase_TDoll(string query)
        {
            var result = new List<UserDataBase_TDoll>();
            var tempData = new UserDataBase_TDoll();

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            var dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                tempData = new UserDataBase_TDoll();
                tempData.OwnershipCode = dataReader.GetInt32(0);
                tempData.DataCode = dataReader.GetInt32(1);
                tempData.Level = dataReader.GetInt32(2);
                tempData.DummyLink = dataReader.GetInt32(3);
                tempData.EquipmentOwnershipNumber0 = dataReader.GetInt32(4);
                tempData.EquipmentOwnershipNumber1 = dataReader.GetInt32(5);
                tempData.EquipmentOwnershipNumber2 = dataReader.GetInt32(6);
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

        public List<UserDataBase_Equipment> ReadUserDataBase_Equipment(string query)
        {
            var result = new List<UserDataBase_Equipment>();
            var tempData = new UserDataBase_Equipment();

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            var dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                tempData = new UserDataBase_Equipment();
                tempData.OwnershipCode = dataReader.GetInt32(0);
                tempData.DataCode = dataReader.GetInt32(1);
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

        public void InsertUserDataBase(List<UserDataBase_TDoll> data)
        {
            var query = string.Empty;

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            foreach (var item in data)
            {
                query = string.Empty;
                query = "Insert Into TDoll(DataCode, Level, DummyLink, EquipmentOwnerShipNumber0, EquipmentOwnerShipNumber1, EquipmentOwnerShipNumber2) VALUES("
                    + item.DataCode.ToString() + ", "
                    + item.Level.ToString() + ", "
                    + item.DummyLink.ToString() + ", "
                    + item.EquipmentOwnershipNumber0.ToString() + ", "
                    + item.EquipmentOwnershipNumber1.ToString() + ", "
                    + item.EquipmentOwnershipNumber2.ToString()
                    + ")";

                dbCommand.CommandText = query;
                dbCommand.ExecuteNonQuery();
            }

            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;
        }

        public void InsertUserDataBase(List<UserDataBase_Equipment> data)
        {
            var query = string.Empty;

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            foreach (var item in data)
            {
                query = string.Empty;
                query = "INSERT INTO TDoll VALUES ("
                     + item.DataCode.ToString()
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

        public void DeleteUserDataBase(List<UserDataBase_TDoll> data)
        {
            var query = string.Empty;

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            foreach (var item in data)
            {
                query = string.Empty;
                query = "DELETE FROM TDoll WHERE OwnershipCode = "
                     + item.OwnershipCode.ToString();

                dbCommand.CommandText = query;
                dbCommand.ExecuteNonQuery();
            }

            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;
        }

        public void DeleteUserDataBase(List<UserDataBase_Equipment> data)
        {
            var query = string.Empty;

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            foreach (var item in data)
            {
                query = string.Empty;
                query = "DELETE FROM Equipment WHERE OwnershipCode = "
                     + item.OwnershipCode.ToString();

                dbCommand.CommandText = query;
                dbCommand.ExecuteNonQuery();
            }

            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;
        }

        public void UpdateUserDataBase(UserDataBase_TDoll data)
        {
            var query = string.Empty;

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            query = string.Empty;
            query = "UPDATE TDoll SET"
                + "Level=" + data.Level
                + "DummyLink=" + data.DummyLink
                + "EquipmentOwnershipNumber0=" + data.EquipmentOwnershipNumber0
                + "EquipmentOwnershipNumber1=" + data.EquipmentOwnershipNumber1
                + "EquipmentOwnershipNumber2=" + data.EquipmentOwnershipNumber2
                + " WHERE OwnershipCode = "
                + data.OwnershipCode.ToString();

            dbCommand.CommandText = query;
            dbCommand.ExecuteNonQuery();

            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;
        }

        public void UpdateUserDataBase(UserDataBase_Equipment data)
        {
            var query = string.Empty;

            var dbConnection = new SQLiteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            query = string.Empty;
            query = "UPDATE Equipment SET "
                + "Level=" + data.Level
                + ", LimitedPower=" + data.LimitedPower
                + " WHERE OwnershipCode = "
                + data.OwnershipCode.ToString();

            dbCommand.CommandText = query;
            dbCommand.ExecuteNonQuery();

            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;
        }


    }
}
