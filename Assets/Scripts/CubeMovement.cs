using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float animationTime = 2f;
    public Vector3 newPos = Vector3.zero;

    void Start()
    {
        TranslateCube(newPos);
    }

    private void Update()
    {
    }

    public void TranslateCube(Vector3 targetPos)
    {
        StartCoroutine(TranslateCubeProcess(targetPos));
    }

    public void RotateCube()
    {

    }

    IEnumerator TranslateCubeProcess(Vector3 targetPos)
    {
        float timeElapsed = 0;
        Vector3 initialPos = transform.position;

        while(timeElapsed < animationTime)
        {
            transform.position = Vector3.Lerp(initialPos, targetPos, timeElapsed / animationTime);
            timeElapsed += Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        transform.position = targetPos;
    }
}
