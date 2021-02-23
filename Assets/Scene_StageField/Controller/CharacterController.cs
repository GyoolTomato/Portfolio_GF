using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.StageField;
using Assets.Scene_StageField;

public class CharacterController
{
    private Player m_selectedPlayerPlatoon;
    private StageFieldManager m_scene_StageField;

    public void Initialize(StageFieldManager stageFieldManager)
    {
        m_scene_StageField = stageFieldManager;
    }

    public void SetSelectedPlayerPlatoon(Player player)
    {
        m_selectedPlayerPlatoon = player;
        Debug.Log("SetSelectedPlayerPlatoon : " + m_selectedPlayerPlatoon);
    }

    

    public void Move(OccupationPoint pointToMove)
    {
        if (m_selectedPlayerPlatoon != null)
        {
            foreach (var item in m_selectedPlayerPlatoon.GetStayPoint().LinkedPoints())
            {
                if (item == pointToMove.gameObject)
                {
                    m_selectedPlayerPlatoon.SetStayPoint(pointToMove);
                    return;
                }
            }
        }
    }

    public void ClickOccupationPoint(OccupationPoint point)
    {
        switch (point.GetPointType())
        {
            case OccupationPoint.E_PointType.MainPoint:
                m_scene_StageField.SetSpawnPlatoonActive(true);
                break;
            case OccupationPoint.E_PointType.HeliPortPoint:
                m_scene_StageField.SetSpawnPlatoonActive(true);
                break;
            case OccupationPoint.E_PointType.NormalPoint:
                break;
            default:
                break;
        }
    }
}
