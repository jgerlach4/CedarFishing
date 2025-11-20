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

    public GameObject Anchovy;
    public GameObject BarredKnifeJaw;
    public GameObject Bitterling;
    public GameObject BlackBass;
    public GameObject BlueGill;
    public GameObject Carp;
    public GameObject CrucianCarp;
    public GameObject Dace;
    public GameObject FreshWaterGoby;
    public GameObject HorseMackeral;
    public GameObject Koi;
    public GameObject Loach;
    public GameObject OarFish;
    public GameObject OliveFlounder;
    public GameObject PaleChub;
    public GameObject PondSmelt;
    public GameObject RedSnapper;
    public GameObject Salmon;
    public GameObject SeaBass;
    public GameObject YellowPerch;

    private GameObject fish;

    private int clickCount = 0;
    private int clickThreshold = 5;

    InputAction click;
    InputAction rightClick;

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
        rightClick = InputSystem.actions.FindAction("RightClick");

    }

    // Update is called once per frame
    void Update()
    {

        //Checks if casting is enabled, if so then it off
        //Also wait untill the delay has happened, then then the fish appears
        if (cast.enabled == true && move.enabled == false)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {

                System.Random random = new System.Random();
                int number = random.Next(1, 21);

                if (number == 1)
                {
                    fish = Anchovy;
                }
                if (number == 2)
                {
                    fish = BarredKnifeJaw;
                }
                if (number == 3)
                {
                    fish = Bitterling;
                }
                if (number == 4)
                {
                    fish = BlackBass;
                }
                if (number == 5)
                {
                    fish = BlueGill;
                }
                if (number == 6)
                {
                    fish = Carp;
                }
                if (number == 7)
                {
                    fish = CrucianCarp;
                }
                if (number == 8)
                {
                    fish = Dace;
                }
                if (number == 9)
                {
                    fish = FreshWaterGoby;
                }
                if (number == 10)
                {
                    fish = HorseMackeral;
                }
                if (number == 11)
                {
                    fish = Koi;
                }
                if (number == 12)
                {
                    fish = Loach;
                }
                if (number == 13)
                {
                    fish = OarFish;
                }
                if (number == 14)
                {
                    fish = OliveFlounder;
                }
                if (number == 15)
                {
                    fish = PaleChub;
                }
                if (number == 16)
                {
                    fish = PondSmelt;
                }
                if (number == 17)
                {
                    fish = RedSnapper;
                }
                if (number == 18)
                {
                    fish = Salmon;
                }
                if (number == 19)
                {
                    fish = SeaBass;
                }
                if (number == 20)
                {
                    fish = YellowPerch;
                }

                cast.enabled = false;
                fish.transform.position = bobber.transform.position;

                fish.transform.LookAt(this.transform);

                fish.SetActive(true);
            }

            if (click.triggered)
            {
                Debug.Log("fish got away");

                move.enabled = true;
                fishScript.enabled = false;

                animator.SetBool("isCasting", false);
                bobber.SetActive(false);
                line.SetActive(false);

            }

        }

        //If casting is turned off, then we have entered fish on mode
        //Use left click on the mouse, if you click as many times as the threshold, you catch the fish
        if (cast.enabled == false && move.enabled == false)
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
