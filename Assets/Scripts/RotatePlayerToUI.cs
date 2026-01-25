using System.Collections;
using UnityEngine;

public class RotatePlayerToUI : MonoBehaviour
{
    public bool matchRotation = true;
    public bool matchPosition = true;

    void Start()
    {
        StartCoroutine(RecenterRoutine());
    }

    private IEnumerator RecenterRoutine()
    {
        yield return new WaitForEndOfFrame();

        Camera player = Camera.main;
        if (player == null ) yield break;

        if (matchRotation)
        {
            float currentHeadY = player.transform.rotation.eulerAngles.y;
            float targetRigY = transform.rotation.eulerAngles.y;
            float rotationDifference = Mathf.DeltaAngle(currentHeadY, targetRigY);
            transform.Rotate(0, rotationDifference, 0);
        }
        if (matchPosition)
        {
            Vector3 headOffset = player.transform.position - transform.position;
            headOffset.y = 0;
            transform.position -= headOffset;
        }
    }
        
}
