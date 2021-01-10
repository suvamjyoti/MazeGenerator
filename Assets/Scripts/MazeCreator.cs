using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//A Maze is a collection of node.
//connect certain node to create a path.
//place walls at unconnected edges.
//and we get a maze.


public enum StateOfWall{                        // State of each wall of a node.
    Left = 1,
    Right = 2,
    Up = 4,
    Down = 8,

    Visited = 128,        
}

public struct Position{

    public int X;
    public int Y;
}

public struct Neighbour{

    public Position Position;
    public StateOfWall SharedWall;
}

//``````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````


public static class MazeCreator {

    public static StateOfWall[,] Create(int width,int height){

        StateOfWall[,] maze = new StateOfWall[width,height];

        StateOfWall initial = StateOfWall.Left | StateOfWall.Right | StateOfWall.Up | StateOfWall.Down;
    
        for(int i=0;i<width;i++){
            for(int j=0;j<height;j++){
                maze[i,j] = initial;
            }
        }

        return ApplyRecursiveBacktracker(maze, width, height);
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````
        private static StateOfWall GetOppositeWall(StateOfWall wall)
        {
        switch (wall){

            case StateOfWall.Right: return StateOfWall.Left;
            case StateOfWall.Left: return StateOfWall.Right;
            case StateOfWall.Up: return StateOfWall.Down;
            case StateOfWall.Down: return StateOfWall.Up;
            default: return StateOfWall.Left;
        }
    }
    
//``````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````
  
     private static StateOfWall[,] ApplyRecursiveBacktracker(StateOfWall[,] maze, int width, int height)
    {
        
        var rng = new System.Random();
        var positionStack = new Stack<Position>();
        var position = new Position { X = rng.Next(0, width), Y = rng.Next(0, height) };

        maze[position.X, position.Y] |= StateOfWall.Visited;  // 1000 1111
        positionStack.Push(position);

        while (positionStack.Count > 0)
        {
            var current = positionStack.Pop();
            var neighbours = GetUnvisitedNeighbours(current, maze, width, height);

            if (neighbours.Count > 0)
            {
                positionStack.Push(current);

                var randIndex = rng.Next(0, neighbours.Count);
                var randomNeighbour = neighbours[randIndex];

                var nPosition = randomNeighbour.Position;
                maze[current.X, current.Y] &= ~randomNeighbour.SharedWall;
                maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNeighbour.SharedWall);
                maze[nPosition.X, nPosition.Y] |= StateOfWall.Visited;

                positionStack.Push(nPosition);
            }
        }

        return maze;
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````

    private static List<Neighbour> GetUnvisitedNeighbours(Position p,StateOfWall[,] maze,int width,int height){
        var list = new List<Neighbour>();

        
        if (p.X > 0) {
            //left wall check
            if (!maze[p.X - 1, p.Y].HasFlag(StateOfWall.Visited)){
                list.Add(new Neighbour{
                    Position = new Position{
                        X = p.X - 1,
                        Y = p.Y
                    },
                    SharedWall = StateOfWall.Left
                });
            }
        }

        
        if (p.Y > 0){
            //bottom wall check
            if (!maze[p.X, p.Y - 1].HasFlag(StateOfWall.Visited)){
                list.Add(new Neighbour{
                    Position = new Position{
                        X = p.X,
                        Y = p.Y - 1
                    },
                    SharedWall = StateOfWall.Down
                });
            }
        } 

        if (p.Y < height - 1){
            //up wall check
            if (!maze[p.X, p.Y + 1].HasFlag(StateOfWall.Visited)){
                list.Add(new Neighbour{
                    Position = new Position{
                        X = p.X,
                        Y = p.Y + 1
                    },
                    SharedWall = StateOfWall.Up
                });
            }
        }

        if (p.X < width - 1){
            //right wall check
            if (!maze[p.X + 1, p.Y].HasFlag(StateOfWall.Visited)){
                list.Add(new Neighbour{
                    Position = new Position{
                        X = p.X + 1,
                        Y = p.Y
                    },
                    SharedWall = StateOfWall.Right
                });
            }
        }

        return list;
    }
}
