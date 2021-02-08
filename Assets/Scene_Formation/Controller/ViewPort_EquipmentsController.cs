using System;
using UnityEngine;

namespace Assets.Scene_Formation.Controller
{
    public class ViewPort_EquipmentsController : Base.SelectPlatoonBase
    {
        private int m_platoonNumber;
        private int m_sequence;
        private int m_equipmentSequence;

        public ViewPort_EquipmentsController()
        {
        }

        public void Load()
        {
            foreach (var item in m_gameManager.UserDBController().UserEquipments())
            {
                var result = GameObject.Instantiate(m_album, Vector3.zero, Quaternion.identity);
                result.transform.parent = m_viewPortContent.transform;

                var albumScript = result.GetComponent<Assets.Resources.Object.Album_Equipment>();
                albumScript.Initialize(m_gameManager.IndexDBController().Equipment(item.DataCode), item.OwnershipCode, item.Level, item.LimitedPower);
            }
        }

        public void OpenValue(int platoonNumber, int sequence, int equipmentSequence)
        {
            m_platoonNumber = platoonNumber;
            m_sequence = sequence;
            m_equipmentSequence = equipmentSequence;
        }
    }
}
