using System;
using System.Linq;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte _t = reading switch
        {
            >= 4_294_967_296 and <= 9_223_372_036_854_775_807 => 256 - sizeof(long), // 0xF8, -8
            >= 2_147_483_648 and <= 4_294_967_295 => sizeof(uint), // 4
            >= 65_536 and <= 2_147_483_647 => 256 - sizeof(int), // 0xFC, -4
            >= 0 and <= 65_535 => sizeof(ushort), // 2
            >= -32_768 and <= -1 => 256 - sizeof(short), // FE, -2
            >= -2_147_483_648 and <= -32_769 => 256 - sizeof(int), // 0xFC -4
            >= -9_223_372_036_854_775_808 and <= -2_147_483_649 => 256 - sizeof(long), // 0xF8 -8
        };

        var index = 0;
        var arr = new byte[9];
        arr[index++] = _t;

        byte[] buffer = new byte[0];

        if (reading >= 0)
        {
            buffer = BitConverter.GetBytes(reading);
        }
        else
        {
            switch (arr[0])
            {
                case 0xFE:
                    buffer = BitConverter.GetBytes((short)reading);
                    break;
                case 0xFC:
                    buffer = BitConverter.GetBytes((int)reading);
                    break;
                case 0xF8:
                    buffer = BitConverter.GetBytes((long)reading);
                    break;
            }
        }

        for (int i = 0; i < buffer.Length; i++)
        {
            arr[i + 1] = buffer[i];
        }
        return arr;
    }

    public static long FromBuffer(byte[] buffer)
    {
        switch (buffer[0])
        {
            case 2:
                return BitConverter.ToUInt16(buffer, 1);
            case 4:
                return BitConverter.ToUInt32(buffer, 1);
            case 8:
                return BitConverter.ToInt64(buffer, 1);
            case 0xFE: // -2
                buffer[0] = (byte) (256 - buffer[0]);
                return BitConverter.ToInt16(buffer, 1);
            case 0xFC:// -4
                buffer[0] = (byte)(256 - buffer[0]);
                return BitConverter.ToInt32(buffer, 1);
            case 0xF8: // -8
                buffer[0] = (byte)(256 - buffer[0]);
                return BitConverter.ToInt64(buffer, 1);
            default:
                return 0;
        }

    }
}
