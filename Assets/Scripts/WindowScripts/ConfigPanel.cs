using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigPanel : WindowScriptBase
{
    //Grab our image for the color in the config.
    [SerializeField]
    Image colorPreview;

    [SerializeField]
    Slider[] ColorSliders;

    //we will just pass in the system ahndler for now. Should be a static global.
    [SerializeField]
    SystemsHandler _handler;

    //Our reference for the color of the system.
    private Color _systemColor, _selectedColor;

    //Going to have to put this here for now.
    //This is becuase we dont want to update the preview tab untill the sliders are fully updated with the given color.
    //This may replace an Selected color or reciving a message on start or something.
    private bool _loaded = false;



    // Start is called before the first frame update
    void Awake()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateColorPreview()
    {
        //Update the color preveiw here.
        colorPreview.color = _selectedColor;
    }

    public void LoadSliders()
    {
        //Update the color preveiw here.
        colorPreview.color = _selectedColor;

        ColorSliders[0].value = colorPreview.color.r ;
        ColorSliders[1].value = colorPreview.color.g ;
        ColorSliders[2].value = colorPreview.color.b ;
        ColorSliders[3].value = colorPreview.color.a ;

        //Set the loaded flag to true here.
        _loaded = true;
 
    }

    public void SliderChange(int channel)
    {
        if (!_loaded)
            return;

        _selectedColor = new Color(
            ColorSliders[0].value,
            ColorSliders[1].value,
            ColorSliders[2].value,
            ColorSliders[3].value
            );

        UpdateColorPreview();
    }
    
    //A config script function that goes to the handle and applies the color that is selected.
    public void ApplySystemColor()
    {
        _handler.ApplySystemColor(colorPreview.color);
    }



    ///Overrides!
    ///Here we override form the base class
    ///Will have to learn Interface, if that would work better than virutal.
    ///Not entirely sure at this point.
    ///TODO: REVISE
    ///
    public override void OnInit()
    {
        base.OnInit();

        //Grab the system color to keep for reference.
        _systemColor =  _handler.SystemWindowColor;
        _selectedColor = _handler.SystemWindowColor;

        //Load sliders values on init. 
        LoadSliders();

        //log message.
        Debug.Log("Override Init Function called : " + this.name);

    }
}
