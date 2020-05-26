using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public AudioClip audioClip;
    public AudioClip audioClip2;
    int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.PlayOneShot(audioClip);
        //audio.PlayOneShot(audioClip2);

        //float lifTime = Mathf.Max(audioClip.length, audioClip2.length);

        //GameObject.Destroy(gameObject, lifTime);

        i++;
        if (i % 2 == 0)
            Managers.Sound.Play("UnityChan/univ0001", Define.Sound.Bgm);
        else
            Managers.Sound.Play("UnityChan/univ0002", Define.Sound.Bgm);
    }
}
