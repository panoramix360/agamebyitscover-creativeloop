using Assets.Scripts.Observer;
using UnityEngine;

public class SpeedScaleController : Observer {

    public float randomSpeedX;

    private float speedY;

    private void Awake()
    {
        GameController.speedSubject.AddObserver(this);

        randomSpeedX = Random.Range(0.005f, GameController.speedXToSum);
        speedY = GameController.speedYToSum;
    }

    public override void OnNotify()
    {
        if (transform.localScale.x > 2f)
        {
            speedY += 0.0005f;
        }
        transform.position = transform.position - new Vector3(randomSpeedX * Mathf.Sign(transform.position.x) * -1, speedY);
        transform.localScale = transform.localScale + new Vector3(GameController.speedScaleToSum, GameController.speedScaleToSum);
    }
}
