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
            //if (Application.platform != RuntimePlatform.Android)
            //{
            //    Destroy(this);
            //    return;
            //}

            //if (m_instance == null)
            //    m_instance = this;
            //else
            //    Destroy(gameObject);

            //m_unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            //m_currentActivity = m_unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            //m_context = m_currentActivity.Call<AndroidJavaObject>("getApplicationContext");

            //DontDestroyOnLoad(this.gameObject);
        }

        public void ShowToast(string message)
        {
            var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                var toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    var toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                    toastObject.Call("show");
                }));
            }
        }
    }
}