using System;
using UnityEngine;

namespace Assets.Common.Android
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