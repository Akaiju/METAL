using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
                SceneManager.LoadScene(SampleScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
