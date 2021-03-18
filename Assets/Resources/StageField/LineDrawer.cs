using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.StageField
{
    public class LineDrawer : MonoBehaviour
    {
        private LineRenderer m_lineRenderer;
        private Gradient m_gradient;
        private OccupationPoint m_target;

        private void Awake()
        {
            m_gradient = new Gradient();
            m_gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.gray, 0.0f), new GradientColorKey(Color.gray, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
                );

            m_lineRenderer = GetComponent<LineRenderer>();
            m_target = null;

        }

        // Start is called before the first frame update
        void Start()
        {
            m_lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            m_lineRenderer.widthMultiplier = 0.2f;
            m_lineRenderer.positionCount = 2;
            m_lineRenderer.colorGradient = m_gradient;
        }

        //// Update is called once per frame
        void Update()
        {
            if (m_target != null)
            {
                m_lineRenderer.SetPosition(0, transform.position);
                m_lineRenderer.SetPosition(1, m_target.transform.position);
            }
        }

        public void SetValue(OccupationPoint target)
        {
            m_target = target;
        }
    }
}