using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    Coroutine co;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Inven>();

        co = StartCoroutine("ExplodeAfterSecond", 4.0f);
        StartCoroutine("CoStopExlode", 2.0f);
    }

    IEnumerator ExplodeAfterSecond(float second)
    {
        Debug.Log("Explode Enter");
        yield return new WaitForSeconds(second);
        Debug.Log("Explode Executed");
        co = null;
    }

    IEnumerator CoStopExlode(float second)
    {
        Debug.Log("Stop Enter");
        yield return new WaitForSeconds(second);
        Debug.Log("Stop Executed");
        if (co != null)
        {
            StopCoroutine(co);
            co = null;
        }
    }

    public override void Clear()
    {
        
    }

}
