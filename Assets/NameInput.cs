using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameInput : HSS
{
    // Start is called before the first frame update

    private string nInput = "";

    // Update is called once per frame
    void Update()
    {


        // loops through all 26 chars and checks if they have been pressed
        if (Input.anyKeyDown)
        {
            char newchar = 'a';
            char charBeingAdded = newchar;
            string newKeyCode = "" + newchar;
            //check for backspacing
            if (Input.GetKeyDown(KeyCode.Backspace) && nInput.Length > 0)
            {
                string newString = "";

                for (int j = 0; j < nInput.Length - 1; j++)
                {
                    newString += nInput[j];
                }
                nInput = newString;

            }
            else
            { // check for keyboard input, add to string
                for (int i = 0; i < 26; i++)
                {
                    if (Input.GetKeyDown(newKeyCode) && nInput.Length < 10)
                    {
                        //we add the char to string, then break the loop)
                        charBeingAdded = newchar;
                        nInput += charBeingAdded;
                        break;
                    }
                    newchar++;
                    newKeyCode = "" + newchar;
                }
            }

            // update displayed text
            text.text = nInput;
            //submit to high score list, then display high scores
            if (Input.GetKeyDown(KeyCode.Return))
            {

                scoreListRef.Submit(nInput);

                Scene thisScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(4);
                SceneManager.UnloadScene(thisScene);


            }


        }


    }



}
