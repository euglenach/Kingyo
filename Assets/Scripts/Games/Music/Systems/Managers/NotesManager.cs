using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Music.Systems.Managers {

    public class NotesManager : MonoBehaviour {
        [SerializeField]
        private GameObject notes;
        [SerializeField]
        private float lineYPos;

        private float delta;
        

        private void FixedUpdate()
        {
            delta += Time.deltaTime;
            for (int i = 0; i > 100/*総ノーツ数*/; i++) {
                if (delta == NotesDate.NotesStatuses[i].Time - (lineYPos / Notes.notesSpeed)){
                    Instantiate(notes, new Vector3(0 + 2 * NotesDate.NotesStatuses[i].Lane, 0, 0), Quaternion.identity);
                }

                if (delta - 1 < NotesDate.NotesStatuses[i].Time && NotesDate.NotesStatuses[i].Time < delta + 1){
                    switch (NotesDate.NotesStatuses[i].Lane)
                    {
                        case 0:
                            if (Input.GetKeyDown(KeyCode.D)) ;
                            break;
                        case 1:
                            if (Input.GetKeyDown(KeyCode.F)) ;
                            break;
                        case 2:
                            if (Input.GetKeyDown(KeyCode.J)) ;
                            break;
                        case 3:
                            if (Input.GetKeyDown(KeyCode.K)) ;
                            break;
                            //コインゲット
                    }
                }
            }
        }
    }
}
