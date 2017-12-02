using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance = null;

	private const int numAudioSources = 30;
	private AudioSource[] audioSources;

	private int currentAudioSource = 0;

	void Awake () {
		if (instance == null) {
			instance = this;
			CreateAudioSources ();
		} else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingle (AudioClip clip, float volume = 1.0f, float pitch = 1.0f)
	{
		currentAudioSource++;
		if (currentAudioSource >= audioSources.Length) {
			currentAudioSource = 0;
		}

		AudioSource audioSource = audioSources[currentAudioSource];

		audioSource.volume = volume;
		audioSource.pitch = pitch;		
		audioSource.clip = clip;
		
		audioSource.Play ();
	}

	private void CreateAudioSources() {
		audioSources = new AudioSource[numAudioSources];

		for (int i = 0; i < numAudioSources; i++) {			
			AudioSource audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;

			audioSource.enabled = true;
			audioSource.loop = false;
			audioSource.playOnAwake = false;
			audioSource.volume = 1.0f;

			audioSources[i] = audioSource;
		}
	}
}

