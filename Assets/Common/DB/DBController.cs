using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
//using System.Data.SQLite;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using UnityEngine.Networking;

namespace Assets.Common.DB
{
    public class DBController
    {
        private GameManager m_gameManager;
        private string m_dBFilePath_Index;
        private string m_dBFilePath_User;

public void Initailize(GameManager gameManager)
        {
            m_gameManager = gameManager;
                        
            Debug.Log("*ExternalWrite : " + Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite));
            Debug.Log("*ExternalRead : " + Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead));

            Permission.RequestUserPermission(Permission.ExternalStorageWrite);

            m_gameManager.StartCoroutine(DBCreate_Index());
            m_gameManager.StartCoroutine(DBCreate_User());
            //DBCreate_Index();
            //DBCreate_User();
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
                return "URI=file:" + m_dBFilePath_Index;
            }
        }

        private string DBFilePath_User
        {
            get
            {
                return "URI=file:" + m_dBFilePath_User;
            }
        }

        private IEnumerator DBCreate_Index()
        {
            var sourceFilePath = Path.Combine(Application.streamingAssetsPath, DBName_Index);
            var filePath = string.Empty;
            if (Application.platform == RuntimePlatform.Android)
            {
                filePath = Path.Combine(Application.persistentDataPath, DBName_Index);
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
                filePath = Path.Combine(Application.dataPath, DBName_Index);
                if (File.Exists(filePath))
                    File.Delete(filePath);

                File.Copy(sourceFilePath, filePath);

                Debug.Log("Create Index DB");
                Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
            }

            m_dBFilePath_Index = filePath;
        }

        //private void DBCreate_Index()
        //{
        //    var filePath = string.Empty;
        //    if (Application.platform == RuntimePlatform.Android)
        //    {
        //        filePath = Path.Combine(Application.persistentDataPath, DBName_Index);
        //        if (File.Exists(filePath))
        //            File.Delete(filePath);

        //        File.Copy(Path.Combine(Application.streamingAssetsPath, DBName_Index), filePath);

        //        Debug.Log("Create Index DB");
        //        Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
        //    }
        //    else if (Application.platform == RuntimePlatform.IPhonePlayer)
        //    {

        //    }
        //    else
        //    {
        //        filePath = Path.Combine(Application.dataPath, DBName_Index);
        //        if (File.Exists(filePath))
        //            File.Delete(filePath);

        //        File.Copy(Path.Combine(Application.streamingAssetsPath, DBName_Index), filePath);

        //        Debug.Log("Create Index DB");
        //        Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
        //    }

        //    m_dBFilePath_Index = filePath;
        //}

        private IEnumerator DBCreate_User()
        {
            var sourceFilePath = Path.Combine(Application.streamingAssetsPath, DBName_User);
            var filePath = string.Empty;
            if (Application.platform == RuntimePlatform.Android)
            {
                filePath = Path.Combine(Application.persistentDataPath, DBName_User);
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
                filePath = Path.Combine(Application.dataPath, DBName_User);
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

            m_dBFilePath_User = filePath;
        }

        //private void DBCreate_User()
        //{
        //    var filePath = string.Empty;
        //    if (Application.platform == RuntimePlatform.Android)
        //    {
        //        filePath = Path.Combine(Application.persistentDataPath, DBName_User);
        //        if (!File.Exists(filePath))
        //        {
        //            File.Copy(Path.Combine(Application.streamingAssetsPath, DBName_User), filePath);

        //            Debug.Log("Create User DB");
        //            Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
        //        }
        //        else
        //        {
        //            Debug.Log("Find User DB");
        //        }
        //    }
        //    else if (Application.platform == RuntimePlatform.IPhonePlayer)
        //    {

        //    }
        //    else
        //    {
        //        filePath = Path.Combine(Application.dataPath, DBName_User);
        //        if (!File.Exists(filePath))
        //        {
        //            File.Copy(Path.Combine(Application.streamingAssetsPath, DBName_User), filePath);

        //            Debug.Log("Create User DB");
        //            Debug.Log("*Size : " + File.ReadAllBytes(filePath).Length);
        //        }
        //        else
        //        {
        //            Debug.Log("Find DB");
        //        }
        //    }

        //    m_dBFilePath_User = filePath;
        //}

        public List<IndexDataBase_TDoll> ReadIndexDataBase_TDoll(string query)
        {
            var result = new List<IndexDataBase_TDoll>();

            try
            {
                var tempData = new IndexDataBase_TDoll();

                var dbConnection = new SqliteConnection(DBFilePath_Index);
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
            catch(System.Exception e)
            {
                Debug.Log("ReadIndexDataBase_TDoll Fail");
                Debug.Log("*Exception : " + e.ToString());
            }

            return result;
        }

        public List<IndexDataBase_Equipment> ReadIndexDataBase_Equipment(string query)
        {
            var result = new List<IndexDataBase_Equipment>();
            var tempData = new IndexDataBase_Equipment();

            var dbConnection = new SqliteConnection(DBFilePath_Index);
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

            try
            {
                var tempData = new UserDataBase_TDoll();

                var dbConnection = new SqliteConnection(DBFilePath_User);
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
                    tempData.Platoon = dataReader.GetInt32(4);
                    tempData.EquipmentOwnershipNumber0 = dataReader.GetInt32(5);
                    tempData.EquipmentOwnershipNumber1 = dataReader.GetInt32(6);
                    tempData.EquipmentOwnershipNumber2 = dataReader.GetInt32(7);
                    result.Add(tempData);
                }

                dataReader.Dispose();
                dataReader = null;
                dbCommand.Dispose();
                dbCommand = null;
                dbConnection.Close();
                dbConnection = null;

                Debug.Log("ReadUserDataBase_TDoll Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("ReadUserDataBase_TDoll Fail");
                Debug.Log("*Exception : " + e.ToString());
                Debug.Log("*URL : " + DBFilePath_User);
                Debug.Log("*Path : " + m_dBFilePath_User);
                Debug.Log("*Exist : " + File.Exists(m_dBFilePath_User).ToString());
                if (File.Exists(m_dBFilePath_User))
                {
                    Debug.Log("*Size : " + File.ReadAllBytes(m_dBFilePath_User).Length);
                }
            }

            return result;
        }

        public List<UserDataBase_Equipment> ReadUserDataBase_Equipment(string query)
        {
            var result = new List<UserDataBase_Equipment>();
            var tempData = new UserDataBase_Equipment();

            var dbConnection = new SqliteConnection(DBFilePath_User);
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

            var dbConnection = new SqliteConnection(DBFilePath_User);
            dbConnection.Open();
            var dbCommand = dbConnection.CreateCommand();

            foreach (var item in data)
            {
                query = string.Empty;
                query = "Insert Into TDoll(DataCode, Level, DummyLink, Platoon, EquipmentOwnerShipNumber0, EquipmentOwnerShipNumber1, EquipmentOwnerShipNumber2) VALUES("
                    + item.DataCode.ToString() + ", "
                    + item.Level.ToString() + ", "
                    + item.DummyLink.ToString() + ", "
                    + item.Platoon.ToString() + ", "
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

            var dbConnection = new SqliteConnection(DBFilePath_User);
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

            var dbConnection = new SqliteConnection(DBFilePath_User);
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

            var dbConnection = new SqliteConnection(DBFilePath_User);
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

            var dbConnection = new SqliteConnection(DBFilePath_User);
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

            var dbConnection = new SqliteConnection(DBFilePath_User);
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
