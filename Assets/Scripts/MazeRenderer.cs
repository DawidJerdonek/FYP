using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    //Used Serialized Fields as I want to see them in inspector but no need for accessing from other scripts
    [SerializeField] 
    private int mazeWidth = 10;
    [SerializeField]
    private int mazeHeight = 10;

    [SerializeField]
    private float size = 1.0f; //Desired size, must be same as X scale of wall prefab

    [SerializeField]
    private Transform wallPrefab;

    [SerializeField]
    private Transform mazePos;

    // Start is called before the first frame update
    void Start()
    {
        //Maze is a 2D array of cells created using the enum flags
        WallsState[,] maze = MazeGenerator.GenerateMaze(mazeWidth,mazeHeight); //Generate maze data before drawing
        Draw(maze); //Draw the maze
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Used for frawing the initial grid 
    private void Draw(WallsState[,] maze)
    {
        for (int x = 0; x < mazeWidth; ++x)
        {
            for (int y = 0; y < mazeHeight; ++y)
            {
                WallsState cell = maze[x,y];
                Vector3 position = new Vector3(-mazeWidth / 2 + x + mazePos.position.x + size / 2, mazePos.position.y + mazePos.localScale.y + size / 2, - mazeHeight / 2 + y + mazePos.position.z + size /2 );
                
                if ((x > 0 && y == 0) || (y > 0 && x == 0) || (x>0 && y > 0)) //Leave out for entrance or exit
                {
                    if((x < mazeWidth - 1 && y == mazeHeight - 1) || (y < mazeHeight - 1 && x == mazeWidth - 1) || (x < mazeWidth - 1 && y < mazeHeight - 1 )) //Leave out for entrance or exit
                    { 
                        if (cell.HasFlag(WallsState.TOP))
                        {
                            Transform topWall = Instantiate(wallPrefab, transform);

                            topWall.position = position + new Vector3(0, 0, size / 2);
                            //topWall.position = position + new Vector3(0, 0, 0);   //Interesting results

                            topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                        }

                        if (cell.HasFlag(WallsState.LEFT))
                        {
                            Transform leftWall = Instantiate(wallPrefab, transform);

                            leftWall.position = position + new Vector3(-size / 2, 0, 0);
                            //leftWall.position = position + new Vector3(0, 0, 0); //Interesting results

                            leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                            leftWall.eulerAngles = new Vector3(0, 90, 0);

                        }

                        //Left and Top will take care of most of the grid, last rows on x and y axis need to be handled by the two below

                        if (x == mazeWidth - 1)
                        {
                            if (cell.HasFlag(WallsState.RIGHT))
                            {
                                Transform rightWall = Instantiate(wallPrefab, transform);

                                rightWall.position = position + new Vector3(size / 2, 0, 0);
                                //rightWall.position = position + new Vector3(0, 0, 0); //Interesting results

                                rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                                rightWall.eulerAngles = new Vector3(0, 90, 0);
                            }
                        }

                        if (y == 0)
                        {
                            if (cell.HasFlag(WallsState.BOTTOM))
                            {
                                Transform bottomWall = Instantiate(wallPrefab, transform);

                                bottomWall.position = position + new Vector3(0, 0, -size / 2);
                                //bottomWall.position = position + new Vector3(0, 0, 0); //Interesting results

                                bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                            }
                        }
                    }
                }
            }
        }
    }
}
