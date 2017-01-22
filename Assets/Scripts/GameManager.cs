using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject nameInputPanel;
	public GameObject bubbleLoadingPanel;
	public InputField nameInputField;

	public string name;
	public int score;

	public Text nameLabel;
	public Text scoreLabel;

	void Start ()
	{
		nameInputPanel.SetActive(true);
		bubbleLoadingPanel.SetActive(false);
	}

	void Update ()
	{
		scoreLabel.text = "Score: " + score;
	}

	public void GoToBubbleLoadingPanel()
	{
		name = nameInputField.text;
		nameInputPanel.SetActive(false);
		bubbleLoadingPanel.SetActive(true);
		nameLabel.text = name;
	}
}
