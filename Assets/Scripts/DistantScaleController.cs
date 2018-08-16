using Assets.Scripts.Observer;
using UnityEngine;

public class DistantScaleController : Observer {

    private void Awake()
    {
        GameController.distantSubject.AddObserver(this);
    }

    public override void OnNotify()
    {
        transform.position = transform.position - new Vector3(0f, GameController.distantYToSum);
        transform.localScale = transform.localScale + new Vector3(GameController.distantScaleToSum, GameController.distantScaleToSum);
    }
}
