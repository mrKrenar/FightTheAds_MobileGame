using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

    public Canvas howToPlayImage;
    public Canvas storeMenu;
    public Canvas doYouLikeGameImage;
	public Canvas quitMenu;
	public Canvas creditsImage;
    public Canvas resume;

    public Button resumeGame;
    public Button newGame;
    public Button playTutorial;
	public Button startText;
	public Button credits;
	public Button exitText;
	public Button okCredits;
    public Button howToPlayText;
    public Button okHowToPlay;
    public Button storeText;
    public Button okStore;
    public Button doYouLikeGameText;
    public Button yesDoYouLikeGame;
    public Button noDoYouLikeGame;
    public int lastPlayedLevel;

    public Done_GameController gameController;

    void Start () 
	{
        quitMenu = quitMenu.GetComponent<Canvas> ();
		creditsImage = creditsImage.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		okCredits = okCredits.GetComponent<Button> ();
		credits = credits.GetComponent<Button> ();
        resume = resume.GetComponent<Canvas>();
        resume.enabled = false;

        newGame = newGame.GetComponent<Button>();
        resumeGame= resumeGame.GetComponent<Button>();

        howToPlayText = howToPlayText.GetComponent<Button>();
        okHowToPlay = okHowToPlay.GetComponent<Button>();
        storeText = storeText.GetComponent<Button>();
        okStore = okStore.GetComponent<Button>();
        doYouLikeGameText = doYouLikeGameText.GetComponent<Button>();
        yesDoYouLikeGame = yesDoYouLikeGame.GetComponent<Button>();
        noDoYouLikeGame = noDoYouLikeGame.GetComponent<Button>();
        creditsImage.enabled = false;
		quitMenu.enabled = false;
        howToPlayImage.enabled = false;
        doYouLikeGameImage.enabled = false;
        storeMenu.enabled = false;
        lastPlayedLevel = gameController.lastPlayedLevel;
	}

    public void HowToPlayPress()
    {
        okHowToPlay.enabled = true;
        howToPlayText.enabled = false;
        howToPlayImage.enabled = true;
        storeText.enabled = false;
        doYouLikeGameText.enabled = false;
        quitMenu.enabled = false;
        creditsImage.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
        credits.enabled = false;
    }

    public void StorePress()
    {
        okStore.enabled = true;
        storeMenu.enabled = true;
        storeText.enabled = false;
        okHowToPlay.enabled = false;
        howToPlayText.enabled = false;
        doYouLikeGameText.enabled = false;
        quitMenu.enabled = false;
        creditsImage.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
        credits.enabled = false;
    }

    public void DoYouLikeGamePress()
    {
        yesDoYouLikeGame.enabled = true;
        noDoYouLikeGame.enabled = true;
        doYouLikeGameImage.enabled = true;
        okHowToPlay.enabled = false;
        howToPlayText.enabled = false;
        storeText.enabled = false;
        doYouLikeGameText.enabled = false;
        quitMenu.enabled = false;
        creditsImage.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
        credits.enabled = false;
    }

	public void ExitPress()

	{
		quitMenu.enabled = true;
		creditsImage.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
		credits.enabled = false;
        howToPlayText.enabled = false;
        storeText.enabled = false;
        doYouLikeGameText.enabled = false;
	}

	public void CreditsPress()
	{
		quitMenu.enabled = false;
		creditsImage.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		credits.enabled = false;
		okCredits.enabled = true;
        howToPlayText.enabled = false;
        storeText.enabled = false;
        doYouLikeGameText.enabled = false;
    }

	public void NoPress()

	{
        howToPlayImage.enabled = false;
        storeMenu.enabled = false;
        doYouLikeGameImage.enabled = false;
        quitMenu.enabled = false;
		creditsImage.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		credits.enabled = true;
        howToPlayText.enabled = true;
        storeText.enabled = true;
        doYouLikeGameText.enabled = true;
        resume.enabled = false;
    }

	public void RateGame()
	{
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.YoungDevs.fta");
	}

    public void SendFeedback()
    {
        Application.OpenURL("http://young-developers.weebly.com/contact.html");
    }


	public void StartLevel()
	{
        resume.enabled = true;
	}

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void ResumeGame()
  {
      SceneManager.LoadScene(gameController.lastPlayedLevel);
        Time.timeScale = 1.0f;
        if(lastPlayedLevel >= 11)
        {
            SceneManager.LoadScene(11);
        }
  }

    public void PlayTutorial()
    {
      SceneManager.LoadScene(1);
       Time.timeScale = 1.0f;
    }

	public void ExitGame()

	{
		Application.Quit ();
	}

}


