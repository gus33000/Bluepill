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

using Microsoft.Win32;
using System;
using System.IO;

namespace Bluepill
{
    class Program
    {
        private static string[] guids = new string[]
        {
            "41579D76-09BA-4ABD-A49A-A2335B9CB706",
            "6214949A-5BE4-4568-A383-E2126CFDCF9C",
            "9D80FD12-3D92-40FE-AF28-4F0E41372D2C",
            "BE2CDE86-D165-4107-A26A-A102AFC1A638",
            "D3F37E19-619D-4F38-8D4B-72AE35626C9E",
            "{20D04FE0-3AEA-1069-A2D8-08002B30309D}",
            "{21EC2020-3AEA-1069-A2DD-08002B30309D}",
            "{2559A1F1-21D7-11D4-BDAF-00C04F60B9F0}",
            "{2559A1F3-21D7-11D4-BDAF-00C04F60B9F0}",
            "{2559A1F4-21D7-11D4-BDAF-00C04F60B9F0}",
            "{2559A1F5-21D7-11D4-BDAF-00C04F60B9F0}",
            "{3080F90D-D7AD-11D9-BD98-0000947B0257}",
            "{35786D3C-B075-49B9-88DD-029876E11C01}",
            "{3EEEEFEB-B964-4E74-B7E7-B1C7C19C1AB0}",
            "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}",
            "{59031A47-3F72-44A7-89C5-5595FE6B30EE}",
            "{640167B4-59B0-47A6-B335-A6B3C0695AEA}",
            "{756AEB4E-2A05-4FE6-915E-D7F5F124ABD3}",
            "{865E5E76-AD83-4DCA-A109-50DC2113CE9A}",
            "{871C5380-42A0-1069-A2EA-08002B30309D}",
            "{90BCFBC2-E8F5-4DD3-91B2-7106A4D0F47F}",
            "{9113A02D-00A3-46B9-BC5F-9C04DADDD5D7}",
            "{A5181F28-5A04-4DBE-A8F6-EEBD7FE228F2}",
            "{B155BDF8-02F0-451E-9A26-AE317CFD7779}",
            "{D0BF7CA7-ECF5-4BAA-945F-8D2E3FB531BE}",
            "{DFC187C7-EA34-482F-AB17-FD4FD8CE3946}",
            "{ED228FDF-9EA8-4870-83B1-96B02CFE0D52}"
        };

        static void Main(string[] args)
        {
            Install();
        }

