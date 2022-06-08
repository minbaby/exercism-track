using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        // ushort
        // short
        // int
        // long
        byte _t = reading switch
        {
            >= 4_294_967_296 and <= 9_223_372_036_854_775_807 => 256 - sizeof(long),
            >= 2_147_483_648 and <= 4_294_967_295 => sizeof(uint),
            >= 65_536 and <= 2_147_483_647 => 256 - sizeof(int),
            >= 0 and <= 65_535 => sizeof(ushort),
            >= -32_768 and <= -1 => 256 - sizeof(short),
            >= -2_147_483_648 and <= -32_769 => sizeof(int),
            >= -9_223_372_036_854_775_808 and <= -2_147_483_649 => sizeof(long),
        };

        var arr = new byte[9];
        arr[0] = _t;

        var x = reading;
        var index = 1;

        if (x < 0)
        {
            arr[index] = 0xff;
            index++;
        }

        while (x >= 0xff)
        {
            arr[index] = ((byte)(x % 0x100));
            x /= 0x100;
            index++;
        }
        arr[index] = ((byte)x);

        return arr;
    }

    public static long FromBuffer(byte[] buffer)
    {
        throw new NotImplementedException("Please implement the static TelemetryBuffer.FromBuffer() method");
    }
}
