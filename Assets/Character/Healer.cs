using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character
{
    public class Healer : Base.CharacterBase
    {
        public Healer()
        {
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();

            Initialize(m_gameManager.IndexDBController().TDoll(1));
        }

        protected override void Update()
        {
            base.Update();

        }
    }
}