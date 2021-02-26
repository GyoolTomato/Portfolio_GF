using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.StageField;

namespace Assets.Scene_StageField.Controller.EnemyData.Base
{
    public class EnemyListBase
    {
        protected List<EnemyParty> m_enemyParties;
        protected GameObject m_map;

        public virtual void Initialize()
        {
            m_enemyParties = new List<EnemyParty>();
            m_map = GameObject.Find("Map");
        }

        public List<EnemyParty> GetEnemyParties()
        {
            return m_enemyParties;
        }
    }
}