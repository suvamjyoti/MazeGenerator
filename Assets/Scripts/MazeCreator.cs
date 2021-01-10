using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//A Maze is a collection of node.
//connect certain node to create a path.
//place walls at unconnected edges.
//and we get a maze.


public enum StateOfWall{                        // State of each wall of a node.
    Left,Right,Up,Down,        
}


public static class MazeCreator {

    public static StateOfWall[,] Create(int width,int height){

        StateOfWall[,] maze = new StateOfWall[width,height];

        StateOfWall initial = StateOfWall.Left | StateOfWall.Right | StateOfWall.Up | StateOfWall.Down;
    
        for(int i=0;i<width;i++){
            for(int j=0;j<height;j++){
                maze[i,j] = initial;
            }
        }

        return maze;
    }
}
