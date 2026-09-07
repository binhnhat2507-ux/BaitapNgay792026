using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position.z >= (this.transform.position.z + 30))
        {
            this.transform.position += new Vector3(0, 0, 30);
        }
    }
}
