using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gator : homeBonus
{
    //uses mostly the homebonus updates
    //start tells the update the difference between gator and fly
    void Start()
    {
        thisSprite = this.GetComponent<SpriteRenderer>();
        type = 1;
    }

}
