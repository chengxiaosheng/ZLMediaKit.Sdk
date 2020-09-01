namespace ZLMediaKit.Sdk.Original
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user_data"></param>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate void on_mk_async(System.IntPtr user_data);

    /// <summary>
    /// 定时器触发事件
    /// </summary>
    /// <param name="user_data"></param>
    /// <returns>下一次触发延时(单位毫秒)，返回0则不再重复</returns>
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    public delegate uint on_mk_timer(System.IntPtr user_data);


    public class mk_thread
    {
        /// <summary>
        /// 获取tcp会话对象所在事件线程
        /// </summary>
        /// <param name="ctx">tcp会话对象</param>
        /// <returns>对象所在事件线程</returns>
        public static System.IntPtr mk_thread_from_tcp_session(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_thread_windows.mk_thread_from_tcp_session(ctx) : mk_thread_unix.mk_thread_from_tcp_session(ctx);

        /// <summary>
        /// 获取tcp客户端对象所在事件线程
        /// </summary>
        /// <param name="ctx">tcp客户端</param>
        /// <returns>对象所在事件线程</returns>
        public static System.IntPtr mk_thread_from_tcp_client(System.IntPtr ctx)
            => LibraryConst.IsWindows ? mk_thread_windows.mk_thread_from_tcp_client(ctx) : mk_thread_unix.mk_thread_from_tcp_client(ctx);


        /// <summary>
        /// 根据负载均衡算法，从事件线程池中随机获取一个事件线程
        /// <para>如果在事件线程内执行此函数将返回本事件线程</para>
        /// <para>事件线程指的是定时器、网络io事件线程</para>
        /// </summary>
        /// <returns>事件线程</returns>
        public static System.IntPtr mk_thread_from_pool()
            => LibraryConst.IsWindows? mk_thread_windows.mk_thread_from_pool() : mk_thread_unix.mk_thread_from_pool();

        /// <summary>
        /// 根据负载均衡算法，从后台线程池中随机获取一个线程
        /// <para>后台线程本质与事件线程相同，只是优先级更低，同时可以执行短时间的阻塞任务  </para>
        /// <para>ZLMediaKit中后台线程用于dns解析、mp4点播时的文件解复用</para>
        /// </summary>
        /// <returns>后台线程</returns>
        public static System.IntPtr mk_thread_from_pool_work()
            => LibraryConst.IsWindows ? mk_thread_windows.mk_thread_from_pool_work() : mk_thread_unix.mk_thread_from_pool_work();

        /// <summary>
        /// 切换到事件线程并异步执行
        /// </summary>
        /// <param name="ctx">事件线程</param>
        /// <param name="cb">回调函数</param>
        /// <param name="user_data">用户数据指针</param>
        public static void mk_async_do(System.IntPtr ctx, on_mk_async cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_thread_windows.mk_async_do(ctx, cb, user_data); 
            else mk_thread_unix.mk_async_do(ctx, cb, user_data);
        }


        /// <summary>
        /// 切换到事件线程并同步执行
        /// </summary>
        /// <param name="ctx">事件线程</param>
        /// <param name="cb">回调函数</param>
        /// <param name="user_data">用户数据指针</param>
        public static void mk_sync_do(System.IntPtr ctx, on_mk_async cb, System.IntPtr user_data)
        {
            if (LibraryConst.IsWindows) mk_thread_windows.mk_sync_do(ctx, cb, user_data);
            else mk_thread_unix.mk_sync_do(ctx, cb, user_data);
        }

        /// <summary>
        /// 创建定时器
        /// </summary>
        /// <param name="ctx">线程对象</param>
        /// <param name="delay_ms">执行延时，单位毫秒</param>
        /// <param name="cb">回调函数</param>
        /// <param name="user_data">用户数据指针</param>
        /// <returns>定时器对象</returns>
        public static System.IntPtr mk_timer_create(System.IntPtr ctx, uint delay_ms, on_mk_timer cb, System.IntPtr user_data)
            => LibraryConst.IsWindows ? mk_thread_windows.mk_timer_create(ctx, delay_ms, cb, user_data) : mk_thread_unix.mk_timer_create(ctx, delay_ms, cb, user_data);

        /// <summary>
        /// 销毁和取消定时器
        /// </summary>
        /// <param name="ctx">定时器对象</param>
        public static void mk_timer_release(System.IntPtr ctx)
        {
            if (LibraryConst.IsWindows) mk_thread_windows.mk_timer_release(ctx);
            else mk_thread_unix.mk_timer_release(ctx);
        }

    }

    internal class mk_thread_windows
    {
        /// Return Type: mk_thread->void*
        ///ctx: mk_tcp_session->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_thread_from_tcp_session", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_thread_from_tcp_session(System.IntPtr ctx);


        /// Return Type: mk_thread->void*
        ///ctx: mk_tcp_client->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_thread_from_tcp_client", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_thread_from_tcp_client(System.IntPtr ctx);


        /// Return Type: mk_thread->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_thread_from_pool", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_thread_from_pool();


        /// Return Type: mk_thread->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_thread_from_pool_work", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_thread_from_pool_work();

        /// Return Type: void
        ///ctx: mk_thread->void*
        ///cb: on_mk_async
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_async_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_async_do(System.IntPtr ctx, on_mk_async cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_thread->void*
        ///cb: on_mk_async
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_sync_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_sync_do(System.IntPtr ctx, on_mk_async cb, System.IntPtr user_data);


        /// Return Type: mk_timer->void*
        ///ctx: mk_thread->void*
        ///delay_ms: uint64_t->unsigned int
        ///cb: on_mk_timer
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_timer_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_timer_create(System.IntPtr ctx, uint delay_ms, on_mk_timer cb, System.IntPtr user_data);

        


        /// Return Type: void
        ///ctx: mk_timer->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForWindows, EntryPoint = "mk_timer_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_timer_release(System.IntPtr ctx);

    }

    internal class mk_thread_unix
    {
        /// Return Type: mk_thread->void*
        ///ctx: mk_tcp_session->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_thread_from_tcp_session", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_thread_from_tcp_session(System.IntPtr ctx);


        /// Return Type: mk_thread->void*
        ///ctx: mk_tcp_client->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_thread_from_tcp_client", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_thread_from_tcp_client(System.IntPtr ctx);


        /// Return Type: mk_thread->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_thread_from_pool", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_thread_from_pool();


        /// Return Type: mk_thread->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_thread_from_pool_work", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_thread_from_pool_work();

        /// Return Type: void
        ///ctx: mk_thread->void*
        ///cb: on_mk_async
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_async_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_async_do(System.IntPtr ctx, on_mk_async cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_thread->void*
        ///cb: on_mk_async
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_sync_do", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_sync_do(System.IntPtr ctx, on_mk_async cb, System.IntPtr user_data);

        /// Return Type: mk_timer->void*
        ///ctx: mk_thread->void*
        ///delay_ms: uint64_t->unsigned int
        ///cb: on_mk_timer
        ///user_data: void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_timer_create", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern System.IntPtr mk_timer_create(System.IntPtr ctx, uint delay_ms, on_mk_timer cb, System.IntPtr user_data);


        /// Return Type: void
        ///ctx: mk_timer->void*
        [System.Runtime.InteropServices.DllImportAttribute(LibraryConst.LibraryNameForLinux, EntryPoint = "mk_timer_release", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        internal static extern void mk_timer_release(System.IntPtr ctx);

    }
}
