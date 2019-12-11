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
        events.playVoiceLine.AddListener(playVoiceLine);
        events.playSoundAt.AddListener(PlaySoundAt);
    }


    void playVoiceLine(string name)
    {
        var clip = clips.FirstOrDefault(x => x.name == name);
        if (clip != null)
            audio.PlayOneShot(clip);
    }

    void PlaySoundAt(string name, Vector3 pos)
    {
        var clip = clips.FirstOrDefault(x => x.name == name);
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, pos);
    }


    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = player.transform.position;
    }
}
