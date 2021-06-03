using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scenes.Dormitory.Controller
{
    public class MenuController : Assets.Objects.Menu.Base.MenuBase
    {
        public MenuController()
        {

        }

        public override void Initialize(GameObject canvas)
        {
            var menu = canvas.transform.Find("Menu");
            m_buttonObject1 = menu.Find("TDoll").gameObject;
            m_buttonObject2 = menu.Find("Equipment").gameObject;

            m_menuView = canvas.transform.Find("MenuView").gameObject;
            m_view1 = m_menuView.transform.Find("TDoll").gameObject;
            m_view2 = m_menuView.transform.Find("Equipment").gameObject;

            base.Initialize(canvas);
        }
    }
}
