﻿using Bluepill.UI;
using Microsoft.Win32;
using System;
using System.IO;

namespace Bluepill
{
    public class BPMain
    {
        private BluepillProgressInterface progress;

        public BPMain(BluepillProgressInterface progress)
        {
            this.progress = progress;
        }

        private string[] guids = new string[]
        {
            //
            // Commented out GUIDs are commented because they already
            // are defined earlier. They are given for information
            // purposes only.
            //

            //
            // 6608.1
            //

            // explorer.exe & shell32.dll & 
            // stobject.dll & themecpl.dll & 
            // themeui.dll 6608.1
            "9d80fd12-3d92-40fe-af28-4f0e41372d2c",

            // explorer.exe & shell32.dll 6608.1
            "BE2CDE86-D165-4107-A26A-A102AFC1A638",

            // stobject.dll & themecpl.dll & 
            // themeui.dll 6608.1
            "1CEBB195-B449-4212-962B-2B9F7FB18BD5",

            // explorer.exe 6608.1
            "6214949A-5BE4-4568-A383-E2126CFDCF9C",

            // explorer.exe 6608.1
            "D3F37E19-619D-4F38-8D4B-72AE35626C9E",

            //
            // 6730.1
            //
            
            // explorer.exe & shell32.dll & 
            // stobject.dll & themecpl.dll &
            // themeui.dll 6730.1
            "{A5181F28-5A04-4DBE-A8F6-EEBD7FE228F2}",
            
            // inetcpl.cpl & mshtml.dll &
            // ieframe.dll 6730.1
            "41579D76-09BA-4abd-A49A-A2335B9CB706",
            
            // stobject.dll & themecpl.dll &
            // themeui.dll 6730.1
            "{90BCFBC2-E8F5-4DD3-91B2-7106A4D0F47F}",

            // explorer.exe & shell32.dll 6730.1
            "{DFC187C7-EA34-482F-AB17-FD4FD8CE3946}",

            //
            // 6780.0
            //
            
            // explorer.exe & powercfg.cpl &
            // shell32.dll & stobject.dll & 
            // themecpl.dll & themeui.dll 6780.0
            //"{A5181F28-5A04-4DBE-A8F6-EEBD7FE228F2}",
            
            // inetcpl.cpl & msfeeds.dll &
            // mshtml.dll ieframe.dll 6780.0
            //"41579D76-09BA-4abd-A49A-A2335B9CB706",
            
            // powercfg.cpl & stobject.dll &
            // themecpl.dll & themeui.dll 6780.0
            //"{90BCFBC2-E8F5-4DD3-91B2-7106A4D0F47F}",
            
            // explorer.exe & shell32.dll 6780.0
            //"{DFC187C7-EA34-482F-AB17-FD4FD8CE3946}",
            
            // SAAServer.exe 6780.0
            // HKEY_CURRENT_USER\SOFTWARE\Microsoft\SelectAndAsk\Preferences
            // DisablePreview=0

            //
            // 6801.0
            //
            
            // explorer.exe & ieframe.dll &
            // powercfg.cpl & shell32.dll &
            // stobject.dll & themecpl.dll &
            // themeui.dll 6801.0
            //"{A5181F28-5A04-4DBE-A8F6-EEBD7FE228F2}",
            
            // ieframe.dll 6801.0
            //"41579D76-09BA-4abd-A49A-A2335B9CB706",
            
            // powercfg.cpl & stobject.dll &
            // themecpl.dll & themeui.dll 6801.0
            //"{90BCFBC2-E8F5-4DD3-91B2-7106A4D0F47F}",
            
            // explorer.exe & shell32.dll 6801.0
            //"{DFC187C7-EA34-482F-AB17-FD4FD8CE3946}",
            
            // wisptis.exe & TabletPC.cpl 6801.0
            "{5690fbbe-eea2-4426-9cb0-aa8f95e5c53d}",
            
            // wisptis.exe & TabletPC.cpl 6801.0
            "{756aeb4e-2a05-4fe6-915e-d7f5f124abd3}",

            //
            // 6910.0
            //

            // explorer.exe & ieframe.dll &
            // powercfg.cpl & shell32.dll &
            // stobject.dll & themecpl.dll &
            // themeui.dll 6910.0
            //"{A5181F28-5A04-4DBE-A8F6-EEBD7FE228F2}",
            
            // explorer.exe 6910.0
            "{3EEEEFEB-B964-4E74-B7E7-B1C7C19C1AB0}",
            
            // ieframe.dll 6910.0
            //"41579D76-09BA-4abd-A49A-A2335B9CB706",
            
            // powercfg.cpl & stobject.dll &
            // themecpl.dll & themeui.dll 6910.0
            //"{90BCFBC2-E8F5-4DD3-91B2-7106A4D0F47F}",
            
            // shell32.dll 6910.0
            //"{DFC187C7-EA34-482F-AB17-FD4FD8CE3946}",
            
            // wisptis.exe & TabletPC.cpl 6910.0
            //"{5690fbbe-eea2-4426-9cb0-aa8f95e5c53d}",
            
            // wisptis.exe & TabletPC.cpl 6910.0
            //"{756aeb4e-2a05-4fe6-915e-d7f5f124abd3}",

            //
            // 6931.0
            //
            
            // explorer.exe & ieframe.dll &
            // powercfg.cpl & shell32.dll &
            // stobject.dll & themecpl.dll &
            // themeui.dll 6931.0
            //"{A5181F28-5A04-4DBE-A8F6-EEBD7FE228F2}",
            
            // explorer.exe 6931.0
            //"{3EEEEFEB-B964-4E74-B7E7-B1C7C19C1AB0}",
            
            // ieframe.dll 6931.0
            //"41579D76-09BA-4abd-A49A-A2335B9CB706",
            
            // powercfg.cpl & stobject.dll &
            // themecpl.dll & themeui.dll 6931.0
            //"{90BCFBC2-E8F5-4DD3-91B2-7106A4D0F47F}",
            
            // shell32.dll 6931.0
            //"{DFC187C7-EA34-482F-AB17-FD4FD8CE3946}",

            //
            // 6936.0
            //
            
            // explorer.exe & ieframe.dll &
            // powercfg.cpl & shell32.dll &
            // stobject.dll & themecpl.dll &
            // themeui.dll 6936.0
            //"{A5181F28-5A04-4DBE-A8F6-EEBD7FE228F2}",
            
            // explorer.exe 6936.0
            //"{3EEEEFEB-B964-4E74-B7E7-B1C7C19C1AB0}",
            
            // ieframe.dll 6936.0
            //"41579D76-09BA-4abd-A49A-A2335B9CB706",
            
            // powercfg.cpl & shell32.dll &
            // stobject.dll & themecpl.dll &
            // themeui.dll 6936.0
            //"{90BCFBC2-E8F5-4DD3-91B2-7106A4D0F47F}",

            // shell32.dll 6936.0
            "{D0BF7CA7-ECF5-4BAA-945F-8D2E3FB531BE}",

            //
            // 6941.0
            //
            
            // explorer.exe & ieframe.dll &
            // powercfg.cpl & stobject.dll &
            // themecpl.dll & themeui.dll 6941.0
            //"{A5181F28-5A04-4DBE-A8F6-EEBD7FE228F2}",
            
            // explorer.exe 6941.0
            //"{3EEEEFEB-B964-4E74-B7E7-B1C7C19C1AB0}",
            
            // ieframe.dll 6941.0
            //"41579D76-09BA-4abd-A49A-A2335B9CB706",
            
            // powercfg.cpl & stobject.dll &
            // themecpl.dll & themeui.dll 6941.0
            //"{90BCFBC2-E8F5-4DD3-91B2-7106A4D0F47F}",

            //
            // 6956.0
            //

            // ieframe.dll 6956.0
            //"{A5181F28-5A04-4DBE-A8F6-EEBD7FE228F2}",
            
            // ieframe.dll 6956.0
            //"41579D76-09BA-4abd-A49A-A2335B9CB706",
            
            //
            // Unknown
            //

            // all of these are from TCB, 
            // not sure where they got them from

            // weird ones
            // (third block should have been starting with 4)
            "{20D04FE0-3AEA-1069-A2D8-08002B30309D}",
            "{21EC2020-3AEA-1069-A2DD-08002B30309D}",
            "{2559A1F1-21D7-11D4-BDAF-00C04F60B9F0}",
            "{2559A1F3-21D7-11D4-BDAF-00C04F60B9F0}",
            "{2559A1F4-21D7-11D4-BDAF-00C04F60B9F0}",
            "{2559A1F5-21D7-11D4-BDAF-00C04F60B9F0}",
            "{3080F90D-D7AD-11D9-BD98-0000947B0257}",
            "{871C5380-42A0-1069-A2EA-08002B30309D}",

            // maybe these are valid, but no way to check
            "{9113A02D-00A3-46B9-BC5F-9C04DADDD5D7}",
            "{B155BDF8-02F0-451E-9A26-AE317CFD7779}",
            "{ED228FDF-9EA8-4870-83B1-96B02CFE0D52}",
            "{35786D3C-B075-49B9-88DD-029876E11C01}",
            "{5399E694-6CE5-4D6C-8FCE-1D8870FDCBA0}",
            "{59031A47-3F72-44A7-89C5-5595FE6B30EE}",
            "{640167B4-59B0-47A6-B335-A6B3C0695AEA}",
            "{865E5E76-AD83-4DCA-A109-50DC2113CE9A}",
        };

