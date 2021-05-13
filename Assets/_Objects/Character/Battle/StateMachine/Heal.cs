using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Character.Battle.Base;
using Assets.Skill.Base;

namespace Assets.Character.Battle.StateMachine
{
    public class Heal : Base.StateMachineBase
    {
        protected override void LoadAnimation()
        {
            if (!m_animator.GetBool(m_stringIsAttack))
            {
                base.LoadAnimation();

                m_animator.speed = m_characterBase.GetCharacterStat().AttackSpeed * m_animationCorrection;
                m_animator.SetBool(m_stringIsAttack, true);
            }
        }

        public override void Action()
        {
            base.Action();

            foreach (var item in GameObject.FindGameObjectsWithTag(m_characterBase.transform.tag))
            {
                var temp = item.GetComponent<CharacterBase>();
                if (temp != null)
                {
                    var healingObject = MonoBehaviour.Instantiate(SkillObject.Heal(),
                        new Vector3(
                            m_characterBase.transform.position.x,
                            m_characterBase.transform.position.y + 0.5f,
                            m_characterBase.transform.position.z),
                        Quaternion.identity);
                    var tempScript = healingObject.GetComponent<SkillBase>();
                    tempScript.Initialize(m_characterBase, temp, m_characterBase.GetCharacterStat().FirePower, true);
                }
            }
        }
    }
}