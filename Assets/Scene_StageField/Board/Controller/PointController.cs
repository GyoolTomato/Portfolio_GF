using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.StageField;
using Assets.Scene_StageField;

namespace Assets.Scene_StageField.Board.Controller
{
    public class PointController
    {
        private BoardManager m_boardManager;
        private List<OccupationPoint> m_occupationPoints;
        private OccupationPoint m_selectPoint;

        private GameObject m_spawnAnswer;
        private Button m_spawnAnswer_Spawn;
        private Button m_spawnAnswer_Move;

        public PointController()
        {
        }

        public void Initialize(BoardManager boardManager)
        {
            m_boardManager = boardManager;
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

        public void ClickOccupationPoint(OccupationPoint point)
        {
            m_selectPoint = point;
            var selectedPlayerPlatoon = m_boardManager.GetPlayerPlatoonController().SelectedPlayerPlatoon;

            if (m_boardManager.IsStart())
            {
                if (selectedPlayerPlatoon == OnPlayer(point))
                    return;

                switch (m_boardManager.GetNowState())
                {
                    case BoardManager.E_State.PlayerTurn:
                        switch (m_selectPoint.GetPointType())
                        {
                            case OccupationPoint.E_PointType.MainPoint:
                                if (selectedPlayerPlatoon == null)
                                {
                                    if (m_selectPoint.Owner == OccupationPoint.E_Owner.Player)
                                        m_boardManager.SetSpawnPlatoonActive(true);
                                }
                                else
                                    m_spawnAnswer.SetActive(true);
                                break;
                            case OccupationPoint.E_PointType.HeliPortPoint:
                                if (selectedPlayerPlatoon == null)
                                {
                                    if (m_selectPoint.Owner == OccupationPoint.E_Owner.Player)
                                        m_boardManager.SetSpawnPlatoonActive(true);
                                }
                                else
                                    m_spawnAnswer.SetActive(true);
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