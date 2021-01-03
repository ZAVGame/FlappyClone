using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHelper : MonoBehaviour
{

    public float force;
    private new Rigidbody2D rigidbody;
    private GameHelper gameHelper;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gameHelper = Camera.main.GetComponent<GameHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            rigidbody.AddForce(Vector2.up * (force - rigidbody.velocity.y), ForceMode2D.Impulse);
            rigidbody.MoveRotation(rigidbody.velocity.y - 2.0F);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        gameHelper.restartButton.gameObject.SetActive(true);
        Time.timeScale = 0.0F;
    }

    void OnTriggerExit2D(Collider2D other) {
        gameHelper.score++;
    }
}
