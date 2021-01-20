using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Android;

public class LoginManager : MonoBehaviour
{
    private Button m_EnterButton;

    private void Awake()
    {
        var vLogin = GameObject.Find("Login");
        var vEnter = vLogin.transform.Find("Enter").gameObject;
        m_EnterButton = vEnter.GetComponent<Button>();
        m_EnterButton.onClick.AddListener(AccountVerification);
    }

    // Start is called before the first frame update
    void Start()
    {
        Permission.RequestUserPermission(Permission.ExternalStorageRead);
        
        if (Application.platform == RuntimePlatform.Android)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AccountVerification()
    {
        SceneManager.LoadScene("Lobby");
    }

    IEnumerator PermissionCheck()
    {
        
        Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        yield return null;
    }
}
