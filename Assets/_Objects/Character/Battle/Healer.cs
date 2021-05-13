using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Character.Battle.Base;
using Assets.Skill.Base;

namespace Assets.Character.Battle
{
    public class Healer : CharacterBase
    {
        private float m_healCoolTime;
        private float m_healCounter;

        private StateMachine.Die m_stateMachineDie;
        private StateMachine.Idle m_stateMachineIdle;
        private StateMachine.Run m_stateMachineRun;
        private StateMachine.NormalAttack m_stateMachineNormalAttack;
        private StateMachine.Heal m_stateMachineHeal;

        public Healer()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_dbManager.GetIndexDBController().TDoll(1), 1.5f);
            m_healCoolTime = 3;
            m_healCounter = 0;

            m_stateMachineDie = new StateMachine.Die();
            m_stateMachineDie.Initialize(m_animator, this);
            m_stateMachineIdle = new StateMachine.Idle();
            m_stateMachineIdle.Initialize(m_animator, this);
            m_stateMachineRun = new StateMachine.Run();
            m_stateMachineRun.Initialize(m_animator, this);
            m_stateMachineNormalAttack = new StateMachine.NormalAttack();
            m_stateMachineNormalAttack.Initialize(m_animator, this);
            m_stateMachineHeal = new StateMachine.Heal();
            m_stateMachineHeal.Initialize(m_animator, this);
        }

        protected override void Start()
        {
            base.Start();            
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void StateMachine()
        {
            if (m_characterStat.Hp > 0)
            {
                if (TargetingEnemy() == null)
                {
                    m_stateMachineIdle.Action();
                }
                else
                {
                    if (m_healCounter > 0)
                        m_healCounter -= Time.deltaTime;

                    if (IsInAttackRange())
                    {
                        if (m_healCounter <= 0)
                        {
                            m_stateMachineHeal.Action();
                            m_healCounter = m_healCoolTime;
                        }
                        else
                        {
                            m_stateMachineNormalAttack.Action(TargetingEnemy(), SkillObject.Magic());
                        }
                    }
                    else
                    {
                        m_stateMachineRun.Action();
                    }
                }
            }
            else
                m_stateMachineDie.Action();
        }
    }
}