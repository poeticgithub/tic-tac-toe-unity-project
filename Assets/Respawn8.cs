using UnityEngine;
using System.Collections;

public class Respawn8 : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnMouseDown()

    {
        GameObject current = GameManager.gm2.Box[7];

        if (GameManager.gm2.tags[7] == "canchange")
        {
            current.GetComponentInChildren<TextMesh>().text = GameManager.gm2.playerTurn;
            Debug.Log("Player Moved!");
            GameManager.gm2.tags[7] = "cannotchange";
            GameManager.gm2.openBoxcount = GameManager.gm2.openBoxcount - 1;
            GameManager.gm2.winconditions();
            StartCoroutine(timedelay()); //to delay computer's move by 2 seconds
        }
    }

    IEnumerator timedelay()
    {
        yield return new WaitForSeconds(2);
        GameManager.gm2.whoseTurn();
        GameManager.gm2.computerMove();
    }
}
