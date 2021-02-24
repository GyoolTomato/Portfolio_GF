using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.StageField;
using Assets.Scene_StageField;

namespace Assets.Scene_StageField.Controller
{
    public class PointController
    {
        private StageFieldManager m_stageFieldManager;
        private OccupationPoint m_selectBeforePoint;
        private OccupationPoint m_selectPoint;

        public PointController()
        {
        }

        public void Initialize(StageFieldManager manager)
        {
            m_stageFieldManager = manager;
        }

        public void ClickOccupationPoint(OccupationPoint point)
        {
            m_selectBeforePoint = m_selectPoint;
            m_selectPoint = point;
            switch (point.GetPointType())
            {
                case OccupationPoint.E_PointType.MainPoint:
                    if (point.Owner == OccupationPoint.E_Owner.Player && point.OnPlayer == null)
                    {
                        m_stageFieldManager.SetSpawnPlatoonActive(true);
                        return;
                    }

                    Move(point);
                    break;
                case OccupationPoint.E_PointType.HeliPortPoint:
                    if (point.Owner == OccupationPoint.E_Owner.Player && point.OnPlayer == null)
                    {
                        m_stageFieldManager.SetSpawnPlatoonActive(true);
                        return;
                    }

                    Move(point);
                    break;
                case OccupationPoint.E_PointType.NormalPoint:
                    Move(point);
                    break;
                default:
                    break;
            }
        }

        public OccupationPoint GetSelectedPoint()
        {
            return m_selectPoint;
        }

        public void Move(OccupationPoint pointToMove)
        {
            if (m_stageFieldManager.GetCharacterController().SelectedPlayerPlatoon != null)
            {
                if (IsLinked(m_selectBeforePoint, pointToMove))
                {
                    pointToMove.OnPlayer = m_stageFieldManager.GetCharacterController().SelectedPlayerPlatoon;
                }
            }
        }

        private bool IsLinked(OccupationPoint point0, OccupationPoint point1)
        {
            var result = false;

            foreach (var item in point0.LinkedPoints())
            {
                if (item == point1)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}