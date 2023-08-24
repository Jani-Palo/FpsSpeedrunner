using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
	public Text timerText;
	public static UiManager instance;

	private float secondsCount;
	private int minuteCount;
	private int hourCount;

	public float speed = 10f;
	void Update()
	{
		UpdateTimerUI();
	}

	//call this on update
	public void UpdateTimerUI()
	{
		//set timer UI
		secondsCount += Time.deltaTime;
		timerText.text = minuteCount + "m" + (int)secondsCount + "s";
		if (secondsCount >= 60)
		{
			minuteCount++;
			secondsCount = 0;
		}
		else if (minuteCount >= 60)
		{
			hourCount++;
			minuteCount = 0;
		}
		DontDestroyOnLoad(gameObject);
	}
}
