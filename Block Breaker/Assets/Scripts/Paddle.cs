using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float minx = 1f;
    [SerializeField] float maxx = 15f;
    [SerializeField] float screenwidthinUnits = 16f;

    private GameSession gameSession;
    private Ball ball;

	// Use this for initialization
	void Start () {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePos = new Vector2(Mathf.Clamp(GetXPos(), minx, maxx), transform.position.y);       
        transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenwidthinUnits;
        }
    }
}
