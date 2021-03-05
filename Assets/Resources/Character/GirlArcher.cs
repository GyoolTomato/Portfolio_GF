using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character
{
    public class GirlArcher : Base.CharacterBase
    {
        public GirlArcher()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.IndexDBController().TDoll(5));
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