//c call dll 2017 7 30  7:52pm
// console app .c
#include "..\..\Win32Project1\Win32Project1\dll001.h"
#pragma comment(lib,"Win32Project Dll.lib")

int _tmain(int argc, _TCHAR* argv[])
{
	printf("%d", dll());
	return 0;
}

//dll.h
extern "C" __declspec(dllexport)  int dll();

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
