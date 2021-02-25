using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.StageField;
using Assets.Scene_StageField;

public class CharacterController
{
    private Player m_selectedPlayerPlatoon;
    private StageFieldManager m_scene_StageField;
    private OccupationPoint m_selectPoint;

    public void Initialize(StageFieldManager stageFieldManager)
    {
        m_scene_StageField = stageFieldManager;
    }

    public Player SelectedPlayerPlatoon
    {
        get
        {
            return m_selectedPlayerPlatoon;        
        }
        set
        {
            m_selectedPlayerPlatoon = value;
            Debug.Log("SetSelectedPlayerPlatoon : " + m_selectedPlayerPlatoon);
        }
    }

    public int NumberOfPlayer()
    {
        var temp = GameObject.FindGameObjectsWithTag("Player");

        return temp.Length;
    }

    //public void Move(OccupationPoint pointToMove)
    //{
    //    if (m_selectedPlayerPlatoon != null)
    //    {
    //        foreach (var item in pointToMove.LinkedPoints())
    //        {
    //            if (item == pointToMove.gameObject)
    //            {
    //                pointToMove.OnPlayer = m_selectedPlayerPlatoon;
    //                return;
    //            }
    //        }
    //    }
    //}
}
