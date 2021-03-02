using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Album;

namespace Assets.Scene_Platoon.Controller
{
    public class ViewPort_EquipmentsController : Base.SelectPlatoonBase
    {
        private int m_tDollOwnershipCode;
        private int m_equipmentSequence;

        public ViewPort_EquipmentsController()
        {
        }

        public void Load()
        {
            foreach (var item in m_list)
            {
                GameObject.Destroy(item);
            }

            m_list = new List<GameObject>();
            foreach (var item in m_gameManager.UserDBController().UserEquipments())
            {
                var result = GameObject.Instantiate(m_album, Vector3.zero, Quaternion.identity);
                result.transform.parent = m_viewPortContent.transform;
                m_list.Add(result);

                var albumScript = new Album_Equipment();
                albumScript = result.GetComponent<Album_Equipment>();
                albumScript.Initialize(item, Handle_ClickEvent);
            }
        }

        public void OpenValue(int tDollOwnershipCode, int equipmentSequence)
        {
            m_tDollOwnershipCode = tDollOwnershipCode;
            m_equipmentSequence = equipmentSequence;
        }

        private void Handle_ClickEvent(int ownershipCode)
        {
            var temp = new Assets.Common.DB.User.UserDataBase_TDoll();
            var tempList = m_gameManager.UserDBController().UserTDoll();

            foreach (var item in tempList)
            {
                if (item.EquipmentOwnershipNumber0 == ownershipCode)
                {
                    temp = item;
                    temp.EquipmentOwnershipNumber0 = 0;
                    m_gameManager.UserDBController().UpdateOwnership(temp);
                }
                else if (item.EquipmentOwnershipNumber1 == ownershipCode)
                {
                    temp = item;
                    temp.EquipmentOwnershipNumber1 = 0;
                    m_gameManager.UserDBController().UpdateOwnership(temp);
                }
                else if (item.EquipmentOwnershipNumber2 == ownershipCode)
                {
                    temp = item;
                    temp.EquipmentOwnershipNumber2 = 0;
                    m_gameManager.UserDBController().UpdateOwnership(temp);
                }
            }

            temp = new Common.DB.User.UserDataBase_TDoll();
            foreach (var item in tempList)
            {
                if (item.OwnershipCode == m_tDollOwnershipCode)
                {
                    temp = item;
                    switch (m_equipmentSequence)
                    {
                        case 1:
                            temp.EquipmentOwnershipNumber0 = ownershipCode;
                            break;
                        case 2:
                            temp.EquipmentOwnershipNumber1 = ownershipCode;
                            break;
                        case 3:
                            temp.EquipmentOwnershipNumber2 = ownershipCode;
                            break;
                        default:
                            break;                            
                    }

                    m_gameManager.UserDBController().UpdateOwnership(temp);
                    m_platoonController.CloseDormitory();
                    break;
                }
            }

        }
    }
}
