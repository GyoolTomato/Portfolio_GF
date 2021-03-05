using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character
{
    public class Sorceress : Base.CharacterBase
    {
        public Sorceress()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.IndexDBController().TDoll(2));
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