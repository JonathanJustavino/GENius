using UnityEngine;
using System.Collections;

public class Feeding : MonoBehaviour
{
	public GameObject[] visualProgress;
	int progress = 0;
	AudioSource audio;

	void Awake()
	{
		audio = GetComponent<AudioSource>();
	}

	public void Feed(Plant p)
	{
		audio.Play();
		if (GameManager.Instance.EpicWinning(p.GenoType) && visualProgress != null && progress < visualProgress.Length)
		{
			visualProgress[progress].SetActive(false);
			progress++;
		}
		Destroy(p.gameObject);
	}
}
