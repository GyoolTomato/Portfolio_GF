using System;
using UnityEngine;
using Assets.Common;

public class DormitoryBase
{
    protected GameObject m_viewPortContent;
    protected GameObject m_album;

    protected GameManager m_gameManager;

    public DormitoryBase()
    {
    }

    public void Initialize(GameManager gameManager, string menuViewName, string albumName)
    {
        m_gameManager = gameManager;
        var canvas = GameObject.Find("Canvas");
        var menuView = canvas.transform.Find("MenuView");
        var tDoll = menuView.Find(menuViewName);
        var scrollView = tDoll.Find("ScrollView");
        var viewPort = scrollView.Find("Viewport");
        m_viewPortContent = viewPort.Find("Content").gameObject;
        m_album = Resources.Load<GameObject>("Object/" + albumName);
    }
}
