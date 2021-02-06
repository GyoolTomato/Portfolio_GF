using UnityEngine;
using UnityEngine.UI;
using Assets.Common.Interface;

namespace Assets.Common.Base
{
    public class MenuBase
    {
        //private Assets.Common.GameManager m_gameManager;

        protected GameObject m_buttonObject1;        
        protected GameObject m_buttonObject2;        
        protected GameObject m_buttonObject3;        
        protected GameObject m_buttonObject4;        
        protected GameObject m_buttonObject5;    

        protected GameObject m_view1;
        protected GameObject m_view2;
        protected GameObject m_view3;
        protected GameObject m_view4;
        protected GameObject m_view5;

        private Button m_button1;
        private Button m_button2;
        private Button m_button3;
        private Button m_button4;
        private Button m_button5;
        private Image m_buttonImage1;
        private Image m_buttonImage2;
        private Image m_buttonImage3;
        private Image m_buttonImage4;
        private Image m_buttonImage5;
        private Text m_buttonText1;
        private Text m_buttonText2;
        private Text m_buttonText3;
        private Text m_buttonText4;
        private Text m_buttonText5;

        public MenuBase()
        {
            m_buttonObject1 = null;
            m_buttonObject2 = null;
            m_buttonObject3 = null;
            m_buttonObject4 = null;
            m_buttonObject5 = null;

            m_view1 = null;
            m_view2 = null;
            m_view3 = null;
            m_view4 = null;
            m_view5 = null;

            m_button1 = null;
            m_button2 = null;
            m_button3 = null;
            m_button4 = null;
            m_button5 = null;
            m_buttonImage1 = null;
            m_buttonImage2 = null;
            m_buttonImage3 = null;
            m_buttonImage4 = null;
            m_buttonImage5 = null;
            m_buttonText1 = null;
            m_buttonText2 = null;
            m_buttonText3 = null;
            m_buttonText4 = null;
            m_buttonText5 = null;
        }

        public virtual void Initialize(GameObject canvas)
        {
            if (m_buttonObject1 != null)
            {
                m_button1 = m_buttonObject1.GetComponent<Button>();
                m_buttonImage1 = m_buttonObject1.GetComponent<Image>();
                m_buttonText1 = m_buttonObject1.transform.Find("Text").GetComponent<Text>();
            }
            if (m_buttonObject2 != null)
            {
                m_button2 = m_buttonObject2.GetComponent<Button>();
                m_buttonImage2 = m_buttonObject2.GetComponent<Image>();
                m_buttonText2 = m_buttonObject2.transform.Find("Text").GetComponent<Text>();
            }
            if (m_buttonObject3 != null)
            {
                m_button3 = m_buttonObject3.GetComponent<Button>();
                m_buttonImage3 = m_buttonObject3.GetComponent<Image>();
                m_buttonText3 = m_buttonObject3.transform.Find("Text").GetComponent<Text>();
            }
            if (m_buttonObject4 != null)
            {
                m_button4 = m_buttonObject4.GetComponent<Button>();
                m_buttonImage4 = m_buttonObject4.GetComponent<Image>();
                m_buttonText4 = m_buttonObject4.transform.Find("Text").GetComponent<Text>();
            }
            if (m_buttonObject5 != null)
            {
                m_button5 = m_buttonObject5.GetComponent<Button>();
                m_buttonImage5 = m_buttonObject5.GetComponent<Image>();
                m_buttonText5 = m_buttonObject5.transform.Find("Text").GetComponent<Text>();
            }

            ApplyAction();
            Handle_ButtonClick1();
        }

        protected void ApplyAction()
        {
            if (m_button1 != null)
                m_button1.onClick.AddListener(Handle_ButtonClick1);
            if (m_button2 != null)
                m_button2.onClick.AddListener(Handle_ButtonClick2);
            if (m_button3 != null)
                m_button3.onClick.AddListener(Handle_ButtonClick3);
            if (m_button4 != null)
                m_button4.onClick.AddListener(Handle_ButtonClick4);
            if (m_button5 != null)
                m_button5.onClick.AddListener(Handle_ButtonClick5);
        }

        protected virtual void Handle_ButtonClick1()
        {
            if (m_view1 != null)
                m_view1.SetActive(true);
            if (m_view2 != null)
                m_view2.SetActive(false);
            if (m_view3 != null)
                m_view3.SetActive(false);
            if (m_view4 != null)
                m_view4.SetActive(false);
            if (m_view5 != null)
                m_view5.SetActive(false);

            ChangeColor(m_buttonText1, m_buttonImage1);
        }

        protected virtual void Handle_ButtonClick2()
        {
            if (m_view1 != null)
                m_view1.SetActive(false);
            if (m_view2 != null)
                m_view2.SetActive(true);
            if (m_view3 != null)
                m_view3.SetActive(false);
            if (m_view4 != null)
                m_view4.SetActive(false);
            if (m_view5 != null)
                m_view5.SetActive(false);

            ChangeColor(m_buttonText2, m_buttonImage2);
        }

        protected virtual void Handle_ButtonClick3()
        {
            if (m_view1 != null)
                m_view1.SetActive(false);
            if (m_view2 != null)
                m_view2.SetActive(false);
            if (m_view3 != null)
                m_view3.SetActive(true);
            if (m_view4 != null)
                m_view4.SetActive(false);
            if (m_view5 != null)
                m_view5.SetActive(false);

            ChangeColor(m_buttonText3, m_buttonImage3);
        }

        protected virtual void Handle_ButtonClick4()
        {
            if (m_view1 != null)
                m_view1.SetActive(false);
            if (m_view2 != null)
                m_view2.SetActive(false);
            if (m_view3 != null)
                m_view3.SetActive(false);
            if (m_view4 != null)
                m_view4.SetActive(true);
            if (m_view5 != null)
                m_view5.SetActive(false);

            ChangeColor(m_buttonText4, m_buttonImage4);
        }

        protected virtual void Handle_ButtonClick5()
        {
            if (m_view1 != null)
                m_view1.SetActive(false);
            if (m_view2 != null)
                m_view2.SetActive(false);
            if (m_view3 != null)
                m_view3.SetActive(false);
            if (m_view4 != null)
                m_view4.SetActive(false);
            if (m_view5 != null)
                m_view5.SetActive(true);

            ChangeColor(m_buttonText5, m_buttonImage5);
        }

        private void ChangeColor(Text buttonText, Image buttonImage)
        {
            if (m_buttonText1 != null)            
                m_buttonText1.color = CustomColor.Gold;
            if (m_buttonText2 != null)
                m_buttonText2.color = CustomColor.Gold;
            if (m_buttonText3 != null)
                m_buttonText3.color = CustomColor.Gold;
            if (m_buttonText4 != null)
                m_buttonText4.color = CustomColor.Gold;
            if (m_buttonText5 != null)
                m_buttonText5.color = CustomColor.Gold;

            if (m_buttonImage1 != null)
                m_buttonImage1.color = CustomColor.DarkGray;
            if (m_buttonImage2 != null)
                m_buttonImage2.color = CustomColor.DarkGray;
            if (m_buttonImage3 != null)
                m_buttonImage3.color = CustomColor.DarkGray;
            if (m_buttonImage4 != null)
                m_buttonImage4.color = CustomColor.DarkGray;
            if (m_buttonImage5 != null)
                m_buttonImage5.color = CustomColor.DarkGray;

            if (buttonText != null)
                buttonText.color = Color.black;
            if (buttonImage != null)
                buttonImage.color = CustomColor.Gold;
        }
    }
}