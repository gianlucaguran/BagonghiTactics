using UnityEngine;

namespace Shared.Messaging
{
    public abstract class IMessageListener : MonoBehaviour
    {
       public int MessageGroup { get; private set; }

        public abstract void ProcessMessage(Message i_message);

        protected void StartListening()
        { }

        protected void StopListening()
        { }
    }
}