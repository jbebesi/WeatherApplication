�
xC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\WeatherApplication\Client\Program.cs
	namespace 	
WeatherApplication
 
. 
Client #
{ 
public 

class 
Program 
{ 
public 
static 
async 
Task  
Main! %
(% &
string& ,
[, -
]- .
args/ 3
)3 4
{		 	
var

 
builder

 
=

 "
WebAssemblyHostBuilder

 0
.

0 1


1 >
(

> ?
args

? C
)

C D
;

D E
builder 
. 
RootComponents "
." #
Add# &
<& '
App' *
>* +
(+ ,
$str, 1
)1 2
;2 3
builder
.
Services
.
	AddScoped
(
sp
=>
new

HttpClient
{
BaseAddress
=
new
Uri
(
builder
.
HostEnvironment
.
BaseAddress
)
}
)
;
builder 
. 
Services 
. 
	AddScoped &
<& '$
ShowWeatherDataViewModel' ?
>? @
(@ A
)A B
;B C
builder 
. 
Services 
. 
	AddScoped &
<& '
IndexViewModel' 5
>5 6
(6 7
)7 8
;8 9
builder 
. 
Services 
. 

AddLogging '
(' (
)( )
;) *
await 
builder 
. 
Build 
(  
)  !
.! "
RunAsync" *
(* +
)+ ,
;, -
} 	
} 
} 