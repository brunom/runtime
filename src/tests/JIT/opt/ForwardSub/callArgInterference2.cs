// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;
// Generated by Fuzzlyn v1.5 on 2022-02-06 17:06:01
// Run on X86 Windows
// Seed: 7854701479455767355
// Reduced from 192.2 KiB to 0.6 KiB in 00:03:51
// Debug: Outputs 0
// Release: Outputs 1
public struct S0
{
    public uint F0;
    public ulong F2;
    public int F3;
    public ushort F6;
    public int F8;
    public static int s_result;

    public int[] M35(int arg0, int[] arg1)
    {
        this.F3 = arg1[0];
        ForwardSubCallArgInterference2.s_rt.WriteLine(arg0);
        s_result = arg0 + 100;
        return arg1;
    }
}

public class ForwardSubCallArgInterference2
{
    public static IRT s_rt;
    public static int[][] s_28 = new int[][]{new int[]{1}};
    [Fact]
    public static int TestEntryPoint()
    {
        s_rt = new C();
        var vr3 = new S0();
        var vr6 = vr3.F3;
        var vr13 = s_28[0];
        var vr12 = vr3.M35(0, vr13);
        vr3.M35(vr6, vr12);
        return S0.s_result;
    }
}

public interface IRT
{
    void WriteLine<T>(T value);
}

public class C : IRT
{
    public void WriteLine<T>(T value)
    {
        System.Console.WriteLine(value);
    }
}