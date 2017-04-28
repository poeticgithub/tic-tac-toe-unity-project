using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class reset_script : MonoBehaviour {


    void OnMouseDown()

    {

        for (int i = 0; i < GameManager.gm2.tags.Length; i++)//make all boxes available
        {
            GameManager.gm2.boxLetter[i].text = " ";
            GameManager.gm2.openBoxcount = 9;
            GameManager.gm2.playerTurn = "X";
            GameManager.gm2.winner.text = " ";
            GameManager.gm2.gameOver = false;
            GameManager.gm2.tags[i] = "canchange";
            GameManager.gm2.firstmove = true;
        }

    }

	
	// Update is called once per frame
	void Update () {

	
	}
}
