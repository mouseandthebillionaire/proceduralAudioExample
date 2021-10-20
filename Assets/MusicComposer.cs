using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicComposer : MonoBehaviour {
    public AudioSource lead;
    public AudioClip[] leadNotes;
    
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(RandomArp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RandomArp() {
        int noteToPlay = Random.Range(0, leadNotes.Length);
        int noteDelay  = (int) Random.Range(1, 8);
        
        lead.PlayOneShot(leadNotes[noteToPlay]);
        
        
        //yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(4/noteDelay);
        StartCoroutine(RandomArp());
    }
}
