// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Sharing.Tests
{
    /// <summary>
    /// GameObject transforms are sent and received in the local coordinate space of the GameObject this component is on.
    /// </summary>
    public class ObjectSharingManager : MonoBehaviour, IInputClickHandler
    {
        public GameObject gameObj;
        public AudioSource Audiosource;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Transform the obj position and rotation from world space into local space
            //Vector3 objPosition = transform.InverseTransformPoint(gameObj.transform.position);
            Vector3 objPosition = gameObj.transform.localPosition;
            Vector3 objScale = gameObj.transform.localScale;
            Quaternion objRotation = gameObj.transform.localRotation;
            CustomMessages.Instance.SendGameObjectTransform(objPosition, objScale, objRotation);
            if (!Audiosource.isPlaying)
            {
                Audiosource.Play();
            }
        }

        private void Start()
        {
            CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.GameObjectTransform] = UpdateGameObjectTransform;
        }
        /// <summary>
        /// Called when a Client sends a object transform.
        /// </summary>
        /// <param name="msg"></param>
        private void UpdateGameObjectTransform(NetworkInMessage msg)
        {
            // Parse the message
            long userID = msg.ReadInt64();

            Vector3 objPos = CustomMessages.Instance.ReadVector3(msg);
            Vector3 objScale = CustomMessages.Instance.ReadVector3(msg);
            Quaternion objRot = CustomMessages.Instance.ReadQuaternion(msg);
            gameObj.transform.localPosition = objPos;
            gameObj.transform.localScale = objScale;
            gameObj.transform.localRotation = objRot;
        }
    }
}