using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    IEnumerator LoadLevelCoroutine = null;
    [SerializeField]private Animator transition;

    private void Start() {
        if (SceneManager.GetActiveScene().buildIndex==0){
            LoadNextLevel();
        }
    }

    internal void LoadNextLevel(){
    
        if(LoadLevelCoroutine==null){
                LoadLevelCoroutine = LoadLevel(SceneManager.GetActiveScene().buildIndex + 1); 
                StartCoroutine(LoadLevelCoroutine); 
        }
    }

    internal void Restart(){
         SceneManager.LoadScene(0);
    }

    IEnumerator LoadLevel(int levelIndex){
        
        //starting the transition animation
        transition.SetTrigger("Start");

        //waiting for animation to over
        yield return new WaitForSeconds(1);
        LoadLevelCoroutine = null;

        //load the scene
        SceneManager.LoadScene(levelIndex);
    }


}
