using _Watchm1.Helpers.Singleton;
using UnityEngine;

namespace _Watchm1.SceneManagment.Manager
{
    public enum LevelState
    {
        waitingOnfirstTouch,
        onFirstTouchDone,
        Start,
        BeforeSuccess,
        Success,
        BeforeFail,
        Fail,
        Finished
    }
    public class LevelManager : Singleton<LevelManager>
    {
        [HideInInspector]public LevelState currentState;
        // Start is called before the first frame update
        void Start()
        {
            currentState = LevelState.waitingOnfirstTouch;
        }
        
    }
}
