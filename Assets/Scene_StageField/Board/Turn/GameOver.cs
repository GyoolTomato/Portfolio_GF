using System;
using UnityEngine;

public class GameOver
{
    private Transform m_curtain;
    private Transform m_win;
    private Transform m_lose;

    public GameOver()
    {
    }

    public void StartTurn(GameObject gameOverBanner)
    {
        m_curtain = gameOverBanner.transform.Find("Curtain");
        m_win = gameOverBanner.transform.Find("Win");
        m_lose = gameOverBanner.transform.Find("Lose");
    }


}
