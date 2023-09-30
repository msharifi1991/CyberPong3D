using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public Starter starter;

    public TextMeshProUGUI ScoreTextLeft;
    public TextMeshProUGUI ScoreTextRight;

    private bool started = false;

    private int scorerLeft = 0;
    private int scorerRight = 0;

    private BallController1 ballController1;

    private Vector3 startingPosition;

       // Start is called before the first frame update
    void Start()
    {
        this.ballController1 = this.ball.GetComponent<BallController1>();
        this.startingPosition = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.started)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            this.started = true;
            this.starter.StartCountDown();
        }
    }


    public void StartGame() {
        this.ballController1.Go();
    }

    public void ScoreGoalLeft() {
        Debug.Log("ScoreGoalLeft");
        this.scorerRight +=  1;
        UpdateUI();
        ResetBall();
    }

   
    public void ScoreGoalRight()
    {
        Debug.Log("ScoreGoalRight");
        this.scorerLeft += 1;
        UpdateUI();
        ResetBall();
    }

    private void UpdateUI()
    {
      this.ScoreTextLeft.text = this.scorerLeft.ToString();
        this.ScoreTextRight.text = this.scorerRight.ToString();
    }

    private void ResetBall()
    {
        this.ballController1.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountDown();
    }
}
