using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameCore : MonoBehaviour
{
    [SerializeField]
    private GameSettings gameSettings;
    [SerializeField]
    private GameObject playerShip;

    private int _currentWave = 1;
    private int _livesCount = 3;
    private int _currentScore = 0;

    public static GameCore Instance { get; private set; } = null;


    public GameSettings GameSettings
    {
        get => gameSettings;
    }

    private void SetInstance()
    {
        if (Instance == null) Instance = this;
    }

    public GameObject PlayerShip
    {
        get => playerShip;
    }

    private void Awake()
    {
        SetInstance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ReloadScene();
        }
    }

    //test stuff: reload scene
    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    #region HyperspaceHadler
    private bool _readyToGoIntoHyperSpace = true;

    public void TravelToHyperSpace()
    {
        if (_readyToGoIntoHyperSpace)
            StartCoroutine(HyperSpace());
    }

    private IEnumerator HyperSpace()
    {
        print("Going into Hyperspace...");
        _readyToGoIntoHyperSpace = false;
        Instance.PlayerShip.SetActive(false);
        yield return new WaitForSeconds(Instance.GameSettings.TimeInHyperSpace);

        Instance.PlayerShip.SetActive(true);
        ChooseNewPosition();
        print("...and appearing from Hyperspace!");
        yield return new WaitForSeconds(Instance.GameSettings.HyperSpaceCooldown);
        _readyToGoIntoHyperSpace = true;
    }

    private void ChooseNewPosition()
    {
        var minPos = 0.00f;
        var maxPos = 1.00f;

        var origZPos = transform.position.z;
        var newPos = new Vector3(Random.Range(minPos, maxPos), Random.Range(minPos, maxPos), Camera.main.transform.position.z);
        newPos = Camera.main.ViewportToWorldPoint(newPos);
        newPos.z = origZPos;

        Instance.PlayerShip.GetComponent<Rigidbody2D>().position = newPos;
    }
    #endregion
}
