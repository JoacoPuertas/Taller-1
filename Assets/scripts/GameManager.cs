using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public HUD hud;
    public int vidas = 5;
    public int vidasSaturno = 8;
    private GameState _actualGameState;
    [SerializeField] private GameObject _ventanaDePerder;
    [SerializeField] private GameObject _ventanaDeGanar;
    [SerializeField] private GameObject _inicio;
    [SerializeField] private GameObject _Spawn;
    [SerializeField] private GameObject _Oleada2;
    private string VidasPrefsName = "Vidas";



    //Lo tengo en el boton de perder
    public void Inicio()
    {
        _actualGameState = GameState.Inicio;
        UpdateGameState();
        Reiniciar();
        LoadData();
       // hud.iteratorVidas = vidas-1;
    }

    public void Reiniciar() {
        _inicio.SetActive(true);
        _Spawn.SetActive(false);
    }
    public void ApagarVentanaInicio() {
        //SceneManager.LoadScene("level1");
        SceneManager.LoadScene("Cinematicas");
    }
    public void ApagarVentanaPerder()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ApagarVentanaGanar()
    {
        _ventanaDeGanar.SetActive(false);
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
                _inicio.SetActive(false);;
                //apagar pantalla de inicio y prender el juego
                break;
            case GameState.Perder:
                //ventana de que sos malisimo
                SceneManager.LoadScene("Perdiste");
                break;
            case GameState.Ganar:
                //ventana de que sos un titan
                _Spawn.SetActive(false);
                _ventanaDeGanar.SetActive(true);
                break;
            default:

                break;

        }
    }

    private void OnDestroy()
    {
        //SaveData();
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
        LoadData();
       // hud.iteratorVidas = vidas - 1;
    }

    public void PerderVida()
    {
        vidas -= 1;
        SaveData();
        hud.DesactivarVida(vidas);
        if(vidas==0)
        ChangeActualScene(GameState.Perder); 
    }

    public void PerderVidaSaturno()
    {
        vidasSaturno -= 1;
        //SaveData();
        hud.DesactivarVidaSaturno(vidasSaturno);
        if (vidas == 0)
            ChangeActualScene(GameState.Ganar);
    }

    //hud.DesactivarVidaSaturno();
    public void SumarVida()
    {
        Debug.Log("Vida sumada. Vidas actuales: " + vidas);
        vidas += 1;
        SaveData();
        hud.ActivarVidas(vidas);
    }

    public void RestarVidaSaturno()
    {
        Debug.Log("Vida sumada. Vidas actuales: " + vidasSaturno);
        vidasSaturno += 1;
        //SaveData();
        //hud.ActivarVidas(vidas);
    }


    private void SaveData()
    {
        PlayerPrefs.SetInt(VidasPrefsName, vidas);
        PlayerPrefs.Save(); // Guardar los datos inmediatamente
        Debug.Log("Datos guardados. Vidas: " + vidas);
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("Vidas"))
        {
            if (SceneManager.GetActiveScene().name == "level1")
            {
                PlayerPrefs.SetInt(VidasPrefsName, 5);
            }
            vidas = PlayerPrefs.GetInt("Vidas");
            Debug.Log("Vidas"+ vidas);
            HUD.Instance.UpdateVidas(vidas);
        }
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

