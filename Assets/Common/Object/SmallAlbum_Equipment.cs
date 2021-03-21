using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Album
{
    public class SmallAlbum_Equipment : MonoBehaviour
    {
        public delegate void SelectEquipment(int tDollOwnershipCode, int sequence);

        private Assets.Common.GameManager m_gameManager;
        private SelectEquipment m_selectEquipment;
        private int m_tDollOwnershipCode;
        private int m_sequence;        

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

        public void Initialize(SelectEquipment selectEquipment)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Assets.Common.GameManager>();
            m_selectEquipment = selectEquipment;            

            m_button = this.GetComponent<Button>();
            m_button.onClick.AddListener(Handle_SelectEquipment);
            m_image = transform.Find("Image").GetComponent<Image>();
            m_limitedPower = transform.Find("LimitedPower").GetComponent<Text>();
            m_curtain = transform.Find("Curtain").gameObject;
            SetCurtain(true);
        }

        public void ApplyValue(int tDollOwnershipCode, int sequence, int ownershipCode)
        {            
            try
            {
                m_tDollOwnershipCode = tDollOwnershipCode;
                m_sequence = sequence;
                var data = m_gameManager.GetUserDBController().UserEquipment(ownershipCode);

                if (data != null)
                {
                    m_image.sprite = m_gameManager.GetSpriteController().GetEquipmentImage(data.DataCode);
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
            m_selectEquipment(m_tDollOwnershipCode, m_sequence);
        }

        private void SetCurtain(bool set)
        {
            m_curtain.SetActive(set);
        }
    }
}
