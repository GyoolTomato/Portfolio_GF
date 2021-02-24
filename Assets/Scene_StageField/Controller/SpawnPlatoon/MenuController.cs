using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_StageField.Controller.SpawnPlatoon
{
    public class MenuController : Assets.Common.Base.MenuBase
    {
        public delegate void Listener();

        private Listener m_listener;
        private Button m_spanwPlatoon;
        private int m_selectedPlatoonNumber;

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

            m_spanwPlatoon = spawnPlatoon.transform.Find("SpawnButton").GetComponent<Button>();
            m_spanwPlatoon.onClick.AddListener(Handle_Spawn);

            base.Initialize(spawnPlatoon);
        }

        protected override void SceneChangeEvent()
        {
            
        }

        protected override void Handle_ButtonClick1()
        {
            base.Handle_ButtonClick1();
            m_selectedPlatoonNumber = 1;
        }

        protected override void Handle_ButtonClick2()
        {
            base.Handle_ButtonClick2();
            m_selectedPlatoonNumber = 2;
        }

        protected override void Handle_ButtonClick3()
        {
            base.Handle_ButtonClick3();
            m_selectedPlatoonNumber = 3;
        }

        protected override void Handle_ButtonClick4()
        {
            base.Handle_ButtonClick4();
            m_selectedPlatoonNumber = 4;
        }

        protected override void Handle_ButtonClick5()
        {
            base.Handle_ButtonClick5();
            m_selectedPlatoonNumber = 5;
        }

        private void Handle_Spawn()
        {
            m_listener();
        }

        public void SetSpawnListener(Listener listener)
        {
            m_listener = listener;
        }

        public int GetSelectedPlatoonNumber()
        {
            return m_selectedPlatoonNumber;
        }
    }
}