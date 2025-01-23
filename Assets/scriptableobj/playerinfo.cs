using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName ="playerinfo",menuName ="info/playerinfo")]
public class playerinfo : ScriptableObject
{
    //player o2 level
    public float oxlevel;

    //notify when to stop moving the levels
    public bool stop;
    //signif
    public int stars;
    public float deplespeed;
    
}
