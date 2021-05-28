using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.DB.User.Base;
using Assets.Resources.Album;

namespace Assets.Scenes.Factory.Controller
{
    public class SpawnPopupController
    {
        private GameObject m_spawnPopup;
        private GameObject m_pressTouch;
        private Button m_pressTouchButton;
        private Button m_imageButton;
        private GameObject m_tDoll;
        private Album_TDoll m_tDollAlbum;
        private GameObject m_equipment;
        private Album_Equipment m_equipmentAlbum;

        public SpawnPopupController()
        {
        }

        public void Initialize()
        {
            m_spawnPopup = GameObject.Find("SpawnPopup");
            m_pressTouch = m_spawnPopup.transform.Find("PressTouch").gameObject;
            m_pressTouchButton = m_pressTouch.GetComponent<Button>();
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
        }

        public void Open(UserDataBase_Equipment equipment)
        {
            m_spawnPopup.SetActive(true);
            m_tDoll.SetActive(false);
            m_equipment.SetActive(true);
            m_equipmentAlbum.Initialize(equipment);
        }

        private void Close()
        {
            m_spawnPopup.SetActive(false);
        }
    }
}
