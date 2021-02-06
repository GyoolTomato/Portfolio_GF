using System;
using UnityEngine;
using UnityEngine.UI;

public class SmallAlbum_Equipment : MonoBehaviour
{
    private Assets.Common.GameManager m_gameManager;
    private Image m_image;
    private Text m_limitedPower;
    private GameObject m_curtain;

    public SmallAlbum_Equipment()
    {
    }

    public void Start()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<Assets.Common.GameManager>();
        m_image = transform.Find("Image").GetComponent<Image>();
        m_limitedPower = transform.Find("LimitedPower").GetComponent<Text>();
        m_curtain = transform.Find("Curtain").gameObject;
        SetCurtain(true);
    }

    public void Update()
    {
        
    }    

    public void ApplyValue(int ownershipCode)
    {
        try
        {
            var data = m_gameManager.UserDBController().UserEquipment(ownershipCode);

            if (data != null)
            {
                m_limitedPower.text = data.LimitedPower + "%";
                SetCurtain(false);
            }
            else
                SetCurtain(true);
        }
        catch
        {
            SetCurtain(true);
        }
    }

    private void SetCurtain(bool set)
    {
        m_curtain.SetActive(set);
    }
}
