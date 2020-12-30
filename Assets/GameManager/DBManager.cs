using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SQLite;
using System.Data;
using System.IO;
using UnityEngine.Networking;

public class DBManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {        
        StartCoroutine(DBCreate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DBCreate()
    {
        Debug.Log("Insert DB Create");
        var filePath = string.Empty;
        if (Application.platform == RuntimePlatform.Android)
        {
            filePath = Application.persistentDataPath + "/Portfolio_GF.db";
            if (!File.Exists(filePath))
            {
                var unityWebRequest = UnityWebRequest.Get("jar:file//" + Application.dataPath + "!/assets/Portfolio_GF.db");
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
            filePath = Application.dataPath + "/Portfolio_GF.db";
            if (!File.Exists(filePath))
            {
                File.Copy(Application.streamingAssetsPath + "/Portfolio_GF.db", filePath);
            }
            else
            {
                Debug.Log("Find DB");
            }
        }
    }

    private void DataBaseRead(string query)
    {
        var dbConnection = new SQLiteConnection();
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
    }
}
