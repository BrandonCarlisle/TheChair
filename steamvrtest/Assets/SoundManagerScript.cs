using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;




public class SoundManagerScript : MonoBehaviour
{
    public GameObject eventManager;
    public GameObject player;

    private AudioSource audio;

    public List<AudioClip> clips = new List<AudioClip>();


    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();

        var events = eventManager.GetComponent<EventManager>();
        events.playVoiceLine.AddListener(playSound);
        events.playSoundAt.AddListener(PlaySoundAt);
        events.changeBackgroundNoise.AddListener(ChangeMainAudio);
    }


    void playSound(string name, float vol)
    {
        var clip = clips.FirstOrDefault(x => x.name == name);
        if (clip != null)
            audio.PlayOneShot(clip);
    }

    void PlaySoundAt(string name, float vol, Vector3 pos)
    {
        var clip = clips.FirstOrDefault(x => x.name == name);
       
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, pos, 1f);
    }

    void ChangeMainAudio(string name, float vol)
    {
        var clip = clips.FirstOrDefault(x => x.name == name);
        if (clip == null)
            return;

        audio.clip = clip;
        audio.loop = true;
        audio.volume = vol;
        audio.Play();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = player.transform.position;
    }
}
