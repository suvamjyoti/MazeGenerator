using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    [SerializeField]private MazeRenderer mazeRenderer;
    [SerializeField]private LevelLoader levelLoader; 
   
    private void Start() {

        //move win block to desired position
        Vector3 WinBlockPosition = new Vector3((mazeRenderer.width-1)*mazeRenderer.size,1,(mazeRenderer.height-1)*mazeRenderer.size);
        transform.position = WinBlockPosition;
    }

    private void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag=="Player"){
            //player Won
            levelLoader.LoadNextLevel();   
        }
    }     

}
