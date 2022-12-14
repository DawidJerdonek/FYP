using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Using flags to allow each cell to have up to 5 enums dictating what walls are present and if it was visited
[Flags]
public enum WallsState
{
    //Bit mask, Powers of 2
    LEFT = 1,   //0001
    RIGHT = 2,  //0010
    TOP = 4,    //0100
    BOTTOM = 8, //1000
    VISITED = 128    //1000 0000
}

public struct Position
{
    public int X; //width
    public int Y; //height
}

public struct Neighbour
{
    public Position Position;
    public WallsState SharedWall;
}

public class MazeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static WallsState GetOppositeWall(WallsState wall)
    {
        switch(wall)
        {
            case WallsState.RIGHT:
                return WallsState.LEFT;
            case WallsState.LEFT:
                return WallsState.RIGHT;
            case WallsState.TOP:
                return WallsState.BOTTOM;
            case WallsState.BOTTOM:
                return WallsState.TOP;
            default:
                return WallsState.BOTTOM;
        }
    }

    private static WallsState[,] RecursivePathfinding(WallsState[,] maze, int mazeWidth,int mazeHeight)
    {
        System.Random randomNum = new System.Random((int)System.DateTime.Now.Ticks); //Use date and time for seed so maze is always random

        Stack<Position> positionStack = new Stack<Position>();
        Position position = new Position { X = randomNum.Next(0, mazeWidth), Y = randomNum.Next(0, mazeHeight) };

        maze[position.X, position.Y] |= WallsState.VISITED; //1000 1111
        positionStack.Push(position);

        while(positionStack.Count > 0)
        {
            Position current = positionStack.Pop();
            List<Neighbour> neighbours = GetUnvisitedNeighbours(current, maze, mazeWidth, mazeHeight);

            if(neighbours.Count > 0)
            {
                positionStack.Push(current);

                int randIndex = randomNum.Next(0, neighbours.Count);
                Neighbour randomNeighbour = neighbours[randIndex];

                Position nPosition = randomNeighbour.Position;
                maze[current.X, current.Y] &= ~randomNeighbour.SharedWall;
                maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNeighbour.SharedWall);

                maze[nPosition.X, nPosition.Y] |= WallsState.VISITED;

                positionStack.Push(nPosition);
            }
        }


        return maze;
    }

    private static List<Neighbour> GetUnvisitedNeighbours(Position p, WallsState[,] maze, int mazeWidth, int mazeHeight)
    {
        List<Neighbour> list = new List<Neighbour>();

        if(p.X > 0) // Left
        {
            if (!maze[p.X - 1, p.Y].HasFlag(WallsState.VISITED)) //Check if cells were not visited
            {
                list.Add(new Neighbour { Position = new Position { X = p.X - 1, Y = p.Y }, SharedWall = WallsState.LEFT });//Add the left neighbour to list
            }
        }

        if (p.X < mazeWidth - 1) // Right
        {
            if (!maze[p.X  + 1, p.Y].HasFlag(WallsState.VISITED)) //Check if cells were not visited
            {
                list.Add(new Neighbour { Position = new Position { X = p.X + 1, Y = p.Y }, SharedWall = WallsState.RIGHT });//Add the right neighbour to list
            }
        }

        if (p.Y > 0) // Bottom
        {
            if (!maze[p.X, p.Y - 1].HasFlag(WallsState.VISITED)) //Check if cells were not visited
            {
                list.Add(new Neighbour { Position = new Position { X = p.X , Y = p.Y - 1 }, SharedWall = WallsState.BOTTOM });//Add the bottom neighbour to list
            }
        }

        if (p.Y < mazeHeight - 1) // Top
        {
            if (!maze[p.X, p.Y + 1].HasFlag(WallsState.VISITED)) //Check if cells were not visited
            {
                list.Add(new Neighbour { Position = new Position { X = p.X, Y = p.Y + 1 }, SharedWall = WallsState.TOP}); //Add the top neighbour to list
            }
        }
        return list;
    }

    public static WallsState[,] GenerateMaze(int mazeWidth, int mazeHeight)
    {
        WallsState[,] maze = new WallsState[mazeWidth, mazeHeight];
        WallsState premade = WallsState.RIGHT | WallsState.LEFT | WallsState.TOP | WallsState.BOTTOM; 

        for (int x = 0; x < mazeWidth; ++x)
        {
            for (int y = 0; y < mazeHeight; ++y)
            {
                maze[x, y] = premade; //Set up initial maze grid with all walls present
            }
        }


        return RecursivePathfinding(maze,mazeWidth,mazeHeight); //Used Pathfinding to remove walls
    }
}
