using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance{ get { return instance; } }

    //a rapaziada precisa dar esse awake
    protected virtual void Awake() {
        if (instance !=null && gameObject != null) {
            Destroy(this.gameObject);
        } else { 
            instance = (T)this;
        }

        if (!gameObject.transform.parent) {
            DontDestroyOnLoad(gameObject);
        }
        
    }

}
