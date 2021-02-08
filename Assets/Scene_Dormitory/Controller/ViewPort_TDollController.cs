using System;
using UnityEngine;
using UnityEditor;
using Assets.Resources.Object;

namespace Assets.Scene_Dormitory.Controller
{
    public class ViewPort_TDollController : Base.DormitoryBase
    {        
        public ViewPort_TDollController()
        {
        }

        public void Load()
        {
            foreach (var item in m_gameManager.UserDBController().UserTDoll())
            {
                var result = GameObject.Instantiate(m_album, Vector3.zero, Quaternion.identity);
                result.transform.parent = m_viewPortContent.transform;

                var albumScript = result.GetComponent<Album_TDoll>();
                albumScript.Initialize(item);
            }
        }
    }
}
