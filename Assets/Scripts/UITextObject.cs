using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextObject
{
    public string axisText { get; private set; }
    public string buttonText { get; private set; }

    public UITextObject(string axisText, string buttonText)
    {
        this.axisText = axisText;
        this.buttonText = buttonText;
    }
}
