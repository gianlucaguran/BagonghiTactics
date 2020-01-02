
using UnityEngine;

namespace Shared.Messaging
{
    public class Message
    {
        public Message()
        {
            m_param = null;
            m_delay = 0.0f;
        }

        int m_group;
        int m_type;
        object m_param;
        float m_delay;

        public void Setup (int i_group , int i_type, object i_param)
        {
            m_group = i_group;
            m_type = i_type;
            m_param = i_param;
        }

        public void SetupDelayed(int i_group, int i_type, object i_param, float i_delay)
        {
            Debug.Assert(0.0f <= i_delay, "Should not set negative delay");

            this.Setup(i_group, i_type, i_param);

            m_delay = i_delay;
        }
    }
}