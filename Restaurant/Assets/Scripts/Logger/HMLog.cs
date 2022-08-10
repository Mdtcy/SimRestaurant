using UnityEngine;
#if ZSTRING
using MyString = Cysharp.Text.ZString;
#else
using MyString = System.String;
#endif

namespace Logger
{
    public static class HMLog
    {
        private enum LogLevel
        {
            Error   = 0,
            Warning = 1,
            Info    = 2,
            Debug   = 3,
            Verbose = 4,
        }

        #region InternalLog

        private static void InternalLog(LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Error:
                {
                    Debug.LogError(MyString.Format("<color=red>{1:hh:mm:ss.fff}|{0}</color>", message, System.DateTime.Now));

                    break;
                }
                case LogLevel.Warning:
                {
                    Debug.LogWarning(MyString.Format("<color=#FF9933>{1:hh:mm:ss.fff}|{0}</color>", message, System.DateTime.Now));

                    break;
                }
                case LogLevel.Info:
                case LogLevel.Debug:
                case LogLevel.Verbose:
                {
                    Debug.Log(MyString.Format("{1:hh:mm:ss.fff}|{0}", message, System.DateTime.Now));
                    break;
                }
            }
        }

        private static void InternalLog<T1>(LogLevel logLevel, string format, T1 arg1)
        {
            InternalLog(logLevel, MyString.Format(format, arg1));
        }

        private static void InternalLog<T1, T2>(LogLevel logLevel, string format, T1 arg1, T2 arg2)
        {
            InternalLog(logLevel, MyString.Format(format, arg1, arg2));
        }

        private static void InternalLog<T1, T2, T3>(LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3)
        {
            InternalLog(logLevel, MyString.Format(format, arg1, arg2, arg3));
        }

        private static void InternalLog<T1, T2, T3, T4>(LogLevel logLevel,
                                                        string format,
                                                        T1 arg1,
                                                        T2 arg2,
                                                        T3 arg3,
                                                        T4 arg4)
        {
            InternalLog(logLevel, MyString.Format(format, arg1, arg2, arg3, arg4));
        }

        private static void InternalLog<T1, T2, T3, T4, T5>(LogLevel logLevel,
                                                            string format,
                                                            T1 arg1,
                                                            T2 arg2,
                                                            T3 arg3,
                                                            T4 arg4,
                                                            T5 arg5)
        {
            InternalLog(logLevel, MyString.Format(format, arg1, arg2, arg3, arg4, arg5));
        }

        private static void InternalLog<T1, T2, T3, T4, T5, T6>(LogLevel logLevel,
                                                                string format,
                                                                T1 arg1,
                                                                T2 arg2,
                                                                T3 arg3,
                                                                T4 arg4,
                                                                T5 arg5,
                                                                T6 arg6)
        {
            InternalLog(logLevel, MyString.Format(format, arg1, arg2, arg3, arg4, arg5, arg6));
        }

        #endregion

