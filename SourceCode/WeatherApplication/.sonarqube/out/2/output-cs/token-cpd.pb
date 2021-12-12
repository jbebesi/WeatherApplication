î
xC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\WeatherApplication\Client\Program.cs
	namespace 	
WeatherApplication
 
. 
Client #
{ 
public 

static 
class 
Program 
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
CreateDefault
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
builder 
. 
Services 
. 
	AddScoped &
(& '
sp' )
=>* ,
new- 0

HttpClient1 ;
{< =
BaseAddress> I
=J K
newL O
UriP S
(S T
builderT [
.[ \
HostEnvironment\ k
.k l
BaseAddressl w
)w x
}y z
)z {
;{ |
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