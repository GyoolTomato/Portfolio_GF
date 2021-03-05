using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character
{
    public class BoyKnight : Base.CharacterBase
    {
        public BoyKnight()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.IndexDBController().TDoll(7));
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