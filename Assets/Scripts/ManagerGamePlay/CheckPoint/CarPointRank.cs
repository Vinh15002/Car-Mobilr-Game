using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class CarPointRank
{
    

    public float[,] Point;

    private int currentLap = 0;

   


    public CarPointRank(int lapCount, int AmountPoint)
    {
        Point = new float[lapCount,AmountPoint];
        SetNewMatrixBool(lapCount, AmountPoint);
    }


    private void SetNewMatrixBool(int col, int row)
    {
        for(int i = 0; i < col; i++)
        {
            for(int j = 0 ; j < row; j++)
            {
                Point[i,j] = 0;
            }
        }
    }

    public void setPassCheckPoint(int index)
    {
       
        Point[currentLap,index] = TimeGamePlay.Instance.TimeGame;
        if(index == Point.GetLength(1)-1)
        {
            currentLap++;
        }
        
        
    }

    public int Ranking()
    {
        int result = 0;
        for (int i = 0; i < Point.GetLength(0); i++)
        {
            for (int j = 0; j < Point.GetLength(1); j++)
            {
                if (Point[i, j] > 0) result++;
            }
        }
        return result;
    }


    public int CompareRanking(CarPointRank carOpponent)
    {
        if(carOpponent.Ranking() == this.Ranking())
        {
            float Timerank1 = carOpponent.GetValueRank();
            float Timerank2 = this.GetValueRank();
            return (Timerank1 > Timerank2) ? 1 : -1;

            
        }
        else if (carOpponent.Ranking() < this.Ranking())
        {
            return 1;
        }
        else
        {
            return -1;
        }
     
    }


    private float GetValueRank()
    {
        if(Ranking() == 0) return 0;
        int position = Ranking() - 1;
        int i = position/Point.GetLength(1);
        int j = position%Point.GetLength(1);
       
        return Point[i,j];

    }





}

