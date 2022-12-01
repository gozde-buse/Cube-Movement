using UnityEngine;
using UnityEngine.UI;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;

    [Header("UI")]
    [SerializeField] private GameObject creationPanel;
    [SerializeField] private InputField[] axisFields;
    [SerializeField] private Text errorText;

    public void CreateCube()
    {
        float[] axes = new float[axisFields.Length];

        for(int i = 0; i < axisFields.Length; i++)
        {
            axes[i] = axisFields[i].text == "" ? 0 : float.Parse(axisFields[i].text.Replace(".", ","));
        }

        Vector3 cubePos = new Vector3(axes[0], axes[1], axes[2]);
        GameObject cube = Instantiate(cubePrefab, cubePos, cubePrefab.transform.rotation);
        CubeUIController.instance.SetCube(cube);

        creationPanel.SetActive(false);
    }
}
