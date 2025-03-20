using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 _offset  = new Vector3(18, 0, 0);
    private Quaternion _rotate = Quaternion.Euler(0, -90, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = plane.transform.position + _offset;
        transform.rotation = _rotate;
    }
}
