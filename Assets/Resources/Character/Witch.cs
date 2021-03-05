using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character
{
    public class Witch : Base.CharacterBase
    {
        public Witch()
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