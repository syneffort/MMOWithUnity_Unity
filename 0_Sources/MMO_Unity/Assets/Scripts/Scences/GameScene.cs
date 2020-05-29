using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    class CoroutineTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 1000000; i++)
            {
                if (i % 10000 == 0)
                    yield return i;
            }
        }
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Inven>();

        CoroutineTest test = new CoroutineTest();
        foreach (int t in test)
        {
            Debug.Log(t);
        }
    }

    public override void Clear()
    {
        
    }

}
