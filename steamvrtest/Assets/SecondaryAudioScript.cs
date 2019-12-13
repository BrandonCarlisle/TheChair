using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SecondaryAudioScript : MonoBehaviour
{
    public GameObject eventManager;
    private EventManager events;

    private AudioSource audio;

    public List<AudioClip> clips = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();

        events = eventManager.GetComponent<EventManager>();
        events.changeSecondaryNoise.AddListener(ChangeAudio);
    }

    void ChangeAudio(string name, float vol)
    {
        if (name == "")
            audio.Stop();

        var clip = clips.FirstOrDefault(x => x.name == name);
        if (clip == null)
            return;

        audio.clip = clip;
        audio.loop = true;
        audio.volume = vol;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
