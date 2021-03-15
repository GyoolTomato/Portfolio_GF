using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Character
{
    public class ElfKnight : Base.CharacterBase
    {
        public ElfKnight()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            Initialize(m_gameManager.IndexDBController().TDoll(9));
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