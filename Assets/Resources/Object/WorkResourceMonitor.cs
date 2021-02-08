using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Object
{
    public class WorkResourceMonitor : MonoBehaviour
    {
        private GameObject m_image;
        private GameObject m_title;
        private GameObject m_amount;
        private GameObject m_chargingVolume;
        private GameObject m_chargingVolume_Amount;
        private GameObject m_chargingVolume_Time;

        private void Awake()
        {
            m_image = transform.Find("Image").gameObject;
            m_title = transform.Find("Title").gameObject;
            m_amount = transform.Find("Amount").gameObject;
            m_chargingVolume = transform.Find("ChargingVolume").gameObject;
            m_chargingVolume_Amount = m_chargingVolume.transform.Find("Amount").gameObject;
            m_chargingVolume_Time = m_chargingVolume.transform.Find("Time").gameObject;
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
            var titleText = m_title.GetComponent<Text>();
            var amountText = m_amount.GetComponent<Text>();
            var chargingVolume_AmountText = m_chargingVolume_Amount.GetComponent<Text>();
            var chargingVolume_TimeText = m_chargingVolume_Time.GetComponent<Text>();

            titleText.text = in_WorkResourceInformation.Title;
            amountText.text = in_WorkResourceInformation.Amount.ToString();
            chargingVolume_AmountText.text = "+" + in_WorkResourceInformation.ChargingVolume_Amount.ToString();
            chargingVolume_TimeText.text = "/" + in_WorkResourceInformation.ChargingVolume_Time.ToString() + "SEC";
        }
    }
}
