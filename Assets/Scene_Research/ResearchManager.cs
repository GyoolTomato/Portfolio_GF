using System;
using UnityEngine;

public class ResearchManager : MonoBehaviour
{
    private Assets.Common.GameManager m_gameManager;
    private GameObject m_canvas;

    private Assets.Resources.Object.Title m_title;
    //private MenuController m_menuController;

    public ResearchManager()
    {
    }

    private void Awake()
    {

    }

    private void Start()
    {
        m_gameManager = GameObject.Find("GameManager").gameObject.GetComponent<Assets.Common.GameManager>();
        m_canvas = GameObject.Find("Canvas");

        m_title = m_canvas.transform.Find("Title").GetComponent<Assets.Resources.Object.Title>();
        m_title.Initialize(m_gameManager, "연구");
        //m_menuController = new Controller.MenuController();
        //m_menuController.Initialize(m_gameManager, m_canvas);
    }

    private void Update()
    {

    }
}
