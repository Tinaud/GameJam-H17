using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetScripter : MonoBehaviour {

    public int frequencyTweet;
    public float startTweetWait;
    public float afterTweetWait;
    private string tweet;
    private int subject;
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
                tweetWindow.SetActive(true);
                int numTweet = 0;
                subject = Random.Range(0, 2);

                //subject:    0-Random subject, no particular bonuses 1-Woman 2-Man 3-Trump is happy about what you do 4-Trump is not happy about what you do
                switch (subject)
                {
                    case 0:
                        numTweet = Random.Range(0, 3);
                        switch (numTweet)
                        {
                            case 0:
                                tweet = "Make America great again!";
                                break;
                            case 1:
                                tweet = "Big interview tonight at Fox News";
                                break;
                            case 2:
                                tweet = "www.pornhub.com/trump\nDon't botter the last tweet! i thought i was on google.";
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
                                tweet = "Most of women are stupid, cheaters, liars, can't think right.\nOther than that their body are great.";
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
                    case 3:
                        numTweet = Random.Range(0, 3);
                        switch (numTweet)
                        {
                            case 0:
                                tweet = "The U.S. military are doing a great job at the mexican border!";
                                break;
                            case 1:
                                tweet = "We are intercepting a lot of mexican illegal immigrants";
                                break;
                            case 2:
                                tweet = "The wall is getting bigger!";
                                break;
                            case 3:
                                tweet = "100 000 000 $ military budget as been established for \nthe mexican border";
                                break;
                        }
                        break;
                    case 4:
                        numTweet = Random.Range(0, 2);
                        switch (numTweet)
                        {
                            case 0:
                                tweet = "The General of 'the operation illegal immegrant' is an incapable";
                                break;
                            case 1:
                                tweet = "Come on troups! get rid of those mexicans!";
                                break;
                            case 2:
                                tweet = "My grandmother could be more efficient than the custom officers";
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

    public int tweetSubject()
    {
        return subject;
    }

    // Use this for initialization
    void Start () {
        tweet = "";
        subject = 0;
        StartCoroutine(SpawnTweet());
        tweetWindow.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}