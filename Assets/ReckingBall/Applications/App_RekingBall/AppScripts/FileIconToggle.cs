using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scriptables.GameEvents;

namespace RekingBall.Panels
{
    [RequireComponent(typeof(Toggle))]
    public class FileIconToggle : MonoBehaviour
    {
        //Reference to the button that is me
        [SerializeField] Text Filename;
        [SerializeField] RawImage FileImage;

        //Hook up the button doing dev time, sure why not.
        [SerializeField] Toggle toggle;

        [SerializeField] IntGameEvent selectFileEvent;

        //Internal values.
        Color highlightColor;

        //local reference to index of file.
        private int indexReference;



        //Will have refernce for image, and also coordinates on the image for icons.
        private void Start()
        {
            toggle.onValueChanged.AddListener((value) =>
            {
                if (value)
                    SelectFile();
            });

        }


        private void SelectFile()
        {
            selectFileEvent.Raise(indexReference);

            Debug.Log("FILE SELECTED! AT: " + IndexReference);
        }

        //Accessors for Panel.
        public string Label
        {
            get { return Filename.text; }
            set { Filename.text = value; }
        }

        public ToggleGroup MyToggleGroup
        {
            get { return toggle.group; }
            set { toggle.group = value; }
        }

        public Color HighlightColor
        {
            get { return highlightColor; }
            set { highlightColor = value; }
        }
        public int IndexReference
        {
            get { return indexReference; }
            set { indexReference = value; }
        }

        public Toggle myToggle => toggle;
        
    }

}
