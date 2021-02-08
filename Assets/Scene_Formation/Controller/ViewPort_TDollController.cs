using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.Resources.Object;

namespace Assets.Scene_Formation.Controller
{
    public class ViewPort_TDollController : Base.SelectPlatoonBase
    {
        private int m_platoonNumber;
        private int m_sequence;

        

        public ViewPort_TDollController()
        {
        }

        public void Load()
        {
            foreach (var item in m_list)
            {
                GameObject.Destroy(item);
            }

            foreach (var item in m_gameManager.UserDBController().UserTDoll())
            {
                var result = GameObject.Instantiate(m_album, Vector3.zero, Quaternion.identity);
                result.transform.parent = m_viewPortContent.transform;
                m_list.Add(result);

                var albumScript = new Album_TDoll();
                albumScript = result.GetComponent<Album_TDoll>();
                albumScript.Initialize(item, Handle_ClickEvent);                
            }
        }

        public void OpenValue(int platoonNumber, int sequence)
        {
            m_platoonNumber = platoonNumber;
            m_sequence = sequence;
        }

        private void Handle_ClickEvent(int ownershipCode)
        {
            var temp = new Assets.Common.DB.User.UserDataBase_Formation();
            var tempList = m_gameManager.UserDBController().UserFormation();

            foreach (var item in tempList)
            {
                if (item.Number == m_platoonNumber)
                {
                    temp = item;

                    switch (m_sequence)
                    {
                        case 1:
                            temp.Platoon1 = ownershipCode;
                            break;
                        case 2:
                            temp.Platoon2 = ownershipCode;
                            break;
                        case 3:
                            temp.Platoon3 = ownershipCode;
                            break;
                        case 4:
                            temp.Platoon4 = ownershipCode;
                            break;
                        default:
                            break;
                    }
                    m_gameManager.UserDBController().UpdateFormation(temp);
                    m_platoonController.CloseDormitory();
                }
            }            
        }
    }
}
