using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour{
    private Rigidbody2D rb;
    private Animator anim;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate(){
        var ve = rb.velocity;
        anim.SetBool("Wait",false);
        if (ve.x < 0){
            anim.SetBool("Forward", true);
            //.Log("x < 0");
        }else if (ve.x > 0){
            anim.SetBool("Forward",true);
            //Debug.Log("x > 0");
        }else if (ve.y < 0){
            anim.SetBool("Down",true);
            //Debug.Log("y < 0");
        }else if (ve.y > 0){
            anim.SetBool("Up",true);
            //Debug.Log("y > 0");
        }
        else{
            anim.SetBool("Forward", false);
            anim.SetBool("Down",false);
            anim.SetBool("Up",false);
            anim.SetBool("Wait",true);
            //Debug.Log("ve == 0");
        }
    }
}
