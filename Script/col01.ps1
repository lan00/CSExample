#check files
$runid=1
$runid=5529276
$file1="\\mdfile3\orcasts\files\core\results\run$runid\omnilog.html"
if ( test-path $file1) {
echo exist $file1 
} else { 
new-item $file1
}  # =========== create files if don't exist ===========

# =========== move files ===========
$d="AbstractionLayer.dll",
"AbstractionLayer.pdb",
"Maui.VisualStudio.Current.dll",
"Maui.VisualStudio.Current.pdb",
"Maui.VisualStudio.Current.WebForms.dll",
"Maui.VisualStudio.Current.WebForms.pdb"
$d=
"Maui.VisualStudio.Current.dll",
"Maui.VisualStudio.Current.pdb"
$d2="E:\devdiv\VS\out\binaries\x86ret\SuiteBin\"
$d=
"Maui.VisualStudio.Current.dll",
"Maui.VisualStudio.Current.pdb",
"maui.core.dll",
"maui.core.pdb"
#  $d|%{mv $_ 2Dll\o}

md 2dll
md 2dll\o
md 2dll\n
# md 2n
$d|%{dir $_}
$d|%{mv $_ 2Dll\o}
$d|%{dir $_}

$d|%{mv $_ 2Dll\n}
$d|%{mv 2Dll\$_ }

$d|%{dir $_}

# =========== find str ===========

$driverLog="\\mdfile3\OrcasTS\Files\Core\Results\Run5513370\362104_24243_MSBuild.Driver.log"
$r2=type $driverLog |findstr /i /l "copying"
$r3= $r2 |findstr /i /l "file" |findstr /i /l ".vb"
$r= $r3 |findstr /i /l "aa.vb"
echo $r

# =========== open pro ===========
#open rdp , if don't open it
Start-Transcript -Path C:\Users\v-shacui\Downloads\其它\task\log.txt -Append

$start2=date -Format "yyyy-MM-dd hh:mm:ss"
write-host $start2  "start"

$remote= ps -name  mstsc
$run='false'
$remote| %{ if ($_.mainWindowTitle.contains("v-shacui001") ) {  $run='true'; } 
    #else { $run='false' } 
    }
if($run -eq 'true'){ write-host remote desktop run  }
else { write-host remote desktop donot run ; start "C:\Users\v-shacui\Downloads\其它\task\Default 1.rdp" }

$start2=date -Format "yyyy-MM-dd hh:mm:ss"
write-host $start2  "end"
write-host

Stop-Transcript
# pause

# =========== install pro ===========
cmd /c start cmd /c \\sharefile\ver \channels\internal\Preview\bootstrappers\fixed\Enterprise\vs_enterprise.exe --installPath "%SystemDrive%\Program Files (x86)\Microsoft Visual Studio 15.0" --add Microsoft.VisualStudio.Workload.NetWeb --add Microsoft.VisualStudio.Workload.ManagedDesktop --add Microsoft.VisualStudio.Component.LinqToSql --add Microsoft.VisualStudio.Component.TestTools.CodedUITest --includeRecommended --includeOptional --norestart --passive --wait
