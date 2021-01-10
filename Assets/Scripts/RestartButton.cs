using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{

    private Button button;

    void Start(){

        button = GetComponent<Button>();
        button.onClick.AddListener(restart);
    }

    void restart(){
        //do on click of button
          
    }
}
