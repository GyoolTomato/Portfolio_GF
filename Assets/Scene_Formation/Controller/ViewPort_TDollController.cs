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

            m_list = new List<GameObject>();
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
            var temp = new Assets.Common.DB.User.UserDataBase_Platoon();
            var tempList = m_gameManager.UserDBController().UserFormation();

            foreach (var item in tempList)
            {
                if (item.Member1 == ownershipCode)
                {
                    temp = item;
                    temp.Member1 = 0;
                    m_gameManager.UserDBController().UpdatePlatoon(temp);
                }
                else if (item.Member2 == ownershipCode)
                {
                    temp = item;
                    temp.Member2 = 0;
                    m_gameManager.UserDBController().UpdatePlatoon(temp);
                }
                else if (item.Member3 == ownershipCode)
                {
                    temp = item;
                    temp.Member3 = 0;
                    m_gameManager.UserDBController().UpdatePlatoon(temp);
                }
                else if (item.Member4 == ownershipCode)
                {
                    temp = item;
                    temp.Member4 = 0;
                    m_gameManager.UserDBController().UpdatePlatoon(temp);
                }
            }

            temp = new Common.DB.User.UserDataBase_Platoon();
            foreach (var item in tempList)
            {
                if (item.Number == m_platoonNumber)
                {
                    temp = item;

                    switch (m_sequence)
                    {
                        case 1:
                            temp.Member1 = ownershipCode;
                            break;
                        case 2:
                            temp.Member2 = ownershipCode;
                            break;
                        case 3:
                            temp.Member3 = ownershipCode;
                            break;
                        case 4:
                            temp.Member4 = ownershipCode;
                            break;
                        default:
                            break;
                    }
                    m_gameManager.UserDBController().UpdatePlatoon(temp);
                    m_platoonController.CloseDormitory();
                    break;
                }
            }            
        }
    }
}
