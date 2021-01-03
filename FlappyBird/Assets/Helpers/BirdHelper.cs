using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHelper : MonoBehaviour
{

    public float force;
    private new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y < 4) {
            Fly();
        }
    }

    private void Fly() {
        if (Input.GetMouseButtonDown(0)) {
            rigidbody.AddForce(Vector2.up * (force - rigidbody.velocity.y), ForceMode2D.Impulse);
            rigidbody.MoveRotation(rigidbody.velocity.y - 2.0F);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        RestartHelper.instanse.restartButton.gameObject.SetActive(true);
        Time.timeScale = 0.0F;
    }

    void OnTriggerExit2D(Collider2D other) {
        ScoreCalculator.instanse.ShiftScore(1);
    }
}
