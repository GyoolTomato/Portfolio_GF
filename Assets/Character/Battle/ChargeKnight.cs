using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character.Battle
{
    public class ChargeKnight : Base.CharacterBase
    {
        public ChargeKnight()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.IndexDBController().TDoll(8));
        }

        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}