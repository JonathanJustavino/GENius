using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

	private static SoundManager sm;
	public static SoundManager Instance
	{
		get
		{
			return sm;
		}
		private set
		{
			sm = value;
		}
	}

	[Tooltip("Put into this array any gameobject, which is inactive at the start of the level " +
			 "and has button-scripts attached to itself or its children.")]
	public GameObject[] inactiveButtonholders;

	private AudioListener audLis;
	private Dictionary<string, AudioSource> sounds;

	void Awake()
	{

		sm = this;
		sounds = new Dictionary<string, AudioSource>();
		initSounds();
		sounds["music"].Play();

		foreach (GameObject go in inactiveButtonholders)
		{
			go.SetActive(true);
		}
		Button[] allBtns = FindObjectsOfType<Button>();
		foreach (Button btn in allBtns)
		{
			btn.onClick.AddListener(() => PlaySound("clicking"));
		}
		foreach (GameObject go in inactiveButtonholders)
		{
			go.SetActive(false);
		}
	}

	private void initSounds()
	{
		AudioClip[] soundsFromFile = Resources.LoadAll<AudioClip>("");
		foreach (AudioClip au in soundsFromFile)
		{
			GameObject g = new GameObject("sound__" + au.name);
			g.transform.parent = this.transform;
			AudioSource auS = g.AddComponent<AudioSource>();
			auS.clip = au;
			auS.volume = 0.3f;

			sounds.Add(au.name, auS);
		}
	}

	public void PlaySound(string name)
	{
		sounds[name].Play();
	}

	public void ToggleMusic()
	{
		sounds["music"].mute = !sounds["music"].mute;
	}
}
