using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scene_Factory.Controller
{
    public class MenuController : Assets.Common.Base.MenuBase
    {
        public MenuController()
        {

        }

        public override void Initialize(GameObject canvas)
        {
            var menu = canvas.transform.Find("Menu");
            m_buttonObject1 = menu.Find("ProduceTDoll").gameObject;
            m_buttonObject2 = menu.Find("DummyLinkNAnalyze").gameObject;
            m_buttonObject3 = menu.Find("EnhanceNDevelop").gameObject;
            m_buttonObject4 = menu.Find("TDollRetire").gameObject;
            m_buttonObject5 = menu.Find("ProduceEquipment").gameObject;

            var menuView = canvas.transform.Find("MenuView");
            m_view1 = menuView.Find("ProduceTDoll").gameObject;
            m_view2 = menuView.Find("DummyLinkNAnalyze").gameObject;
            m_view3 = menuView.Find("EnhanceNDevelop").gameObject;
            m_view4 = menuView.Find("TDollRetire").gameObject;
            m_view5 = menuView.Find("ProduceEquipment").gameObject;

            base.Initialize(canvas);
        }
    }
}
