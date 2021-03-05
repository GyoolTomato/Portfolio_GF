using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character
{
    public class HoodArcher : Base.CharacterBase
    {
        public HoodArcher()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.IndexDBController().TDoll(6));
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