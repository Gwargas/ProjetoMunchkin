using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    [SerializeField] private Toggle toggle;

    public void SetMode()
    {
        if(toggle.enabled){
            GameSettings.contraIA = true;
        }
        else{
            GameSettings.contraIA = false;
        }
    }
}
