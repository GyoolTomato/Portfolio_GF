using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scene_StageField.Object;

namespace Assets.Scene_StageField.Controller.EnemyData.Base
{
    public class EnemyListBase
    {
        protected List<EnemyParty> m_enemyParties;
        protected GameObject m_board;

        public virtual void Initialize()
        {
            m_enemyParties = new List<EnemyParty>();
            m_board = GameObject.Find("Board");
        }

        public List<EnemyParty> GetEnemyParties()
        {
            return m_enemyParties;
        }
    }
}