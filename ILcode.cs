using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs
{
    //il dasm 18 02 26
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface Iabc
    {
        void a();
    }

    delegate int funca(byte b);

    enum enmu1
    {
        a,
        b,
        c
    }

/* il 
.class /*02000002*/ private auto ansi beforefieldinit cs.Program
       extends [mscorlib/*23000001*/]System.Object/*01000010*/
{
  .method /*06000001*/ private hidebysig static 
          void  Main(string[] args) cil managed
  // SIG: 00 01 01 1D 0E
  {
    .entrypoint
    // Method begins at RVA 0x2050
    // Code size       2 (0x2)
    .maxstack  8
    .language '{3F5162F8-07C6-11D3-9053-00C04FA302A1}', '{994B45C4-E6E9-11D2-903F-00C04FA302A1}', '{5A869D0B-6611-11D3-BD2A-0000F80849BD}'
// Source File 'c:\users\v-shacui.fareast\source\repos\cs\cs\Program.cs' 
    .line 12,12 : 9,10 'c:\\users\\v-shacui.fareast\\source\\repos\\cs\\cs\\Program.cs'
//000012:         {
    IL_0000:  /* 00   |                  */ nop
    .line 13,13 : 9,10 ''
//000013:         }
    IL_0001:  /* 2A   |                  */ ret
  } // end of method Program::Main

  .method /*06000002*/ public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  // SIG: 20 00 01
  {
    // Method begins at RVA 0x2053
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  /* 02   |                  */ ldarg.0
    IL_0001:  /* 28   | (0A)00000F       */ call       instance void [mscorlib/*23000001*/]System.Object/*01000010*/::.ctor() /* 0A00000F */
    IL_0006:  /* 00   |                  */ nop
    IL_0007:  /* 2A   |                  */ ret
  } // end of method Program::.ctor

} // end of class cs.Program

.class /*02000003*/ interface private abstract auto ansi cs.Iabc
{
  .method /*06000003*/ public hidebysig newslot abstract virtual 
          instance void  a() cil managed
  // SIG: 20 00 01
  {
    // Method begins at RVA 0x0
  } // end of method Iabc::a

} // end of class cs.Iabc

.class /*02000004*/ private auto ansi sealed cs.funca
       extends [mscorlib/*23000001*/]System.MulticastDelegate/*01000011*/
{
  .method /*06000004*/ public hidebysig specialname rtspecialname 
          instance void  .ctor(object 'object',
                               native int 'method') runtime managed
  // SIG: 20 02 01 1C 18
  {
  } // end of method funca::.ctor

  .method /*06000005*/ public hidebysig newslot virtual 
          instance int32  Invoke(uint8 b) runtime managed
  // SIG: 20 01 08 05
  {
  } // end of method funca::Invoke

  .method /*06000006*/ public hidebysig newslot virtual 
          instance class [mscorlib/*23000001*/]System.IAsyncResult/*01000012*/ 
          BeginInvoke(uint8 b,
                      class [mscorlib/*23000001*/]System.AsyncCallback/*01000013*/ callback,
                      object 'object') runtime managed
  // SIG: 20 03 12 49 05 12 4D 1C
  {
  } // end of method funca::BeginInvoke

  .method /*06000007*/ public hidebysig newslot virtual 
          instance int32  EndInvoke(class [mscorlib/*23000001*/]System.IAsyncResult/*01000012*/ result) runtime managed
  // SIG: 20 01 08 12 49
  {
  } // end of method funca::EndInvoke

} // end of class cs.funca

.class /*02000005*/ private auto ansi sealed cs.enmu1
       extends [mscorlib/*23000001*/]System.Enum/*01000014*/
{
  .field /*04000001*/ public specialname rtspecialname int32 value__
  .field /*04000002*/ public static literal valuetype cs.enmu1/*02000005*/ a = int32(0x00000000)
  .field /*04000003*/ public static literal valuetype cs.enmu1/*02000005*/ b = int32(0x00000001)
  .field /*04000004*/ public static literal valuetype cs.enmu1/*02000005*/ c = int32(0x00000002)
} // end of class cs.enmu1
*/


}
