using System;
using UnityEngine;

namespace Assets.Scene_Dormitory.Controller
{
    public class ViewPort_EquipmentsController : Base.DormitoryBase
    {
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
                albumScript.Initialize(item);
            }
        }
    }
}
