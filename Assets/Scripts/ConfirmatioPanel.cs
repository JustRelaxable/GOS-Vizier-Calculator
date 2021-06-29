using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ConfirmatioPanel : MonoBehaviour
{
    VizierCardDataContainer vizierToDelete;
    public GameObject panel;
    Toggle vizierToggle;

    private void Start()
    {
        VizierCardReader.vizierSelected.AddListener(LoadVizier);
    }

    public void LoadVizier(VizierCard vizier, Toggle toggle)
    {
        vizierToggle = toggle;
        panel.SetActive(true);
        vizierToDelete = MyVizierList.myViziers.Single(v => v.vizierName == vizier.vizierName);
    }

    public void ApplyChanges()
    {
        MyVizierList.myViziers.Remove(vizierToDelete);
        MyVizierList.SaveVizier();
    }

    public void CancelOperation()
    {
        vizierToggle.isOn = true;
    }
}
