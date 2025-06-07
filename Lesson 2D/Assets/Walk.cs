using UnityEngine;

public class Walk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.05f,0,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = gameObject.transform.position - new Vector3(0.05f, 0, 0);
        }
    }
}
