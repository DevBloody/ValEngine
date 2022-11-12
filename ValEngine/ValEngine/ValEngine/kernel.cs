using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValEngineKernel
{
    internal static class proc
    {
        public static void DownloadFile(string Url, string Path)
        {
            (new WebClient()).DownloadFile(Url, Path);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern IntPtr OpenThread(proc.ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);





        public static void Resume(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                IntPtr intPtr = proc.OpenThread(proc.ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (intPtr == IntPtr.Zero)
                {
                    break;
                }
                else
                {
                    proc.ResumeThread(intPtr);
                }
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern int ResumeThread(IntPtr hThread);

        public static void Suspend(this Process process)
        {
            foreach (ProcessThread thread in (ReadOnlyCollectionBase)process.Threads)
            {
                IntPtr intPtr = proc.OpenThread(proc.ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (intPtr == IntPtr.Zero)
                {
                    break;
                }
                else
                {
                    proc.SuspendThread(intPtr);
                }
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern uint SuspendThread(IntPtr hThread);

        [Flags]
        public enum ThreadAccess
        {
            TERMINATE = 1,
            SUSPEND_RESUME = 2,
            GET_CONTEXT = 8,
            SET_CONTEXT = 16,
            SET_INFORMATION = 32,
            QUERY_INFORMATION = 64,
            SET_THREAD_TOKEN = 128,
            IMPERSONATE = 256,
            DIRECT_IMPERSONATION = 512
        }
    }
}