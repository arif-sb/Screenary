using System;
using System.Runtime.InteropServices;

namespace FreeRDP
{	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpBounds
	{
		public Int32 left;
		public Int32 top;
		public Int32 right;
		public Int32 bottom;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct BitmapData
	{
		public UInt32 destLeft;
		public UInt32 destTop;
		public UInt32 destRight;
		public UInt32 destBottom;
		public UInt32 width;
		public UInt32 height;
		public UInt32 bitsPerPixel;
		public UInt32 flags;
		public UInt32 bitmapLength;
		public fixed byte bitmapComprHdr[8];
		public IntPtr bitmapDataStream;
		public int compressed;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct BitmapUpdate
	{
		public UInt32 count;
		public UInt32 number;
		public BitmapData* rectangles;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PaletteEntry
	{
		public byte red;
		public byte green;
		public byte blue;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PaletteUpdate
	{
		public UInt32 number;
		public PaletteEntry* entries;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpPalette
	{
		public UInt32 count;
		public PaletteEntry* entries;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct PlaySoundUpdate
	{
		public UInt32 duration;
		public UInt32 frequency;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SurfaceBitsCmd
	{
		public UInt32 cmdType;
		public UInt32 destLeft;
		public UInt32 destTop;
		public UInt32 destRight;
		public UInt32 destBottom;
		public UInt32 bpp;
		public UInt32 codecID;
		public UInt32 width;
		public UInt32 height;
		public UInt32 bitmapDataLength;
		public byte* bitmapData;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct SurfaceFrameMarker
	{
		public UInt32 frameAction;
		public UInt32 frameId;
	}
	
	public unsafe delegate void pBeginPaint(rdpContext* context);
	public unsafe delegate void pEndPaint(rdpContext* context);
	public unsafe delegate void pSetBounds(rdpContext* context, rdpBounds* bounds);
	public unsafe delegate void pSynchronize(rdpContext* context);
	public unsafe delegate void pDesktopResize(rdpContext* context);
	public unsafe delegate void pBitmapUpdate(rdpContext* context, BitmapUpdate* bitmap);
	public unsafe delegate void pPalette(rdpContext* context, PaletteUpdate* palette);
	public unsafe delegate void pPlaySound(rdpContext* context, PlaySoundUpdate* playSound);
	
	public unsafe delegate void pRefreshRect(rdpContext* context, byte count, IntPtr areas);
	public unsafe delegate void pSuppressOutput(rdpContext* context, byte allow, IntPtr area);
	
	public unsafe delegate void pSurfaceCommand(rdpContext* context, IntPtr s);
	public unsafe delegate void pSurfaceBits(rdpContext* context, SurfaceBitsCmd* surfaceBitsCmd);
	
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct rdpUpdate
	{
		public rdpContext* context;
		public fixed UInt32 paddingA[16-1];
		
		public IntPtr BeginPaint;
		public IntPtr EndPaint;
		public IntPtr SetBounds;
		public IntPtr Synchronize;
		public IntPtr DesktopResize;
		public IntPtr BitmapUpdate;
		public IntPtr Palette;
		public IntPtr PlaySound;
		public fixed UInt32 paddingB[32-24];
		
		public rdpPointerUpdate* pointer;
		public rdpPrimaryUpdate* primary;
		public rdpSecondaryUpdate* secondary;
		public rdpAltSecUpdate* altsec;
		public rdpWindowUpdate* window;
		public fixed UInt32 paddingC[48-37];
		
		public IntPtr RefreshRect;
		public IntPtr SuppressOutput;
		public fixed UInt32 paddingD[64-50];
		
		public IntPtr SurfaceCommand;
		public IntPtr SurfaceBits;
		public fixed UInt32 paddingE[80-66];
	}
}

