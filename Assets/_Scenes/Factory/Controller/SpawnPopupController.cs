using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.DB.User.Base;
using Assets.Resources.Album;

namespace Assets.Scenes.Factory.Controller
{
    public class SpawnPopupController
    {
        private FactoryManager m_factoryManager;
        private GameObject m_spawnPopup;
        private Text m_pressTouch;
        private Button m_pressTouchButton;
        private Button m_imageButton;
        private GameObject m_tDoll;
        private Album_TDoll m_tDollAlbum;
        private GameObject m_equipment;
        private Album_Equipment m_equipmentAlbum;

        public SpawnPopupController()
        {
        }

        public void Initialize(FactoryManager factoryManager)
        {
            m_factoryManager = factoryManager;
            m_spawnPopup = GameObject.Find("SpawnPopup");
            m_pressTouch = m_spawnPopup.transform.Find("PressTouch").GetComponent<Text>();
            m_pressTouchButton = m_pressTouch.gameObject.GetComponent<Button>();
            m_pressTouchButton.onClick.AddListener(Close);
            m_imageButton = m_spawnPopup.transform.Find("Background").GetComponent<Button>();
            m_imageButton.onClick.AddListener(Close);
            m_tDoll = m_spawnPopup.transform.Find("TDoll").gameObject;
            m_equipment = m_spawnPopup.transform.Find("Equipment").gameObject;
            m_tDollAlbum = m_tDoll.GetComponent<Album_TDoll>();
            m_equipmentAlbum = m_equipment.GetComponent<Album_Equipment>();

            m_spawnPopup.SetActive(false);
        }

        public void Open(UserDataBase_TDoll tDoll)
        {
            m_spawnPopup.SetActive(true);
            m_tDoll.SetActive(true);
            m_equipment.SetActive(false);
            m_tDollAlbum.Initialize(tDoll);
            m_factoryManager.StartCoroutine(TextAnimation());
        }

        public void Open(UserDataBase_Equipment equipment)
        {
            m_spawnPopup.SetActive(true);
            m_tDoll.SetActive(false);
            m_equipment.SetActive(true);
            m_equipmentAlbum.Initialize(equipment);
            m_factoryManager.StartCoroutine(TextAnimation());
        }

        private void Close()
        {
            m_factoryManager.StopCoroutine(TextAnimation());
            m_spawnPopup.SetActive(false);
        }

        private IEnumerator TextAnimation()
        {
            var visible = false;
            var alpha = 1.0f;

            while (m_spawnPopup.activeSelf)
            {
                if (alpha >= 1.0f)
                    visible = true;
                else if (alpha <= 0.0f)
                    visible = false;

                if (visible)                
                    alpha -= 0.1f;                
                else
                    alpha += 0.1f;

                m_pressTouch.color = new Color(m_pressTouch.color.r, m_pressTouch.color.g, m_pressTouch.color.b, alpha);


                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
