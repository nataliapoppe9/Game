using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static bool gameIsPaused;


    [SerializeField] GameObject panelPause, panelSaved, panelBoat, panelGameOver;
    public GameObject parachuteInfo;
    public GameObject canvasPantalla;
    [SerializeField] GameObject hint;

    int rand;
    int doneRandom;

    [SerializeField] List<string> hints;

    public PlayableDirector timeLineEntry;
    public bool loaded;

    private void Awake()
    {
        SaveGame.Init();
        
    }

    private void Start()
    {
        gm = this;
       
        if (ChangeScene.cs.loaded)
        {
            print("start Loading");
            Load();
            ExitEntryTL();
            ChangeScene.cs.loaded = false;
        }
        else { print("not started Loading"); }




        hints.Add("Jump on mushrooms");
        hints.Add("Save Game from Time 2 Time");
        hints.Add("S-Coins will take you far");
        hints.Add("Press C for skyview");
        hints.Add("Don't leave anything behind..");
        hints.Add("Boat Token ready?");
        hints.Add("Boat Time info at Tent");
        hints.Add("Check backpack");
        hints.Add("Amonites seem friendly, don't they?");
        hints.Add("Is that a boat light?");
        hints.Add("Win Coins on Gadget");



        rand = Random.Range(0, hints.Count);
        hint.GetComponent<Text>().text = hints[rand];


    }

    public void ExitEntryTL()
    {
        print("escape");
        IntroManager.introMan.ChangeAudio();
        timeLineEntry.Stop();
        timeLineEntry.enabled = false;
        
    }

    private void Update()
    {
        if (timeLineEntry.enabled == true && Input.anyKey)
        { ExitEntryTL(); }

      /*  if(Input.GetKeyDown(KeyCode.L)) {

           
            Load();
           
        }*/

    }

    public void ChangeHint()
    {
        doneRandom = rand;
        rand = Random.Range(0, hints.Count);
        print("doneRand" + doneRandom + "rand" + rand);

        while (rand == doneRandom)
        {
            rand = Random.Range(0, hints.Count);
        }

        print("changeHint in Pause");
        //print(doneRandom + "   " + rand);
        hint.GetComponent<Text>().text = hints[rand];
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        //if (Time.timeScale == 1)
        //{
            print("paused");
            panelPause.SetActive(true);
            
            ChangeHint();
            canvasPantalla.SetActive(false);

            gameIsPaused = true;
           // Time.timeScale = 0f;
       // }
    }

    public void ParachuteYes()
    {
        if (CanvasManager.gm.numCoins < 20)
        {
            parachuteInfo.transform.GetChild(3).GetComponent<Text>().text = "You need 20 scoins";
            parachuteInfo.transform.GetChild(4).GetComponent<Text>().text = CanvasManager.gm.numCoins.ToString() + "  is not enough";
            parachuteInfo.transform.GetChild(4).GetComponent<Text>().color = Color.red;
        }
        else
        {
            print("go");

            CanvasManager.gm.SubtractCoins(20);
            PlayerMovement.pm.usingParachute = true;
            Destroy(ParachutePrefab.ppm.gameObject);
            Destroy(parachuteInfo);
        }
    }

    public void ParachuteNo()
    {
        parachuteInfo.SetActive(false);
        GameManager.gm.canvasPantalla.SetActive(true);
    }



    public void ResumeGame(GameObject panel)
    {
        panel.SetActive(false);
        canvasPantalla.SetActive(true);
        gameIsPaused = false;
        Time.timeScale = 1;
    }


    public void SaveButton()
    {
        print("activoSaved");
        panelPause.SetActive(false);
        panelSaved.SetActive(true);
        SaveIt();
        StartCoroutine(DesactivarPanel(panelSaved));
        gameIsPaused = false;
        Time.timeScale = 1;
        
    }



    IEnumerator DesactivarPanel(GameObject panel)
    {
        print("desactivarPanel");
        yield return new WaitForSeconds(1);
        print("off");

        panel.SetActive(false);
        canvasPantalla.SetActive(true);
       

    }

    private class SaveData
    {
        public int _numCoins;
        public Vector3 _positionPlayer;
        public Vector3 _rotationPlayer;
        public bool _boatCoin;
        public bool savedGame;

        //public Vector3 _positionBarco;
       // public Vector3 _positionGota;

        public bool _startAmonite;
        public List<GameObject> _amoniteList;
        public int _numAmonites;

        public List<string> _disabled;
        public List<int> _obtainedSprites;
        public List<ItemSprite> _obtainedItems;

    }

   public void SaveIt()
    {
        SaveData saveData = new SaveData
        {
            _numCoins = CanvasManager.gm.numCoins,
            _positionPlayer = PlayerMovement.pm.transform.position,
            _rotationPlayer = PlayerMovement.pm.transform.rotation.eulerAngles,
            _boatCoin = CanvasManager.gm.boatCoin,
            
           //_positionBarco = BoatScript.bsm.gameObject.transform.position,
            //_positionGota = GotaManager.gotm.gameObject.transform.position,

           _startAmonite = Amonite.am.start,
           _amoniteList = Amonite.am.amoniteList,
           _numAmonites = Amonite.am.startedNum.Count,

           _disabled=ItemManager.itemMan.disabled,
           _obtainedSprites=ItemManager.itemMan.obtainedSprites
            
          
        };
        string json = JsonUtility.ToJson(saveData);
        SaveGame.Save(json);
        print("SAVED");
        
    }

    public void Load()
    {
        string saveString = SaveGame.Load();
        if (saveString != null)
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(saveString);

            CanvasManager.gm.numCoins = saveData._numCoins;
            PlayerMovement.pm.transform.position = saveData._positionPlayer;
            PlayerMovement.pm.transform.rotation = Quaternion.Euler(saveData._rotationPlayer);
            CanvasManager.gm.boatCoin = saveData._boatCoin;

            ItemManager.itemMan.obtainedSprites = saveData._obtainedSprites;
            ItemManager.itemMan.RestartSprites();

            
            ItemManager.itemMan.disabled = saveData._disabled;
            ItemManager.itemMan.DisableObjects();

            //print(ItemManager.itemMan.obtainedItems.Count);
            

            // BoatScript.bsm.gameObject.transform.position = saveData._positionBarco;
            // GotaManager.gotm.gameObject.transform.position = saveData._positionGota;


            //  Amonite.am.amoniteList=saveData._amoniteList;

            // for (int i = 0; i < saveData._numAmonites; i++)
            // {
            //    Amonite.am.startedNum.Add(i);
            // }
            // Amonite.am.start = saveData._startAmonite;

            // _disabled = ItemManager.itemMan.disabled,
            //_obtainedSprites = ItemManager.itemMan.obtainedSprites,
            //_obtainedItems = ItemManager.itemMan.obtainedItems

            //print("disable destroyed Items" + saveData._disabled.Count);
            
            

            print("LOADED");
        }
    }


    public void OpenMiniGame(string myGame)
    {
        SaveIt();
        SceneManager.LoadScene(myGame);
    }

    public void NewGame(string newScene)
    {
        DesactivarPanel(panelGameOver);
        SceneManager.LoadScene(newScene);
    }

    public void LoadLastSave()
    {
        NewGame("SampleScene");
        ChangeScene.cs.loaded = true;
    }
   
}


    /* void SaveGame()
         {
             if (!PlayerMovement.pm.platform)
             {

                 PlayerPrefs.SetInt("numCoins", CanvasManager.gm.numCoins);
                 PlayerPrefs.SetFloat("PositionX", PlayerMovement.pm.transform.position.x);
                 PlayerPrefs.SetFloat("PositionY", PlayerMovement.pm.transform.position.y);
                 PlayerPrefs.SetFloat("PositionZ", PlayerMovement.pm.transform.position.z);
                 PlayerPrefs.SetFloat("RotX", PlayerMovement.pm.transform.rotation.eulerAngles.x);
                 PlayerPrefs.SetFloat("RotY", PlayerMovement.pm.transform.rotation.eulerAngles.y);
                 PlayerPrefs.SetFloat("RotZ", PlayerMovement.pm.transform.rotation.eulerAngles.z);
                 PlayerPrefs.SetInt("BoatBool", (CanvasManager.gm.boatCoin ? 1 : 0));

                 PlayerPrefs.SetInt("AmonitesQMeSiguen", Amonite.am.startedNum.Count);

                 // PlayerPrefs.SetInt("CountGota", GotaManager.gotm.countMoves);

                 PlayerPrefs.SetInt("SavedGame", (true ? 1 : 0));
                 // PlayerPrefs.Save(); No hace falta
                 print("GAME SAVED");

             }
         }*/