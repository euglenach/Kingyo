using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour {
    private Camera camera;
    public static float notesSpeed = 0.1f;
    private Vector3 screenEnd;

    private void Start()
    {
        camera = Camera.main;
        screenEnd = camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
    }

    void FixedUpdate () {
        transform.position += Vector3.down * notesSpeed;
        if (transform.position.y < screenEnd.y) Destroy(gameObject);
	}
	
}
