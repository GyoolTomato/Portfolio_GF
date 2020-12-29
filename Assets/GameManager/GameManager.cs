using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private WorkResourceManager m_workResourceManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        m_workResourceManager = new WorkResourceManager();
        m_workResourceManager.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_workResourceManager.ApplySaveAmount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public WorkResourceManager WorkResource
    {
        get
        {
            return m_workResourceManager;
        }
    }
}
