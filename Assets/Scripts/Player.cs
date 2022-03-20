using UnityEngine;

public class Player : Character{

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PickUp")) {
            collision.gameObject.SetActive(false);
        }
    }

}
