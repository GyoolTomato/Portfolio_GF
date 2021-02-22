using UnityEngine;
using System.Collections;
using Assets.Common.DB.User;
using Assets.Scene_StageField;
using Assets.Scene_StageField.Controller;

namespace Assets.Resources.StageField
{
    public class Character : MonoBehaviour
    {
        public enum E_Owner
        {
            Neutrality,
            Player,
            Enemy,
            End,
        }

        private StageFieldManager m_stageFieldManager;
        private TouchController m_touchController;
        private PlatoonController m_platoonController;
        private UserDataBase_Platoon m_platoonData;
        public E_Owner m_owner;

        // Use this for initialization
        void Start()
        {
            m_stageFieldManager = GameObject.Find("Manager").GetComponent<StageFieldManager>();
            m_touchController = m_stageFieldManager.GetTouchController();
            m_platoonController = m_stageFieldManager.GetPlatoonController();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_owner == E_Owner.Player && m_touchController.GetClickObject() == gameObject)
            {
                m_platoonController.SelectedCharacter = this;
            }
        }

        public void SetValue(UserDataBase_Platoon data, E_Owner owner)
        {
            m_platoonData = data;
            m_owner = owner;
        }

        public GameObject Object()
        {
            return gameObject;
        }

        public UserDataBase_Platoon PlatoonData()
        {
            return m_platoonData;
        }
    }
}