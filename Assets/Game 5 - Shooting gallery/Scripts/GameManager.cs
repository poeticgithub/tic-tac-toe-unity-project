using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager gm2 = null;
    public int number;
    public GameObject[] Box = new GameObject[9];
    public string playerTurn;
    public string[] tags = new string[9];
    public int openBoxcount = 9;
    public TextMesh[] boxLetter = new TextMesh[9]; 
    private int optimizer;
    private bool successfulMove = false;
    public bool gameOver = false;
    public GameObject Reset_button;
    public TextMesh winner;
    private bool firstmove = true;
    

    void Awake()
    {
        if (gm2 == null)
        {
            //if not, set instance to this
            gm2 = this;
        }
        //do not destroy when reloading scene
        DontDestroyOnLoad(transform.gameObject);     
    }


    // Use this for initialization
    void Start()
    {
        playerTurn = "X";
        winner = GameObject.Find("Winner").GetComponent<TextMesh>();
        Reset_button = GameObject.Find("Resetbutton");

        Box[0] = GameObject.Find("Box1");
        boxLetter[0] = GameObject.Find("boxLetter1").GetComponent<TextMesh>();

        Box[1] = GameObject.Find("Box2");
        boxLetter[1] = GameObject.Find("boxLetter2").GetComponent<TextMesh>();

        Box[2] = GameObject.Find("Box3");
        boxLetter[2] = GameObject.Find("boxLetter3").GetComponent<TextMesh>();

        Box[3] = GameObject.Find("Box4");
        boxLetter[3] = GameObject.Find("boxLetter4").GetComponent<TextMesh>();

        Box[4] = GameObject.Find("Box5");
        boxLetter[4] = GameObject.Find("boxLetter5").GetComponent<TextMesh>();

        Box[5] = GameObject.Find("Box6");
        boxLetter[5] = GameObject.Find("boxLetter6").GetComponent<TextMesh>();

        Box[6] = GameObject.Find("Box7");
        boxLetter[6] = GameObject.Find("boxLetter7").GetComponent<TextMesh>();

        Box[7] = GameObject.Find("Box8");
        boxLetter[7] = GameObject.Find("boxLetter8").GetComponent<TextMesh>();

        Box[8] = GameObject.Find("Box9");
        boxLetter[8] = GameObject.Find("boxLetter9").GetComponent<TextMesh>();



        for (int i = 0; i < tags.Length; i++)//make all boxes available
        {
            tags[i] = "canchange";
        }

    }


    public void computerMove() //computer places mark on empty box
    {
        if (gameOver == false)
        {
            successfulMove = false;


            System.Random rnd = new System.Random(DateTime.Now.Millisecond);
            number = rnd.Next(0, 9);
            optimizer = checkforoptimalplay(number); //used to make computer check for gamewinning placement
            if (tags[optimizer] == "canchange")
                number = optimizer; 
            if (firstmove == true)
            {
                number = 4;
                firstmove = false;
            }

            if (tags[number] == "canchange")
            {
                boxLetter[number].text = playerTurn;
                successfulMove = true;
                tags[number] = "cannotchange";
                openBoxcount--;
                winconditions();
                whoseTurn();
            }
            else if (tags[number] == "cannotchange" && successfulMove == false && openBoxcount > 0)
            {
                computerMove();
            }

            else
            {
                winner.text = "THE GAME IS A DRAW";
                gameOver = true;
            }
        }
     
    }

    public void winconditions() //victory conditions
    {

        if (boxLetter[0].text == playerTurn && boxLetter[1].text == playerTurn && boxLetter[2].text == playerTurn)
        {
            blockComputerMove();
        }

        if (boxLetter[3].text == playerTurn && boxLetter[4].text == playerTurn && boxLetter[5].text == playerTurn)
        {
            blockComputerMove();
        }

        if (boxLetter[6].text == playerTurn && boxLetter[7].text == playerTurn && boxLetter[8].text == playerTurn)
        {
            blockComputerMove();
        }

        if (boxLetter[0].text == playerTurn && boxLetter[3].text == playerTurn && boxLetter[6].text == playerTurn)
        {
            blockComputerMove();
        }

        if (boxLetter[1].text == playerTurn && boxLetter[4].text == playerTurn && boxLetter[7].text == playerTurn)
        {
            blockComputerMove();
        }

        if (boxLetter[2].text == playerTurn && boxLetter[5].text == playerTurn && boxLetter[8].text == playerTurn)
        {
            blockComputerMove();
        }

        if (boxLetter[0].text == playerTurn && boxLetter[4].text == playerTurn && boxLetter[8].text == playerTurn)
        {
            blockComputerMove();
        }

        if (boxLetter[2].text == playerTurn && boxLetter[4].text == playerTurn && boxLetter[6].text == playerTurn)
        {
            blockComputerMove();
        }
    }

       
     public void whoseTurn() //swaps turn after player or computer has moved
     {
        playerTurn = (playerTurn == "X") ? "O" : "X";
     }

    private void blockComputerMove() //makes all boxes unclickable after victory comdition met
    {

        Debug.Log(playerTurn + "HAS WON THE GAME !!!!!");
        winner.text = playerTurn + "   HAS WON !";
        Update();
        gameOver = true;

    }

    private int checkforoptimalplay(int anumber) //used to help computer make move that would lead to a victory condition
    {
        if (boxLetter[0].text == playerTurn && boxLetter[1].text == playerTurn)
            return 2;
        else if (boxLetter[3].text == playerTurn && boxLetter[4].text == playerTurn)
            return 5;
        else if (boxLetter[6].text == playerTurn && boxLetter[7].text == playerTurn)
            return 8;
        else if (boxLetter[0].text == playerTurn && boxLetter[3].text == playerTurn)
            return 6;
        else if (boxLetter[1].text == playerTurn && boxLetter[4].text == playerTurn)
            return 7;
        else if (boxLetter[2].text == playerTurn && boxLetter[5].text == playerTurn)
            return 8;
        else if (boxLetter[0].text == playerTurn && boxLetter[4].text == playerTurn)
            return 8;
        else if (boxLetter[2].text == playerTurn && boxLetter[4].text == playerTurn)
            return 6;
        else if (boxLetter[0].text == playerTurn && boxLetter[6].text == playerTurn)
            return 3;
        else if (boxLetter[1].text == playerTurn && boxLetter[7].text == playerTurn)
            return 4;
        else if (boxLetter[2].text == playerTurn && boxLetter[8].text == playerTurn)
            return 5;
        else if (boxLetter[0].text == playerTurn && boxLetter[8].text == playerTurn)
            return 4;
        else if (boxLetter[2].text == playerTurn && boxLetter[6].text == playerTurn)
            return 4;
        else if (boxLetter[3].text == playerTurn && boxLetter[6].text == playerTurn)
            return 0;
        else if (boxLetter[4].text == playerTurn && boxLetter[7].text == playerTurn)
            return 1;
        else if (boxLetter[5].text == playerTurn && boxLetter[8].text == playerTurn)
            return 2;
        else if (boxLetter[0].text == playerTurn && boxLetter[2].text == playerTurn)
            return 1;
        else if (boxLetter[1].text == playerTurn && boxLetter[2].text == playerTurn)
            return 0;
        else if (boxLetter[3].text == playerTurn && boxLetter[5].text == playerTurn)
            return 4;
        else if (boxLetter[4].text == playerTurn && boxLetter[5].text == playerTurn)
            return 3;
        else if (boxLetter[6].text == playerTurn && boxLetter[8].text == playerTurn)
            return 7;
        else if (boxLetter[7].text == playerTurn && boxLetter[8].text == playerTurn)
            return 6;
        else if (boxLetter[0].text == playerTurn && boxLetter[4].text == playerTurn)
            return 8;
        else if (boxLetter[4].text == playerTurn && boxLetter[8].text == playerTurn)
            return 0;
        else if (boxLetter[4].text == playerTurn && boxLetter[6].text == playerTurn)
            return 2;
        else if (boxLetter[2].text == playerTurn && boxLetter[4].text == playerTurn)
            return 6;
		else if (boxLetter[0].text == "X" && boxLetter[1].text == "X")
            return 2;
        else if (boxLetter[3].text == "X" && boxLetter[4].text == "X")
            return 5;
        else if (boxLetter[6].text == "X" && boxLetter[7].text == "X")
            return 8;
        else if (boxLetter[0].text == "X" && boxLetter[3].text == "X")
            return 6;
        else if (boxLetter[1].text == "X" && boxLetter[4].text == "X")
            return 7;
        else if (boxLetter[2].text == "X" && boxLetter[5].text == "X")
            return 8;
        else if (boxLetter[0].text == "X" && boxLetter[4].text == "X")
            return 8;
        else if (boxLetter[2].text == "X" && boxLetter[4].text == "X")
            return 6;
        else if (boxLetter[0].text == "X" && boxLetter[6].text == "X")
            return 3;
        else if (boxLetter[1].text == "X" && boxLetter[7].text == "X")
            return 4;
        else if (boxLetter[2].text == "X" && boxLetter[8].text == "X")
            return 5;
        else if (boxLetter[0].text == "X" && boxLetter[8].text == "X")
            return 4;
        else if (boxLetter[2].text == "X" && boxLetter[6].text == "X")
            return 4;
        else if (boxLetter[3].text == "X" && boxLetter[6].text == "X")
            return 0;
        else if (boxLetter[4].text == "X" && boxLetter[7].text == "X")
            return 1;
        else if (boxLetter[5].text == "X" && boxLetter[8].text == "X")
            return 2;
        else if (boxLetter[0].text == "X" && boxLetter[2].text == "X")
            return 1;
        else if (boxLetter[1].text == "X" && boxLetter[2].text == "X")
            return 0;
        else if (boxLetter[3].text == "X" && boxLetter[5].text == "X")
            return 4;
        else if (boxLetter[4].text == "X" && boxLetter[5].text == "X")
            return 3;
        else if (boxLetter[6].text == "X" && boxLetter[8].text == "X")
            return 7;
        else if (boxLetter[7].text == "X" && boxLetter[8].text == "X")
            return 6;
        else if (boxLetter[0].text == "X" && boxLetter[4].text == "X")
            return 8;
        else if (boxLetter[4].text == "X" && boxLetter[8].text == "X")
            return 0;
        else if (boxLetter[4].text == "X" && boxLetter[6].text == "X")
            return 2;
        else if (boxLetter[2].text == "X" && boxLetter[4].text == "X")
            return 6;
        else
            return anumber;

    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }


}

