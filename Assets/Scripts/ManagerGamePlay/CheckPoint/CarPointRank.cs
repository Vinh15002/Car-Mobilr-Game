using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class CarPointRank
{
    

    public bool[,] Point;

    private int currentLap = 0;
    private int currentIndex = 0;


    public CarPointRank(int lapCount, int AmountPoint)
    {
        Point = new bool[lapCount,AmountPoint];
        SetNewMatrixBool(lapCount, AmountPoint);
    }


    private void SetNewMatrixBool(int col, int row)
    {
        for(int i = 0; i < col; i++)
        {
            for(int j = 0 ; j < row; j++)
            {
                Point[i,j] = false;
            }
        }
    }

    public void setPassCheckPoint(int index)
    {
        currentIndex = index;
        Point[currentLap,index] = true;
        if(index == Point.GetLength(1))
        {
            currentLap++;
        }
        Debug.LogError("Length: " + Point.GetLength(1));
        
    }

    public int Ranking()
    {
        Debug.LogError(currentLap * Point.GetLength(1) + currentIndex);
        return currentLap*Point.GetLength(1) + currentIndex;
    }





}

