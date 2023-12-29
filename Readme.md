<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/311753879/20.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T948017)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
## Gantt for  Web Forms - How to implement a custom "Task details" dialog 
This example demonstrates how to implement a custom "Task details" dialog for the Gantt control. 
 The main idea of a solution is to cancel the default dialog showing in the client-side [TaskDblClick](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.TaskDblClick) event handler and display a custom dialog instead. In this example, the custom dialog is created using [ASPxPopupControl](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPopupControl). 
Data modifications are implemented using the [client-side API](https://docs.devexpress.com/AspNet/js-ASPxClientGantt._methods).

1. Create [PopupControl]./CS/DXWebApplication/Default.aspx#L88) with the FormLayout inside. Adjust editors in the FormLayout.
2. Handle the client-side [TaskDblClick](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.TaskDblClick) event and [cancel](./CS/DXWebApplication/Default.aspx#L12) the default dialog showing. Display your custom dialog.
3. Handle the onShown event of the popup. Obtain an edited task using the [GetTaskData](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.GetTaskData%28key%29) method. [Specify values](./CS/DXWebApplication/Default.aspx#L28) of editors in the dialog.
4. To save changes, use the [UpdateTask](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.UpdateTask%28key-data%29?p=netframework) and [AssignResourceToTask](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.AssignResourceToTask%28resourceKey-taskKey%29)/[UnassignResourceFromTask](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.UnassignResourceFromTask%28resourceKey-taskKey%29) methods. Hide the popup after this.

[Default.aspx](./CS/DXWebApplication/Default.aspx)([Default.aspx](./VB/DXWebApplication/Default.aspx))

[Default.aspx.cs](./CS/DXWebApplication/Default.aspx.cs)([Default.aspx.vb](./VB/DXWebApplication/Default.aspx.vb))

[GanttDataProvider.cs](./CS/DXWebApplication/App_Data/GanttDataProvider.cs)([GanttDataProvider.vb](./VB/DXWebApplication/App_Data/GanttDataProvider.vb))
