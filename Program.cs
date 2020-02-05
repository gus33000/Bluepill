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

using Bluepill.UI;
using Bluepill.UI.Aero;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Bluepill
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (Debugger.IsAttached)
                return;
            for (int i = 0; i < args.Length; i++)
                args[i] = args[i].ToLower();

            //Console.Title = "Bluepill";

            BluepillProgressInterface progress = new Aero();

            if (args == null || args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                var res = Dialogs.ShowChoiceDialog();

                switch (res)
                {
                    case Dialogs.Choices.Install:
                        {
                            args = new string[1] { "install" };
                            break;
                        }
                    case Dialogs.Choices.Uninstall:
                        {
                            args = new string[1] { "uninstall" };
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }
            }

            switch (args[0].ToLower())
            {
                case "install":
                    {
                        new BluepillProgress((object sender, DoWorkEventArgs e) =>
                        {
                            new BPMain(progress).Install();
                        }, progress);
                        break;
                    }
                case "uninstall":
                    {
                        new BluepillProgress((object sender, DoWorkEventArgs e) =>
                        {
                            new BPMain(progress).Uninstall();
                        }, progress);
                        break;
                    }
                default:
                    {
                        ShowHelp();
                        break;
                    }
            }
        }

        public static void ShowHelp()
        {
            Console.WriteLine("\nUsage: bluepill <mode>");
            Console.WriteLine("\n       mode:    install   - installs   bluepill");
            Console.WriteLine("                uninstall - uninstalls bluepill");
        }
    }
}
