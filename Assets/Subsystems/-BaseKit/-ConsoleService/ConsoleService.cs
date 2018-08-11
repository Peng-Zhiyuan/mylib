using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class ConsoleService
{
    static ConsoleService _instance;
    public static ConsoleService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConsoleService();
            }
            return _instance;
        }
    }

    public Dictionary<string, CommandInfo> commandInfoDic = new Dictionary<string, CommandInfo>();
    public Dictionary<Type, object> providerInstanceDic = new Dictionary<Type, object>();



    public event Action<LogLevel, string> OnPrint;



    private ConsoleService()
    {
        Init();
    }

    /// <summary>
    /// 在这里注册更多的命令提供者
    /// </summary>
    public Type[] TYPE_LIST = new Type[]{ typeof(TestCommandProvider) };


    private void Init()
    {
        //var providerTypeList = ReflectionHelper.GetSubClasses<CommandProvider>();
        var providerTypeList = TYPE_LIST;
        foreach(var providerType in providerTypeList)
        {
            var methodInfoList = providerType.GetMethods().ToList();
            methodInfoList = methodInfoList.FindAll(info =>
            {
                return ReflectionHelper.HasAttribute<CommandAttribute>(info);
            });
            if(methodInfoList.Count > 0)
            {
                var providerInstance = Activator.CreateInstance(providerType);
                (providerInstance as CommandProvider).consoleService = this;
                providerInstanceDic.Add(providerType, providerInstance);
            }
            foreach(var m in methodInfoList)
            {
                RegisterCommand(providerType, m);
            }
        }
    }

    public void RegisterCommand(Type providerType, MethodInfo methodInfo)
    {
        var commandInfo = new CommandInfo
        {
            name = methodInfo.Name,
            methodInfo = methodInfo,
            providerType = providerType,
        };
        commandInfoDic.Add(commandInfo.name, commandInfo);
    }

    private void ExecuteCommand(CommandInfo commandInfo, string[] args)
    {
        var methodInfo = commandInfo.methodInfo;
        var provierType = commandInfo.providerType;
        var providerInstance = providerInstanceDic[provierType];
        // 参数补全
        var parInfos = methodInfo.GetParameters();
        var argsList = args.ToList();
        for (int i = 0; i < parInfos.Length; i++)
        {
            if (argsList.Count <= i)
            {
                argsList.Add("");
            }
        }
        args = argsList.ToArray();
        try
        {
            methodInfo.Invoke(providerInstance, args);
        }
        catch(Exception e)
        {
            Println(LogLevel.Error, e.Message + "\n" + e.InnerException);
            Debug.LogException(e.InnerException);
        }

    }

    public void ExecuteCommand(string commandLine)
    {
        Println(LogLevel.Info, "> " + commandLine);
        var args = commandLine.Split(' ');
        var command = args[0];
        var commandArgs = new string[args.Length - 1];
        for(int i = 1; i < args.Length; i++)
        {
            commandArgs[i - 1] = args[i];
        }
        CommandInfo commandInfo;
        this.commandInfoDic.TryGetValue(command, out commandInfo);
        if(commandInfo == null)
        {
            Print(LogLevel.Info, "comand '" + command + "' not found\n");
            return;
        }
        ExecuteCommand(commandInfo, commandArgs);
    }


    public void Print(LogLevel level, string text)
    {
        if(OnPrint != null)
        {
            OnPrint(level, text);
        }
    }

    public void Println(LogLevel level, string text)
    {
        Print(level, text + "\n");
    }

    public List<string> Prompt(string test)
    {
        test = test.ToLower();
        List<string> proptionColelction = new List<string>();
        foreach(var k in commandInfoDic.Keys)
        {
            var cmd = k.ToLower();
            if(cmd.StartsWith(test))
            {
                proptionColelction.Add(k);
            }
        }
        return proptionColelction;
    }
}


public class CommandInfo
{
    public string name;
    public MethodInfo methodInfo;
    public Type providerType;
}

public abstract class CommandProvider
{
    public ConsoleService consoleService;
    public void Print(LogLevel level, string text)
    {
        this.consoleService.Print(level, text);
    }

    public void Println(LogLevel level, string text)
    {
        this.consoleService.Println(level, text);
    }

    public void Println(string text)
    {
        this.consoleService.Println(LogLevel.Info, text);
    }

    public void Print(string text)
    {
        this.consoleService.Print(LogLevel.Info, text);
    }
}

public class CommandAttribute : Attribute
{
    
}

public enum LogLevel
{
    Debug,
    Info,
    Error,
}