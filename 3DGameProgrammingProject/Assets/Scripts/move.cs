using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public float speed = 75f;
    private bool forward;
    private int score = 0;
    public TMP_Text scoreText;
    public TMP_Text GameOverScoreText;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    }
    void Update()
    {
        speed = 75f;
        forward = true;

        if (Input.GetKey(KeyCode.W) && forward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * (speed / 2));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 100000f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            print("hit");
            forward = false;
        }
        if (collision.gameObject.tag == "trash")
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = score.ToString();
            GameOverScoreText.text = "Final Score: " + score.ToString();
        }
    }
}