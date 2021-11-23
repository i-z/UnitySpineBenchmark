using Spine.Unity;
using UnityEngine;

public class AnimationOptimizer: MonoBehaviour {
    private void Start() {
        SkeletonAnimation a;
        if (TryGetComponent(out a)) {
            a.UpdateMode = UpdateMode.OnlyAnimationStatus;
            a.useClipping = false;
            a.immutableTriangles = true;
            a.singleSubmesh = true;
        }
    }
}
