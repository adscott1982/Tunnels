using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float MouseSensitivity = 1f;

    private Vector3 startPosition;
    private Vector3 lastMousePosition;
    private float pixelsToWorld;

    // Use this for initialization
    void Start ()
    {
        this.startPosition = this.transform.position;

        this.pixelsToWorld = 1 / ((Screen.height / 2.0f) / Camera.main.orthographicSize);
    }
	
	// Update is called once per frame
	void Update ()
    {
        var xMov = this.Speed * Time.deltaTime;
        var yMov = this.GetMouseYDelta();
        var movement = new Vector3(xMov, yMov, 0);
        this.transform.position += movement;
	}

    private float GetMouseYDelta()
    {
        var yDelta = 0f;

        if (Input.GetMouseButtonDown(0))
        {
            this.lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            yDelta = (Input.mousePosition - this.lastMousePosition).y;
            yDelta = yDelta * this.pixelsToWorld * this.MouseSensitivity;
            this.lastMousePosition = Input.mousePosition;
        }

        return yDelta;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "boundary")
        {
            this.transform.position = this.startPosition;
        }
    }
}
