using System.Collections.Generic;
using UnityEngine;

namespace Shared.Messaging
{
    public class MessageQueue : MonoBehaviour
    {

        //singleton
        private static MessageQueue m_instance = null;
        public static MessageQueue Get { get { return m_instance; } private set { m_instance = value; } }
        //

        List<IMessageListener> m_listeners;
        List<Message> m_messages;

        public void Awake()
        {
            Get = this;
            m_listeners = new List<IMessageListener>();
            m_messages = new List<Message>();
        }

        public void AddListener(IMessageListener i_listener)
        {
            Debug.Assert(null != m_listeners, "List of listeners is null");
            Debug.Assert(null != i_listener, "A null listener is being added");

            if (null!= m_listeners 
                && null != i_listener)
            {
                m_listeners.Add(i_listener);
            }
        }

        public void RemoveListener(IMessageListener i_listener)
        {
            Debug.Assert(null != m_listeners, "List of listeners is null");
            Debug.Assert(null != i_listener, "A null listener is being added");

            if (null != m_listeners
                && null != i_listener)
            {
                m_listeners.Remove(i_listener);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}