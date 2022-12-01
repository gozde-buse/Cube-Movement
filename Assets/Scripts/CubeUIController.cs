using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeUIController : MonoBehaviour
{
    [SerializeField] private GameObject creationPanel;
    [SerializeField] private Dropdown operationDropdown;

    [Header("Axes")]
    [SerializeField] private GameObject axesPanel;
    [SerializeField] private Text axisText;
    [SerializeField] private InputField[] axisFields;

    [Header("Button")]
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] private Text buttonText;
    [SerializeField] private Text errorText;

    public static CubeUIController instance;

    private GameObject cube;
    private UITextObject[] uiTexts;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        UITextObject translateTexts = new UITextObject("Öteleme eksen deðerlerini giriniz: ", "ÖTELE");
        UITextObject rotateTexts = new UITextObject("Döndürme eksen deðerlerini(derece) giriniz: ", "DÖNDÜR");

        uiTexts = new UITextObject[] { translateTexts, rotateTexts };
    }

    public void SetCube(GameObject cube)
    {
        CubeUIController.instance.cube = cube;
    }

    public void SetOperation()
    {
        switch(operationDropdown.value)
        {
            case 0:
                ResetAll();
                break;

            case 1:
            case 2:
                axisText.text = uiTexts[operationDropdown.value - 1].axisText;
                buttonText.text = uiTexts[operationDropdown.value - 1].buttonText;
                axesPanel.SetActive(true);
                buttonPanel.SetActive(true);
                break;
        }
    }

    public void MoveCube()
    {
        if(!cube)
        {
            //errorText.text = "Önce küpü oluþturunuz.";
            creationPanel.SetActive(true);
            ResetAll();
            return;
        }
        else if(errorText.text != "")
        {
            errorText.text = "";
        }

        float[] axes = new float[axisFields.Length];

        for (int i = 0; i < axisFields.Length; i++)
        {
            axes[i] = axisFields[i].text == "" ? 0 : float.Parse(axisFields[i].text.Replace(".", ","));
        }

        Vector3 opVector = new Vector3(axes[0], axes[1], axes[2]);

        switch (operationDropdown.value)
        {
            case 1:
                cube.GetComponent<CubeMovement>().TranslateCube(opVector);
                break;

            case 2:
                cube.GetComponent<CubeMovement>().RotateCube(opVector);
                break;
        }

        ResetValues();
    }

    private void ResetValues()
    {
        for (int i = 0; i < axisFields.Length; i++)
        {
            axisFields[i].text = "";
        }
    }
    private void ResetAll()
    {
        if (operationDropdown.value != 0)
            operationDropdown.value = 0;

        axesPanel.SetActive(false);
        buttonPanel.SetActive(false);
        buttonText.text = "";
        errorText.text = "";

        for (int i = 0; i < axisFields.Length; i++)
        {
            axisFields[i].text = "";
        }
    }
}
