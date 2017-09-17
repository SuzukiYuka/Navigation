using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 2.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        Vector3 move = Vector3.forward * Input.GetAxis("Vertical");
        move += Vector3.right * Input.GetAxis("Horizontal");
        transform.position += move * speed * Time.deltaTime;

        if (transform.position.y <= -10) {

            Retry();
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.name == "Goal") {
            SceneManager.LoadScene("Goal");
        }
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.name == "Enemy") {
            Retry();
        }

        if (collision.gameObject.tag == "Break") {
            Destroy((collision.gameObject));
        }
    }

    void Retry() {
        //Mainシーン移動
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("Main"); でもOK?
    }

}
