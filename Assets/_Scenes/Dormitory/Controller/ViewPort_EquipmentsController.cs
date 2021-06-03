using System;
using UnityEngine;

namespace Assets.Scenes.Dormitory.Controller
{
    public class ViewPort_EquipmentsController : Base.DormitoryBase
    {
        public ViewPort_EquipmentsController()
        {
        }

        public void Load()
        {
            foreach (var item in m_dbManager.GetUserDBController().UserEquipments())
            {
                var result = GameObject.Instantiate(m_album, Vector3.zero, Quaternion.identity);
                result.transform.parent = m_viewPortContent.transform;

                var albumScript = result.GetComponent<Assets.Objects.Album.Album_Equipment>();
                albumScript.Initialize(item);
            }
        }
    }
}
