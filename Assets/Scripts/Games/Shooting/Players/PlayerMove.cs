using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Shooting.Players{
    public class PlayerMove : MonoBehaviour{

        GameObject Player;

        private void Move(){
            Player = GameObject.Find("Player");
            float movex_Min=-8f;
            float movex_Max=8f;
            float movey_Min=-4.5f;
            float movey_Max=-0.5f;

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0.1f, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-0.1f, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, -0.1f, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(0.1f, 0, 0);
            }

            Player.transform.position = (new Vector3(Mathf.Clamp(Player.transform.position.x, movex_Min, movex_Max),
      Mathf.Clamp(Player.transform.position.y, movey_Min, movey_Max), Player.transform.position.z));

        }

        private void Update()
        {
            Move();
        }
    }
}