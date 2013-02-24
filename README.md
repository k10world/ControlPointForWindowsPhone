ControlPointForWindowsPhone
===========================

ControlPoint for Windows Phone was a summer project that I started during mid-2012. This was an effort to learn Windows Phone 7.5 development and get hands dirty. It turned out to be a great little client that leveraged the SharePoint list OData API to fetch data and display reports.
<div>
<div style ="float:left;"><img src="http://blogs.k10world.com/wp-content/uploads/2013/02/Portrait_CP_Moby.jpg" alt="Portrait Mode Snapshot" /></div>
<div style ="float:right;"><img src="http://blogs.k10world.com/wp-content/uploads/2013/02/Landscape_MobyCP.jpg" alt="Landscape Mode Snapshot"  /></div>
</div>

<div style="clear:both">
ControlPoint for Windows Phone is a client application. That said, it does not run reports live, but instead shows reports that can be scheduled by ControlPoint on-premise or on-cloud. All that the user has to do in preparation is that schedule a report to run daily or hourly recurring and view the report anytime they want using their Windows Phone.

Currently not all reports are available. The plumbing for Storage By File Type report is in place and other reports can be added easily. 

Use Case:
-  Site Admins or Administrators can monitor different sites at the same time – while traveling or take a quick peek on smartphone anywhere!
-	Monitor storage usage in the scope remotely (while on a weekend or vacation)
-	Monitor Activity in the scope remotely (while on a weekend or vacation)
-	Get ControlPoint Alerts instantly on phone. (Permissions change alert for example – within minutes) – not currently implemented.
-	Configure config settings using phone – not currently implemented


Technologies  - 
REST (OData) – API 
(The power of RESTful API  https://ketansp2010.axcelertest.local/_vti_bin/ListData.svc/XcrFileTypeStorageReport_m_Storage_VirtualServersDS()?$orderby=TotalSize&$select=Extension,TotalSize,TotalFiles)
Silverlight/WPF (MVVM)
Windows Phone development
 
Technical Details – 
I am not running the reports real time – but making the use of “recurring” ControlPoint’s - report to SharePoint List feature. SharePoint exposes the RESTful API and I fetch the data from the SharePoint list that contains report data. I am downloading the data as JSON (not XML) – considering 3G speed these reports render within seconds (not minutes!!!). I have done the math!!
 
Features available in this app! (Overview)
-  Storage By File Type
-	Site Activity Analysis
-	Top Page Views
-	Top Document Views
-	Users Most Active
Users can instantly rate this app and post comment!!
Errors and stack traces can be registered automatically with one tap!
Call support instantly from phone!!
 
What’s Good!
1.	The common data/business logic layer can also be reused for tablet application of any platform. (Microsoft tablet Surface is coming!!)
2.	It supports Claims based authentication (Tested this with FBA).
3.	The learning curve for anyone inheriting/contributing this project is minimal, since it’s all .NET technologies. (Silverlight, C#)
 
What’s not so Good!
-	NTLM/Windows authentication is not supported and is no good for internet applications. Neither Android nor iOS apps supports that (while browsers do (firefox) – apps don’t)
-	We can make this application work with intranet and NTLM but it will require installation of UAG in SharePoint environment.
-	We need to restrict reports to TOP 10/30/50 (a number that makes sense for display of charts).
-	I am artistically austistic – so the look and feel needs touch-up.
 
Future Feature Enhancements:
-	ControlPoint Alerts (notification on application bar of Windows Mobile)
-	More features that really make sense can be added.
 
***This application is not standalone application – but works only if you have ControlPoint. There are other vendors (not competitors) who are doing things along the same line and Microsoft App store allows such dependent apps.

