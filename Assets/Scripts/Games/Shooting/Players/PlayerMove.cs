using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEditor;
using UnityEngine;

namespace Games.Shooting.Players{
    public class PlayerMove : MonoBehaviour{

        Rigidbody2D rb;
        private Animator anim;
        private PlayerManager pm;
        private float speed => GetSpeed();
        private bool canMove;
        private float x, y;

        float GetSpeed(){
            var child = transform.GetChild(0).gameObject;
            float s = 0;
            if(Input.GetKey(KeyCode.LeftShift)){
                s = 2;
                child.SetActive(true);
            }else
            {
                s = 3.5f;
                child.SetActive(false);
            }
            return s;
        }


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            pm = GetComponent<PlayerManager>();
        }

        private void Move(){
            if (!pm.IsMove){
                StopAnim();
                rb.velocity = Vector2.zero;
                return;
            }

            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(x, y) * speed;

            if (Mathf.Abs(x) > 0){
                anim.SetBool("Forward",true);
                anim.SetBool("Wait",false);
            }else if (y > 0){
                anim.SetBool("Down",true);
                anim.SetBool("Wait",false);
            }else if (y < 0){
                anim.SetBool("Up",true);
                anim.SetBool("Wait",false);
            }
            else{
                StopAnim();
            }

        }

        void StopAnim(){
            anim.SetBool("Forward",false);
            anim.SetBool("Down",false);
            anim.SetBool("Up",false);
            anim.SetBool("Wait",true);
        }
        
        private void Update()
        {
            Move();
        }

//        private void FixedUpdate(){
//            if (canMove){
//                rb.velocity = new Vector2(x,y) * speed;
//            }
//        }
    }
}