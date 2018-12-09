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
using System.Text;

namespace Bluepill
{
    public static class Utils
    {
        public static int EnablePrivileges()
        {
            int token = 0;
            int retval = 0;
            NativeMethods.TOKEN_PRIVILEGES TP = new NativeMethods.TOKEN_PRIVILEGES();
            NativeMethods.TOKEN_PRIVILEGES TP2 = new NativeMethods.TOKEN_PRIVILEGES();
            NativeMethods.LUID RestoreLuid = new NativeMethods.LUID();
            NativeMethods.LUID BackupLuid = new NativeMethods.LUID();
            retval = NativeMethods.OpenProcessToken(NativeMethods.GetCurrentProcess(), NativeMethods.TOKEN_ADJUST_PRIVILEGES | NativeMethods.TOKEN_QUERY, ref token);
            retval = NativeMethods.LookupPrivilegeValue(null, NativeMethods.SE_RESTORE_NAME, ref RestoreLuid);
            retval = NativeMethods.LookupPrivilegeValue(null, NativeMethods.SE_BACKUP_NAME, ref BackupLuid);
            TP.PrivilegeCount = 1;
            TP.Attributes = NativeMethods.SE_PRIVILEGE_ENABLED;
            TP.Luid = RestoreLuid;
            TP2.PrivilegeCount = 1;
            TP2.Attributes = NativeMethods.SE_PRIVILEGE_ENABLED;
            TP2.Luid = BackupLuid;
            retval = NativeMethods.AdjustTokenPrivileges(token, 0, ref TP, 1024, 0, 0);
            retval = NativeMethods.AdjustTokenPrivileges(token, 0, ref TP2, 1024, 0, 0);
            return retval;
        }

        public static int LoadRegistryHiveIntoHKU(string filename, string mountname)
        {
            return NativeMethods.RegLoadKey(NativeMethods.HKEY_USERS, mountname, filename);
        }

        public static int UnloadRegistryHiveFromHKU(string mountname)
        {
            return NativeMethods.RegUnLoadKey(NativeMethods.HKEY_USERS, mountname);
        }
    }
}
