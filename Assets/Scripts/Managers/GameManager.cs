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
	private float interval = 1;
    private float nextTime = 0;
    int filtro = 0;

    public AudioSource ouvido;
    public AudioClip[] menu;
    public AudioClip[] gameplay;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
        scenes[1].SetActive(false); //painel de sobre
        scenes[2].SetActive(false); //painel de game
        scenes[3].SetActive(false); //painel de game
        ouvido.clip = menu[Random.Range(0, menu.Length)];
        ouvido.Play();
    }

    void Awake()
    {
        interval = 1.5f;
        nextTime = 0;
    }
    // Paineis //

    public void PlayIt() {
        Time.timeScale = 1;
        scenes[0].SetActive(false); //painel de menu
        scenes[1].SetActive(false); //painel de sobre
        scenes[2].SetActive(true); //painel de game
        scenes[3].SetActive(false); //painel de game
        ouvido.clip = gameplay[Random.Range(0, gameplay.Length)];
        ouvido.Play();
        SwipeDetector.instance.GameStarted();
        //SwipeMobileDetector.instance.GameStarted();
    }
    public void LerSobre() {
        Time.timeScale = 0;
        scenes[0].SetActive(false); //painel de menu
        scenes[1].SetActive(true); //painel de sobre
        scenes[2].SetActive(false); //painel de game
        scenes[3].SetActive(false); //painel de game
    }
    public void SelectPlayer()
    {
        Time.timeScale = 0;
        scenes[0].SetActive(false); //painel de menu
        scenes[1].SetActive(false); //painel de sobre
        scenes[2].SetActive(false); //painel de game
        scenes[3].SetActive(true); //painel de game
    }
    public void chamarMenu() {
        Time.timeScale = 0;
        scenes[0].SetActive(true); //painel de menu
        scenes[1].SetActive(false); //painel de sobre
        scenes[2].SetActive(false); //painel de game
        scenes[3].SetActive(false); //painel de game
    }
    public void SairJogo(string cena) {
		interval = 1;
		nextTime = 0;
        SceneManager.LoadScene(cena);
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		if (scenes[0].activeSelf || scenes[3].activeSelf)
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
        if (Time.time >= nextTime)
        {
            if (filtro == 0)
            CreateObstacle();
        }
}

    void CreateObstacle()
    {
        if (Time.time >= nextTime)
        {
            GameObject obstacle = faixas[Random.Range(0, faixas.Length)].faixas;
            Instantiate(obstacle);
            nextTime += interval;
        }

    }
}
