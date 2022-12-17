using UnityEngine;
using UnityEngine.UI;

/**
 * Bar can be built up by holding space. If the bar fills completely, it will
 * begin to decrease. Releasing space will save the bar's value and freeze it.
 * The bar's state can be reset via Reset().
 */
public class BuildUpBar : MonoBehaviour
{
    Slider bar;
    BuildStatus buildStatus = BuildStatus.Idle;
    public float BarValueAtRelease { get; private set; }

    void Start()
    {
        bar = GetComponent<Slider>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && IsIdle())
            buildStatus = BuildStatus.BuildingUp;

        if (IsBuildingUp() || IsEmptying())
        {
            float barDelta = 0f;
            if (IsBuildingUp()) barDelta = 1f;
            else if (IsEmptying()) barDelta = -1f;
            bar.value += barDelta * Time.deltaTime;

            if (Input.GetKeyUp("space"))
            {
                buildStatus = BuildStatus.Done;
                BarValueAtRelease = bar.value;
            }

            if (bar.value == bar.maxValue) buildStatus = BuildStatus.Emptying;
            else if (bar.value == bar.minValue) buildStatus = BuildStatus.Done;
        }
    }

    bool IsBuildingUp() { return buildStatus == BuildStatus.BuildingUp; }
    bool IsEmptying() { return buildStatus == BuildStatus.Emptying; }
    bool IsIdle() { return buildStatus == BuildStatus.Idle; }
    bool IsDone() { return buildStatus == BuildStatus.Done; }

    public void Reset()
    {
        buildStatus = BuildStatus.Idle;
        bar.value = bar.minValue;
    }
}

enum BuildStatus
{
    Idle,
    BuildingUp,
    Emptying,
    Done
}

