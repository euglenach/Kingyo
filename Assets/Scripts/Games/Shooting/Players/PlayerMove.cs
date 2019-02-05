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

        float GetSpeed(){
            return Input.GetKey(KeyCode.LeftShift) ? 5 : 10;
        }


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            pm = GetComponent<PlayerManager>();
        }

        private void Move(){
            if (!pm.IsMove){
                return;
            }

            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(x,y);

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
                anim.SetBool("Forward",false);
                anim.SetBool("Down",false);
                anim.SetBool("Up",false);
                anim.SetBool("Wait",true);
            }

        }

        private void Update()
        {
            Move();
        }


    }
}