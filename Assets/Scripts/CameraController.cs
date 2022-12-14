using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject target;
    private Vector3 positionOffset;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        positionOffset = new Vector3(0, 8, -10);
        gameObject.transform.rotation = Quaternion.Euler(35, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = target.transform.position + positionOffset;
    }
}
