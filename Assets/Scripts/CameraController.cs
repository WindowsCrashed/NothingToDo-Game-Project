using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] SpriteRenderer reference;
    [SerializeField] LayoutGroup verticallyAlignedTapArea;
    [SerializeField] LayoutGroup horizontallyAlignedTapArea;

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

            verticallyAlignedTapArea.enabled = false;
            horizontallyAlignedTapArea.enabled = true;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = reference.bounds.size.y / 2 * differenceInSize;
            
            Debug.Log(2);

            verticallyAlignedTapArea.enabled = true;
            horizontallyAlignedTapArea.enabled = false;
        }

        /*
        float orthoSize = reference.bounds.size.x * Screen.height / Screen.width * 0.5f;

        Camera.main.orthographicSize = orthoSize;
        */
    }
}
