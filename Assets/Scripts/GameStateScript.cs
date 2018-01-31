using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour {
	public GameObject EnemyMngr;
	public GameObject Player;

	public GameObject Title;
	public GameObject Play;
	//public GameObject Options;
	public GameObject TryAgain;

	EnemyManager enemies;
	PlayerManager playerScript;

	enum GameState {MainMenu, Options, Play, GameOver};
	GameState gState;

	// Use this for initialization
	void Start () {
		playerScript = Player.GetComponent<PlayerManager>();
		enemies = EnemyMngr.GetComponent<EnemyManager>();

		gState = GameState.MainMenu;
	}
	
	// Update is called once per frame
	void Update () {
		if (gState == GameState.MainMenu) {
			Title.GetComponent<Renderer> ().enabled = true;
			Play.GetComponent<Renderer> ().enabled = true;
			TryAgain.GetComponent<Renderer> ().enabled = false;

			enemies.runEnemy = false;
			Player.GetComponent<Renderer> ().enabled = false;
		}
		if (gState == GameState.Options) {

		}
		if (gState == GameState.Play) {
			Title.GetComponent<Renderer> ().enabled = false;
			Play.GetComponent<Renderer> ().enabled = false;
			TryAgain.GetComponent<Renderer> ().enabled = false;

			enemies.runEnemy = true;
			Player.GetComponent<Renderer> ().enabled = true;
		}
		if (gState == GameState.GameOver) {
			Title.GetComponent<Renderer> ().enabled = false;
			Play.GetComponent<Renderer> ().enabled = false;
			TryAgain.GetComponent<Renderer> ().enabled = true;

			enemies.runEnemy = false;
			Player.GetComponent<Renderer> ().enabled = false;
		}
	}

	void OnMouseDown(){
		if (gState == GameState.MainMenu) { gState = GameState.Play; Debug.Log ("Mouse clicked!"); }

		if (gState == GameState.GameOver) { gState = GameState.MainMenu; }

	}
}
