using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace RekingBall.Panels
{

    //Not sure if monobehavior is the best to derrive from
    //Might be able to get away with scriptable object only?
    [RequireComponent(typeof(Button))]
    public class FileIconButton : MonoBehaviour
    {
        //Reference to the button that is me
        [SerializeField] Text Filename;
        [SerializeField] RawImage FileImage;

        //Hook up the button doing dev time, sure why not.
        [SerializeField]
        Button _button;

        //Will have refernce for image, and also coordinates on the image for icons.
        private void Start()
        {

        }



        //Accessors for Panel.
        public string Label
        {
            get { return Filename.text; }
            set { Filename.text = value; }
        }




    }


}
