using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum JudgementState
{
    Win,
    Lose,
    Draw
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float transitionTime = 5f;
    // ゲームSceneが始まってからの経過時間
    private Timer timer;
    private TransitionToStart transitionToStart;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Enemy enemy;
    private bool isJudging = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer();
        transitionToStart = new TransitionToStart(timer, transitionTime, 3);
        timer.startTimer();
        Debug.Log("Start");
        StartCoroutine(startTimer());
    }
    // start timer
    public IEnumerator startTimer()
    {
        transitionToStart.transitionTime = transitionTime;
        transitionToStart.divideNumber = 7;
        yield return new WaitForSeconds(transitionTime);
        timer.setSignalTime();
        isJudging = true;
        Debug.Log("Timer started");
    }

    JudgementState Judgement(Player player, Enemy enemy)
    {
        if (player.deltaTime < enemy.deltaTime)
        {
            return JudgementState.Win;
        }
        else if(player.deltaTime > enemy.deltaTime)
        {
            return JudgementState.Lose;
        }
        else
        {
            return JudgementState.Draw;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transitionToStart.Update();
        // 判定してすぐにシーン遷移するので、1フレームだけ判定する
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space");
            if (isJudging)
            {
                player.deltaTime = timer.getDeltaTime();
                switch (Judgement(player, enemy))
                {
                    case JudgementState.Win:
                        Debug.Log("Win");
                        SceneManager.LoadScene("WinScene");
                        break;
                    case JudgementState.Lose:
                        Debug.Log("Lose");
                        SceneManager.LoadScene("LoseScene");
                        break;
                    case JudgementState.Draw:
                        Debug.Log("Draw");
                        SceneManager.LoadScene("DrawScene");
                        break;
                }
            }
            // お手つき
            else
            {
                Debug.Log("お手つき");
                SceneManager.LoadScene("TooEarlyScene");
            }
        }
    }
}
