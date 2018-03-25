using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {

	public void OnClickPlay(){
		//Debug.Log ("Play");
		SceneManager.LoadScene("state_one");
	}
}
