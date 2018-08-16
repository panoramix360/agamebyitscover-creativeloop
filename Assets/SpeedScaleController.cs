using Assets.Scripts.Observer;
using UnityEngine;

public class SpeedScaleController : Observer {

    private void Awake()
    {
        GameController.speedSubject.AddObserver(this);
    }

    public override void OnNotify()
    {
        transform.position = transform.position - new Vector3(GameController.speedXToSum * Mathf.Sign(transform.position.x) * -1, GameController.speedYToSum);
        transform.localScale = transform.localScale + new Vector3(GameController.speedScaleToSum, GameController.speedScaleToSum);
    }
}
