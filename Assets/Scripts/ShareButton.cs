using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareButton : MonoBehaviour
{
    public void CallChooser()
    {
        IntentManager.instance.ShareViziers();
    }
}
