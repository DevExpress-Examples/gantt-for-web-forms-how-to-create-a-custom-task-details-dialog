## Gantt for  Web Forms - How to implement a custom "Task details" dialog 
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/311753879/)**
<!-- run online end -->
This example demonstrates how to implement a custom "Task details" dialog for the Gantt control. 
 The main idea of a solution is to cancel the default dialog showing in the client-side [TaskDblClick](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.TaskDblClick) event handler and display a custom dialog instead. In this example, the custom dialog is created using [ASPxPopupControl](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPopupControl). 
Data modifications are implemented using the [client-side API](https://docs.devexpress.com/AspNet/js-ASPxClientGantt._methods).

1. Create [PopupControl](https://github.com/DevExpress-Examples/gantt-for-web-forms-how-to-create-a-custom-task-details-dialog/blob/20.2.3%2B/CS/DXWebApplication/Default.aspx#L88) with the FormLayout inside. Adjust editors in the FormLayout.
2. Handle the client-side [TaskDblClick](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.TaskDblClick) event and [cancel](https://github.com/DevExpress-Examples/gantt-for-web-forms-how-to-create-a-custom-task-details-dialog/blob/20.2.3%2B/CS/DXWebApplication/Default.aspx#L12) the default dialog showing. Display your custom dialog.
3. Handle the onShown event of the popup. Obtain an edited task using the [GetTaskData](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.GetTaskData%28key%29) method. [Specify values](https://github.com/DevExpress-Examples/gantt-for-web-forms-how-to-create-a-custom-task-details-dialog/blob/20.2.3%2B/CS/DXWebApplication/Default.aspx#L28) of editors in the dialog.
4. To save changes, use the [UpdateTask](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.UpdateTask%28key-data%29?p=netframework) and [AssignResourceToTask](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.AssignResourceToTask%28resourceKey-taskKey%29)/[UnassignResourceFromTask](https://docs.devexpress.com/AspNet/js-ASPxClientGantt.UnassignResourceFromTask%28resourceKey-taskKey%29) methods. Hide the popup after this.

[Default.aspx][0]([Default.aspx][1])

[Default.aspx.cs][2]([Default.aspx.vb][3])

[GanttDataProvider.cs][4]([GanttDataProvider.vb][5])
 
 

[0]: https://github.com/DevExpress-Examples/gantt-for-web-forms-how-to-create-a-custom-task-details-dialog/blob/20.2.3%2B/CS/DXWebApplication/Default.aspx
[1]: https://github.com/DevExpress-Examples/gantt-for-web-forms-how-to-create-a-custom-task-details-dialog/blob/20.2.3%2B/VB/DXWebApplication/Default.aspx
[2]: https://github.com/DevExpress-Examples/gantt-for-web-forms-how-to-create-a-custom-task-details-dialog/blob/20.2.3%2B/CS/DXWebApplication/Default.aspx.cs
[3]: https://github.com/DevExpress-Examples/gantt-for-web-forms-how-to-create-a-custom-task-details-dialog/blob/20.2.3%2B/VB/DXWebApplication/Default.aspx.vb
[4]: https://github.com/DevExpress-Examples/gantt-for-web-forms-how-to-create-a-custom-task-details-dialog/blob/20.2.3%2B/CS/DXWebApplication/App_Data/GanttDataProvider.cs
[5]: https://github.com/DevExpress-Examples/gantt-for-web-forms-how-to-create-a-custom-task-details-dialog/blob/20.2.3%2B/VB/DXWebApplication/App_Data/GanttDataProvider.vb
