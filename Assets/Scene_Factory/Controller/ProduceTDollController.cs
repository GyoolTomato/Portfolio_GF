using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scene_Factory.Controller
{
    public class ProduceTDollController
    {
        private Assets.Project.GameManager m_gameManager;

        public ProduceTDollController()
        {
        }

        public void Initialize(Assets.Project.GameManager gameManager)
        {
            m_gameManager = gameManager;
        }

        public void OrderReceive(int manPower, int bullet, int food, int militarySupplies)
        {
            if (manPower > 400 &&
                bullet > 400 &&
                food > 400 &&
                militarySupplies > 200)
            {
                var tDollList = m_gameManager.DBControllerIndex.TDolls(Project.DBController_Index.E_TDoll.All);
                var selectNumber = UnityEngine.Random.Range(0, tDollList.Count);
                                
                m_gameManager.DBControllerUser.AddOwnership(tDollList[selectNumber]);
            }
            else if (manPower > 100 &&
                bullet > 400 &&
                food > 400 &&
                militarySupplies > 200)
            {

            }
            else if (manPower > 400 &&
                bullet > 100 &&
                food > 400 &&
                militarySupplies > 200)
            {

            }
            else if (manPower > 400 &&
                bullet > 400 &&
                food > 100 &&
                militarySupplies > 200)
            {

            }
            else
            {

            }
        }
    }
}
