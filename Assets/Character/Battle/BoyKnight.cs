﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Character.Battle.Base;
using Assets.Skill;

namespace Assets.Character.Battle
{
    public class BoyKnight : Base.CharacterBase
    {
        public BoyKnight()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.GetIndexDBController().TDoll(7));
        }

        protected override void Start()
        {
            base.Start();            
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void AttackAction()
        {
            base.AttackAction();

            if (TargetingEnemy() != null)
            {
                var temp = Instantiate(SkillObject.NearAttack(), new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                temp.transform.parent = transform;
                var tempScript = temp.GetComponent<Skill.Base.SkillBase>();
                tempScript.Initialize(gameObject, TargetingEnemy().gameObject, m_stat.FirePower);
            }
        }
    }
}