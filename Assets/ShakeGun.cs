using UnityEngine;

public class ShakeGun : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float shakeAmount = 0.1f;
    public float shakeDuration = 0.5f;

    private float shakeTimer = 0f;
    private Vector3 originalPosition;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            // Genera una posición de agitación basada en un movimiento sinusoidal
            Vector3 shakeOffset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0) * shakeAmount;

            // Aplica el desplazamiento de agitación a la posición
            transform.position = originalPosition + shakeOffset;

            // Reduce el temporizador de agitación
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Restaura la posición original si no hay agitación
            transform.position = originalPosition;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            // Inicia la agitación al presionar la tecla "P"
            StartShake();
        }
    }

    private void StartShake()
    {
        // Inicia la agitación configurando el temporizador
        shakeTimer = shakeDuration;
    }
}
