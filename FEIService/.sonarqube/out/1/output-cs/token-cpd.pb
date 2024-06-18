Ð

HC:\Users\danse\source\repos\FEIService\Domain\ViewStudentsQueueReport.cs
	namespace 	
Domain
 
{ 
[		 
DataContract		 
]		 
public

 

class

 #
ViewStudentsQueueReport

 (
{ 
[ 	

DataMember	 
] 
public 
int 
idAppointment  
{! "
get# &
;& '
set( +
;+ ,
}- .
[ 	

DataMember	 
] 
public 
DateTime 
attendedDate $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	

DataMember	 
] 
public 
int 
status 
{ 
get 
;  
set! $
;$ %
}& '
[!! 	

DataMember!!	 
]!! 
public"" 
string"" 
	idStudent"" 
{""  !
get""" %
;""% &
set""' *
;""* +
}"", -
['' 	

DataMember''	 
]'' 
public(( 
string(( 
studentName(( !
{((" #
get(($ '
;((' (
set(() ,
;((, -
}((. /
})) 
}** §
@C:\Users\danse\source\repos\FEIService\Domain\ViewStudentInfo.cs
	namespace 	
Domain
 
{ 
[ 
DataContract 
] 
public		 

class		 
ViewStudentInfo		  
{

 
[ 	

DataMember	 
] 
public 
string 
	idStudent 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	

DataMember	 
] 
public 
string 
fullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	

DataMember	 
] 
public 
int 
idTutor 
{ 
get  
;  !
set" %
;% &
}' (
[   	

DataMember  	 
]   
public!! 
int!! 
idCareer!! 
{!! 
get!! !
;!!! "
set!!# &
;!!& '
}!!( )
[&& 	

DataMember&&	 
]&& 
public'' 
int'' 
idUser'' 
{'' 
get'' 
;''  
set''! $
;''$ %
}''& '
[,, 	

DataMember,,	 
],, 
public-- 
string-- 
password-- 
{--  
get--! $
;--$ %
set--& )
;--) *
}--+ ,
[22 	

DataMember22	 
]22 
public33 
string33 
	tutorName33 
{33  !
get33" %
;33% &
set33' *
;33* +
}33, -
[88 	

DataMember88	 
]88 
public99 
string99 

careerName99  
{99! "
get99# &
;99& '
set99( +
;99+ ,
}99- .
}:: 
};; Ö
@C:\Users\danse\source\repos\FEIService\Domain\ViewAppointment.cs
	namespace 	
Domain
 
{ 
[		 
DataContract		 
]		 
public

 

class

 
ViewAppointment

  
{ 
[ 	

DataMember	 
] 
public 
int 
idAppointment  
{! "
get# &
;& '
set( +
;+ ,
}- .
[ 	

DataMember	 
] 
public 
DateTime 
attendedDate $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	

DataMember	 
] 
public 
int 
duration 
{ 
get !
;! "
set# &
;& '
}( )
[!! 	

DataMember!!	 
]!! 
public"" 
int"" 
status"" 
{"" 
get"" 
;""  
set""! $
;""$ %
}""& '
['' 	

DataMember''	 
]'' 
public(( 
string(( 
	idStudent(( 
{((  !
get((" %
;((% &
set((' *
;((* +
}((, -
[-- 	

DataMember--	 
]-- 
public.. 
string.. 
fullName.. 
{..  
get..! $
;..$ %
set..& )
;..) *
}..+ ,
[33 	

DataMember33	 
]33 
public44 
string44 
	tutorName44 
{44  !
get44" %
;44% &
set44' *
;44* +
}44, -
[99 	

DataMember99	 
]99 
public:: 
int:: 
idTutor:: 
{:: 
get::  
;::  !
set::" %
;::% &
}::' (
[?? 	

DataMember??	 
]?? 
public@@ 
int@@ 
idProcedure@@ 
{@@  
get@@! $
;@@$ %
set@@& )
;@@) *
}@@+ ,
[EE 	

DataMemberEE	 
]EE 
publicFF 
stringFF 
procedureNameFF #
{FF$ %
getFF& )
;FF) *
setFF+ .
;FF. /
}FF0 1
}GG 
}HH «
6C:\Users\danse\source\repos\FEIService\Domain\Tutor.cs
	namespace 	
Domain
 
{ 
[ 
DataContract 
] 
public		 

class		 
Tutor		 
{

 
[ 	

DataMember	 
] 
public 
int 
idTutor 
{ 
get  
;  !
set" %
;% &
}' (
[ 	

DataMember	 
] 
public 
string 
fullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ˜
GC:\Users\danse\source\repos\FEIService\Domain\StudentCallbackChanels.cs
	namespace 	
Domain
 
{ 
[ 
DataContract 
] 
public		 

class		 "
StudentCallbackChanels		 '
{

 
[ 	

DataMember	 
] 
public  
IAppointmentCallback #
appointmentCallback$ 7
{8 9
get: =
;= >
set? B
;B C
}D E
} 
} ñ
8C:\Users\danse\source\repos\FEIService\Domain\Student.cs
	namespace 	
Domain
 
{ 
[ 
DataContract 
] 
public		 

class		 
Student		 
{

 
[ 	

DataMember	 
] 
public 
string 
	idStudent 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	

DataMember	 
] 
public 
string 
fullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	

DataMember	 
] 
public 
int 
idTutor 
{ 
get  
;  !
set" %
;% &
}' (
[   	

DataMember  	 
]   
public!! 
int!! 
idCareer!! 
{!! 
get!! !
;!!! "
set!!# &
;!!& '
}!!( )
[&& 	

DataMember&&	 
]&& 
public'' 
int'' 
idUser'' 
{'' 
get'' 
;''  
set''! $
;''$ %
}''& '
[,, 	

DataMember,,	 
],, 
public-- 
string-- 
	matricula-- 
{--  !
get--" %
;--% &
set--' *
;--* +
}--, -
}.. 
}// ó
HC:\Users\danse\source\repos\FEIService\Domain\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str !
)! "
]" #
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
] 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str #
)# $
]$ %
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *³
:C:\Users\danse\source\repos\FEIService\Domain\Procedure.cs
	namespace 	
Domain
 
{ 
[ 
DataContract 
] 
public		 

class		 
	Procedure		 
{

 
[ 	

DataMember	 
] 
public 
string 
name 
{ 
get  
;  !
set" %
;% &
}' (
[ 	

DataMember	 
] 
public 
int 
idProcedure 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} °
KC:\Users\danse\source\repos\FEIService\Domain\Intafaces\IViewStudentInfo.cs
	namespace 	
Domain
 
{ 
[ 
ServiceContract 
] 
public		 

	interface		 
IViewStudentInfo		 %
{

 
[ 	
OperationContract	 
] 
ViewStudentInfo 
LogIn 
( 
string $
	studentId% .
,. /
string0 6
password7 ?
)? @
;@ A
} 
} £
AC:\Users\danse\source\repos\FEIService\Domain\Intafaces\ITutor.cs
	namespace 	
Domain
 
{ 
[

 
ServiceContract

 
]

 
public 

	interface 
ITutor 
{ 
[ 	
OperationContract	 
] 
List 
< 
Tutor 
> 
GetTutorsList !
(! "
)" #
;# $
[ 	
OperationContract	 
] 
Tutor 
GetTutorById 
( 
int 
idTutor &
)& '
;' (
} 
} ª
7C:\Users\danse\source\repos\FEIService\Domain\Career.cs
	namespace 	
Domain
 
{ 
[ 
DataContract 
] 
public		 

class		 
Career		 
{

 
[ 	

DataMember	 
] 
public 
int 
idCareer 
{ 
get !
;! "
set# &
;& '
}( )
[ 	

DataMember	 
] 
public 
string 
name 
{ 
get  
;  !
set" %
;% &
}' (
} 
} õ
EC:\Users\danse\source\repos\FEIService\Domain\Intafaces\IProcedure.cs
	namespace 	
Domain
 
{ 
[		 
ServiceContract		 
]		 
public

 

	interface

 

IProcedure

 
{ 
[ 	
OperationContract	 
] 
List 
< 
	Procedure 
> 
GetProcedureList (
(( )
)) *
;* +
} 
} ·
CC:\Users\danse\source\repos\FEIService\Domain\Intafaces\IStudent.cs
	namespace 	
Domain
 
{ 
[ 
ServiceContract 
] 
public		 

	interface		 
IStudent		 
{

 
[ 	
OperationContract	 
] 
bool 
RegisterStudent 
( 
ViewStudentInfo ,
student- 4
)4 5
;5 6
[ 	
OperationContract	 
] 
Student 
GetStudentNameById "
(" #
string# )
	idStudent* 3
)3 4
;4 5
} 
} é
BC:\Users\danse\source\repos\FEIService\Domain\Intafaces\ICareer.cs
	namespace 	
Domain
 
{ 
[

 
ServiceContract

 
]

 
public 

	interface 
ICareer 
{ 
[ 	
OperationContract	 
] 
List 
< 
Career 
> 
GetCareerList "
(" #
)# $
;$ %
} 
} á
GC:\Users\danse\source\repos\FEIService\Domain\Intafaces\IAppointment.cs
	namespace 	
Domain
 
{ 
[ 
ServiceContract 
( 
CallbackContract %
=& '
typeof( .
(. / 
IAppointmentCallback/ C
)C D
)D E
]E F
public 

	interface 
IAppointment !
{ 
[ 	
OperationContract	 
] 
List 
< 
Appointment 
> 
GetAllAppointments ,
(, -
)- .
;. /
[ 	
OperationContract	 
( 
IsOneWay #
=$ %
true& *
)* +
]+ ,
void 
AppointmentRequest 
(  
Domain  &
.& '
Appointment' 2
newAppointment3 A
)A B
;B C
[!! 	
OperationContract!!	 
(!! 
IsOneWay!! #
=!!$ %
true!!& *
)!!* +
]!!+ ,
void"" 
LeaveAppointment"" 
("" 
string"" $
	studentId""% .
,"". /
string""0 6
reason""7 =
)""= >
;""> ?
[)) 	
OperationContract))	 
])) 
void** 
CancelAppointment** 
(** 
int** "
idAppointment**# 0
,**0 1
string**2 8
reason**9 ?
)**? @
;**@ A
[00 	
OperationContract00	 
]00 
void11 %
MarkAppointmentAsAttended11 &
(11& '
int11' *
idAppointment11+ 8
)118 9
;119 :
[88 	
OperationContract88	 
]88 
void99 (
MarkAppointmentAsNotAttended99 )
(99) *
int99* -
idAppointment99. ;
,99; <
string99= C
reason99D J
)99J K
;99K L
[?? 	
OperationContract??	 
]?? 
List@@ 
<@@ #
ViewStudentsQueueReport@@ $
>@@$ %"
GetStudentsQueueReport@@& <
(@@< =
)@@= >
;@@> ?
[GG 	
OperationContractGG	 
]GG 
ListHH 
<HH 
ViewAppointmentHH 
>HH &
GetAppointmentReportByDateHH 8
(HH8 9
DateTimeHH9 A
dateHHB F
)HHF G
;HHG H
[NN 	
OperationContractNN	 
]NN 
voidOO 
JoinToSesionOO 
(OO 
stringOO  
	idStudentOO! *
)OO* +
;OO+ ,
}QQ 
[VV 
ServiceContractVV 
]VV 
publicWW 

	interfaceWW  
IAppointmentCallbackWW )
{XX 
[]] 	
OperationContract]]	 
]]] 
void^^ 
SetAppointments^^ 
(^^ 
List^^ !
<^^! "
Appointment^^" -
>^^- .
appointments^^/ ;
)^^; <
;^^< =
[dd 	
OperationContractdd	 
]dd 
voidee 
UpdateTimeree 
(ee 
TimeSpanee !
elapsedTimeee" -
)ee- .
;ee. /
[kk 	
OperationContractkk	 
]kk 
voidll 
NotifyCancellationll 
(ll  
stringll  &
reasonll' -
)ll- .
;ll. /
}mm 
}nn ”
<C:\Users\danse\source\repos\FEIService\Domain\Appointment.cs
	namespace 	
Domain
 
{ 
[ 
DataContract 
] 
public		 

class		 
Appointment		 
{

 
[ 	

DataMember	 
] 
public 
int 
idAppointment  
{! "
get# &
;& '
set( +
;+ ,
}- .
[ 	

DataMember	 
] 
public 
System 
. 
DateTime 
attendedDate +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
[ 	

DataMember	 
] 
public 
int 
duration 
{ 
get !
;! "
set# &
;& '
}( )
[   	

DataMember  	 
]   
public!! 
int!! 
status!! 
{!! 
get!! 
;!!  
set!!! $
;!!$ %
}!!& '
[&& 	

DataMember&&	 
]&& 
public'' 
string'' 
notAttendedReason'' '
{''( )
get''* -
;''- .
set''/ 2
;''2 3
}''4 5
[,, 	

DataMember,,	 
],, 
public-- 
string-- 
student_IdStudent-- '
{--( )
get--* -
;--- .
set--/ 2
;--2 3
}--4 5
[22 	

DataMember22	 
]22 
public33 
int33 !
procedure_IdProcedure33 (
{33) *
get33+ .
;33. /
set330 3
;333 4
}335 6
}44 
}55 