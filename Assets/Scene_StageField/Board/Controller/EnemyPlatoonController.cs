using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scene_StageField.Controller.EnemyData;
using Assets.Scene_StageField.Controller.EnemyData.Base;
using Assets.Scene_StageField.Object;
using Assets.Character;

namespace Assets.Scene_StageField.Board.Controller
{
    public class EnemyPlatoonController
    {
        enum E_State
        {
            Move,
            Battle,
            Occupation,
            TurnEnd,
            End,
        }

        private Common.GameManager m_gameManager;
        private BoardManager m_boardManager;
        private EnemyListBase m_selectedStageEnemy;
        private Stage1_1 m_stage1_1;
        private Stage1_2 m_stage1_2;
        private Stage1_3 m_stage1_3;
        private Stage1_4 m_stage1_4;
        private Stage1_5 m_stage1_5;
                
        private GameObject m_board;
        private bool m_isMoveFinish;

        public EnemyPlatoonController()
        {
        }

        public void Initialize(BoardManager boardManager)
        {
            m_gameManager = GameObject.Find("GameManager").GetComponent<Common.GameManager>();
            m_boardManager = boardManager;

            var gameManager = GameObject.Find("GameManager").GetComponent<Assets.Common.GameManager>();
            var selectedStage = gameManager.SelectedStage;            
            m_board = GameObject.Find("Board");

            if (selectedStage.StageNumber == 1)
            {
                switch (selectedStage.InnerNumber)
                {
                    case 1:
                        m_stage1_1 = new Stage1_1();
                        m_stage1_1.Initialize();
                        m_selectedStageEnemy = m_stage1_1;
                        break;
                    case 2:
                        m_stage1_2 = new Stage1_2();
                        m_stage1_2.Initialize();
                        m_selectedStageEnemy = m_stage1_2;
                        break;
                    case 3:
                        m_stage1_3 = new Stage1_3();
                        m_stage1_3.Initialize();
                        m_selectedStageEnemy = m_stage1_3;
                        break;
                    case 4:
                        m_stage1_4 = new Stage1_4();
                        m_stage1_4.Initialize();
                        m_selectedStageEnemy = m_stage1_4;
                        break;
                    case 5:
                        m_stage1_5 = new Stage1_5();
                        m_stage1_5.Initialize();
                        m_selectedStageEnemy = m_stage1_5;
                        break;
                default:
                        break;
                }
            }

            CreateEnemy();
        }

        private void CreateEnemy()
        {
            foreach (var item in m_selectedStageEnemy.GetEnemyParties())
            {
                var platoon = MonoBehaviour.Instantiate(CharacterObject.DataCodeObject(item.Memeber1.IndexNumber), Vector3.zero, Quaternion.identity);
                platoon.transform.parent = m_board.transform;
                platoon.AddComponent<Enemy>();
                var enemyScript = platoon.GetComponent<Enemy>();
                enemyScript.Initialize(item);
            }
        }

        public List<Enemy> GetEnemies()
        {
            var temp = GameObject.FindGameObjectsWithTag("Enemy");
            var enemies = new List<Enemy>();
            foreach (var item in temp)
            {
                enemies.Add(item.GetComponent<Enemy>());
            }

            return enemies;
        }

        public void StartEnemyTurn()
        {
            m_isMoveFinish = false;
            MoveToPoint();
            m_boardManager.GetStageFieldManager().StartCoroutine(MoveFinishCheck());
        }

        private void MoveToPoint()
        {            
            var pointController = m_boardManager.GetPointController();
            var linkedPoints = new List<OccupationPoint>();
            var enableMovePoints = new List<OccupationPoint>();
            var random = 0;

            foreach (var item in GetEnemies())
            {
                linkedPoints = item.GetStayPoint().GetLinkedPoints();
                enableMovePoints = new List<OccupationPoint>();
                random = 0;

                foreach (var point in linkedPoints)
                {
                    if (pointController.OnEnemy(point) == null)
                    {
                        enableMovePoints.Add(point);
                    }
                }

                if (enableMovePoints.Count > 0)
                {
                    random = UnityEngine.Random.Range(0, enableMovePoints.Count);
                    item.MovePoint(enableMovePoints[random]);
                }                
            }
        }

        IEnumerator MoveFinishCheck()
        {
            if (GetEnemies().Count > 0)
            {
                var isFinish = false;

                while (!isFinish)
                {
                    isFinish = true;
                    foreach (var item in GetEnemies())
                    {
                        if (item.IsMoving())
                            isFinish = false;
                    }

                    yield return new WaitForSeconds(1);
                }
            }

            m_isMoveFinish = true;
            yield return null;
        }

        public bool IsMoveFinish()
        {
            return m_isMoveFinish;
        }
    }
}