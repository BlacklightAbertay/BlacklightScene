using Azure.AppServices;
using RESTClient;
using UnityEngine;
using System;
using System.Net;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Scoring : DataModel
{
	public string username;
	public uint score;
}

public class AzureHandler : MonoBehaviour {

	private AppServiceClient _client;
	private AppServiceTable<Scoring> _table;
	//private TableView _tableView;
	public string appURL = "Insert App URL";
	public uint playerScore = 10; // For testing
	private Scoring _score = null;
	private float timer = 0;

	// Use this for initialization
	void Start ()
	{
		if (UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			_client = new AppServiceClient(appURL);
			_table = _client.GetTable<Scoring>("stats");
			Insert();
			//_tableView.dataSource = this;
			//UpdateUI();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			timer += Time.deltaTime;
			if (timer >= 5.0f)
			{
				timer = 0;
				UpdateScore();
			}
		}
	}

	public void Insert()
	{
		Scoring score = GetScore();
		//if (Validate(score))
		//{
			StartCoroutine(_table.Insert<Scoring>(score, OnInsertCompleted));
		//}
	}

	private void OnInsertCompleted(IRestResponse<Scoring> response)
	{
		if (!response.IsError && response.StatusCode == HttpStatusCode.Created)
		{
			Debug.Log("OnInsertItemCompleted: " + response.Content + " status code:" + response.StatusCode + " data:" + response.Data);
			Scoring item = response.Data;
			_score = item;
		}
		else
		{
			Debug.Log("Error " + response.StatusCode);
		}
	}

	public void UpdateScore()
	{
		Scoring score = GetScore();
		StartCoroutine(_table.Update<Scoring>(score, OnUpdateScoreCompleted));
	}

	private void OnUpdateScoreCompleted(IRestResponse<Scoring> response)
	{
		if (!response.IsError)
		{
			Debug.Log("OnUpdateScoreCompleted: " + response.Content);
		}
		else
		{
			Debug.Log("OnUpdateScoreCompleted Error:" + response.StatusCode + " " + response.ErrorMessage);
		}
	}

	public Scoring GetScore()
	{
		Scoring score = new Scoring();
		score.username = "Alice";
		score.score = playerScore;
		score.id = "";
		if (_score != null)
		{
			score.id = _score.id;
		}
		return score;
	}
}
