using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetScripter : MonoBehaviour {

    public int frequencyTweet;
    public float startTweetWait;
    public float afterTweetWait;
    private string tweet;
    public GUIText tweetText;
    public GameObject tweetWindow;

    IEnumerator SpawnTweet()
    {
        yield return new WaitForSeconds(startTweetWait);

        while (Camera.main.GetComponent<GameManager>().IsGameStarted())
        {
            yield return new WaitForSeconds(frequencyTweet);
            if(Random.Range(0,10) == 3)
            {
                int subject = 0;
                tweetWindow.SetActive(true);
                int numTweet = 0;
                subject = Random.Range(0, 2);

                //subject:    0-Random subject, no particular bonuses 1-Woman 2-Man
                switch (subject)
                {
                    case 0:
                        numTweet = Random.Range(0, 2);
                        switch (numTweet)
                        {
                            case 0:
                                tweet = "Make America great again!";
                                break;
                            case 1:
                                tweet = "Big interview tonight at Fox News";
                                break;
                            case 2:
                                tweet = "www.pornhub.com\nDon't botter the last tweet! i thought i was on google.";
                                break;
                            case 3:
                                tweet = "Screw the other countries...";
                                break;
                        }
                        break;
                    case 1:
                        numTweet = Random.Range(0, 4);
                        switch (numTweet)
                        {
                            case 0:
                                tweet = "Grab them by the pu**y!";
                                break;
                            case 1:
                                tweet = "Hillary Clinton should be in jail!";
                                break;
                            case 2:
                                tweet = "Woman should not have the rigth to vote, they are dumb.";
                                break;
                            case 3:
                                tweet = "Most of women are stupid, cheaters, liars, can't think right.\n Other than that their body are great.";
                                break;
                            case 4:
                                tweet = "Must be a pretty picture mexican's women dropping on their knees";
                                break;
                        }
                        break;
                    case 2:
                        numTweet = Random.Range(0, 3);
                        switch (numTweet)
                        {
                            case 0:
                                tweet = "Illegal immigrants are stealing our jobs! We need more men \nto build that wall.";
                                break;
                            case 1:
                                tweet = "The problem with mexican men is that they don't know how \nto make tacos.";
                                break;
                            case 2:
                                tweet = "We are going to intercept every mexican male and send them\n back to their dumb country!";
                                break;
                            case 3:
                                tweet = "''Mexicans are Trump's ennemies'', FAKE NEWS! They are \nAMERICA'S ennemies!";
                                break;
                        }
                        break;
                }
                tweetText.text = tweet;
                yield return new WaitForSeconds(afterTweetWait);
                tweetWindow.SetActive(false);
            }
        }
    }

    // Use this for initialization
    void Start () {
        tweet = "";
        StartCoroutine(SpawnTweet());
        tweetWindow.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}