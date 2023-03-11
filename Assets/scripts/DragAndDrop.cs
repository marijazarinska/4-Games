using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    public GameObject SelectedPiece;
    int OIL = 1;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(origin: Camera.main.ScreenToWorldPoint(Input.mousePosition), direction: Vector2.zero);
            if( hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<piceseScript>().InRightPosition)
                { 
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<piceseScript>().Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL; //za da ni bide delceto od slozuvalkata so go izbereme napred pred drugite 
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))   //koga kliknes na delce od slozuvalkata da mozes da go premestes 
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<piceseScript>().Selected = false;
                SelectedPiece = null;
            }
        }

        if(SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
    }
}
