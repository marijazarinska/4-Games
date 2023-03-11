using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzleSelect_ : MonoBehaviour
{
    //public GameObject Button;

    //skriptata e za da imame 3 slozuvalki , koga kliknes na edna da se otvore taa
    public GameObject StartPanel;
    public void SetPuzzlesPhoto(Image Photo)
    {
       // GameObject[] Pieces;
        for (int i = 0; i < 36; i++)
        {
            GameObject.Find("Pieces (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = Photo.sprite;
        }
        StartPanel.SetActive(false);
        //Button.SetActive(false);
    }
}
