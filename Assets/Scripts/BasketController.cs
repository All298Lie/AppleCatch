using UnityEngine;
using UnityEngine.InputSystem;

public class BasketController : MonoBehaviour
{
    [Header("Input Action")]
    [SerializeField] private InputAction leftClickAction;
    [SerializeField] private InputAction pointer;

    [Header("Component")]
    [SerializeField] private AudioSource audioSource;

    [Header("AudioClip")]
    [SerializeField] private AudioClip getSE;
    [SerializeField] private AudioClip damageSE;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void OnEnable()
    {
        this.leftClickAction.Enable();
        this.pointer.Enable();

        this.leftClickAction.performed += OnClickPerformed;
    }

    void OnDisable()
    {
        this.leftClickAction.performed -= OnClickPerformed;

        this.leftClickAction.Disable();
        this.pointer.Disable();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple") == true)
        {
            this.audioSource.PlayOneShot(this.getSE);
        }
        else if (other.gameObject.CompareTag("Bomb") == true)
        {
            this.audioSource.PlayOneShot(this.damageSE);
        }

        Destroy(other.gameObject);
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        Vector2 screenPos = this.pointer.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            float x = Mathf.RoundToInt(hit.point.x);
            float z = Mathf.RoundToInt(hit.point.z);

            transform.position = new Vector3(x, 0, z);
        }
    }
}
