using System;
using UnityEngine;
using UnityEditor;
using Assets.Common;

namespace Assets.Scene_Formation.Controller
{
    public class ViewPort_TDollController : Base.SelectPlatoonBase
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
                albumScript.Initialize(m_gameManager.IndexDBController().TDoll(item.DataCode), item.OwnershipCode, item.Level, item.DummyLink, item.Platoon);
            }
        }
    }
}
