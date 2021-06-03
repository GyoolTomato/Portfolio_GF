using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Objects.UI
{
    public class WorkResourceMonitor : MonoBehaviour
    {
        private Graphic.GraphicManager m_resourceManager;
        private Image m_image;
        private Text m_title;
        private Text m_amount;
        private Text m_chargingVolume_Amount;
        private Text m_chargingVolume_Time;

        private void Awake()
        {
            m_resourceManager = GameObject.Find("GameManager").GetComponent<Graphic.GraphicManager>();
            m_image = transform.Find("Image").GetComponent<Image>();
            m_title = transform.Find("Title").GetComponent<Text>();
            m_amount = transform.Find("Amount").GetComponent<Text>();
            var chargingVolume = transform.Find("ChargingVolume");
            m_chargingVolume_Amount = chargingVolume.Find("Amount").GetComponent<Text>();
            m_chargingVolume_Time = chargingVolume.Find("Time").GetComponent<Text>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ApplyData(Assets.Common.Interface.WorkResource in_WorkResourceInformation)
        {
            m_image.sprite = m_resourceManager.GetSpriteController().GetWorkResource(in_WorkResourceInformation.DBName);
            m_title.text = in_WorkResourceInformation.Title;
            m_amount.text = in_WorkResourceInformation.Amount.ToString();
            m_chargingVolume_Amount.text = "+" + in_WorkResourceInformation.ChargingVolume_Amount.ToString();
            m_chargingVolume_Time.text = "/" + in_WorkResourceInformation.ChargingVolume_Time.ToString() + "SEC";
        }
    }
}
