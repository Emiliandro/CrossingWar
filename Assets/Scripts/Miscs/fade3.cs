using UnityEngine;
using System.Collections;

public class fade3 : MonoBehaviour {
	public float fadeInTime;
	public float fadeOutTime;
	public string scene;
	public float time;
	public SpriteRenderer sprite;

	void GoScene () {//Muda de Scene
		Application.LoadLevel (scene);

	}

	void Start () { // Manipula o alpha
		sprite.color = Color.clear;
		StartCoroutine ("FadeOut");
		Invoke ("StartFadeOut", time);
		Invoke ("GoScene", time+fadeOutTime);
		//InvokeRepeating ("FadeIn", 0, time/60f);
	}

	IEnumerator FadeIn(){
		while (sprite.color.a < 0.99f) {
			sprite.color = new Color(1f,1f,1f,sprite.color.a+(Time.deltaTime/fadeInTime));

			yield return new WaitForSeconds(Time.deltaTime/fadeInTime);

		}

	}

	IEnumerator FadeOut(){
		while (sprite.color.a > 0.01f) {
			sprite.color = new Color(1f,1f,1f,sprite.color.a-(Time.deltaTime/fadeOutTime));
			yield return new WaitForSeconds(Time.deltaTime/fadeInTime);
			
		}
	}

	public void StartFadeOut(){
		StartCoroutine ("FadeIn");
	}


}
