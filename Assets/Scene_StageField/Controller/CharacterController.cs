using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.StageField;

public class CharacterController : MonoBehaviour
{
    private Player m_selectedPlayerPlatoon;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
