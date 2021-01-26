using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerMovement))]
public class PlayerMovementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("SpeedBoost Player"))
        {
            Debug.Log((PlayerMovement)target);
            ((PlayerMovement)target).speedBooster = true;
        }
        if (GUILayout.Button("InvincibleBoost Player"))
        {
            Debug.Log((PlayerMovement)target);
            ((PlayerMovement)target).invincibleBooster = true;
        }
        if (GUILayout.Button("CoinBoost Player"))
        {
            Debug.Log((PlayerMovement)target);
            ((PlayerMovement)target).coinBooster = true;
        }
        if (GUILayout.Button("MovementSwapBoost Player"))
        {
            Debug.Log((PlayerMovement)target);
            ((PlayerMovement)target).ToggleMovement();
        }

    }

}
