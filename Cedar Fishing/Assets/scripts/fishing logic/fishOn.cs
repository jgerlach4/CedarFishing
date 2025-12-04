using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Subsystems;
using System;
using TMPro;

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
    private string fishName;

    public GameObject wateraffect;
    public GameObject wateraffectWin;
    public GameObject WateraffectLose;

    public GameObject catchingText;
    public TMP_Text text;

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
                    fishName = "Anchovy";
                }
                if (number == 2)
                {
                    fish = BarredKnifeJaw;
                    fishImage = BarredKnifeJawImage;
                    fishName = "Barred KnifeJaw";
                }
                if (number == 3)
                {
                    fish = Bitterling;
                    fishImage = BitterlingImage;
                    fishName = "Bitterling";
                }
                if (number == 4)
                {
                    fish = BlackBass;
                    fishImage = BlackBassImage;
                    fishName = "black Bass";
                }
                if (number == 5)
                {
                    fish = BlueGill;
                    fishImage = BlueGillImage;
                    fishName = "Blue Gill";
                }
                if (number == 6)
                {
                    fish = Carp;
                    fishImage = CarpImage;
                    fishName = "Carp";
                }
                if (number == 7)
                {
                    fish = CrucianCarp;
                    fishImage = CrucianCarpImage;
                    fishName = "Crucian Carp";
                }
                if (number == 8)
                {
                    fish = Dace;
                    fishImage = DaceImage;
                    fishName = "Dace";
                }
                if (number == 9)
                {
                    fish = FreshWaterGoby;
                    fishImage = FreshWaterGobyImage;
                    fishName = "Fresh Water Goby";
                }
                if (number == 10)
                {
                    fish = HorseMackeral;
                    fishImage = HorseMackeralImage;
                    fishName = "Horse Mackeral";
                }
                if (number == 11)
                {
                    fish = Koi;
                    fishImage = KoiImage;
                    fishName = "Koi";
                }
                if (number == 12)
                {
                    fish = Loach;
                    fishImage = LoachImage;
                    fishName = "Loach";
                }
                if (number == 13)
                {
                    fish = OarFish;
                    fishImage = OarFishImage;
                    fishName = "Oarfish";
                }
                if (number == 14)
                {
                    fish = OliveFlounder;
                    fishImage = OliveFlounderImage;
                    fishName = "Olive Flounder";
                }
                if (number == 15)
                {
                    fish = PaleChub;
                    fishImage = PaleChubImage;
                    fishName = "Pale Chub";
                }
                if (number == 16)
                {
                    fish = PondSmelt;
                    fishImage = PondSmeltImage;
                    fishName = "Pond Smelt";
                }
                if (number == 17)
                {
                    fish = RedSnapper;
                    fishImage = RedSnapperImage;
                    fishName = "Red Snapper";
                }
                if (number == 18)
                {
                    fish = Salmon;
                    fishImage = SalmonImage;
                    fishName = "Salmon";
                }
                if (number == 19)
                {
                    fish = SeaBass;
                    fishImage = SeaBassImage;
                    fishName = "Sea Bass";
                }
                if (number == 20)
                {
                    fish = YellowPerch;
                    fishImage = YellowPerchImage;
                    fishName = "Yellow Perch";
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

                WateraffectLose.transform.position = bobber.transform.position;

                WateraffectLose.SetActive(false);
                WateraffectLose.SetActive(true);

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

                WateraffectLose.transform.position = bobber.transform.position;

                WateraffectLose.SetActive(false);
                WateraffectLose.SetActive(true);

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
                catchingText.SetActive(true);
                text.text = "You caught a " + fishName + "!";
                Invoke("turnOffText", 2);
                

                fishImage.SetActive(true);

                wateraffect.SetActive(false);

                wateraffectWin.transform.position = bobber.transform.position;

                wateraffectWin.SetActive(false);
                wateraffectWin.SetActive(true);


                fish.SetActive(false);
                line.SetActive(false);
                bobber.SetActive(false);

                move.enabled = true;
                cast.enabled = true;
                fishScript.enabled = false;
            }


        }

    }

    void turnOffText ()
    {
        catchingText.SetActive(false);
    }

}
