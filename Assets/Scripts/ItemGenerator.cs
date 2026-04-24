using UnityEditor.Rendering;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject bombPrefab;

    private float delta;
    private float span;
    private float speed;

    private int ratio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.delta = 0.0f;
        this.span = 1.0f;
        this.speed = -0.03f;

        this.ratio = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsTimeOut == true) return;

        this.delta = this.delta + Time.deltaTime;

        if (this.delta > this.span)
        {
            this.delta = this.delta - this.span;

            GameObject item;
            int dice = Random.Range(1, 11);

            if (dice <= this.ratio)
            {
                item = Instantiate(bombPrefab);
            }
            else
            {
                item = Instantiate(applePrefab);
            }

            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);

            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().DropSpeed = this.speed;
        }
    }

    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
}
