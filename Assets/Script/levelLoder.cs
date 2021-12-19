using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoder : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    void Start()
    {
        StartCoroutine(LoadAsunchronously("Play"));
    }

    IEnumerator LoadAsunchronously(string SceneNamex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneNamex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/ .9f);
            slider.value = progress;
            progressText.text = progress + "%";

            yield return null;
        }
    }
}
