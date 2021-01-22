using System.Collections;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Networking;

namespace Assets.Common.DB.User
{
    public class UserDBManager
    {
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

        public List<UserDataBase_TDoll> ReadUserDataBase_TDoll(string query)
        {
            var result = new List<UserDataBase_TDoll>();

            try
            {
                var tempData = new UserDataBase_TDoll();

                var dbConnection = new SqliteConnection(ReadDBFilePath);
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

        public List<UserDataBase_Equipment> ReadUserDataBase_Equipment(string query)
        {
            var result = new List<UserDataBase_Equipment>();

            try
            {
                var tempData = new UserDataBase_Equipment();

                var dbConnection = new SqliteConnection(ReadDBFilePath);
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

                Debug.Log("ReadUserDataBase_Equipment Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("ReadUserDataBase_Equipment Fail");
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

        public void InsertUserDataBase(List<UserDataBase_TDoll> data)
        {
            try
            {
                var query = string.Empty;

                var dbConnection = new SqliteConnection(ReadDBFilePath);
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

                Debug.Log("InsertUserDataBase Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("InsertUserDataBase Fail");
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

        public void InsertUserDataBase(List<UserDataBase_Equipment> data)
        {
            try
            {
                var query = string.Empty;

                var dbConnection = new SqliteConnection(ReadDBFilePath);
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

                Debug.Log("InsertUserDataBase Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("InsertUserDataBase Fail");
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

        public void DeleteUserDataBase(List<UserDataBase_TDoll> data)
        {
            try
            {
                var query = string.Empty;

                var dbConnection = new SqliteConnection(ReadDBFilePath);
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

                Debug.Log("DeleteUserDataBase Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("DeleteUserDataBase Fail");
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

        public void DeleteUserDataBase(List<UserDataBase_Equipment> data)
        {
            try
            {
                var query = string.Empty;

                var dbConnection = new SqliteConnection(ReadDBFilePath);
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

                Debug.Log("DeleteUserDataBase Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("DeleteUserDataBase Fail");
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

        public void UpdateUserDataBase(UserDataBase_TDoll data)
        {
            try
            {
                var query = string.Empty;

                var dbConnection = new SqliteConnection(ReadDBFilePath);
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

                Debug.Log("UpdateUserDataBase Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("UpdateUserDataBase Fail");
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

        public void UpdateUserDataBase(UserDataBase_Equipment data)
        {
            try
            {
                var query = string.Empty;

                var dbConnection = new SqliteConnection(ReadDBFilePath);
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

                Debug.Log("UpdateUserDataBase Success");
            }
            catch (System.Exception e)
            {
                Debug.Log("UpdateUserDataBase Fail");
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
