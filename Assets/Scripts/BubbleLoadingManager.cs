using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleLoadingManager : MonoBehaviour {

	public GameObject bubble;

	private List<GameObject> bubbles;
	private List<GameObject> bubblesToRemove;

	private float minX = -484.0f;
	private float maxX = 484.0f;
	private float startY = -484.0f;
	private float endY = 484.0f;

	private float yIncrement = 1.0f;

	private float minSize = 20.0f;
	private float maxSize = 150.0f;

	private int maxBubbles = 100;

	private float timeNewBubble = 0.0f;
	private static float timeNewBubbleTotal = 0.25f;

	void Start ()
	{
		bubble.GetComponent<RectTransform>().localPosition = new Vector2(0, startY);
		bubbles = new List<GameObject>();
		bubblesToRemove = new List<GameObject>();
	}

	void Update ()
	{
		timeNewBubble += Time.deltaTime;
		if (timeNewBubble >= timeNewBubbleTotal && bubbles.Count < maxBubbles)
		{
			// make a new one
			GameObject newBubble = Instantiate(bubble, bubble.transform.parent);
			newBubble.GetComponent<RectTransform>().localPosition = new Vector2(Random.Range(minX, maxX), startY);
			float size = Random.Range(minSize, maxSize);
			newBubble.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
			bubbles.Add(newBubble);
			timeNewBubble = 0.0f;
		}
		Vector2 vect;
		GameObject bub;
		for (int i=0; i<bubbles.Count; i++)
		{
			bub = bubbles[i];
			vect = bub.GetComponent<RectTransform>().localPosition;
			vect.y += yIncrement;
			bub.GetComponent<RectTransform>().localPosition = vect;
			if (bub.GetComponent<RectTransform>().localPosition.y > endY)
			{
				bubblesToRemove.Add(bub);
			}
		}
		for (int i=0; i<bubblesToRemove.Count; i++)
		{
			bub = bubblesToRemove[i];
			bubbles.Remove(bub);
			Destroy(bub);
		}
//		bubbles.RemoveAll(o => o.GetComponent<RectTransform>().localPosition.y > endY);
	}

	public void ButtonPressed(GameObject bubble)
	{
		MonoBehaviour.FindObjectOfType<GameManager>().score++;
		bubbles.Remove(bubble);
		Destroy(bubble);
	}
}
