using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Album_TDoll : MonoBehaviour
{
    private Image m_character;
    private Image m_typeImage;
    private Text m_star;    
    private Text m_level;
    private Text m_name;
    private Text m_dummyLink;
    private GameObject m_platoon;
    private Text m_platoonNumber;

    private Assets.Project.ImageController m_imageController;

    private void Awake()
    {
        m_character = transform.Find("Character").GetComponent<Image>();

        var informationTop = transform.Find("InformationTop");
        m_typeImage = informationTop.Find("Image").GetComponent<Image>();
        m_star = informationTop.Find("Star").GetComponent<Text>();

        var informationBottom = transform.Find("InformationBottom");
        m_level = informationBottom.Find("Level").GetComponent<Text>();
        m_name = informationBottom.Find("Name").GetComponent<Text>();
        m_dummyLink = informationBottom.Find("DummyLink").GetComponent<Text>();
        m_platoon = informationBottom.Find("Platoon").gameObject;

        m_platoonNumber = m_platoon.transform.Find("Platoon").GetComponent<Text>();

        m_imageController = new Assets.Project.ImageController();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {

    }

    public void SetValue(Assets.Project.DB.IndexDataBase_TDoll dBData, int level, int dummyLink, int platoonNumber)
    {
        ApplyDataCode(dBData);
        ApplyLevel(level);
        ApplyDummyLink(dummyLink);
        ApplyPlatoonNumber(platoonNumber);
    }

    private void ApplyDataCode(Assets.Project.DB.IndexDataBase_TDoll dBData)
    {
        //m_typeImage.sprite = m_imageController.LoadSprite(dBData.Type);

        var tempStar = string.Empty;
        for (int i = 0; i < dBData.Star; i++)
            tempStar += "★";

        m_star.text = tempStar;
        //m_character.sprite = m_imageController.LoadSprite(dBData.DataCode);
        m_name.text = dBData.Name;
    }

    private void ApplyLevel(int level)
    {
        m_level.text = "LV." + level.ToString();
    }

    private void ApplyDummyLink(int dummyLink)
    {
        m_dummyLink.text = "x" + dummyLink.ToString();
    }

    private void ApplyPlatoonNumber(int platoonNumber)
    {
        if (platoonNumber == 0)
        {
            m_platoon.SetActive(false);
        }
        else
        {
            m_platoon.SetActive(true);
            m_platoonNumber.text = platoonNumber.ToString();
        }
    }
}
