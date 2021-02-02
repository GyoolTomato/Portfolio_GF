using System;
using UnityEngine;
using UnityEngine.UI;

public class FactoryResourceMonitor : MonoBehaviour
{
    private Image m_image;
    private Text m_title;
    private Text m_amount;

    public FactoryResourceMonitor()
    {
    }

    private void Start()
    {
        m_image = transform.Find("Image").GetComponent<Image>();
        m_title = transform.Find("Title").GetComponent<Text>();
        m_amount = transform.Find("Amount").GetComponent<Text>();
    }

    private void Update()
    {
        
    }

    public void InitValue(Image image, string title)
    {
        m_title.text = title;        
    }

    public void RefreshAmount(int amount)
    {
        m_amount.text = amount.ToString();
    }
}
