using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject[] scenes;
    public GameObject MenuInicial;
    public Faixas[] faixas;
    public float intervalo;
	public GameObject logo;
    private int interval = 1;
    private float nextTime = 0;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
        scenes[1].SetActive(false); //painel de sobre
        scenes[2].SetActive(false); //painel de game
    }

    void Awake() {
        interval = 1;
        nextTime = 0;
}
    // Paineis //

    public void PlayIt() {
        Time.timeScale = 1;
        scenes[0].SetActive(false); //painel de menu
        scenes[1].SetActive(false); //painel de sobre
        scenes[2].SetActive(true); //painel de game
        SwipeDetector.instance.GameStarted();
        SwipeMobileDetector.instance.GameStarted();
    }
    public void LerSobre() {
        Time.timeScale = 0;
        scenes[0].SetActive(false); //painel de menu
        scenes[1].SetActive(true); //painel de sobre
        scenes[2].SetActive(false); //painel de game
    }
    public void chamarMenu() {
        Time.timeScale = 0;
        scenes[0].SetActive(true); //painel de menu
        scenes[1].SetActive(false); //painel de sobre
        scenes[2].SetActive(false); //painel de game
    }
    public void SairJogo() {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    // Update is called once per frame
    void Update()
	{
		if (scenes[0].activeSelf)
		{
			logo.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
		} else if (scenes[1].activeSelf)
		{
			logo.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

		}
        if (scenes[2].activeSelf)
        {
            MenuInicial.SetActive(false);
        }
    }
    void FixedUpdate() {
        if (Time.time >= nextTime)
        {
            Invoke("CreateObstacle", interval);
            nextTime += interval;
        }
    }

    void CreateObstacle()
    {
        GameObject obstacle = faixas[Random.Range(0, faixas.Length)].faixas;
        Instantiate(obstacle);
    }
}
