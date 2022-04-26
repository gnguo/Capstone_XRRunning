using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayerCollisionCtrl : MonoBehaviour
{
    public PlayerCtrl player;
    private GameScene gameScene;

    private void Awake()
    {
        gameScene = GameObject.Find("GameScene").GetComponent<GameScene>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!player.PlayerDie)
        {
            switch (other.tag)
            {
                case "Obstacle":
                    player.HitObstacle();
                    break;

                case "Coin":
                    player.coinScore++;
                    gameScene.coinT.text = player.coinScore.ToString();
                    gameScene.coinT_die.text = player.coinScore.ToString();
                    break;
            }
        }
        else
            return;
    }
}
