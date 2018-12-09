// Copyright (c) 2018, Gustave M. - gus33000.me - @gus33000
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Bluepill
{
    public static class NativeMethods
    {
        public const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        public const int TOKEN_QUERY = 0x00000008;
        public const int SE_PRIVILEGE_ENABLED = 0x00000002;
        public const string SE_RESTORE_NAME = "SeRestorePrivilege";
        public const string SE_BACKUP_NAME = "SeBackupPrivilege";
        public const uint HKEY_USERS = 0x80000003;
        
        [StructLayout(LayoutKind.Sequential)]
        public struct LUID
        {
            public int LowPart;
            public int HighPart;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct TOKEN_PRIVILEGES
        {
            public LUID Luid;
            public int Attributes;
            public int PrivilegeCount;
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int OpenProcessToken(int ProcessHandle, int DesiredAccess, ref int tokenhandle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetCurrentProcess();

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int LookupPrivilegeValue(string lpsystemname, string lpname, [MarshalAs(UnmanagedType.Struct)] ref LUID lpLuid);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int AdjustTokenPrivileges(int tokenhandle, int disableprivs, [MarshalAs(UnmanagedType.Struct)]ref TOKEN_PRIVILEGES Newstate, int bufferlength, int PreivousState, int Returnlength);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int RegLoadKey(uint hKey, string lpSubKey, string lpFile);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int RegUnLoadKey(uint hKey, string lpSubKey);

    }
}
