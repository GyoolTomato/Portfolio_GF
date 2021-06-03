using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.StageField.BattleField.Controller
{
    public class BattleFinishMessageController
    {
        GameObject m_finishMessage;
        Text m_text;
        Animation m_textAnimation;

        public BattleFinishMessageController()
        {
        }

        public void Initialize()
        {
            var canvas = GameObject.Find("Canvas");
            var battleFieldUI = canvas.transform.Find("BattleFieldUI");
            m_finishMessage = battleFieldUI.Find("FinishMessage").gameObject;
            m_text = m_finishMessage.transform.Find("Text").GetComponent<Text>();
            m_textAnimation = m_finishMessage.transform.Find("Text").GetComponent<Animation>();            
        }

        public void Ready()
        {
            m_finishMessage.SetActive(false);
        }

        public void Play(BattleFieldManager.E_Winner winner)
        {
            m_finishMessage.SetActive(true);

            switch (winner)
            {
                case BattleFieldManager.E_Winner.Player:
                    m_text.color = Graphic.CustomColor.PlayerPoint;
                    m_text.text = "- 승리 -";
                    break;
                case BattleFieldManager.E_Winner.Enemy:
                    m_text.color = Graphic.CustomColor.EnemyPoint;
                    m_text.text = "- 패E_Winner -";
                    break;
                default:
                    break;
            }

            m_textAnimation.Play();            
        }
    }
}