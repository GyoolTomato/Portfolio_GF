using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Character;
using Assets.Character.Base;

public class BattleFieldController 
{
    private GameObject m_battleFieldUI;
    private GameObject m_battleField;
    private GameObject m_boardUI;
    private GameObject m_board;
    private List<CharacterBase> m_players;
    private List<CharacterBase> m_enimies;

    public BattleFieldController()
    {
    }

    public void Initialize()
    {
        var canvas = GameObject.Find("Canvas");
        m_battleFieldUI = canvas.transform.Find("BattleField").gameObject;
        m_battleField = GameObject.Find("BattleField");
        m_boardUI = canvas.transform.Find("Board").gameObject;
        m_board = GameObject.Find("Map");
    }

    public void OpenBattleField()
    {
        m_battleFieldUI.SetActive(true);
        m_battleField.SetActive(true);
        m_boardUI.SetActive(false);
        m_board.SetActive(false);

        m_players = new List<CharacterBase>();
        m_enimies = new List<CharacterBase>();

        var tempPlayer = MonoBehaviour.Instantiate(CharacterObject.Healer(), new Vector3(-10, 0, 0), Quaternion.identity);
        var tempEnemy = MonoBehaviour.Instantiate(CharacterObject.Healer(), new Vector3(10, 0, 0), Quaternion.identity);
        var scriptPlayer = tempPlayer.GetComponent<CharacterBase>();
        var scriptEnemy = tempEnemy.GetComponent<CharacterBase>();

        scriptPlayer.Initialize(CharacterBase.E_Team.Player, new Assets.Common.DB.User.UserDataBase_TDoll());
        scriptEnemy.Initialize(CharacterBase.E_Team.Enemy, new Assets.Common.DB.User.UserDataBase_TDoll());
        tempPlayer.transform.parent = m_battleField.transform;
        tempEnemy.transform.parent = m_battleField.transform;

        m_players.Add(scriptPlayer);
        m_enimies.Add(scriptEnemy);
    }

    private void CloseBattleField()
    {
        m_battleFieldUI.SetActive(false);
        m_battleField.SetActive(false);
        m_boardUI.SetActive(true);
        m_board.SetActive(true);
    }
}
