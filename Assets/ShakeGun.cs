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
            // Genera una posici�n de agitaci�n basada en un movimiento sinusoidal
            Vector3 shakeOffset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0) * shakeAmount;

            // Aplica el desplazamiento de agitaci�n a la posici�n
            transform.position = originalPosition + shakeOffset;

            // Reduce el temporizador de agitaci�n
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Restaura la posici�n original si no hay agitaci�n
            transform.position = originalPosition;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            // Inicia la agitaci�n al presionar la tecla "P"
            StartShake();
        }
    }

    private void StartShake()
    {
        // Inicia la agitaci�n configurando el temporizador
        shakeTimer = shakeDuration;
    }
}
