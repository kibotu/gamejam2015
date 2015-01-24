using System;
using UnityEngine;

public class NetworkHandler : MonoBehaviour
{
    public event Action<int, string, byte> OnBytesReceived; 
}
