using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    [SerializeField]gamePlayManager PlayManager;
    //sets up majority of the draw calls. 
  
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        // Create Canvas GameObject.
        GameObject canvasGO = new GameObject();
        canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Get canvas from the GameObject.
        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
     


        // Create the Text GameObject.
        GameObject textGO = new GameObject();
        textGO.transform.position = new Vector3(-7,7,0);
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        // Set Text component properties.
        text = textGO.GetComponent<Text>();
        text.font = arial;
        int newint = PlayManager.scoreManager.getScore();
        string newString = "Score:" + newint.ToString();
        text.text = newString;
        text.fontSize = 48;
        text.alignment = TextAnchor.MiddleLeft;
        text.color = new Color(0f, 0f, 0f);
        // Provide Text position and size using RectTransform.
        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(600, 200);

    }

    // Update is called once per frame
    void Update()
    {
        int newint = PlayManager.scoreManager.getScore();
        text.text = "Score:" + newint.ToString();

    }
}
