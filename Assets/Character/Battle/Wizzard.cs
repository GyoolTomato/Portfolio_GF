using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character.Battle
{
    public class Wizzard : Base.CharacterBase
    {
        public Wizzard()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.IndexDBController().TDoll(3));
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