using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultySettingLVL5 : MonoBehaviour
{

    [SerializeField] private GameObject tomik;
    [SerializeField] private bool tomikActivated;
    [SerializeField] private GameObject HUD;

    [SerializeField] private GameObject startText;
    [SerializeField] private TMP_Text startTextText;

    private GameObject player;
    private Player playerScript;

    void Awake()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
        playerScript.difficultySelection = true;
        HUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void TomikActive(bool value)
    {
        tomikActivated = value;
        if(value == false)
        {
            tomik.SetActive(false);
        }

        playerScript.difficultySelection = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        HUD.SetActive(true);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        startTextText.text = "Zpátky taky nemůžu, protože jsou dveře zamčené.";
        yield return new WaitForSeconds(3f);
        startTextText.text = "Asi budu muset najít nějaký klíč.";
        yield return new WaitForSeconds(3f);
        startText.SetActive(false);
    }

}
