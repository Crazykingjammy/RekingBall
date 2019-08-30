using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WindowObject : MonoBehaviour
{
    //Grab a hold of the window text.
    [SerializeField]
    Text WindowTitle;


    //Maybe we dont need to store color locally.
    //Perhaps color can all just be assiened via modifier.
    Color WindowColor;

    //local access of the background to handle window color
   // [SerializeField]
    Image WindowFrame;


    //Maybe more info later on that would handle window parameters?


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Simple function to deactivate self.
    //Usually to be used by close buttons within this window.
    public void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }

    //Self handled window function to make calls upon activate.
    public void ActivateWindow()
    {
        this.gameObject.SetActive(true);
    }

    //Function to apply the window color.
    public void ApplyWindowColor(Color color)
    {
        if(WindowFrame == null)
        {
            //we have no window frame accessed to change so we bail out.
            //Post error message.
            return;
        }

        //Change the color of the window frame here.
        WindowFrame.color = color;
    }

    //here we have our inity function, just to we make sure we have things handy.
    public void Init()
    {
        //Grab a hold of the image component as the wndow frame.
        WindowFrame = this.GetComponent<Image>();

        //Grab a any Window Scripts attached and call its init as well.
        WindowScriptBase script = this.GetComponent<WindowScriptBase>();

        //Check if we actaully have a script.
        if(script != null)
        {
            //Call the script virtual init function.
            script.OnInit();

            //Do a log call.
            Debug.Log("Window Script found. Name: " + script.name);
        }
    }
}
