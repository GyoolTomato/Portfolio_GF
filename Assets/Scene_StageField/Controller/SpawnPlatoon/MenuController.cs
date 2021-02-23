using System;
using UnityEngine;

namespace Assets.Scene_StageField.Controller.SpawnPlatoon
{
    public class MenuController : Assets.Common.Base.MenuBase
    {
        private GameObject m_selectPlatoon;

        public MenuController()
        {
        }

        public override void Initialize(GameObject spawnPlatoon)
        {
            var menu = spawnPlatoon.transform.Find("Menu");
            m_buttonObject1 = menu.Find("Platoon1").gameObject;
            m_buttonObject2 = menu.Find("Platoon2").gameObject;
            m_buttonObject3 = menu.Find("Platoon3").gameObject;
            m_buttonObject4 = menu.Find("Platoon4").gameObject;
            m_buttonObject5 = menu.Find("Platoon5").gameObject;

            m_menuView = spawnPlatoon.transform.Find("MenuView").gameObject;
            m_view1 = m_menuView.transform.Find("PlatoonWindow1").gameObject;
            m_view2 = m_menuView.transform.Find("PlatoonWindow2").gameObject;
            m_view3 = m_menuView.transform.Find("PlatoonWindow3").gameObject;
            m_view4 = m_menuView.transform.Find("PlatoonWindow4").gameObject;
            m_view5 = m_menuView.transform.Find("PlatoonWindow5").gameObject;

            base.Initialize(spawnPlatoon);
        }

        protected override void SceneChangeEvent()
        {
            
        }
    }
}