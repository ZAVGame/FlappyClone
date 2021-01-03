using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    private Sprite[] cloudSprites;
    private List<GameObject> generatedClouds = new List<GameObject>();
    [SerializeField]
    private float speed;

    void Start()
    {
        cloudSprites = Resources.LoadAll<Sprite>("Sprites/Clouds");

        StartCoroutine(GenerateCloud());
    }

    void Update()
    {
        FloatClouds();
    }

    private void FloatClouds() {
        foreach (var cloud in generatedClouds.ToArray()) {
            if (cloud.transform.position.x < -12) {
                generatedClouds.Remove(cloud);
                Destroy(cloud);
                continue;
            }
            Vector2 targetPosition = new Vector2(-15, cloud.transform.position.y);
            cloud.transform.position = Vector2.MoveTowards(cloud.transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    private IEnumerator GenerateCloud() {
        while (true) {
            var gameObject = new GameObject("Cloud");
            var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = cloudSprites[Random.Range(0, cloudSprites.Length)];
            spriteRenderer.transform.position = new Vector2(15, Random.Range(0, 5));
            spriteRenderer.sortingOrder = 9;
            generatedClouds.Add(gameObject);
            yield return new WaitForSeconds(Random.Range(0.0F, 3.0F));
        }
    }
}
