using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
	KeywordRecognizer keywordRecognizer = null;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	DisableFloors floorDisabler;

	// Use this for initialization
	void Start()
	{
		floorDisabler = GetComponent<DisableFloors>();

		keywords.Add("Floor one", () =>
		{
			// Call the OnReset method on every descendant object.
			floorDisabler.SelectFloor(0);
		});

		keywords.Add("Floor two", () =>
		{
			// Call the OnReset method on every descendant object.
			floorDisabler.SelectFloor(1);
		});

		keywords.Add("Floor three", () =>
		{
			// Call the OnReset method on every descendant object.
			floorDisabler.SelectFloor(2);
		});

		keywords.Add("Floor four", () =>
		{
			// Call the OnReset method on every descendant object.
			floorDisabler.SelectFloor(3);
		});

		//keywords.Add("Floor 2", () =>
		//{
		//	var focusObject = GazeGestureManager.Instance.FocusedObject;
		//	if (focusObject != null)
		//	{
		//		// Call the OnDrop method on just the focused object.
		//		focusObject.SendMessage("OnDrop", SendMessageOptions.DontRequireReceiver);
		//	}
		//});

		// Tell the KeywordRecognizer about our keywords.
		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

		// Register a callback for the KeywordRecognizer and start recognizing!
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
	}

	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;
		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();
		}
	}
}