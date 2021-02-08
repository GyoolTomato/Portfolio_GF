using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Object
{
    public class SmallAlbum_Equipment : MonoBehaviour
    {
        private Assets.Common.GameManager m_gameManager;
        private BigAlbum_TDoll.Handle_SelectPlatoon m_selectEquipment;
        private int m_platoonNumber;
        private int m_sequence;        
        private int m_equipmentSequence;

        private Button m_button;
        private Image m_image;
        private Text m_limitedPower;
        private GameObject m_curtain;

        public SmallAlbum_Equipment()
        {
        }

        public void Start()
        {
            
        }

        public void Update()
        {

        }

        public void Initialize(int platoonNumber, int sequence, int equipmentSequence, BigAlbum_TDoll.Handle_SelectPlatoon selectPlatoon)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Assets.Common.GameManager>();
            m_selectEquipment = selectPlatoon;
            m_platoonNumber = platoonNumber;
            m_sequence = sequence;
            m_equipmentSequence = equipmentSequence;

            m_button = this.GetComponent<Button>();
            m_button.onClick.AddListener(Handle_SelectEquipment);
            m_image = transform.Find("Image").GetComponent<Image>();
            m_limitedPower = transform.Find("LimitedPower").GetComponent<Text>();
            m_curtain = transform.Find("Curtain").gameObject;
            SetCurtain(true);
        }

        public void ApplyValue(int ownershipCode)
        {            
            try
            {
                var data = m_gameManager.UserDBController().UserEquipment(ownershipCode);

                if (data != null)
                {
                    m_limitedPower.text = data.LimitedPower + "%";
                    SetCurtain(false);
                }
                else
                    SetCurtain(true);
            }
            catch
            {
                SetCurtain(true);
            }
        }    

        private void Handle_SelectEquipment()
        {
            m_selectEquipment(m_platoonNumber, m_sequence, m_equipmentSequence);
        }

        private void SetCurtain(bool set)
        {
            m_curtain.SetActive(set);
        }
    }
}
