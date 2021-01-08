using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WorkResourceSlot : MonoBehaviour
{
    private int m_value;
    private bool m_isValueUp;
    private bool m_isValueDown;
    private Image m_image;
    private Text m_valueMonitor;
    private Button m_valueUp;
    private Button m_valueDown;

    public WorkResourceSlot()
    {
        
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        m_image = GameObject.Find("Image").GetComponent<Image>();
        m_valueMonitor = GameObject.Find("ValueMonitor").GetComponent<Text>();
        m_valueUp = GameObject.Find("ValueUp").GetComponent<Button>();
        m_valueDown = GameObject.Find("ValueDown").GetComponent<Button>();

        m_value = 0;
        ApplyValueInMonitor();

        m_valueUp.onClick.AddListener(ValueUp);        
        m_valueDown.onClick.AddListener(ValueDown);        
    }

    private void Update()
    {
        if (m_isValueUp)
        {
            ValueUp();
        }

        if (m_isValueDown)
        {
            ValueDown();
        }
    }

    private void ValueUp()
    {
        if (m_value < 9900)
        {
            m_value += 100;
            ApplyValueInMonitor();
        }
    }

    private void ValueDown()
    {
        if (m_value > 0)
        {
            m_value -= 100;
            ApplyValueInMonitor();
        }
    }

    private void ApplyValueInMonitor()
    {
        m_valueMonitor.text = m_value.ToString("D4");
    }    

    public void ValueUp_OnPointerDown()
    {
        Invoke("ValueUp_Stanby", 1.0f);
    }

    public void ValueUp_OnPointerUp()
    {
        m_isValueUp = false;
        CancelInvoke("ValueUp_Stanby");
    }    

    public void ValueDown_OnPointerDown()
    {
        Invoke("ValueDown_Stanby", 1.0f);
    }

    public void ValueDown_OnPointerUp()
    {
        m_isValueDown = false;
        CancelInvoke("ValueDown_Stanby");
    }

    private void ValueUp_Stanby()
    {
        m_isValueUp = true;
    }

    private void ValueDown_Stanby()
    {
        m_isValueDown = true;
    }

    public int Value
    {
        get
        {
            return m_value;
        }
    }
}