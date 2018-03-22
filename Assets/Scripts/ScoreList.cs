using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreList : MonoBehaviour {

	private TextMesh _textMesh;
	//private Material _textMaterial;
	//private int _colourId;
	public AzureHandler azureHandler;

	private Scoring _score;

	private void Awake()
	{
		_textMesh = gameObject.GetComponentInChildren<TextMesh>();
		displayScore();
		//_textMaterial = _textMesh.GetComponent<MeshRenderer>().material;
		//_colourId = Shader.PropertyToID("_Color");
	}

	//private void OnDestroy()
	//{
	//	Destroy(_textMaterial);
	//	_textMaterial = null;
	//}

	void displayScore()
	{
		_score = azureHandler.GetScore();
		_textMesh.text = string.Format("{0}-{1}", _score.username, _score.score);
	}
}
