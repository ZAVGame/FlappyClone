using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{

    private GameObject _pipes;

    private void Awake() {
        _pipes = Resources.Load<GameObject>("Pipes");
    }

    void Start()
    {
        StartCoroutine(GeneratePipes());
    }

    private IEnumerator GeneratePipes() {
        Vector2 position;
        while (true) {
            position = transform.position;
            position.x += 6.0F;
            Instantiate(_pipes, position, Quaternion.identity);
            yield return new WaitForSeconds(2.0F);
        }
    }
}
