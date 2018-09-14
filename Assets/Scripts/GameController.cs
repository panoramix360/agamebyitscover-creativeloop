using Assets.Scripts.Observer;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static float distantScaleToSum = 0.05f;
    public static float distantYToSum = 0.01f;

    public static float speedFactor = 1.5f;
    public static float speedScaleToSum = .01f * speedFactor;
    public static float speedYToSum = .01f * speedFactor;
    public static float speedXToSum = .01f * speedFactor;

    public static Subject distantSubject = new Subject();
    public static Subject speedSubject = new Subject();

    [SerializeField]
    private GameObject earth;
    [SerializeField]
    private SceneFader sceneFader;

    private float initSpeedTime = .01f;
    private float targetSpeedTime;

    private float initDistantTime = 1f;
    private float targetDistantTime;

    private int targetToIncreaseScale = 5;
    private int countToIncreaseScale = 0;

    private void Awake()
    {
        targetSpeedTime = initSpeedTime;
        targetDistantTime = initDistantTime;
    }

    private void Update()
    {
        targetDistantTime -= Time.deltaTime;

        if(targetDistantTime <= 0.0f)
        {
            distantSubject.Notify();
            targetDistantTime = initDistantTime;
            
            countToIncreaseScale++;
            if(targetToIncreaseScale == countToIncreaseScale)
            {
                distantScaleToSum *= 1.1f;
                countToIncreaseScale = 0;
            }
        }

        targetSpeedTime -= Time.deltaTime;

        if(targetSpeedTime <= 0.0f)
        {
            speedSubject.Notify();
            targetSpeedTime = initSpeedTime;
        }

        if (earth.transform.localScale.x > 19f)
        {
            GameEnd();
        }
    }

    public void GameOver()
    {
        sceneFader.FadeTo("Retry");
    }

    private void GameEnd()
    {
        sceneFader.FadeTo("End");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(new Vector3(Screen.width / 2 * -1, 2.5f), new Vector3(Screen.width, 2.5f));
    }
}
