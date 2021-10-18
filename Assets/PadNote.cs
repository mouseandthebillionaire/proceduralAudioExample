using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PadNote : MonoBehaviour {
    private float initNote;
    private AudioSource padNote;

    // Start is called before the first frame update
    void Start() {
        padNote = GetComponent<AudioSource>();
        initNote = Random.Range(0f, 1f);
        padNote.volume = initNote;
        NoteSetup();

    }

    private void NoteSetup() {
        bool increase;
        float directionChance;
        int timeToNote;
        
        directionChance = Random.Range(0, 100);
        if (directionChance > 50) {
            increase = true;
        }
        else {
            increase = false;
        }

        timeToNote = (int)Random.Range(2, 10);
        StartCoroutine(NoteChange(initNote, timeToNote, increase));
    }

    private IEnumerator NoteChange(float currNote, int timeToNote, bool increase) {
        int waitTime = Random.Range(3, 10);
        
        if (increase) {
            Debug.Log("increasing");
            while(currNote < 1) {
                Debug.Log("hitting");
                currNote += .01f;
                padNote.volume = currNote;
                yield return new WaitForSeconds(timeToNote/100f);
            }
        }
        
        if(!increase){
            while (currNote > 0) {
                currNote -=  .01f;
                padNote.volume = currNote;
                yield return new WaitForSeconds(timeToNote / 100f);
            }
        }

        yield return new WaitForSeconds(waitTime);
        NoteSetup();
        yield return null;
    }
    
    

}
