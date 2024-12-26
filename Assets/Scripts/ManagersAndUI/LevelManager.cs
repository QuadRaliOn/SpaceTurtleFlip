using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator transition;

    public void RestartAfterTime(float time=1f)
    {
        StartCoroutine(Restart(time));
    }

    private IEnumerator Restart(float time)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelAfterTime(float time = 1f)
    {
        StartCoroutine(NextLevel(time));
    }

    public IEnumerator NextLevel(float time)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelByIndex(int index = 0)
    {
        StartCoroutine(LoadLevelByIndexCourutine(index,1f));
    }

    public IEnumerator LoadLevelByIndexCourutine(int index,float time)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(index);
    }
}
