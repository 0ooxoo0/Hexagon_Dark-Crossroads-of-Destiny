using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public List<AudioClip> sound = new List<AudioClip>();
    public Animator characterAnim;
    public AudioSource _audio;
    public AudioClip walkClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playWalkClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playWalkClip()
    {
        while (true)
        {
            if(characterAnim.GetFloat("Speed")>0)
            _audio.PlayOneShot(walkClip);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }
    public void SmenaSoundWalk(string audioName)
    {
        int i = 0;
        while(true)
        {
            if (sound[i].name == audioName)
                walkClip = sound[i];
            else
                i++;
            if (i >= sound.Count)
            {
                if (walkClip == null)
                    walkClip = sound[0];
                return;
            }
        }
    }
}
