using UnityEditor;
using UnityEngine;
using TextEditor = UnityEditor.UI.TextEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(EmojiText), true)]
public class EmojiTextEditor : TextEditor
{
    private SerializedProperty m_conten;

    protected override void OnEnable()
    {
        base.OnEnable();
        m_conten = serializedObject.FindProperty("emojiContent");
        var tar = (EmojiText)target;
        if (tar.canvas != null)
            tar.canvas.additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord1;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (m_conten != null)
            EditorGUILayout.PropertyField(m_conten);
        serializedObject.ApplyModifiedProperties();
    }
}
