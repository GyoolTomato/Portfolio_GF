using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character.Battle
{
    public class Archer : Base.CharacterBase
    {
        public Archer()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.IndexDBController().TDoll(4));
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