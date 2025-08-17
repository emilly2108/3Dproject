using UnityEngine;

public class QuizUIManager : MonoBehaviour
{
  
    public bool AllQuizInactive
    {
        get
        {
            foreach (Transform child in transform) 
            {
                foreach (Transform grandChild in child) 
                {
                    if (grandChild.gameObject.activeSelf)
                        return false;
                }
            }
            return true;
        }
    }
}
