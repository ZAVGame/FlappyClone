using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private GameObject pipes;
    public Button restartButton;
    [HideInInspector]
    public int score;

    private void Awake() {
        pipes = Resources.Load<GameObject>("Pipes");
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(GeneratePipes());
        restartButton.onClick.AddListener(Reset);
    }

    // Update is called once per frame
    private void Update()
    {
        scoreText.text = "Score: " + score;
    }

    private IEnumerator GeneratePipes() {
        Vector2 position;
        while(true) {
            position = transform.position;
            position.x += 6.0F;
            Instantiate(pipes, position, Quaternion.identity);
            yield return new WaitForSeconds(2.0F);
        }
    }

    public void Reset() {
        SceneManager.LoadScene(0);

        Time.timeScale = 1.0F;
        restartButton.gameObject.SetActive(false);
    }
}
