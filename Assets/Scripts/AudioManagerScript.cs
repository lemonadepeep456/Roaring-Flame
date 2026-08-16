using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip slash;
    public AudioClip coinpickup;
    public AudioClip hurt;

    // Dictionary to track cooldown timestamps for specific clips
    private Dictionary<AudioClip, float> sfxCooldowns = new Dictionary<AudioClip, float>();

    // Set your desired cooldown time in seconds (e.g., 0.1s prevents exact frame stacking)
    private const float SFX_COOLDOWN_TIME = 0.08f;
    private AudioSource sfxAudioSource;
    private void Start()
    {
        if (background != null && musicSource != null)
        {
            musicSource.clip = background;
            musicSource.loop = true; // Ensure background music loops
            musicSource.Play();
        }

        sfxAudioSource = GetComponent<AudioSource>();

        // Lower the volume to 30% of its original strength
        sfxAudioSource.volume = 0.3f;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;

        // 1. Cooldown Check to prevent ear-destroying overlapping volume spikes
        if (sfxCooldowns.TryGetValue(clip, out float nextPlayTime))
        {
            if (Time.time < nextPlayTime) return; // Skip playing if it's too soon
        }

        // Update the cooldown timestamp for this clip
        sfxCooldowns[clip] = Time.time + SFX_COOLDOWN_TIME;

        // 2. Pitch Variation (Optional but highly recommended for game feel)
        // We vary the slash and coin sounds, but keep UI or ambient sounds steady
        if (clip == slash || clip == coinpickup)
        {
            sfxSource.pitch = Random.Range(0.9f, 1.1f);
        }
        else
        {
            sfxSource.pitch = 1.0f; // Reset to normal pitch for hurt or standard clips
        }

        sfxSource.PlayOneShot(clip);
    }
}

