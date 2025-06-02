using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;


public class BowlingBall : MonoBehaviour
{
    

    //Game Positons/Rotations
    private List<Vector3> pinPositions;
    private List<Quaternion> pinRotations;
    private Vector3 ballPosition;

    //Game Objects
    GameObject[] pins;
    public GameObject ball;
    public GameObject menu;

    // Everything else
    public TextMeshProUGUI scoreUI;
   
    Rigidbody rb;
    int score = 0;
    int turnCounter = 0;
    public HighScore highScore;
    public float force;
    public static bool GameIsPaused = false;



    void Start()
    {
        //ball = GameObject.;
        pins = GameObject.FindGameObjectsWithTag("Pin");
        rb = ball.GetComponent<Rigidbody>();
        

        pinPositions = new List<Vector3>();
        pinRotations = new List<Quaternion>();
        foreach (var pin in pins)
        {
            pinPositions.Add(pin.transform.position);
            pinRotations.Add(pin.transform.rotation);
        }

        ballPosition = GameObject.FindGameObjectWithTag("Ball").transform.position;
    }

    void Update()
    {

        MoveBall();
        if (ball.transform.position.y < -20)
        {
            CountPinsDown();
            turnCounter++;
            ResetPins();
            ResetBall();

            if(turnCounter == 10)
            {
                menu.SetActive(true);
                Time.timeScale = 0f;
                GameIsPaused = true;
            }
        }
    }


    void MoveBall()
    {

        if(Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 0, force));
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
        }
           
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
        }
            
      
    }
   

    private void CountPinsDown()
    {
        
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                 score++;
                pins[i].SetActive(false);
            }
        }

        scoreUI.text = score.ToString();

        if(score > highScore.highScore)
        {
            highScore.highScore = score;
        }
    }

    private void ResetPins()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(true);
            var pinPhysics = pins[i].GetComponent<Rigidbody>();
            pinPhysics.linearVelocity = Vector3.zero;
            pinPhysics.position = pinPositions[i];
            pinPhysics.rotation = pinRotations[i];
            pinPhysics.linearVelocity = Vector3.zero;
            pinPhysics.angularVelocity = Vector3.zero;

        }
    }

    private void ResetBall()
    {
        var ball = GameObject.FindGameObjectWithTag("Ball");
        ball.transform.position = ballPosition;
        ball.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;
    }
}
