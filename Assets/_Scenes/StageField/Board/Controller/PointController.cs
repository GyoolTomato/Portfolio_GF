﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Scenes.StageField.Object;
using Assets.Scenes.StageField;

namespace Assets.Scenes.StageField.Board.Controller
{
    public class PointController
    {
        private StageFieldManager m_stageFieldManager;
        private BoardManager m_boardManager;
        private List<OccupationPoint> m_occupationPoints;
        private OccupationPoint m_selectPoint;

        private GameObject m_spawnAnswer;
        private Button m_spawnAnswer_Spawn;
        private Button m_spawnAnswer_Move;

        public PointController()
        {
        }

        public void Initialize(StageFieldManager stageFieldManager)
        {
            m_stageFieldManager = stageFieldManager;
            m_boardManager = m_stageFieldManager.GetBoardManager();
            m_occupationPoints = new List<OccupationPoint>();
            var points = GameObject.FindGameObjectsWithTag("Point");
            foreach (var item in points)
            {
                m_occupationPoints.Add(item.GetComponent<OccupationPoint>());
            }            

            var canvas = GameObject.Find("Canvas");
            var board = canvas.transform.Find("BoardUI");
            m_spawnAnswer = board.Find("SpawnAnswer").gameObject;
            m_spawnAnswer.SetActive(false);
            m_spawnAnswer_Spawn = m_spawnAnswer.transform.Find("Spawn").GetComponent<Button>();
            m_spawnAnswer_Spawn.onClick.AddListener(Handle_Spawn);
            m_spawnAnswer_Move = m_spawnAnswer.transform.Find("Move").GetComponent<Button>();
            m_spawnAnswer_Move.onClick.AddListener(Handle_Move);
        }

        public void Update()
        {

        }

        public List<OccupationPoint> GetOccupationPoints()
        {
            return m_occupationPoints;
        }

        public List<OccupationPoint> GetMainPoints()
        {
            var result = new List<OccupationPoint>();

            foreach (var item in GetOccupationPoints())
            {
                if (item.GetPointType() == OccupationPoint.E_PointType.MainPoint)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<OccupationPoint> GetHeliPoints()
        {
            var result = new List<OccupationPoint>();

            foreach (var item in GetOccupationPoints())
            {
                if (item.GetPointType() == OccupationPoint.E_PointType.HeliPortPoint)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<OccupationPoint> GetNormalPoints()
        {
            var result = new List<OccupationPoint>();

            foreach (var item in GetOccupationPoints())
            {
                if (item.GetPointType() == OccupationPoint.E_PointType.NormalPoint)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public void ClickOccupationPoint(OccupationPoint point)
        {
            m_selectPoint = point;
            var selectedPlayerPlatoon = m_boardManager.GetPlayerPlatoonController().SelectedPlayerPlatoon;

            if (m_stageFieldManager.GetPlayController().IsPlaying())
            {
                //캐릭터 존재시 리턴
                if (OnPlayer(point) != null)
                    return;

                switch (m_boardManager.GetNowState())
                {
                    case BoardManager.E_State.PlayerTurn:
                        switch (m_selectPoint.GetPointType())
                        {
                            case OccupationPoint.E_PointType.MainPoint:
                                if (point.Owner == OccupationPoint.E_Owner.Player)
                                {
                                    if (selectedPlayerPlatoon == null)
                                    {
                                        if (m_selectPoint.Owner == OccupationPoint.E_Owner.Player)
                                            m_boardManager.SetSpawnPlatoonActive(true);
                                    }
                                    else
                                        m_spawnAnswer.SetActive(true);
                                }
                                else
                                    MovePlayer(selectedPlayerPlatoon, m_selectPoint);
                                break;
                            case OccupationPoint.E_PointType.HeliPortPoint:
                                if (point.Owner == OccupationPoint.E_Owner.Player)
                                {
                                    if (selectedPlayerPlatoon == null)
                                    {
                                        if (m_selectPoint.Owner == OccupationPoint.E_Owner.Player)
                                            m_boardManager.SetSpawnPlatoonActive(true);
                                    }
                                    else
                                        m_spawnAnswer.SetActive(true);
                                }
                                else
                                    MovePlayer(selectedPlayerPlatoon, m_selectPoint);
                                break;
                            case OccupationPoint.E_PointType.NormalPoint:
                                MovePlayer(selectedPlayerPlatoon, m_selectPoint);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (m_selectPoint.GetPointType())
                {
                    case OccupationPoint.E_PointType.MainPoint:
                        if (m_selectPoint.Owner == OccupationPoint.E_Owner.Player)
                        {
                            m_boardManager.SetSpawnPlatoonActive(true);
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public OccupationPoint GetSelectedPoint()
        {
            return m_selectPoint;
        }

        public void MovePlayer(Player player, OccupationPoint pointToMove)
        {
            if (player != null)
            {
                if (IsLinked(player.GetStayPoint(), pointToMove))
                {
                    player.MovePoint(pointToMove);
                }
            }
        }

        public Player OnPlayer(OccupationPoint point)
        {
            var temp = GameObject.FindGameObjectsWithTag("Player");

            foreach (var item in temp)
            {
                var playerScript = item.GetComponent<Player>();

                if (playerScript != null)
                {
                    if (playerScript.GetStayPoint() == point)
                    {
                        return playerScript;
                    }
                }
            }

            return null;
        }

        public Enemy OnEnemy(OccupationPoint point)
        {
            var temp = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (var item in temp)
            {
                var enemyScript = item.GetComponent<Enemy>();

                if (enemyScript != null)
                {
                    if (enemyScript.GetStayPoint() == point)
                    {
                        return enemyScript;
                    }
                }
            }

            return null;
        }

        private bool IsLinked(OccupationPoint point0, OccupationPoint point1)
        {
            var result = false;

            foreach (var item in point0.GetLinkedPoints())
            {
                if (item == point1)
                {
                    result = true;
                }
            }

            return result;
        }

        private void Handle_Spawn()
        {
            if (m_selectPoint.Owner == OccupationPoint.E_Owner.Player)
                m_boardManager.SetSpawnPlatoonActive(true);                
            
            m_spawnAnswer.SetActive(false);
        }

        private void Handle_Move()
        {
            var selectedPlayerPlatoon = m_boardManager.GetPlayerPlatoonController().SelectedPlayerPlatoon;
            MovePlayer(selectedPlayerPlatoon, m_selectPoint);
            m_spawnAnswer.SetActive(false);
        }
    }
}