´
èC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\WeatherApplication\Server\Controllers\CityListController.cs
	namespace

 	
WeatherApplication


 
.

 
Server

 #
.

# $
Controllers

$ /
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
CityListController #
:$ %
ControllerBase& 4
{ 
private 
readonly 
ILogger  
<  !
CityListController! 3
>3 4
_logger5 <
;< =
private 
readonly 
ICityListProvider *
_cityListProvider+ <
;< =
public 
CityListController !
(! "
ILogger" )
<) *
CityListController* <
>< =
logger> D
,D E
ICityListProviderF W
cityListProviderX h
)h i
{ 	
_logger 
= 
logger 
; 
_cityListProvider 
= 
cityListProvider  0
;0 1
} 	
[ 	
HttpGet	 
( 
) 
] 
public 
async 
Task 
< 
IEnumerable %
<% &
CityData& .
>. /
>/ 0
Get1 4
(4 5
)5 6
{ 	
var 
result 
= 
_cityListProvider *
.* +
GetCityList+ 6
(6 7
$str7 9
)9 :
;: ;
return 
await 
Task 
. 

FromResult (
(( )
result) /
)/ 0
;0 1
} 	
["" 	
HttpGet""	 
("" 
$str"" 
)"" 
]"" 
public## 
async## 
Task## 
<## 
IEnumerable## %
<##% &
CityData##& .
>##. /
>##/ 0
Get##1 4
(##4 5
string##5 ;
filter##< B
)##B C
{$$ 	
var%% 
result%% 
=%% 
_cityListProvider%% *
.%%* +
GetCityList%%+ 6
(%%6 7
filter%%7 =
)%%= >
;%%> ?
return&& 
await&& 
Task&& 
.&& 

FromResult&& (
(&&( )
result&&) /
)&&/ 0
;&&0 1
}'' 	
}(( 
})) ≥
îC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\WeatherApplication\Server\Controllers\SubscriptionsController.cs
	namespace		 	
WeatherApplication		
 
.		 
Server		 #
.		# $
Controllers		$ /
{

 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class #
SubscriptionsController (
:) *
ControllerBase+ 9
{ 
private 
readonly 
ILogger  
<  !#
SubscriptionsController! 8
>8 9
_logger: A
;A B
public #
SubscriptionsController &
(& '
ILogger' .
<. /#
SubscriptionsController/ F
>F G
loggerH N
)N O
{ 	
_logger 
= 
logger 
; 
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
Subscription &
>& '
Get( +
(+ ,
), -
{ 	
try 
{ 
var 
client 
= 
new  

HttpClient! +
(+ ,
), -
{. /
BaseAddress0 ;
=< =
new> A
UriB E
(E F
$strF e
)e f
}g h
;h i
return 
await 
client #
.# $
GetFromJsonAsync$ 4
<4 5
Subscription5 A
>A B
(B C
$strC R
)R S
;S T
} 
catch   
(   
	Exception   
ex   
)    
{!! 
_logger"" 
."" 
LogError""  
(""  !
ex""! #
.""# $
Message""$ +
,""+ ,
ex""- /
)""/ 0
;""0 1
return## 
new## 
Subscription## '
(##' (
)##( )
{##* +
	FirstName##, 5
=##6 7
$"##8 :
$str##: B
{##B C
ex##C E
.##E F
Message##F M
}##M N
"##N O
}##P Q
;##Q R
}$$ 
}%% 	
}&& 
}'' ‡
ñC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\WeatherApplication\Server\Controllers\WeatherForecastController.cs
	namespace 	
WeatherApplication
 
. 
Server #
.# $
Controllers$ /
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 
)

 
]

 
public 

class %
WeatherForecastController *
:+ ,
ControllerBase- ;
{ 
private 
readonly 
ILogger  
<  !%
WeatherForecastController! :
>: ;
_logger< C
;C D
private 
readonly 
IWeatherService (
_weatherService) 8
;8 9
public %
WeatherForecastController (
(( )
ILogger) 0
<0 1%
WeatherForecastController1 J
>J K
loggerL R
,R S
IWeatherServiceT c
weatherProviderd s
)s t
{ 	
_logger 
= 
logger 
; 
_weatherService 
= 
weatherProvider -
;- .
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
WeatherForecastData -
>- .
Get/ 2
(2 3
string3 9
city: >
)> ?
{ 	
_logger 
. 
LogInformation "
(" #
$str# /
)/ 0
;0 1
return 
await 
_weatherService (
.( )$
GetWeatherForecastsAsync) A
(A B
cityB F
)F G
;G H
} 	
[ 	
HttpGet	 
( 
) 
] 
public 
async 
Task 
< 
WeatherForecastData -
>- .
Get/ 2
(2 3
)3 4
{ 	
_logger 
. 
LogInformation "
(" #
$str# /
)/ 0
;0 1
var   
result   
=   
await   
_weatherService   .
.  . /$
GetWeatherForecastsAsync  / G
(  G H
$str  H J
)  J K
;  K L
result!! 
.!! 
CityName!! 
=!! 
$str!! #
;!!# $
return"" 
result"" 
;"" 
}## 	
}$$ 
}%% ∂
ÉC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\WeatherApplication\Server\Pages\Error.cshtml.cs
	namespace 	
