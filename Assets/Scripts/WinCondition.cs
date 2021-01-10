using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag=="Player"){
            //player Won
            Debug.Log("playerWon");   
        }
    }     

}
