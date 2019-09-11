using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scriptables.Variables;
using Scriptables.GameEvents;
using GameKernal.System;

public class VehiclePanel : WindowScriptBase
{
   
    //Value to input the range of the min max of the indcator on the map.
    [SerializeField]
    Vector2 IndicatorRange;

    //Reference of the indicator image.
    [SerializeField]
    Image Indicator, HeightIndicator;

    [SerializeField]
    Slider Strafe, Forward, Height, Rotation;

    [SerializeField]
    Text strafeText, forwardText, heightText, rotationText;

    [SerializeField]
    Toggle ShowGrid;

    //Create a link to the varaible field. and create a wrapper to access it internally.
    [SerializeField]
    Vector3Variable NormalizedPositionOnMap;
    Vector3 _objectMapPosition
    {
        get { return NormalizedPositionOnMap.Value; }
        set { NormalizedPositionOnMap.SetValue(value); }
    }

    [SerializeField]
    FloatVariable CraneRotation;
    float _objectRotation
    {
        get { return CraneRotation.Value; }
        set { CraneRotation.SetValue(value); }
    }


    [SerializeField]
    Vector3GameEvent MoveObject;

    
    //Going to have to put this here for now.
    //This is becuase we dont want to update the preview tab untill the sliders are fully updated with the given color.
    //This may replace an Selected color or reciving a message on start or something.
    //private bool _loaded = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //Can we actually move the update to a callback? Can this update be called by the crane?? hmm...0
    void Update()
    {
        _updateIndicatorMap();
        
    }

    void _updateIndicatorMap()
    {
        Vector3 MapPos = _objectMapPosition;
        float RotAngle = _objectRotation;

        //Scale the X position by the range.
        MapPos.x *= IndicatorRange.x;

        //Scale the X position by the range.
        MapPos.y *= IndicatorRange.y;

        //Set the Y position by the range and the maps Z position.
        MapPos.z *= IndicatorRange.y;

        //Set the Y position by the range and the maps Z position.
        Indicator.rectTransform.localPosition = new Vector3(MapPos.x,MapPos.z,0.0f);

        //Set the rotaiton of the indicator.
        Indicator.rectTransform.localEulerAngles = new Vector3(0.0f, 0.0f, RotAngle);

        //Set the position of the hight.
        HeightIndicator.rectTransform.localPosition = new Vector3(0.0f, MapPos.y, 0.0f);

        //Update the text readouts.
        strafeText.text = MapPos.x.ToString();
        heightText.text = MapPos.y.ToString();
        forwardText.text = MapPos.z.ToString();
        rotationText.text = RotAngle.ToString();

    }


    private void OnEnable()
    {
        ////Grabbing and setting the values on the slider.
        LoadWidgetValues();

    }
   

    public void VEHICLEPANEL_SLIDERCHANGE()
    {
        //Store postion for the vehicle. This is normalized.
        Vector3 VehiclePosition = new Vector3(Strafe.value, Height.value, Forward.value);

        _objectRotation = Rotation.value;

        //_objectMapPosition = VehiclePosition;
        // The following line does not need to get called.
        //It is being triggered by the move event that needs to convert the normalized position.
        //The conversion can be done on this side,
        //to which we may not need an event.
        MoveObject.Raise(VehiclePosition);
    }


    public void VEHICLEPANEL_TOGGLEGRID()
    {
        //if (_handler.ActiveGame == null)
        //{
        //    Debug.LogError("Trying to access a GameOS Reference that is not there:  " + this.name);
        //    return;
        //}

        //_handler.ActiveGame.Grid = ShowGrid.isOn;

        //Debug.Log("Toggle Grid UI Command: " + ShowGrid.isOn );

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
       

        //Load sliders values on init. 
        LoadWidgetValues();

        //log message.
        Debug.Log("Override Init Function called : " + this.name);

    }

    public override void OnExit()
    {
        base.OnExit();

        //Toggle off grid view when you exit the panel.
        ShowGrid.isOn = false;

    }

    void LoadWidgetValues()
    { 
        //Grabbing the map position.
        Vector3 MapPos = _objectMapPosition;

        //Grabbing and setting the values on the slider.
        Strafe.value = MapPos.x;
        Height.value = MapPos.y;
        Forward.value = MapPos.z;

//        ShowGrid.isOn = _handler.ActiveGame.Grid;

        //This loaded bool is here so the feedbak of the sliders
        //wont affect the actual change of the values the sliders are reading to begin with.
       // _loaded = true;
    }


}
