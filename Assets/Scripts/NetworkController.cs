using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


public class NetworkController : MonoBehaviour {
	private const int UDP_PORT = 8085;
	private Socket udpSock;
	private byte[] buffer;

    public event Action<int, string, byte> OnBytesReceived; 

	void Starter(object target){
		//Setup the socket and message buffer
		udpSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		udpSock.Bind(new IPEndPoint(IPAddress.Any, UDP_PORT));
		buffer = new byte[1024];
		
		//Start listening for a new message.
		Debug.Log ("Waiting for UDP connections...");
		EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
		udpSock.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref newClientEP, DoReceiveFrom, udpSock);
	}
	
	private void DoReceiveFrom(IAsyncResult iar){
		try{
			//Get the received message.
			Socket recvSock = (Socket)iar.AsyncState;
			EndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);
			int msgLen = recvSock.EndReceiveFrom(iar, ref clientEP);
			byte[] localMsg = new byte[msgLen];
			Array.Copy(buffer, localMsg, msgLen);
			
			//Start listening for a new message.
			EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
			udpSock.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref newClientEP, DoReceiveFrom, udpSock);
			
			//Handle the received message
			Array.Reverse(localMsg, 0, 4);
			int playerId = BitConverter.ToInt32(localMsg, 0);
			string playerName = System.Text.Encoding.ASCII.GetString(localMsg, 4, 3);
			byte playerAction = localMsg[7];
			Debug.Log(String.Format("Received playerId={0}, name={1}, action={2} ({3} bytes) from {4}:{5}",
			                        playerId, playerName, playerAction, msgLen, ((IPEndPoint)clientEP).Address, ((IPEndPoint)clientEP).Port));

            OnBytesReceived(playerId, playerName, playerAction);

		    //Do other, more interesting, things with the received message.
		} catch (ObjectDisposedException){
			//expected termination exception on a closed socket.
			// ...I'm open to suggestions on a better way of doing this.
		}
	}
	
	void Start () {
		ThreadPool.QueueUserWorkItem (Starter);
	}
}
