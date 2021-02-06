using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Formation.Controller
{
    public class MenuController : Assets.Common.Base.MenuBase
    {
        public MenuController()
        {
        }

        public override void Initialize(GameObject canvas)
        {
            var menu = canvas.transform.Find("Menu");
            m_buttonObject1 = menu.Find("Platoon1").gameObject;
            m_buttonObject2 = menu.Find("Platoon2").gameObject;
            m_buttonObject3 = menu.Find("Platoon3").gameObject;
            m_buttonObject4 = menu.Find("Platoon4").gameObject;
            m_buttonObject5 = menu.Find("Platoon5").gameObject;

            var menuView = canvas.transform.Find("MenuView");
            m_view1 = menuView.Find("PlatoonWindow1").gameObject;
            m_view2 = menuView.Find("PlatoonWindow2").gameObject;
            m_view3 = menuView.Find("PlatoonWindow3").gameObject;
            m_view4 = menuView.Find("PlatoonWindow4").gameObject;
            m_view5 = menuView.Find("PlatoonWindow5").gameObject;

            base.Initialize(canvas);
        }
    }
}