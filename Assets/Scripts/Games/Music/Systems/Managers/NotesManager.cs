using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Music.Systems.Managers {

    public class NotesManager : MonoBehaviour {
        [SerializeField]
        private GameObject notes;
        [SerializeField]
        private float lineYPos;
        [SerializeField]
        private int totalNotes;

        private float delta;
        private int notesCount;
        private bool finished = false;
        

        private void FixedUpdate()
        {
            delta += Time.deltaTime;

            if (!finished
                &&delta > NotesDate.NotesStatuses[notesCount].Time - (lineYPos / (Notes.notesSpeed / 0.02)) 
                && notesCount < totalNotes){

                Instantiate(notes, new Vector3(0 + 2 * NotesDate.NotesStatuses[notesCount].Lane, 0, 0), Quaternion.identity);
                notesCount++;
                if (notesCount == totalNotes) finished = true;
            }

            for (int i = 0; i < totalNotes; i++)
            {
                if (delta - 0.2 < NotesDate.NotesStatuses[i].Time && NotesDate.NotesStatuses[i].Time < delta + 0.2)
                {
                    switch (NotesDate.NotesStatuses[i].Lane)
                    {
                        case 0:
                            if (Input.GetKeyDown(KeyCode.D)) Debug.Log("hit");
                            break;
                        case 1:
                            if (Input.GetKeyDown(KeyCode.F)) Debug.Log("hit");
                            break;
                        case 2:
                            if (Input.GetKeyDown(KeyCode.J)) Debug.Log("hit");
                            break;
                        case 3:
                            if (Input.GetKeyDown(KeyCode.K)) Debug.Log("hit");
                            break;
                            //コインゲット
                    }
                }
            }
        }
    }


}