        #region LogVerbose

        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogVerbose(object message)
        {
            InternalLog(LogLevel.Verbose, message.ToString());
        }

        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogVerbose<T1>(string format, T1 arg1)
        {
            InternalLog(LogLevel.Verbose, format, arg1);
        }

        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogVerbose<T1, T2>(string format, T1 arg1, T2 arg2)
        {
            InternalLog(LogLevel.Verbose, format, arg1, arg2);
        }

        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogVerbose<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
        {
            InternalLog(LogLevel.Verbose, format, arg1, arg2, arg3);
        }

        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogVerbose<T1, T2, T3, T4>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            InternalLog(LogLevel.Verbose, format, arg1, arg2, arg3, arg4);
        }

        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogVerbose<T1, T2, T3, T4, T5>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            InternalLog(LogLevel.Verbose, format, arg1, arg2, arg3, arg4, arg5);
        }

        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogVerbose<T1, T2, T3, T4, T5, T6>(string format,
                                                              T1 arg1,
                                                              T2 arg2,
                                                              T3 arg3,
                                                              T4 arg4,
                                                              T5 arg5,
                                                              T6 arg6)
        {
            InternalLog(LogLevel.Verbose, format, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        #endregion

        #region LogDebug

        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogDebug(object message)
        {
            InternalLog(LogLevel.Debug, message.ToString());
        }

        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogDebug<T1>(string format, T1 arg1)
        {
            InternalLog(LogLevel.Debug, format, arg1);
        }

        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogDebug<T1, T2>(string format, T1 arg1, T2 arg2)
        {
            InternalLog(LogLevel.Debug, format, arg1, arg2);
        }

        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogDebug<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
        {
            InternalLog(LogLevel.Debug, format, arg1, arg2, arg3);
        }

        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogDebug<T1, T2, T3, T4>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            InternalLog(LogLevel.Debug, format, arg1, arg2, arg3, arg4);
        }

        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogDebug<T1, T2, T3, T4, T5>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            InternalLog(LogLevel.Debug, format, arg1, arg2, arg3, arg4, arg5);
        }

        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogDebug<T1, T2, T3, T4, T5, T6>(string format,
                                                            T1 arg1,
                                                            T2 arg2,
                                                            T3 arg3,
                                                            T4 arg4,
                                                            T5 arg5,
                                                            T6 arg6)
        {
            InternalLog(LogLevel.Debug, format, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        #endregion

        #region LogInfo

        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogInfo(object message)
        {
            InternalLog(LogLevel.Info, message.ToString());
        }

        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogInfo<T1>(string format, T1 arg1)
        {
            InternalLog(LogLevel.Info, format, arg1);
        }

        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogInfo<T1, T2>(string format, T1 arg1, T2 arg2)
        {
            InternalLog(LogLevel.Info, format, arg1, arg2);
        }

        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogInfo<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
        {
            InternalLog(LogLevel.Info, format, arg1, arg2, arg3);
        }

        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogInfo<T1, T2, T3, T4>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            InternalLog(LogLevel.Info, format, arg1, arg2, arg3, arg4);
        }

        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogInfo<T1, T2, T3, T4, T5>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            InternalLog(LogLevel.Info, format, arg1, arg2, arg3, arg4, arg5);
        }

        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogInfo<T1, T2, T3, T4, T5, T6>(string format,
                                                           T1 arg1,
                                                           T2 arg2,
                                                           T3 arg3,
                                                           T4 arg4,
                                                           T5 arg5,
                                                           T6 arg6)
        {
            InternalLog(LogLevel.Info, format, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        #endregion

        #region LogWarning

        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogWarning(object message)
        {
            InternalLog(LogLevel.Warning, message.ToString());
        }

        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogWarning<T1>(string format, T1 arg1)
        {
            InternalLog(LogLevel.Warning, format, arg1);
        }

        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogWarning<T1, T2>(string format, T1 arg1, T2 arg2)
        {
            InternalLog(LogLevel.Warning, format, arg1, arg2);
        }

        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogWarning<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
        {
            InternalLog(LogLevel.Warning, format, arg1, arg2, arg3);
        }

        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogWarning<T1, T2, T3, T4>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            InternalLog(LogLevel.Warning, format, arg1, arg2, arg3, arg4);
        }

        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogWarning<T1, T2, T3, T4, T5>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            InternalLog(LogLevel.Warning, format, arg1, arg2, arg3, arg4, arg5);
        }

        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogWarning<T1, T2, T3, T4, T5, T6>(string format,
                                                              T1 arg1,
                                                              T2 arg2,
                                                              T3 arg3,
                                                              T4 arg4,
                                                              T5 arg5,
                                                              T6 arg6)
        {
            InternalLog(LogLevel.Warning, format, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        #endregion

        #region LogError

        [System.Diagnostics.Conditional("HMLOGERROR")]
        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogError(object message)
        {
            InternalLog(LogLevel.Error, message.ToString());
        }

        [System.Diagnostics.Conditional("HMLOGERROR")]
        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogError<T1>(string format, T1 arg1)
        {
            InternalLog(LogLevel.Error, format, arg1);
        }

        [System.Diagnostics.Conditional("HMLOGERROR")]
        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogError<T1, T2>(string format, T1 arg1, T2 arg2)
        {
            InternalLog(LogLevel.Error, format, arg1, arg2);
        }

        [System.Diagnostics.Conditional("HMLOGERROR")]
        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogError<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
        {
            InternalLog(LogLevel.Error, format, arg1, arg2, arg3);
        }

        [System.Diagnostics.Conditional("HMLOGERROR")]
        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogError<T1, T2, T3, T4>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            InternalLog(LogLevel.Error, format, arg1, arg2, arg3, arg4);
        }

        [System.Diagnostics.Conditional("HMLOGERROR")]
        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogError<T1, T2, T3, T4, T5>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            InternalLog(LogLevel.Error, format, arg1, arg2, arg3, arg4, arg5);
        }

        [System.Diagnostics.Conditional("HMLOGERROR")]
        [System.Diagnostics.Conditional("HMLOGWARNING")]
        [System.Diagnostics.Conditional("HMLOGINFO")]
        [System.Diagnostics.Conditional("HMLOGDEBUG")]
        [System.Diagnostics.Conditional("HMLOGVERBOSE")]
        public static void LogError<T1, T2, T3, T4, T5, T6>(string format,
                                                            T1 arg1,
                                                            T2 arg2,
                                                            T3 arg3,
                                                            T4 arg4,
                                                            T5 arg5,
                                                            T6 arg6)
        {
            InternalLog(LogLevel.Error, format, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        #endregion

        #region PROFILER

        [System.Diagnostics.Conditional("ENABLE_PROFILER")]
        public static void BeginSample(string name)
        {
            UnityEngine.Profiling.Profiler.BeginSample(name);
        }

        [System.Diagnostics.Conditional("ENABLE_PROFILER")]
        public static void EndSample()
        {
            UnityEngine.Profiling.Profiler.EndSample();
        }
        #endregion

        #region ASSERT

        [System.Diagnostics.Conditional("DEBUG")]
        public static void Assert(bool condition, object message = null, params object[] objects)
        {
            if (objects.Length > 0)
            {
                Debug.AssertFormat(condition, message as string, objects);
            }
            else
            {
                Debug.Assert(condition, message);
            }
        }

        #endregion
    }
}