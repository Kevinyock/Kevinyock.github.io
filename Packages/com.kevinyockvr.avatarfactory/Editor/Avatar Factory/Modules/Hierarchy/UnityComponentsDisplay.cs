using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

namespace Kevin.VRChat.Base.Editor
{
    // TODO: Add
    // Cloth,
    // Colliders,
    // FlareLayer,
    // Joints,
    // Light,
    // LineRenderer,
    // LookAtConstraint,
    // MeshFilter,
    // MeshRenderer
    // Parent Constraints
    // ParentConstraint
    // ParticleSystemRenderer
    // ParticleSystem
    // PositionConstraint
    // Rigidbody
    // RotationConstraint
    // ScaleConstraint
    // SkinnedMeshRenderer
    // TrailRenderer

    public class UnityComponentsDisplay
    {
        static readonly CommonScripts commonScripts = new();
        public void ToggleGameObject(GameObject gameObject, Rect toggleRect)
        {
            bool activeObject = EditorGUI.Toggle(toggleRect, gameObject.activeSelf);

            gameObject.SetActive(activeObject);
        }

        public void ToggleLight(Light light, Rect toggleRect)
        {   
            GUIContent guiContent = commonScripts.GrabComponentIcon(light, light.GetType());

            if (GUI.Button(toggleRect, guiContent))
            {
                light.enabled = !light.enabled;
            }
        }
        //

        public void ToggleAimConstraint(AimConstraint constraint, Rect toggleRect)
        {

            GUIContent guiContent = commonScripts.GrabComponentIcon(constraint, constraint.GetType());

            if (GUI.Button(toggleRect, guiContent))
            {
                constraint.enabled = !constraint.enabled;
            }
        }

        public void ToggleAnimation(Animation animation, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(animation, animation.GetType());
            if(GUI.Button(toggleRect, guiContent))
            {
                animation.enabled = !animation.enabled;
            }
        }

        public void ToggleAnimator(Animator animator, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(animator, animator.GetType());
            if(GUI.Button(toggleRect,guiContent))
            {
                animator.enabled = !animator.enabled;
            }
        }

        //
        public void ToggleAudioSource(AudioSource audioSource, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(audioSource, audioSource.GetType());
            if(GUI.Button(toggleRect, guiContent))
            {
                audioSource.enabled = !audioSource.enabled;
            }
        }

        public void ToggleCamera(Camera camera, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(camera, camera.GetType());
            if (GUI.Button(toggleRect, guiContent))
            {
                camera.enabled = !camera.enabled;
            }
        }

        public void ToggleMeshRenderer(MeshRenderer meshRenderer, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(meshRenderer, meshRenderer.GetType());
            if (GUI.Button(toggleRect, guiContent))
            {
                meshRenderer.enabled = !meshRenderer.enabled;
            }
        }

        public void ToggleSkinnedMeshRenderer(SkinnedMeshRenderer skinnedMeshRenderer, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(skinnedMeshRenderer, skinnedMeshRenderer.GetType());
            if (GUI.Button(toggleRect, guiContent))
            {
                skinnedMeshRenderer.enabled = !skinnedMeshRenderer.enabled;
            }
        }


        /// <summary>
        /// Toggle Box Collider
        /// </summary>
        /// <param name="collider">The Collider component</param>
        /// <param name="toggleRect"></param>
        public void ToggleBoxCollider(BoxCollider collider, Rect toggleRect)
        {
            GUIContent guiContent = commonScripts.GrabComponentIcon(collider, collider.GetType());
            if(GUI.Button(toggleRect, guiContent))
            {
                collider.enabled = !collider.enabled;
            }
        }
    }
}