//c call dll 2017 7 30  7:52pm
// console app .c
#include "stdafx.h"
#include "windows.h"
#include "..\..\Win32Project1\Win32Project1\dll001.h"
//#pragma comment(lib,"Win32Project Dll.lib")

void staticCallDll();
void dynamicCallDll();


int _tmain(int argc, _TCHAR* argv[])
{
	staticCallDll();
	printf("\n");
	dynamicCallDll();
	return 0;
}

void staticCallDll()
{
	printf("%s \n", "staticCallDll()");
	printf("%d", dll());
	//printf("\n");
}

void dynamicCallDll()
{
	dllFun lucky; //声明一个函数指针
 
	printf("%s \n", "dynamicCallDll()");
	HINSTANCE hdll;
	hdll = LoadLibrary(_T("Win32Project Dll.dll"));
	if(hdll == NULL)
	{
		printf("无法载入dll\n");
		FreeLibrary(hdll);
		getchar();
		exit (1);
	}
	lucky = (dllFun)GetProcAddress(hdll, "dll");
	if(lucky == NULL)
	{
		printf("无法获取函数地址\n");
		FreeLibrary(hdll);
		getchar();
		exit(1);
		 
	}
 
	int b = lucky();
	printf("%d\n",b);
 
	FreeLibrary(hdll);

}

//dll.h
extern "C" __declspec(dllexport)  int dll();

typedef int (*dllFun)();

//dllmain.c
int dll()
{
	return 123;
}

/*  18 07 18
C++对dll链接库的显示（动态）调用和隐式（静态）调用
From <https://blog.csdn.net/ojshilu/article/details/12954957> 

DLL调用（1）：C++静态调用DLL
From <https://blog.csdn.net/ezhchai/article/details/78784572> 

*/
