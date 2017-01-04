using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxSource;                   // Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                 // Drag a reference to the audio source which will play the music.
    public static SoundManager instance = null;     // Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              // The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            // The highest a sound effect will be randomly pitched.
    public AudioClip menuMusic;
    public AudioClip[] music;

    public bool MusicEnabled = true;
    public bool SFXEnabled = true;

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);

        musicSource.loop = true;
    }


    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        if (SFXEnabled)
        {
            //Set the clip of our sfxSource audio source to the clip passed in as a parameter.
            sfxSource.clip = clip;

            sfxSource.volume = 0.42f;

            //Play the clip.
            sfxSource.Play();
        }
    }

    //Used to play single sound clips.
    public void PlaySingleMusic(AudioClip clip)
    {
        if (MusicEnabled)
        {
            //Set the clip of our sfxSource audio source to the clip passed in as a parameter.
            musicSource.clip = clip;

            musicSource.volume = 0.42f;

            //Play the clip.
            musicSource.Play();
        }
    }


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(AudioClip[] clips)
    {
        if (SFXEnabled)
        {
            //Generate a random number between 0 and the length of our array of clips passed in.
            int randomIndex = Random.Range(0, clips.Length);

            //Choose a random pitch to play back our clip at between our high and low pitch ranges.
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);

            //Set the pitch of the audio source to the randomly chosen pitch.
            sfxSource.pitch = randomPitch;

            //Set the clip to the clip at our randomly chosen index.
            sfxSource.clip = clips[randomIndex];

            //Play the clip.
            sfxSource.Play();
        }
    }

    public void RandomizeMusic(AudioClip[] clips)
    {
        if (MusicEnabled)
        {
            //Generate a random number between 0 and the length of our array of clips passed in.
            int randomIndex = Random.Range(0, clips.Length);

            //Choose a random pitch to play back our clip at between our high and low pitch ranges.
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);

            //Set the pitch of the audio source to the randomly chosen pitch.
            musicSource.pitch = randomPitch;

            //Set the clip to the clip at our randomly chosen index.
            musicSource.clip = clips[randomIndex];
            musicSource.volume = 0.42f;

            //Play the clip.
            musicSource.Play();
        }
    }

    public void PlayMenuMusic()
    {
        PlaySingleMusic(menuMusic);
    }

    public void PlayInGameMusic()
    {
        RandomizeMusic(music);
    }

    public void ToggleMusic()
    {
        //
    }

    public void ToggleSFX()
    {
        //
    }

}
