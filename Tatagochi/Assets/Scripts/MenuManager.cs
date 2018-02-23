using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;

public class MenuManager : MonoBehaviour {

    private AudioSource source;

    [BoxGroup("Buttons")] public Button NewGameButton;                                          // Nuova partita

    [BoxGroup("Images")] public Image fadeImage;                                                // Immagine di Fade

    //[BoxGroup("Audio")] public AudioClip audio1;                                                // New Game audio

    void Start () {

        source = GetComponent<AudioSource>();

        fadeImage.enabled = false;
        fadeImage.DOFade(0, 0);

	}

    void FixedUpdate() { Screen.SetResolution(480, 800, true); }

    public void NewGame()
    {
        StartCoroutine(NewGameCoroutine());
    }

    private IEnumerator NewGameCoroutine()
    {
        //source.PlayOneShot(audio1);

        fadeImage.enabled = true;
        NewGameButton.interactable = false;

        yield return new WaitForSeconds(1);
        fadeImage.DOFade(1, 1);
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
