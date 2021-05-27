using System;
using UnityEngine;

namespace Assets.Common
{
    public class AndroidManager : MonoBehaviour
    {
        static public AndroidManager m_instance;

        private AndroidJavaObject m_currentActivity;
        private AndroidJavaClass m_unityPlayer;
        private AndroidJavaObject m_context;
        private AndroidJavaObject m_toast;

        public AndroidManager()
        {
        }

        private void Awake()
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                Destroy(this);
                return;
            }

            if (m_instance == null)
                m_instance = this;
            else
                Destroy(gameObject);

            m_unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            m_currentActivity = m_unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            m_context = m_currentActivity.Call<AndroidJavaObject>("getApplicationContext");

            DontDestroyOnLoad(this.gameObject);
        }

        public void ShowToast(string message)
        {
            m_currentActivity.Call(
                "runOnUiThread",
                new AndroidJavaRunnable(() =>
                {
                    AndroidJavaClass Toast
                    = new AndroidJavaClass("android.widget.Toast");

                    AndroidJavaObject javaString
                    = new AndroidJavaObject("java.lang.String", message);

                    m_toast = Toast.CallStatic<AndroidJavaObject>
                    (
                        "makeText",
                        m_context,
                        javaString,
                        Toast.GetStatic<int>("LENGTH_SHORT")
                    );

                    m_toast.Call("show");
                })
             );
        }

        public void CancelToast()
        {
            m_currentActivity.Call("runOnUiThread",
                new AndroidJavaRunnable(() =>
                {
                    if (m_toast != null) m_toast.Call("cancel");
                }));
        }
    }
}