WeatherApplication
 
. 
Server #
.# $
Pages$ )
{ 
[		 
ResponseCache		 
(		 
Duration		 
=		 
$num		 
,		  
Location		! )
=		* +!
ResponseCacheLocation		, A
.		A B
None		B F
,		F G
NoStore		H O
=		P Q
true		R V
)		V W
]		W X
public

 

class

 

ErrorModel

 
:

 
	PageModel

 '
{ 
public 
string 
	RequestId 
{  !
get" %
;% &
set' *
;* +
}, -
public 
bool 
ShowRequestId !
=>" $
!% &
string& ,
., -
IsNullOrEmpty- :
(: ;
	RequestId; D
)D E
;E F
private 
readonly 
ILogger  
<  !

ErrorModel! +
>+ ,
_logger- 4
;4 5
public 

ErrorModel 
( 
ILogger !
<! "

ErrorModel" ,
>, -
logger. 4
)4 5
{ 	
_logger 
= 
logger 
; 
} 	
public 
void 
OnGet 
( 
) 
{ 	
try 
{ 
	RequestId 
= 
Activity $
.$ %
Current% ,
?, -
.- .
Id. 0
??1 3
HttpContext4 ?
.? @
TraceIdentifier@ O
;O P
} 
catch 
( 
	Exception 
ex 
)  
{ 
_logger 
. 
LogError  
(  !
ex! #
.# $
Message$ +
)+ ,
;, -
}   
}!! 	
}"" 
}## ˚

xC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\WeatherApplication\Server\Program.cs
	namespace 	
WeatherApplication
 
. 
Server #
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{		 	
CreateHostBuilder

 
(

 
args

 "
)

" #
.

# $
Build

$ )
(

) *
)

* +
.

+ ,
Run

, /
(

/ 0
)

0 1
;

1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} â
xC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\WeatherApplication\Server\Startup.cs
	namespace 	
WeatherApplication
 
. 
Server #
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. #
AddControllersWithViews ,
(, -
)- .
;. /
services 
. 
	AddScoped 
< 
IWeatherService .
,. /
WeatherService0 >
>> ?
(? @
)@ A
;A B
services 
. 
	AddScoped 
< 
IWeatherDataStore 0
,0 1
WeatherDataStore2 B
>B C
(C D
)D E
;E F
services 
. 
	AddScoped 
< 
IWeatherProvider /
,/ 0!
ConnectOpenWeatherMap1 F
>F G
(G H
)H I
;I J
services 
. 
	AddScoped 
< 
ICityListProvider 0
,0 1
CityListProvider2 B
>B C
(C D
)D E
;E F
services   
.   
	AddScoped   
<   

HttpClient   )
>  ) *
(  * +
)  + ,
;  , -
services!! 
.!! 
AddRazorPages!! "
(!!" #
)!!# $
;!!$ %
}"" 	
public%% 
void%% 
	Configure%% 
(%% 
IApplicationBuilder%% 1
app%%2 5
,%%5 6
IWebHostEnvironment%%7 J
env%%K N
)%%N O
{&& 	
if'' 
('' 
env'' 
.'' 
IsDevelopment'' !
(''! "
)''" #
)''# $
{(( 
app)) 
.)) %
UseDeveloperExceptionPage)) -
())- .
))). /
;))/ 0
app** 
.** #
UseWebAssemblyDebugging** +
(**+ ,
)**, -
;**- .
}++ 
else,, 
{-- 
app.. 
... 
UseExceptionHandler.. '
(..' (
$str..( 0
)..0 1
;..1 2
app00 
.00 
UseHsts00 
(00 
)00 
;00 
}11 
app33 
.33 
UseHttpsRedirection33 #
(33# $
)33$ %
;33% &
app44 
.44 #
UseBlazorFrameworkFiles44 '
(44' (
)44( )
;44) *
app55 
.55 
UseStaticFiles55 
(55 
)55  
;55  !
app77 
.77 

UseRouting77 
(77 
)77 
;77 
app99 
.99 
UseEndpoints99 
(99 
	endpoints99 &
=>99' )
{:: 
	endpoints;; 
.;; 
MapRazorPages;; '
(;;' (
);;( )
;;;) *
	endpoints<< 
.<< 
MapControllers<< (
(<<( )
)<<) *
;<<* +
	endpoints== 
.== 
MapFallbackToFile== +
(==+ ,
$str==, 8
)==8 9
;==9 :
}>> 
)>> 
;>> 
}?? 	
}@@ 
}AA 