using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to disable collision with a certain type of object after 15 seconds
        StartCoroutine(DisableCollisionAfterTime(25f));
    }

    // Coroutine to disable collision with a specified type of object after a specified time
    IEnumerator DisableCollisionAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        // Assuming the certain type of object has a tag "barrier"
        GameObject[] certainTypeObjects = GameObject.FindGameObjectsWithTag("Barrier");
        foreach (GameObject obj in certainTypeObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        // Start the coroutine to destroy the game object after 10 seconds
        StartCoroutine(DestroyAfterTime(10f));
    }

    // Coroutine to destroy the game object after a specified time
    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
