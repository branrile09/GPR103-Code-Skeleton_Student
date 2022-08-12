using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HSS : MonoBehaviour
{
    public HighScoreList scoreListRef;
    //make text and score refrencing universal
    protected Text text;
    // Start is called before the first frame update
    void Start()
    { 
        text = this.GetComponent<Text>();
    }

}
