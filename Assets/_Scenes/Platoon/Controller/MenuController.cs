using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Platoon.Controller
{
    public class MenuController : Assets.Objects.Menu.Base.MenuBase
    {
        private GameObject m_selectPlatoon;

        public MenuController()
        {
        }

        public override void Initialize(GameObject canvas)
        {
            m_selectPlatoon = canvas.transform.Find("SelectPlatoon").gameObject;

            var menu = canvas.transform.Find("Menu");
            m_buttonObject1 = menu.Find("Platoon1").gameObject;
            m_buttonObject2 = menu.Find("Platoon2").gameObject;
            m_buttonObject3 = menu.Find("Platoon3").gameObject;
            m_buttonObject4 = menu.Find("Platoon4").gameObject;
            m_buttonObject5 = menu.Find("Platoon5").gameObject;

            m_menuView = canvas.transform.Find("MenuView").gameObject;
            m_view1 = m_menuView.transform.Find("PlatoonWindow1").gameObject;
            m_view2 = m_menuView.transform.Find("PlatoonWindow2").gameObject;
            m_view3 = m_menuView.transform.Find("PlatoonWindow3").gameObject;
            m_view4 = m_menuView.transform.Find("PlatoonWindow4").gameObject;
            m_view5 = m_menuView.transform.Find("PlatoonWindow5").gameObject;

            base.Initialize(canvas);
        }

        protected override void SceneChangeEvent()
        {
            m_selectPlatoon.SetActive(false);
        }
    }
}