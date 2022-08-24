using _Watchm1.Helpers.Singleton;
using UnityEngine;

namespace _Watchm1.SceneManagment.Manager
{
    public enum LevelState
    {
        loading,
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
            currentState = LevelState.loading;
        }


        public bool PlayModeActive()
        {
            if (currentState == LevelState.Fail ||
                currentState == LevelState.loading ||
                currentState == LevelState.Finished
                || currentState == LevelState.Success ||
                currentState == LevelState.waitingOnfirstTouch)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
