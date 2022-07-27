using UnityEngine;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    // Start is called before the first frame update
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }    
}
