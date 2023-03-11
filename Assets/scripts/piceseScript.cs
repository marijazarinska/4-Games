using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class piceseScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(x:Random.Range(5f,12f) , y: Random.Range(5f, -5) );  //od deka do deka da ni e slozuvalkata od desno ama delce po delce
    }

    
    void Update()
    {
        if (Vector3.Distance(a: transform.position, b: RightPosition) < 0.5f)
        {  //da se mestat delcinjata od puzzle na tocni mesta (ne mozeme da gi pomesteme po stavanjeto na tocno mesto)
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
    }
}
