using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Shooting.Players{
    public class PlayerMove : MonoBehaviour{

        Rigidbody2D rb;
        private Animator anim;
        private PlayerManager pm;
        public float moveSpeed = 3.0f;
        public float moveX = 8f;
        public float moveY = 8f;

        /*float movex_Min = -8f;
        float movex_Max = 8f;
        float movey_Min = -4.5f;
        float movey_Max = -0.5f;*/


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
            
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity=new Vector3(0, moveY, 0);
                anim.SetBool("Down",true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                rb.velocity = Vector3.zero;
                anim.SetBool("Down",false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector3(-moveX, 0, 0);
                anim.SetBool("Forward",true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                rb.velocity = Vector3.zero;
                anim.SetBool("Forward",false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector3(0, -moveY, 0);
                anim.SetBool("Up",true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                rb.velocity = Vector3.zero;
                anim.SetBool("Up",false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(moveX,0, 0);
                anim.SetBool("Forward",true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = Vector3.zero;
                anim.SetBool("Forward",false);
            }

            /*Player.transform.position = (new Vector3(Mathf.Clamp(Player.transform.position.x, movex_Min, movex_Max),
      Mathf.Clamp(Player.transform.position.y, movey_Min, movey_Max), Player.transform.position.z));*/

        }

        private void Update()
        {
            Move();
        }


    }
}