using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject nameInputPanel;
	public GameObject bubbleLoadingPanel;



	void Start ()
	{
		nameInputPanel.SetActive(true);
		bubbleLoadingPanel.SetActive(false);
	}

	void Update ()
	{
		
	}

	public void GoToBubbleLoadingPanel()
	{
		nameInputPanel.SetActive(false);
		bubbleLoadingPanel.SetActive(true);
	}
}
