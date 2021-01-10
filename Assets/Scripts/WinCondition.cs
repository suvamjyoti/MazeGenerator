using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    private MazeRenderer mazeRenderer;
   
    private void Start() {

        mazeRenderer = FindObjectOfType<MazeRenderer>();

        //move win block to otherCorner
        Vector3 WinBlockPosition = new Vector3((mazeRenderer.width-1)*mazeRenderer.size,1,(mazeRenderer.height-1)*mazeRenderer.size);
        transform.position = WinBlockPosition;
    }

    private void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag=="Player"){
            //player Won
            Debug.Log("playerWon");   
        }
    }     

}
