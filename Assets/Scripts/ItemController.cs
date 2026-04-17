using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private float dropSpeed = -0.03f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, this.dropSpeed, 0.0f);

        if (transform.position.y < -1.0f)
        {
            Destroy(gameObject);
        }
    }
}
