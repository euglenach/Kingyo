using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour {
    private Camera camera;
    public static float notesSpeed = 0.2f;
    private Vector3 screenEnd;
    [SerializeField]
    private GameObject hitCoin;

    private void Start()
    {
        camera = Camera.main;
        screenEnd = camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
    }

    void FixedUpdate () {
        transform.position += Vector3.down * notesSpeed;
        if (transform.position.y < screenEnd.y - 5) Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(hitCoin, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
