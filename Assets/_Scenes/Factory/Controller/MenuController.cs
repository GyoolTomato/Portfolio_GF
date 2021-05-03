using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scenes.Factory.Controller
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

            m_menuView = canvas.transform.Find("MenuView").gameObject;
            m_view1 = m_menuView.transform.Find("ProduceTDoll").gameObject;
            m_view2 = m_menuView.transform.Find("DummyLinkNAnalyze").gameObject;
            m_view3 = m_menuView.transform.Find("EnhanceNDevelop").gameObject;
            m_view4 = m_menuView.transform.Find("TDollRetire").gameObject;
            m_view5 = m_menuView.transform.Find("ProduceEquipment").gameObject;

            base.Initialize(canvas);
        }
    }
}
