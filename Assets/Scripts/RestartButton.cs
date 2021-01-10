using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{

    private Button button;
    [SerializeField]private LevelLoader levelLoader;

    void Start(){

        button = GetComponent<Button>();
        button.onClick.AddListener(restart);
    }

    void restart(){
          levelLoader.Restart();
    }
}
