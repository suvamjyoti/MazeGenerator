using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{

    [SerializeField][Range(1,30)]internal int height=10;
    [SerializeField][Range(1,30)]internal int width=10;

    [SerializeField]private Transform wallPrefab = null;

    [SerializeField]private Transform WinBlockPrefab = null;


    [SerializeField]internal float size = 1.0f;                 

//``````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````
    void Start()
    {
        //creation of maze matrix at start
        var maze = MazeCreator.Create(height,width);
        Draw(maze);
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````

    void Draw(StateOfWall[,] maze){

        //actual drawing of maze using wall prefab and the matrix data created
        
        for (int i = 0; i < width; ++i){
            for (int j = 0; j < height; ++j){

                var cell = maze[i, j];
                Vector3 position = new Vector3( i*size, 0,j*size);

                if (cell.HasFlag(StateOfWall.Up))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(StateOfWall.Left))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(StateOfWall.Right))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(StateOfWall.Down))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }

        }

    }

}
