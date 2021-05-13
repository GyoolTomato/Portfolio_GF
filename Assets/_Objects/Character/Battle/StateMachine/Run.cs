using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character.Battle.StateMachine
{
    public class Run : Base.StateMachineBase
    {
        protected override void LoadAnimation()
        {
            if (!m_animator.GetBool(m_stringIsRun))
            {
                base.LoadAnimation();

                m_animator.speed = 1.3f;
                m_animator.SetBool(m_stringIsRun, true);
            }
        }

        public override void Action()
        {
            base.Action();

            switch (m_characterBase.GetTeam())
            {
                case Battle.Base.Team.Player:
                    m_characterBase.gameObject.transform.Translate(Vector2.right * Time.deltaTime * m_characterBase.GetCharacterStat().MoveSpeed);
                    break;
                case Battle.Base.Team.Enemy:
                    m_characterBase.gameObject.transform.Translate(Vector2.left * Time.deltaTime * m_characterBase.GetCharacterStat().MoveSpeed);
                    break;
                default:
                    break;
            }
        }
    }
}