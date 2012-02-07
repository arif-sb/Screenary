using System;
using System.IO;

namespace FreeRDP
{
	public class FrameMarkerCommand : SurfaceCommand
	{
		private UInt16 frameAction;
		private UInt32 frameId;
		
		public FrameMarkerCommand()
		{
		}
		
		public override void Read(BinaryReader fp)
		{
			frameAction = fp.ReadUInt16(); /* frameAction */
			frameId = fp.ReadUInt32(); /* frameId */
		}
		
		public override byte[] Write()
		{
			byte[] buffer = new byte[2 + 6];
			BinaryWriter s = new BinaryWriter(new MemoryStream(buffer));
			
			s.Write(CmdType);
			
			s.Write(frameAction);
			s.Write(frameId);
			
			return buffer;
		}
		
		public override UInt16 GetCmdType()
		{
			return CMDTYPE_FRAME_MARKER;
		}
		
		public override void Execute(SurfaceReceiver receiver)
		{
			receiver.window.ProcessUpdates(false);	
		}
	}
}

