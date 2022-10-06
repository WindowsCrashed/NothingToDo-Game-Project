using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] SpriteRenderer reference;

    void Start()
    {
        ScaleWithScreenSize();
    }

    void ScaleWithScreenSize()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float targetRatio = reference.bounds.size.x / reference.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = reference.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = reference.bounds.size.y / 2 * differenceInSize;
        }

        /*
        float orthoSize = reference.bounds.size.x * Screen.height / Screen.width * 0.5f;

        Camera.main.orthographicSize = orthoSize;
        */
    }
}
