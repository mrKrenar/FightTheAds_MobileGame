using UnityEngine;
using UnityEngine.Advertisements;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public int coinsValue;
	public int levelScoreValue;
	public int levelCoinsValue;

    private int deathsNumber;

    private Done_GameController gameController;
    public int canIShowAd;

//    public WeaponObject[] weapons;
//    public int currentWeapon = 0;

    public void ShowAd()
    {
        //if (Advertisement.IsReady())
        //{
        //    Advertisement.Show();
        //}
    }

    void Start ()
	{
        deathsNumber = PlayerPrefs.GetInt("Deaths number:", deathsNumber); 
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Ad")
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
        
        if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            deathsNumber += 1;
            PlayerPrefs.SetInt("Deaths number:", deathsNumber);
            if(canIShowAd==1 || deathsNumber==4)
            {
                ShowAd();
                deathsNumber = 0;
                PlayerPrefs.SetInt("Deaths number:", deathsNumber);
            }
            if(deathsNumber>4)
            {
                deathsNumber = 0;
                PlayerPrefs.SetInt("Deaths number:", deathsNumber);
            }
        }

    gameController.AddCoins (coinsValue);
	gameController.AddLevelCoins (levelCoinsValue);
	gameController.AddLevelScore (levelScoreValue);
	Destroy (other.gameObject);
	Destroy (gameObject);
	}
}