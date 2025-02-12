using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class LoadingEvent:  MonoBehaviour
{
    public delegate void ChangeTextLoading(float present);
    public static ChangeTextLoading changeTextLoading;
}

