# sys.psm1，PowerShell模块代码

# 立即关闭屏幕
function turnOffMonitor {
	# 检查新定义的类是否已经加载，避免重复
	if (-not ("me.joshua.powershell.MonitorUtil" -as [type])) {

	# C#代码
	$Source = @"
	// 引入Dll及相关的函数
	[DllImport("user32.dll")]
	public static extern int PostMessage(int hWnd, int Msg, int wParam, int lParam);

	public static void TurnOffMonitor()
	{
		// “SendMessage”会有被阻塞无法返回的情况，所以使用“PostMessage”
		PostMessage(0xffff, 0x0112, 0xF170, 2);
	}
"@

		#  // 加载新定义的类型，指定类名和Namespace
		Add-Type -MemberDefinition $Source -name "MonitorUtil" -namespace "me.joshua.powershell"
	}
	#  // 调用函数关闭屏幕
	[me.joshua.powershell.MonitorUtil]::TurnOffMonitor()
}

# 锁屏
function lock {
	# “LockWorkStation”没入参，可以直接使用rundll32.exe调用，“PostMessage”则因为需要转化参数类型而不行
	rundll32.exe user32.dll,LockWorkStation
	# 2秒后关闭屏幕
	sleep -Seconds 2
	turnOffMonitor
}

# 把模块中的函数导出，以便直接在PowerShell中使用
Export-ModuleMember -Function turnOffMonitor
Export-ModuleMember -Function lock

#how to call 
# PowerShell -Command "& { dir . ;  Import-Module  .\turnOffMonitor.psm1;    turnOffMonitor }"
