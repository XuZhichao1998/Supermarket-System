<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        string sLogFile = AppDomain.CurrentDomain.BaseDirectory + "VisitedLog.txt";//日志文件的路径
        // 在应用程序启动时运行的代码
        if (!System.IO.File.Exists(sLogFile))
        {
            System.IO.FileStream fsnew = System.IO.File.Create(sLogFile);
            fsnew.Close();
        }
        string[] lines = System.IO.File.ReadAllLines(sLogFile);//读取并得到日志文件的行数
        long iTotalCount = 0;//设置初始访问人数为0
        int iOnline = 0;//设置初始在线人数为0
        if (lines != null && lines.Length > 0)
        {
            Int64.TryParse(lines[lines.Length - 1].ToString(), out iTotalCount);
        }
        Application.Lock();
        Application["TotalCount"] = iTotalCount;
        Application["Online"] = iOnline;
        Application.UnLock();
    }

    void Application_End(object sender, EventArgs e)
    {
        //  在应用程序关闭时运行的代码

    }

    void Application_Error(object sender, EventArgs e)
    {
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e)
    {
        // 在新会话启动时运行的代码
        try
        {
            Application.Lock();
            Application["Online"] = (int)Application["Online"] + 1;
            Application.UnLock();
            string sLogFile = AppDomain.CurrentDomain.BaseDirectory + "VisitedLog.txt";//日志文件的路径
            System.IO.StreamWriter file = new System.IO.StreamWriter(sLogFile,false);
            Application.Lock();
            long tot = (long)Application["TotalCount"] + 1;
            file.Write(tot.ToString().Trim());
            Application["TotalCount"] = tot;
            Application.UnLock();
            file.Close();
            file.Dispose();
        }
        catch(Exception es)
        {

        }


    }

    void Session_End(object sender, EventArgs e)
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
        // 或 SQLServer，则不引发该事件。
            Application.Lock();
            Application["Online"] = (int)Application["Online"] - 1;
            Application.UnLock();
    }

</script>
