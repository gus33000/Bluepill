﻿/*****************************************************
 * WindowsFormsAero
 * https://github.com/LorenzCK/WindowsFormsAero
 * http://windowsformsaero.codeplex.com
 *
 * Author: Lorenz Cuno Klopfenstein <lck@klopfenstein.net>
 *****************************************************/

using System;
using WindowsFormsAero.Native;

namespace WindowsFormsAero {

    /// <summary>
    /// Static class providing information about the running OS's version.
    /// </summary>
    public static class OsSupport {

        private const int VistaMajorVersion = 6;
        private const int SevenMinorVersion = 1;
        private const int EightMinorVersion = 2;
        private const int EightDotOneMinorVersion = 3;
        private const int TenMajorVersion = 10;
        private const int TenAnniversaryBuild = 14393;

        /// <summary>
        /// Gets whether the running operating system is Windows Vista or a more recent
        /// version.
        /// </summary>
        [Obsolete("Use IsVistaOrLater")]
        public static bool IsVistaOrBetter {
            get {
                return (Environment.OSVersion.Platform == PlatformID.Win32NT &&
                        Environment.OSVersion.Version.Major >= VistaMajorVersion);
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows Vista or a more recent
        /// version.
        /// </summary>
        public static bool IsVistaOrLater {
            get {
                return (Environment.OSVersion.Platform == PlatformID.Win32NT &&
                        Environment.OSVersion.Version.Major >= VistaMajorVersion);
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows Seven or a more recent
        /// version.
        /// </summary>
        [Obsolete("Use IsSevenOrLater")]
        public static bool IsSevenOrBetter {
            get {
                return IsSevenOrLater;
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows Seven or a more recent
        /// version.
        /// </summary>
        public static bool IsSevenOrLater {
            get {
                if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    return false;

                var version = Environment.OSVersion.Version;
                if (version.Major > VistaMajorVersion)
                    return true;
                else if (version.Major == VistaMajorVersion)
                    return (version.Minor >= SevenMinorVersion);

                return false;
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows 8 or a more recent
        /// version.
        /// </summary>
        [Obsolete("Use IsEightOrLater")]
        public static bool IsEightOrBetter {
            get {
                return IsEightOrLater;
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows 8 or a more recent
        /// version.
        /// </summary>
        public static bool IsEightOrLater {
            get {
                if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    return false;

                var version = Environment.OSVersion.Version;

                if (version.Major > VistaMajorVersion)
                    return true;
                else if (version.Major == VistaMajorVersion)
                    return (version.Minor >= EightMinorVersion);

                return false;
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows 8.1 or a more recent
        /// version.
        /// </summary>
        [Obsolete("Use IsEightDotOneOrLater")]
        public static bool IsEightDotOneOrBetter {
            get {
                return IsEightDotOneOrLater;
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows 8.1 or a more recent
        /// version.
        /// </summary>
        public static bool IsEightDotOneOrLater {
            get {
                if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    return false;

                var version = Environment.OSVersion.Version;

                if (version.Major > VistaMajorVersion)
                    return true;
                else if (version.Major == VistaMajorVersion)
                    return (version.Minor >= EightDotOneMinorVersion);

                return false;
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows 10 or a more recent
        /// version.
        /// </summary>
        [Obsolete("Use IsTenOrLater")]
        public static bool IsTenOrBetter {
            get {
                return IsTenOrLater;
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows 10 or a more recent
        /// version.
        /// </summary>
        public static bool IsTenOrLater {
            get {
                if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    return false;

                var version = Environment.OSVersion.Version;

                if (version.Major >= TenMajorVersion)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows 10 "Anniversary Edition"
        /// or a more recent version.
        /// </summary>
        [Obsolete("Use IsTenAnniversaryEditionOrLater")]
        public static bool IsTenAnniversaryEditionOrBetter {
            get {
                return IsTenAnniversaryEditionOrLater;
            }
        }

        /// <summary>
        /// Gets whether the running operating system is Windows 10 "Anniversary Edition"
        /// or a more recent version.
        /// </summary>
        public static bool IsTenAnniversaryEditionOrLater {
            get {
                if (!IsTenOrLater)
                    return false;

                return Environment.OSVersion.Version.Build >= TenAnniversaryBuild;
            }
        }

        /// <summary>
        /// Is true if the DWM composition engine is currently enabled.
        /// </summary>
        public static bool IsCompositionEnabled {
            get {
                if (!IsVistaOrLater)
                    return false;

                try {
                    DwmMethods.DwmIsCompositionEnabled(out bool enabled);
                    return enabled;
                }
                catch (Exception) {
                    return false;
                }
            }
        }

    }

}
