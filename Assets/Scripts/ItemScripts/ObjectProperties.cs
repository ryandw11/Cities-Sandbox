using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is to be attached to the properties script of each object.
/// <para>The classes that implement this interface also extend MonoBehaviour.</para>
/// <para>The <see cref="SerObjectProperties"/> are used for serialization of the object property.</para>
/// </summary>
public interface ObjectProperties
{
    /// <summary>
    /// Display the Object Property UI in the inspector.
    /// </summary>
    /// <param name="content">The content GameObject that the Property menu needs to be put in.</param>
    void Display(GameObject content);

    /// <summary>
    /// Get the serialized object properties data.
    /// <para>This is used for when the game is saved.</para>
    /// </summary>
    /// <returns>The Serialized object properties data.</returns>
    SerObjectProperties GetSerializedData();

    /// <summary>
    /// Setup the property from the serialized data.
    /// <para>This is called when the game is loaded from a save file.</para>
    /// </summary>
    /// <param name="serData">The serialized data.</param>
    /// <returns>If the serialized data could be successfully loaded.</returns>
    bool SetupSerialziedData(SerObjectProperties serData);

    /// <summary>
    /// This method handles the duplication of the object.
    /// <para>This is called when the user duplicates the object and the new objects needs to properties set.</para>
    /// </summary>
    /// <param name="objectProperties">The existing object properties.</param>
    void Duplicate(ObjectProperties objectProperties);
}
