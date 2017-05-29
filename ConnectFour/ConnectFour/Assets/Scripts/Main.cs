using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public GameObject red;
    public GameObject black;
    public string currTurn = "";

	// Use this for initialization
	void Start () {
        System.Random rand = new System.Random();
        if (rand.Next(0, 2) == 0)
        {
            currTurn = "red";
            //Instantiate(red, red.transform.position, Quaternion.identity);
            createRed();
        }
        else
        {
            currTurn = "black";
            //Instantiate(black, black.transform.position, Quaternion.identity);
            createBlack();
        }

		
	}

    void createRed()
    {
        Instantiate(red, red.transform.position, Quaternion.identity);
    }
	
    void createBlack()
    {
        Instantiate(black, black.transform.position, Quaternion.identity);
    }

	// Update is called once per frame
	void LateUpdate () {


        /*
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currTurn.Equals("red"))
            {
                Instantiate(red, red.transform.position, Quaternion.identity);
                currTurn = "black";
            }
            else if (currTurn.Equals("black"))
            {
                Instantiate(black, black.transform.position, Quaternion.identity);
                currTurn = "red";
            }

        }
        */

        print(currTurn);
		if (currTurn.Equals("red"))
        {
            if (ballScript.fin == true )
            {
                currTurn = "black";
                createBlack();
            }
        }
        else if (currTurn.Equals("black"))
        {

            if (ballScript.fin == true)
            {
                currTurn = "red";
                createRed();
            }
        }

    }
}
