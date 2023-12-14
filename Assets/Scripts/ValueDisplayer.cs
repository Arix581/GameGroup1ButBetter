using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueDisplayer : MonoBehaviour
{
    public Text textBox;
    public bool roundValue = true;

    public FloatObject floatObject;
    public string starter = "Empty: ";
    public string ender = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = starter + (
            roundValue ? Mathf.Round(floatObject.value).ToString() : floatObject.value.ToString()
            ) + ender;
    }
}
