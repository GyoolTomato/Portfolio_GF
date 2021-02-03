using System;
using UnityEngine;
using UnityEngine.UI;

public class SmallAlbum_Equipment : MonoBehaviour
{
    private Assets.Common.GameManager m_gameManager;
    private Image m_image;
    private Text m_limitedPower;

    public SmallAlbum_Equipment()
    {
    }

    public void Start()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<Assets.Common.GameManager>();
        m_image = transform.Find("Image").GetComponent<Image>();
        m_limitedPower = transform.Find("LimitedPower").GetComponent<Text>();
    }

    public void Update()
    {
        
    }

    public void ApplyValue(int ownershipCode)
    {
        var data = m_gameManager.UserDBController().UserEquipment(ownershipCode);
        m_limitedPower.text = data.LimitedPower + "%";
    }    
}
