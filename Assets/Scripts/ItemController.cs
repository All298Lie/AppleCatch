using UnityEngine;

public class ItemController : MonoBehaviour
{
    [HideInInspector] public float DropSpeed = -0.03f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, this.DropSpeed, 0.0f);

        if (transform.position.y < -1.0f)
        {
            Destroy(gameObject);
        }
    }
}
