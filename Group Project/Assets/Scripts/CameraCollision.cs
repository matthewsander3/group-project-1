using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minDist = 1.0f;
    public float maxDist = 4.0f;
    public float smooth = 10.0f;
    Vector3 moveDir;
    public Vector3 moveDirAdjusted;
    public float dist;

    private void Awake()
    {
        moveDir = transform.localPosition.normalized;
        dist = transform.localPosition.magnitude;
    }

    private void Update()
    {
        Vector3 desiredCamPos = transform.parent.TransformPoint(moveDir * maxDist);
        RaycastHit hit;

        if(Physics.Linecast(transform.parent.position, desiredCamPos, out hit))
        {
            dist = Mathf.Clamp((hit.distance * 0.9f), minDist, maxDist);
        }
        else
        {
            dist = maxDist;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, moveDir * dist, Time.deltaTime * smooth);
    }
}
