/**
 * Screenary: Real-Time Collaboration Redefined.
 * Session Channel
 *
 * Copyright 2011-2012 Terri-Anne Cambridge <tacambridge@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;
using System.Threading;
using System.Collections;

namespace Screenary
{
	public abstract class SessionChannel : Channel
	{
		protected Queue queue;
		protected Thread thread;
		protected TransportClient transport;
		
		public const UInt16 PDU_CHANNEL_SESSION = 0x0000;
		
		public const byte PDU_SESSION_JOIN_REQ = 0x01;
		public const byte PDU_SESSION_LEAVE_REQ = 0x02;
		public const byte PDU_SESSION_CREATE_REQ = 0x03;
		public const byte PDU_SESSION_TERM_REQ = 0x04;
		public const byte PDU_SESSION_AUTH_REQ = 0x05;
		public const byte PDU_SESSION_REMOTE_ACCESS_REQ = 0x06;
		public const byte PDU_SESSION_REMOTE_ACCESS_PERMISSION_REQ = 0x07;
		public const byte PDU_SESSION_TERM_REMOTE_ACCESS_REQ = 0x08;
		public const byte PDU_SESSION_JOIN_RSP = 0x81;
		public const byte PDU_SESSION_LEAVE_RSP = 0x82;
		public const byte PDU_SESSION_CREATE_RSP = 0x83;
		public const byte PDU_SESSION_TERM_RSP = 0x84;
		public const byte PDU_SESSION_AUTH_RSP = 0x85;
		public const byte PDU_SESSION_PARTICIPANTS_RSP = 0x86;	
		public const byte PDU_SESSION_NOTIFICATION_RSP = 0x87;
		public const byte PDU_SESSION_FIRST_NOTIFICATION_RSP = 0x88;
		public const byte PDU_SESSION_REMOTE_ACCESS_RSP = 0x89;
		public const byte PDU_SESSION_REMOTE_ACCESS_PERMISSION_RSP = 0x90;
		
		public const byte SESSION_FLAGS_PASSWORD_PROTECTED = 0x01;
						
		public SessionChannel()
		{
			queue = new Queue();
		}
		
		public override UInt16 GetChannelId()
		{
			return PDU_CHANNEL_SESSION;
		}
		
		public override abstract void OnOpen();
		public override abstract void OnClose();
		
		public override abstract void OnRecv(byte[] buffer, byte pduType);
		
		public override void Send(byte[] buffer, byte pduType)
		{
			transport.SendPDU(buffer, PDU_CHANNEL_SESSION, pduType);
		}						
	}
}

