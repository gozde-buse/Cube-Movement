using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float animationTime = 2f;
    public Vector3 newPos = Vector3.zero;
    public Vector3 rotation = new Vector3(0, 180, 0);

    void Start()
    {
        //TranslateCube(newPos);
        RotateCube(rotation);
    }

    public void TranslateCube(Vector3 targetDir)
    {
        StartCoroutine(TranslateCubeCoroutine(targetDir));
    }

    public void RotateCube(Vector3 rotAngles)
    {
        StartCoroutine(RotateCubeCoroutine(rotAngles));
    }

    IEnumerator TranslateCubeCoroutine(Vector3 targetDir)
    {
        float timeElapsed = 0;
        Vector3 initialPos = transform.position;
        Vector3 targetPos = initialPos + targetDir;

        while (timeElapsed < animationTime)
        {
            transform.position = Vector3.Lerp(initialPos, targetPos, timeElapsed / animationTime);
            timeElapsed += Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        transform.position = targetPos;
    }

    IEnumerator RotateCubeCoroutine(Vector3 rotAngles)
    {
        float timeElapsed = 0;
        Vector3 initialRot = transform.eulerAngles;
        Vector3 targetRot = initialRot + rotAngles;

        while (timeElapsed < animationTime)
        {
            transform.eulerAngles = Vector3.Lerp(initialRot, targetRot, timeElapsed / animationTime);
            timeElapsed += Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        transform.eulerAngles = targetRot;
    }
}
