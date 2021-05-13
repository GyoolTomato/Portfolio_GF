using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Skill.Base;

namespace Assets.Character.Battle.StateMachine
{
    public class NormalAttack : Base.StateMachineBase
    {
        private float m_elapsedTimeAttackDelay;

        protected override void LoadAnimation()
        {
            if (!m_animator.GetBool(m_stringIsAttack))
            {
                base.LoadAnimation();

                m_animator.speed = m_characterBase.GetCharacterStat().AttackSpeed * m_animationCorrection;
                m_animator.SetBool(m_stringIsAttack, true);
            }
        }

        public override void Action(Battle.Base.CharacterBase targetCharacterBase, GameObject skillObject)
        {
            base.Action(targetCharacterBase, skillObject);

            if (m_elapsedTimeAttackDelay <= 0.0f)
            {
                var temp = UnityEngine.MonoBehaviour.Instantiate(skillObject,
                    new Vector3(
                        m_characterBase.gameObject.transform.position.x,
                        m_characterBase.gameObject.transform.position.y + 0.5f,
                        m_characterBase.gameObject.transform.position.z),
                    Quaternion.identity);
                var tempScript = temp.GetComponent<Skill.Base.SkillBase>();
                tempScript.Initialize(m_characterBase, targetCharacterBase, m_characterBase.GetCharacterStat().FirePower);

                m_elapsedTimeAttackDelay = m_characterBase.GetCharacterStat().AttackSpeed;
            }
            else
            {
                m_elapsedTimeAttackDelay -= Time.deltaTime;
            }
        }
    }
}
