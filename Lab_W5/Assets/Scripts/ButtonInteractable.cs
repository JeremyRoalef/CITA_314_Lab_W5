using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonInteractable : XRSimpleInteractable
{
    [SerializeField]
    Color[] buttonColors = new Color[4];

    [SerializeField]
    Image buttonImage;

    Color buttonNormalColor;
    Color buttonHighlightedColor;
    Color buttonPressedColor;
    Color buttonSelectedColor;

    bool isPressed;

    protected override void Awake()
    {
        base.Awake();

        //Set the colors of the different button states
        buttonNormalColor = buttonColors[0];
        buttonHighlightedColor = buttonColors[1];
        buttonPressedColor = buttonColors[2];
        buttonSelectedColor = buttonColors[3];

        //Set image color to normal color
        buttonImage.color = buttonNormalColor;

    }

    //Controller hovered over button
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        isPressed = false;

        buttonImage.color = buttonHighlightedColor;
    }

    //Controller stopped hovering over button
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        if (isPressed) { return; }
        buttonImage.color = buttonNormalColor;
    }

    //Button has been selected
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (isPressed) { return; }
        isPressed = true;
        buttonImage.color = buttonPressedColor;
    }
    
    //Button is no longer selected
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        buttonImage.color = buttonSelectedColor;
    }

    public void SetColorToNormal()
    {
        buttonImage.color = buttonNormalColor;
    }
}
