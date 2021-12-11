¬
ŽC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\SubscriptionService\Controllers\SubscriptionsController.cs
	namespace 	
SubscriptionService
 
. 
Controllers )
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
class #
SubscriptionsController (
:) *
ControllerBase+ 9
{ 
private 
readonly 
ILogger  
<  !#
SubscriptionsController! 8
>8 9
_logger: A
;A B
private 
readonly  
ISubscriptionService -#
_iSubscriptionInterface. E
;E F
public #
SubscriptionsController &
(& '
ILogger' .
<. /#
SubscriptionsController/ F
>F G
loggerH N
,N O 
ISubscriptionServiceP d"
isubscriptionInterfacee {
){ |
{ 	
_logger 
= 
logger 
; #
_iSubscriptionInterface #
=$ %"
isubscriptionInterface& <
;< =
} 	
[ 	
HttpGet	 
] 
public 
Subscription 
Get 
(  
)  !
{ 	
try 
{ 
return #
_iSubscriptionInterface .
.. /
GetSubscription/ >
(> ?
$str? A
)A B
;B C
} 
catch 
( 
	Exception 
ex 
) 
{ 
_logger   
.   

LogWarning   "
(  " #
ex  # %
.  % &
Message  & -
,  - .
ex  . 0
)  0 1
;  1 2
return!! 
null!! 
;!! 
}"" 
}## 	
}$$ 
}%% ›
ŒC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\SubscriptionService\Interfaces\ISubscriptionInterface.cs
	namespace 	
SubscriptionService
 
. 

Interfaces (
{ 
public 

	interface  
ISubscriptionService )
{ 
public 
Subscription 
GetSubscription +
(+ ,
string, 2
subscriptionName3 C
)C D
;D E
} 
}		 ç

rC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\SubscriptionService\Program.cs
	namespace 	
SubscriptionService
 
{ 
public 

static 
class 
Program 
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
} ß
‡C:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\SubscriptionService\Services\SubscriptionService.cs
	namespace 	
SubscriptionService
 
. 
Services &
{ 
public 

class 
SubscriptionService $
:% & 
ISubscriptionService' ;
{ 
public		 
Subscription		 
GetSubscription		 +
(		+ ,
string		, 2
subscriptionName		3 C
)		C D
{

 	
return 
new 
Subscription #
(# $
)$ %
{ 
	FirstName 
= 
$str '
,' (
ID 
= 
$num 
, 
LastName 
= 
$str %
,% &
SubscriberUntil 
=  !
DateTime" *
.* +
Now+ .
.. /

AddMinutes/ 9
(9 :
$num: ;
); <
} 
; 
} 	
} 
} 
rC:\Users\Janos Bebesi\source\repos\WeatherApplication\SourceCode\WeatherApplication\SubscriptionService\Startup.cs
	namespace		 	
SubscriptionService		
 
{

 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddControllers #
(# $
)$ %
;% &
services 
. 
	AddScoped 
<  
ISubscriptionService 3
,3 4
Services5 =
.= >
SubscriptionService> Q
>Q R
(R S
)S T
;T U
services 
. 
AddSwaggerGen "
(" #
c# $
=>% '
{ 
c 
. 

SwaggerDoc 
( 
$str !
,! "
new# &
OpenApiInfo' 2
{3 4
Title5 :
=; <
$str= R
,R S
VersionT [
=\ ]
$str^ b
}c d
)d e
;e f
} 
) 
; 
} 	
public!! 
void!! 
	Configure!! 
(!! 
IApplicationBuilder!! 1
app!!2 5
,!!5 6
IWebHostEnvironment!!7 J
env!!K N
)!!N O
{"" 	
if## 
(## 
env## 
.## 
IsDevelopment## !
(##! "
)##" #
)### $
{$$ 
app%% 
.%% %
UseDeveloperExceptionPage%% -
(%%- .
)%%. /
;%%/ 0
app&& 
.&& 

UseSwagger&& 
(&& 
)&&  
;&&  !
app'' 
.'' 
UseSwaggerUI''  
(''  !
c''! "
=>''# %
c''& '
.''' (
SwaggerEndpoint''( 7
(''7 8
$str''8 R
,''R S
$str''T l
)''l m
)''m n
;''n o
}(( 
app** 
.** 

UseRouting** 
(** 
)** 
;** 
app,, 
.,, 
UseAuthorization,,  
(,,  !
),,! "
;,," #
app.. 
... 
UseEndpoints.. 
(.. 
	endpoints.. &
=>..' )
{// 
	endpoints00 
.00 
MapControllers00 (
(00( )
)00) *
;00* +
}11 
)11 
;11 
}22 	
}33 
}44 