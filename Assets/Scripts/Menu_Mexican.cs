using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Mexican : Mexican {

    private void Awake()
    {
        StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(8.0f);
        
        Destroy(gameObject);
    }
}
