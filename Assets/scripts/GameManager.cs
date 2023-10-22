using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HUD hud;
    private int vidas = 3;
    private GameState _actualGameState;
    [SerializeField] private GameObject _ventanaDePerder;
    [SerializeField] private GameObject _inicio;
    [SerializeField] private GameObject _Spawn;


    //Lo tengo en el boton de perder
    public void Inicio()
    {
        _actualGameState = GameState.Inicio;
        UpdateGameState();
        Reiniciar();
    }

    public void Reiniciar() {
        _inicio.SetActive(true);
        _Spawn.SetActive(false);
    }
    public void ApagarVentanaInicio() {
        _inicio.SetActive(false);
        _Spawn.SetActive(true);
    }
    public void ApagarVentanaPerder()
    {
        _ventanaDePerder.SetActive(false);
    }
    public void ChangeActualScene(GameState newGamestate)
    {
        _actualGameState = newGamestate;
        UpdateGameState();

    }
    private void UpdateGameState()
    {
        switch (_actualGameState)
        {
            case GameState.Inicio:
                _inicio.SetActive(true);
                _Spawn.SetActive(false);
                //prender la pantalla de inicio 
                break;
            case GameState.Jugar:
                _inicio.SetActive(false);
                _Spawn.SetActive(true);
                //apagar pantalla de inicio y prender el juego
                break;
            case GameState.Perder:
                //ventana de que sos malisimo
                _ventanaDePerder.SetActive(true);
                break;
            case GameState.Ganar:
                //ventana de que sos un titan
                break;
            default:

                break;

        }
    }

    private void Awake()
    {
        _actualGameState = GameState.Inicio;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un GameManagger en escena.");
        }
    }

    private void Start()
    {

    }

    public void PerderVida()
    {
        vidas -= 1;
        //hud.DesactivarVida(vidas);
    }

}
public enum GameState
{
    Inicio,
    Jugar,
    Perder,
    Ganar,
    None
}

