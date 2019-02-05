using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAttack : MonoBehaviour {
    Rigidbody2D rb;
    public float moveSpeed = 3.0f;
    public float shootX = 8f;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector3(shootX, 0, 0);
        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }
}
