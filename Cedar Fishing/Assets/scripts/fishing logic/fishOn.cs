using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Subsystems;
using System;

public class fishOn : MonoBehaviour
{

    private MonoBehaviour cast;
    private MonoBehaviour move;
    private MonoBehaviour fishScript;

    public GameObject line;
    public GameObject bobber;

    //public Camera mainCamera;
    //public Camera catchCamera;

    Animator animator;

    public GameObject testFish;
    public GameObject testFish2;

    private GameObject fish;

    private int clickCount = 0;
    private int clickThreshold = 5;

    InputAction click;

    //delay
    public float delay = 3;
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cast = GetComponent<Cast>();
        move = GetComponent<Example>();
        fishScript = GetComponent<fishOn>();

        animator = GetComponent<Animator>();    

        click = InputSystem.actions.FindAction("Attack");

    }

    // Update is called once per frame
    void Update()
    {

        //Checks if casting is enabled, if so tuen it off
        //Also wait untill the delay has happened, then then the fish appears
        if (cast.enabled == true)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {

                System.Random random = new System.Random();
                int number = random.Next(1, 3);

                if (number == 1)
                {
                    fish = testFish;
                }
                if (number == 2)
                {
                    fish = testFish2;
                }

                cast.enabled = false;
                fish.transform.position = bobber.transform.position;

                fish.transform.LookAt(this.transform);

                fish.SetActive(true);
            }
        }

        //If casting is turned off, then we have entered fish on mode
        //Use left click on the mouse, if you click as many times as the threshold, you catch the fish
        if (cast.enabled == false)
        {
            fish.transform.position = bobber.transform.position;
            if (click.triggered)
            {
                clickCount++;
            }
            if (clickCount == clickThreshold)
            {
                animator.SetBool("isCasting", false);

                clickCount = 0;
                timer = 0;

                Debug.Log("Fish Caught");

                fish.SetActive(false);
                line.SetActive(false);
                bobber.SetActive(false);

                move.enabled = true;
                cast.enabled = true;
                fishScript.enabled = false;


            }

        }

    }
}
