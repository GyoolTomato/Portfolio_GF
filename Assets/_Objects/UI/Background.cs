using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Objects.UI
{
    public class Background : MonoBehaviour
    {
        RectTransform m_cloud1;
        RectTransform m_cloud2;
        RectTransform m_cloud3;

        private void Awake()
        {
            m_cloud1 = transform.Find("Cloud1").GetComponent<RectTransform>();
            m_cloud2 = transform.Find("Cloud2").GetComponent<RectTransform>();
            m_cloud3 = transform.Find("Cloud3").GetComponent<RectTransform>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            m_cloud1.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);
            m_cloud2.Translate(new Vector3(-40, 0, 0) * Time.deltaTime);
            m_cloud3.Translate(new Vector3(-20, 0, 0) * Time.deltaTime);

            if (m_cloud1.anchoredPosition.x <= Screen.width * -1)
            {
                m_cloud1.anchoredPosition = new Vector2(m_cloud1.sizeDelta.x, m_cloud1.anchoredPosition.y);
            }

            if (m_cloud2.anchoredPosition.x <= Screen.width * -1)
            {
                m_cloud2.anchoredPosition = new Vector2(m_cloud1.sizeDelta.x, m_cloud2.anchoredPosition.y);
            }

            if (m_cloud3.anchoredPosition.x <= Screen.width * -1)
            {
                m_cloud3.anchoredPosition = new Vector2(m_cloud1.sizeDelta.x, m_cloud3.anchoredPosition.y);
            }
        }
    }
}