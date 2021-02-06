using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Common.View
{
    public class CameraAspect : MonoBehaviour
    {
        private Camera m_uICamera;
        private Camera m_letterBox;

        private void Awake()
        {
            m_uICamera = GameObject.Find("UI Camera").GetComponent<Camera>();
            m_letterBox = UnityEngine.Resources.Load<Camera>("Object/LetterBox Camera");
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void ApplyLetterBox(float wRatio, float hRatio)
        {
            var mainCamera = Camera.main;
            var letterBox_left = Instantiate(m_letterBox);
            var letterBox_Right = Instantiate(m_letterBox);

            letterBox_left.transform.parent = mainCamera.transform;
            letterBox_left.transform.parent = mainCamera.transform;
        }

        private void OnPreCull()
        {
            var camera = GetComponent<Camera>();
            camera.ResetWorldToCameraMatrix();
            camera.ResetProjectionMatrix();
            camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(100, 100, 100));
        }
    }
}