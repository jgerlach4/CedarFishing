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
    public GameObject AnchovyImage;
    public GameObject BarredKnifeJaw;
    public GameObject BarredKnifeJawImage;
    public GameObject Bitterling;
    public GameObject BitterlingImage;
    public GameObject BlackBass;
    public GameObject BlackBassImage;
    public GameObject BlueGill;
    public GameObject BlueGillImage;
    public GameObject Carp;
    public GameObject CarpImage;
    public GameObject CrucianCarp;
    public GameObject CrucianCarpImage;
    public GameObject Dace;
    public GameObject DaceImage;
    public GameObject FreshWaterGoby;
    public GameObject FreshWaterGobyImage;
    public GameObject HorseMackeral;
    public GameObject HorseMackeralImage;
    public GameObject Koi;
    public GameObject KoiImage;
    public GameObject Loach;
    public GameObject LoachImage;
    public GameObject OarFish;
    public GameObject OarFishImage;
    public GameObject OliveFlounder;
    public GameObject OliveFlounderImage;
    public GameObject PaleChub;
    public GameObject PaleChubImage;
    public GameObject PondSmelt;
    public GameObject PondSmeltImage;
    public GameObject RedSnapper;
    public GameObject RedSnapperImage;
    public GameObject Salmon;
    public GameObject SalmonImage;
    public GameObject SeaBass;
    public GameObject SeaBassImage;
    public GameObject YellowPerch;
    public GameObject YellowPerchImage;

    private GameObject fish;
    private GameObject fishImage;

    public GameObject wateraffect;

    private int clickCount = 0;
    private int clickThreshold = 5;

    InputAction click;
    InputAction rightClick;

    //delay
    public float delay = 3;
    float timer;

    //time limit for catching fish
    public float timeLimit = 1;
    float timer2;

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
                    fishImage = AnchovyImage;
                }
                if (number == 2)
                {
                    fish = BarredKnifeJaw;
                    fishImage = BarredKnifeJawImage;
                }
                if (number == 3)
                {
                    fish = Bitterling;
                    fishImage = BitterlingImage;
                }
                if (number == 4)
                {
                    fish = BlackBass;
                    fishImage = BlackBassImage;
                }
                if (number == 5)
                {
                    fish = BlueGill;
                    fishImage = BlueGillImage;
                }
                if (number == 6)
                {
                    fish = Carp;
                    fishImage = CarpImage;
                }
                if (number == 7)
                {
                    fish = CrucianCarp;
                    fishImage= CrucianCarpImage;
                }
                if (number == 8)
                {
                    fish = Dace;
                    fishImage = DaceImage;
                }
                if (number == 9)
                {
                    fish = FreshWaterGoby;
                    fishImage = FreshWaterGobyImage;
                }
                if (number == 10)
                {
                    fish = HorseMackeral;
                    fishImage = HorseMackeralImage;
                }
                if (number == 11)
                {
                    fish = Koi;
                    fishImage = KoiImage;
                }
                if (number == 12)
                {
                    fish = Loach;
                    fishImage = LoachImage;
                }
                if (number == 13)
                {
                    fish = OarFish;
                    fishImage = OarFishImage;
                }
                if (number == 14)
                {
                    fish = OliveFlounder;
                    fishImage = OliveFlounderImage;
                }
                if (number == 15)
                {
                    fish = PaleChub;
                    fishImage = PaleChubImage;
                }
                if (number == 16)
                {
                    fish = PondSmelt;
                    fishImage = PondSmeltImage;
                }
                if (number == 17)
                {
                    fish = RedSnapper;
                    fishImage = RedSnapperImage;
                }
                if (number == 18)
                {
                    fish = Salmon;
                    fishImage = SalmonImage;
                }
                if (number == 19)
                {
                    fish = SeaBass;
                    fishImage = SeaBassImage;
                }
                if (number == 20)
                {
                    fish = YellowPerch;
                    fishImage = YellowPerchImage;
                }

                cast.enabled = false;
                fish.transform.position = bobber.transform.position;

                fish.transform.LookAt(this.transform);

                wateraffect.transform.position = bobber.transform.position;

                fish.SetActive(true);
                wateraffect.SetActive(true);



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

            timer2 += Time.deltaTime;
            if (timer2 > timeLimit)
            {
                animator.SetBool("isCasting", false);

                clickCount = 0;
                timer = 0;
                timer2 = 0;

                Debug.Log("Fish Got away");

                wateraffect.SetActive(false);

                fish.SetActive(false);
                line.SetActive(false);
                bobber.SetActive(false);

                move.enabled = true;
                cast.enabled = true;
                fishScript.enabled = false;
            }

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
                timer2 = 0;

                Debug.Log("Fish Caught");
                fishImage.SetActive(true);

                wateraffect.SetActive(false);


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