        private void InstallIntoPath(RegistryKey key, string oUserHive)
        {
            RegistryKey keyExplorer;

            try
            {
                Console.WriteLine("\t-> Enabling Superbar v1");
                key.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand");
                keyExplorer = key.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand", true);
                keyExplorer.SetValue("CanHasSuperbar", 1, RegistryValueKind.DWord);
                keyExplorer.Close();
            }
            catch { };

            try
            {
                Console.WriteLine("\t-> Enabling Superbar v2");
                key.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
                keyExplorer = key.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true);
                keyExplorer.SetValue("EnableCHS", 1, RegistryValueKind.DWord);
                keyExplorer.Close();
            }
            catch { };

            try
            {
                foreach (var guid in guids)
                {
                    Console.WriteLine("\t-> Installing " + guid + " lockdown CLSID");
                    key.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}");
                    key.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}\ShellFolder");
                    keyExplorer = key.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}\ShellFolder", true);
                    keyExplorer.SetValue("Attributes", -1609564156, RegistryValueKind.DWord);
                    keyExplorer.Close();
                }
            }
            catch { };

            try
            {
                // Thanks IE team
                key.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer");
                keyExplorer = key.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer", true);
                keyExplorer.SetValue("Attributes", -1609564156, RegistryValueKind.DWord);
                keyExplorer.Close();
            }
            catch { };

            try
            {
                Console.WriteLine("\t-> Enabling Select And Ask Preview");
                key.CreateSubKey($@"{oUserHive}\SOFTWARE\Microsoft\SelectAndAsk\Preferences");
                keyExplorer = key.OpenSubKey($@"{oUserHive}\SOFTWARE\Microsoft\SelectAndAsk\Preferences", true);
                keyExplorer.SetValue("DisablePreview", 0, RegistryValueKind.DWord);
                keyExplorer.Close();
            }
            catch { }
        }

        private void UninstallIntoPath(RegistryKey key, string oUserHive)
        {
            RegistryKey keyExplorer;

            try
            {
                Console.WriteLine("\t-> Disabling Superbar v1");
                key.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand");
                keyExplorer = key.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\TaskBand", true);
                keyExplorer.DeleteValue("CanHasSuperbar", false);
                keyExplorer.Close();
            }
            catch { }

            try
            {
                Console.WriteLine("\t-> Disabling Superbar v2");
                key.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
                keyExplorer = key.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true);
                keyExplorer.DeleteValue("EnableCHS", false);
                keyExplorer.Close();
            }
            catch { }

            try
            {
                foreach (var guid in guids)
                {
                    Console.WriteLine("\t-> Uninstalling " + guid + " lockdown CLSID");
                    key.DeleteSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}\ShellFolder", false);
                    key.DeleteSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{guid}", false);
                }
            }
            catch { }

            try
            {
                // Thanks IE team
                key.CreateSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer");
                keyExplorer = key.OpenSubKey($@"{oUserHive}\Software\Microsoft\Windows\CurrentVersion\Explorer", true);
                keyExplorer.DeleteValue("Attributes", false);
                keyExplorer.Close();
            }
            catch { }

            try
            {
                Console.WriteLine("\t-> Disabling Select And Ask Preview");
                keyExplorer = key.OpenSubKey($@"{oUserHive}\SOFTWARE\Microsoft\SelectAndAsk\Preferences", true);
                keyExplorer.DeleteValue("DisablePreview", false);
                keyExplorer.Close();
            }
            catch { }
        }

        public void Install()
        {
            Console.WriteLine("[i] Installing Bluepill");

            progress.ReportProgress(0, "Gathering user hives");
            Console.WriteLine("-> Gathering user hives");
            string[] userHives = Registry.Users.GetSubKeyNames();

            string[] profileArray;
            using (RegistryKey keyProfileList = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList"))
                profileArray = keyProfileList.GetSubKeyNames();

            string documentsPath = Environment.GetEnvironmentVariable("PUBLIC");
            DirectoryInfo dirInfo = new DirectoryInfo(documentsPath);
            string userImagePath = $@"{dirInfo.Parent.FullName}\Default\NTuser.dat";

            int counter = 0;
            foreach (string oUserHive in userHives)
            {
                int progressval = 33 + (int)Math.Round((profileArray.Length + userHives.Length + 1 - (double)counter) * 33 / userHives.Length);
                progress.ReportProgress(progressval, "Installing for " + oUserHive);
                Console.WriteLine("-> Installing for " + oUserHive);
                InstallIntoPath(Registry.Users, oUserHive);
                counter++;
            }

            Utils.EnablePrivileges();
            foreach (string oProfile in profileArray)
            {
                if (!Array.Exists(userHives, x => x == oProfile))
                {
                    RegistryKey keyProfile = Registry.LocalMachine.OpenSubKey($@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\{oProfile}");
                    if (Array.Exists(keyProfile.GetValueNames(), x => x == "ProfileImagePath"))
                    {
                        int progressval = 33 + (int)Math.Round((profileArray.Length + userHives.Length + 1 - (double)counter) * 33 / userHives.Length);
                        progress.ReportProgress(progressval, "Installing for " + oProfile);
                        Console.WriteLine("-> Installing for " + oProfile);

                        string imagePath = keyProfile.GetValue("ProfileImagePath") as string;
                        Utils.LoadRegistryHiveIntoHKU($@"{imagePath}\NTuser.dat", oProfile);

                        InstallIntoPath(Registry.Users, oProfile);

                        Utils.UnloadRegistryHiveFromHKU(oProfile);
                    }
                    keyProfile.Close();
                }
                counter++;
            }

            int progressval2 = 33 + (int)Math.Round((profileArray.Length + userHives.Length + 1 - (double)counter) * 33 / userHives.Length);
            Utils.LoadRegistryHiveIntoHKU(userImagePath, "Default");
            progress.ReportProgress(progressval2, "Installing for Default");
            Console.WriteLine("-> Installing for Default");
            InstallIntoPath(Registry.Users, "Default");
            Utils.UnloadRegistryHiveFromHKU("Default");

            progress.ReportProgress(66, "Enabling locked down wintage apps");
            Console.WriteLine("-> Enabling locked down wintage apps");

            try
            {
                progress.ReportProgress(74, "Enabling Calculator");
                Console.WriteLine("\t-> Enabling Calculator");
                Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\calculator");
                RegistryKey redpillKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\calculator", true);
                redpillKey.SetValue("EnableNew", 1, RegistryValueKind.DWord);
                redpillKey.Close();
            }
            catch { }

            try
            {
                progress.ReportProgress(83, "Enabling Calculator");
                Console.WriteLine("\t-> Enabling Paint");
                Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\paint");
                RegistryKey redpillKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\paint", true);
                redpillKey.SetValue("EnableNew", 1, RegistryValueKind.DWord);
                redpillKey.Close();
            }
            catch { }

            try
            {
                progress.ReportProgress(91, "Enabling Sticky Notes");
                Console.WriteLine("\t-> Enabling Sticky Notes");
                Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\StickyNotes");
                RegistryKey redpillKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\StickyNotes", true);
                redpillKey.SetValue("EnableNew", 1, RegistryValueKind.DWord);
                redpillKey.Close();
            }
            catch { }

            try
            {
                progress.ReportProgress(99, "Enabling Sticky Notes");
                Console.WriteLine("\t-> Enabling WordPad");
                Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\wordpad");
                RegistryKey redpillKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\wordpad", true);
                redpillKey.SetValue("EnableNew", 1, RegistryValueKind.DWord);
                redpillKey.Close();
            }
            catch { }

            Console.WriteLine("[i] Bluepill installation finished. You may need to log off and log back on.");

            progress.Close();
        }

        public void Uninstall()
        {
            Console.WriteLine("[i] Uninstalling Bluepill");

            progress.ReportProgress(0, "Gathering user hives");
            Console.WriteLine("-> Gathering user hives");
            string[] userHives = Registry.Users.GetSubKeyNames();

            string[] profileArray;
            using (RegistryKey keyProfileList = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList"))
                profileArray = keyProfileList.GetSubKeyNames();

            string documentsPath = Environment.GetEnvironmentVariable("PUBLIC");
            DirectoryInfo dirInfo = new DirectoryInfo(documentsPath);
            string userImagePath = $@"{dirInfo.Parent.FullName}\Default\NTuser.dat";

            int counter = 0;
            foreach (string oUserHive in userHives)
            {
                int progressval = 33 + (int)Math.Round((profileArray.Length + userHives.Length + 1 - (double)counter) * 33 / userHives.Length);
                progress.ReportProgress(progressval, "Uninstalling for " + oUserHive);
                Console.WriteLine("-> Uninstalling for " + oUserHive);
                UninstallIntoPath(Registry.Users, oUserHive);
                counter++;
            }

            Utils.EnablePrivileges();
            foreach (string oProfile in profileArray)
            {
                if (!Array.Exists(userHives, x => x == oProfile))
                {
                    RegistryKey keyProfile = Registry.LocalMachine.OpenSubKey($@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\{oProfile}");
                    if (Array.Exists(keyProfile.GetValueNames(), x => x == "ProfileImagePath"))
                    {
                        int progressval = 33 + (int)Math.Round((profileArray.Length + userHives.Length + 1 - (double)counter) * 33 / userHives.Length);
                        progress.ReportProgress(progressval, "Uninstalling for " + oProfile);
                        Console.WriteLine("-> Uninstalling for " + oProfile);

                        string imagePath = keyProfile.GetValue("ProfileImagePath") as string;
                        Utils.LoadRegistryHiveIntoHKU($@"{imagePath}\NTuser.dat", oProfile);

                        UninstallIntoPath(Registry.Users, oProfile);

                        Utils.UnloadRegistryHiveFromHKU(oProfile);
                    }
                    keyProfile.Close();
                }
                counter++;
            }

            int progressval2 = 33 + (int)Math.Round((profileArray.Length + userHives.Length + 1 - (double)counter) * 33 / userHives.Length);
            Utils.LoadRegistryHiveIntoHKU(userImagePath, "Default");
            progress.ReportProgress(progressval2, "Uninstalling for Default");
            Console.WriteLine("-> Uninstalling for Default");
            UninstallIntoPath(Registry.Users, "Default");
            Utils.UnloadRegistryHiveFromHKU("Default");
            counter++;

            progress.ReportProgress(66, "Disabling locked down wintage apps");
            Console.WriteLine("-> Disabling locked down wintage apps");

            try
            {
                progress.ReportProgress(74, "Disabling Calculator");
                Console.WriteLine("\t-> Disabling Calculator");
                Registry.LocalMachine.DeleteSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\calculator", false);
            }
            catch { }

            try
            {
                progress.ReportProgress(83, "Disabling Paint");
                Console.WriteLine("\t-> Disabling Paint");
                Registry.LocalMachine.DeleteSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\paint", false);
            }
            catch { }

            try
            {
                progress.ReportProgress(91, "Disabling Sticky Notes");
                Console.WriteLine("\t-> Disabling Sticky Notes");
                Registry.LocalMachine.DeleteSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\StickyNotes", false);
            }
            catch { }

            try
            {
                progress.ReportProgress(99, "Disabling WordPad");
                Console.WriteLine("\t-> Disabling WordPad");
                Registry.LocalMachine.DeleteSubKey(@"Software\Microsoft\Windows\CurrentVersion\Wintage\Apps\Redpill\wordpad", false);
            }
            catch { }

            progress.Close();
        }
    }
}
