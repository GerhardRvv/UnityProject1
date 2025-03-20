using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 25f;
    private float _turnSpeed = 30f;
    private float _horizontalInput;
    private float _forwardInput;

    public string inputID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get Player input
        _horizontalInput = Input.GetAxis("Horizontal" + inputID);
        _forwardInput = Input.GetAxis("Vertical" + inputID);
        
        // Move the vehicle forward
        transform.Translate(Vector3.forward * (Time.deltaTime * _moveSpeed * _forwardInput));
        transform.Rotate(Vector3.up * (Time.deltaTime * _turnSpeed * _horizontalInput));
    }
}
