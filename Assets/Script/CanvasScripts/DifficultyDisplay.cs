using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyDisplay : MonoBehaviour
{
    [SerializeField] gamePlayManager playManager;
    [SerializeField]SpriteRenderer spriteToLoad;
    public Sprite[] sprites;
    
    int previousDifficulty = 1;
    int difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//reads the current difficulty from the play manager
        difficulty = playManager.DIFFICULTY;
        //clamp (dont want to try to access array out of bounds)
        if (difficulty > sprites.Length)
        {
            difficulty = sprites.Length;
            
        }
        if (difficulty < 1)
        {
            difficulty = 1;
        }
        //if diificult changed, we updatet sprite and update preious difficulty so we can keep track if it hass changed
        //more efficient to compare 2 ints rather than changing sprite to same or different sprite every frame
        if (previousDifficulty != difficulty)
        {
            spriteToLoad.sprite = sprites[difficulty-1];
            previousDifficulty = difficulty;
        }

    }
}
