using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Common
{
    public class CameraResolation : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var camera = GetComponent<Camera>();
            var rect = camera.rect;

            var scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16);
            var scaleWidth = 1f / scaleHeight;

            if (scaleHeight < 1)
            {
                rect.height = scaleHeight;
                rect.y = (1.0f - scaleHeight) / 2.0f;
            }
            else
            {
                rect.width = scaleWidth;
                rect.x = (1.0f - scaleWidth) / 2.0f;
            }

            camera.rect = rect;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnPreCull() => GL.Clear(true, true, Color.black);
    }
}