        public static void Install()
        {
            RegistryKey keyExplorer;
            string[] userHives = Registry.Users.GetSubKeyNames();
            foreach (string oUserHive in userHives)
            {
                try
                {
                    Registry.Users.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand");
                    keyExplorer = Registry.Users.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand", true);
                    keyExplorer.SetValue("CanHasSuperbar", 1, RegistryValueKind.DWord);
                    keyExplorer.Close();

                    keyExplorer = Registry.Users.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true);
                    keyExplorer.SetValue("EnableCHS", 1, RegistryValueKind.DWord);
                    keyExplorer.Close();

                    foreach (var guid in guids)
                    {
                        Registry.Users.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}");
                        Registry.Users.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}\ShellFolder");
                        keyExplorer = Registry.Users.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}\ShellFolder", true);
                        keyExplorer.SetValue("Attributes", -1609564156, RegistryValueKind.DWord);
                        keyExplorer.Close();
                    }
                }
                catch { }
            }

            string[] profileArray;
            using (RegistryKey keyProfileList = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList"))
                profileArray = keyProfileList.GetSubKeyNames();

            Utils.EnablePrivileges();
            foreach (string oProfile in profileArray)
            {
                if (!Array.Exists(userHives, x => x == oProfile))
                {
                    RegistryKey keyProfile = Registry.LocalMachine.OpenSubKey($@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\{oProfile}");
                    if (Array.Exists(keyProfile.GetValueNames(), x => x == "ProfileImagePath"))
                    {
                        string imagePath = keyProfile.GetValue("ProfileImagePath") as string;
                        Utils.LoadRegistryHiveIntoHKU($@"{imagePath}\NTuser.dat", oProfile);
                        try
                        {
                            Registry.Users.CreateSubKey($@"{oProfile}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand");
                            keyExplorer = Registry.Users.OpenSubKey($@"{oProfile}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand", true);
                            keyExplorer.SetValue("CanHasSuperbar", 1, RegistryValueKind.DWord);
                            keyExplorer.SetValue("EnableCHS", 1, RegistryValueKind.DWord);
                            keyExplorer.Close();

                            foreach (var guid in guids)
                            {
                                Registry.Users.CreateSubKey($@"{oProfile}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}");
                                Registry.Users.CreateSubKey($@"{oProfile}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}\ShellFolder");
                                keyExplorer = Registry.Users.OpenSubKey($@"{oProfile}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}\ShellFolder", true);
                                keyExplorer.SetValue("Attributes", -1609564156, RegistryValueKind.DWord);
                                keyExplorer.Close();
                            }
                        }
                        catch { }
                        Utils.UnloadRegistryHiveFromHKU(oProfile);
                    }
                    keyProfile.Close();
                }
            }

            string documentsPath = Environment.GetEnvironmentVariable("PUBLIC");
            DirectoryInfo dirInfo = new DirectoryInfo(documentsPath);
            string userImagePath = $@"{dirInfo.Parent.FullName}\Default\NTuser.dat";
            Utils.LoadRegistryHiveIntoHKU(userImagePath, "Default");
            try
            {
                Registry.Users.CreateSubKey($@"Default\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand");
                keyExplorer = Registry.Users.OpenSubKey(@"Default\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand", true);
                keyExplorer.SetValue("CanHasSuperbar", 1, RegistryValueKind.DWord);
                keyExplorer.SetValue("EnableCHS", 1, RegistryValueKind.DWord);
                keyExplorer.Close();

                foreach (var guid in guids)
                {
                    Registry.Users.CreateSubKey($@"Default\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}");
                    Registry.Users.CreateSubKey($@"Default\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}\ShellFolder");
                    keyExplorer = Registry.Users.OpenSubKey($@"Default\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}\ShellFolder", true);
                    keyExplorer.SetValue("Attributes", -1609564156, RegistryValueKind.DWord);
                    keyExplorer.Close();
                }
            }
            catch { }
            Utils.UnloadRegistryHiveFromHKU("Default");

            Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\calculator");
            RegistryKey redpillKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\calculator", true);
            redpillKey.SetValue("EnableNew", 1, RegistryValueKind.DWord);
            redpillKey.Close();

            Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\paint");
            redpillKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\paint", true);
            redpillKey.SetValue("EnableNew", 1, RegistryValueKind.DWord);
            redpillKey.Close();

            Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\StickyNotes");
            redpillKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\StickyNotes", true);
            redpillKey.SetValue("EnableNew", 1, RegistryValueKind.DWord);
            redpillKey.Close();

            Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\wordpad");
            redpillKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\wordpad", true);
            redpillKey.SetValue("EnableNew", 1, RegistryValueKind.DWord);
            redpillKey.Close();
        }

        public static void Uninstall()
        {
            RegistryKey keyExplorer;
            string[] userHives = Registry.Users.GetSubKeyNames();
            foreach (string oUserHive in userHives)
            {
                try
                {
                    keyExplorer = Registry.Users.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand", true);
                    keyExplorer.DeleteValue("CanHasSuperbar", false);
                    keyExplorer.Close();

                    keyExplorer = Registry.Users.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true);
                    keyExplorer.DeleteValue("EnableCHS", false);
                    keyExplorer.Close();

                    foreach (var guid in guids)
                        Registry.Users.DeleteSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}", false);
                }
                catch { }
            }

            string[] profileArray;
            using (RegistryKey keyProfileList = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList"))
                profileArray = keyProfileList.GetSubKeyNames();

            Utils.EnablePrivileges();
            foreach (string oProfile in profileArray)
            {
                if (!Array.Exists(userHives, x => x == oProfile))
                {
                    RegistryKey keyProfile = Registry.LocalMachine.OpenSubKey($@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\{oProfile}");
                    if (Array.Exists(keyProfile.GetValueNames(), x => x == "ProfileImagePath"))
                    {
                        string imagePath = keyProfile.GetValue("ProfileImagePath") as string;
                        Utils.LoadRegistryHiveIntoHKU($@"{imagePath}\NTuser.dat", oProfile);
                        try
                        {
                            Registry.Users.CreateSubKey($@"{oProfile}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand");
                            keyExplorer = Registry.Users.OpenSubKey($@"{oProfile}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand", true);
                            keyExplorer.DeleteValue("CanHasSuperbar", false);
                            keyExplorer.DeleteValue("EnableCHS", false);
                            keyExplorer.Close();

                            foreach (var guid in guids)
                                Registry.Users.DeleteSubKey($@"{oProfile}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}", false);
                        }
                        catch { }
                        Utils.UnloadRegistryHiveFromHKU(oProfile);
                    }
                    keyProfile.Close();
                }
            }

            string documentsPath = Environment.GetEnvironmentVariable("PUBLIC");
            DirectoryInfo dirInfo = new DirectoryInfo(documentsPath);
            string userImagePath = $@"{dirInfo.Parent.FullName}\Default\NTuser.dat";
            Utils.LoadRegistryHiveIntoHKU(userImagePath, "Default");
            try
            {
                Registry.Users.CreateSubKey($@"Default\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand");
                keyExplorer = Registry.Users.OpenSubKey(@"Default\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand", true);
                keyExplorer.DeleteValue("CanHasSuperbar", false);
                keyExplorer.DeleteValue("EnableCHS", false);
                keyExplorer.Close();

                foreach (var guid in guids)
                    Registry.Users.DeleteSubKey($@"Default\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}", false);
            }
            catch { }
            Utils.UnloadRegistryHiveFromHKU("Default");

            Registry.LocalMachine.DeleteSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\calculator", false);
            Registry.LocalMachine.DeleteSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\paint", false);
            Registry.LocalMachine.DeleteSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\StickyNotes", false);
            Registry.LocalMachine.DeleteSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\wordpad", false);
        }
    }
}
