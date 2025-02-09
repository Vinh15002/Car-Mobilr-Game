using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RankEvent
{
    public delegate void UpdateRank(int pos);
    public static UpdateRank updateRank;
}

