using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scene_Dormitory.Controller
{
    public class MenuController : Assets.Common.Base.MenuBase
    {
        public MenuController()
        {

        }

        public override void Initialize(GameObject canvas)
        {
            var menu = canvas.transform.Find("Menu");
            m_buttonObject1 = menu.Find("TDoll").gameObject;
            m_buttonObject2 = menu.Find("Equipment").gameObject;

            var menuView = canvas.transform.Find("MenuView");
            m_view1 = menuView.Find("TDoll").gameObject;
            m_view2 = menuView.Find("Equipment").gameObject;

            base.Initialize(canvas);
        }
    }
}
