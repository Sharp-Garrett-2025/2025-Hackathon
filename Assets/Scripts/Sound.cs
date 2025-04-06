using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeleteAfterTime());
    }

    public IEnumerator DeleteAfterTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);

    }
}
