<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DXWebApplication14.WebForm1" %>

<%@ Register Assembly="DevExpress.Web.ASPxGantt.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGantt" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script>
        function onTaskDblClick(s, e) {
            e.cancel = true;
            hiddenField.Clear();
            hiddenField.Add("taskKey", e.key);
            customTaskDetailsPopup.Show();
        }
        function onCancelClick(s, e) {
            hiddenField.Remove("taskKey");
            customTaskDetailsPopup.Hide();
        }
        function onUpdateClick(s, e) {
            UpdateAndClose(hiddenField.Get("taskKey"), { Subject: textBox.GetText(), PercentComplete: trackBar.GetValue(), Description: memo.GetText() }, tokenBox.GetValue());
        }

        function onShown(s, e) {
            var currentTask = clientGantt.GetTaskData(hiddenField.Get("taskKey"));
            textBox.SetText(currentTask.Subject);
            trackBar.SetValue(currentTask.PercentComplete);
            memo.SetValue(currentTask.Description);
            currentResources = clientGantt.GetTaskResources(hiddenField.Get("taskKey")).map(r => r.ID);
            tokenBox.SetValue(currentResources.join(","));
        }

        function UpdateAndClose(key, task, newResources) {
            clientGantt.UpdateTask(key, task);
            currentResources = clientGantt.GetTaskResources(key).map(r => r.ID);
            newResources.split(",").filter(r => !currentResources.includes(r)).forEach(r => clientGantt.AssignResourceToTask(r, key));
            currentResources.filter(r => !newResources.split(",").includes(r)).forEach(r => clientGantt.UnassignResourceFromTask(r, key));
            hiddenField.Remove("taskKey");
            customTaskDetailsPopup.Hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGantt ID="Gantt" runat="server" Height="700" Width="100%" ClientInstanceName="clientGantt" EnableViewState="false"
                TasksDataSourceID="TasksDataSource"
                DependenciesDataSourceID="DependenciesDataSource"
                ResourcesDataSourceID="ResourcesDataSource"
                ResourceAssignmentsDataSourceID="ResourceAssignmentsDataSource">
                <SettingsEditing Enabled="true" />
                <SettingsGanttView ShowResources="true" TaskTitlePosition="Outside" ViewType="Months" />
                <SettingsStripLine ShowCurrentTime="true" />
                <SettingsToolbar>
                    <Items>
                        <dx:GanttZoomInToolbarItem Text="Zoom In" />
                        <dx:GanttZoomOutToolbarItem Text="Zoom Out" />
                        <dx:GanttCollapseAllToolbarItem Text="Collapse all" />
                        <dx:GanttExpandAllToolbarItem Text="Expand all" />
                        <dx:GanttFullScreenToolbarItem Text="Full screen" />
                        <dx:GanttCustomToolbarItem Text="Custom" CommandName="custom1" />
                    </Items>
                </SettingsToolbar>
                <SettingsTaskList AllowSort="true" Width="600">
                    <Columns>
                        <dx:GanttTextColumn FieldName="Subject" Caption="Title" Width="250px" />
                        <dx:GanttDateTimeColumn FieldName="StartDate" Caption="Start" Width="90px" />
                        <dx:GanttDateTimeColumn FieldName="EndDate" Caption="End" Width="90px" />
                        <dx:GanttTextColumn FieldName="Description" Caption="Notes"></dx:GanttTextColumn>
                    </Columns>
                </SettingsTaskList>
                <Mappings>
                    <Task Key="ID" ParentKey="ParentID" Title="Subject" Start="StartDate" End="EndDate" Progress="PercentComplete" />
                    <Dependency Key="ID" PredecessorKey="ParentID" SuccessorKey="DependentID" DependencyType="Type" />
                    <Resource Key="ID" Name="Name" />
                    <ResourceAssignment Key="ID" TaskKey="TaskID" ResourceKey="ResourceID" />
                </Mappings>
                <ClientSideEvents TaskDblClick="onTaskDblClick" />
                <SettingsGanttView ViewType="Weeks" />
            </dx:ASPxGantt>
            <asp:ObjectDataSource ID="TasksDataSource" runat="server" DataObjectTypeName="Task" TypeName="GanttDataProvider" SelectMethod="GetTasks" UpdateMethod="UpdateTask" InsertMethod="InsertTask" DeleteMethod="DeleteTask" />
            <asp:ObjectDataSource ID="DependenciesDataSource" runat="server" DataObjectTypeName="Dependency" TypeName="GanttDataProvider" SelectMethod="GetDependencies" InsertMethod="InsertDependency" DeleteMethod="DeleteDependency" />
            <asp:ObjectDataSource ID="ResourcesDataSource" runat="server" DataObjectTypeName="Resource" TypeName="GanttDataProvider" SelectMethod="GetResources" UpdateMethod="UpdateResource" InsertMethod="InsertResource" DeleteMethod="DeleteResource" />
            <asp:ObjectDataSource ID="ResourceAssignmentsDataSource" runat="server" DataObjectTypeName="ResourceAssignment" TypeName="GanttDataProvider" SelectMethod="GetResourceAssignments" InsertMethod="InsertResourceAssignment" DeleteMethod="DeleteResourceAssignment" />

            <dx:ASPxPopupControl runat="server" ID="CustomTaskDetails" ClientInstanceName="customTaskDetailsPopup"
                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="Middle" Width="600" Height="400" HeaderText="Task Details">
                <ClientSideEvents Shown="onShown" />
                <ContentCollection>
                    <dx:PopupControlContentControl>
                        <dx:ASPxHiddenField runat="server" ID="HiddenField" ClientInstanceName="hiddenField"></dx:ASPxHiddenField>
                        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" Width="100%">
                            <Items>
                                <dx:LayoutGroup GroupBoxDecoration="None">
                                    <Items>
                                        <dx:LayoutItem FieldName="Subject">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ClientInstanceName="textBox" Width="100%" ID="ASPxFormLayout1_E1" runat="server">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="PercentComplete">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTrackBar ClientInstanceName="trackBar" Width="100%" runat="server" ID="ASPxFormLayout1_E2" MinValue="0" MaxValue="100" Step="1" ScalePosition="LeftOrTop" LargeTickInterval="10">
                                                    </dx:ASPxTrackBar>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="Resources">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTokenBox runat="server" ClientInstanceName="tokenBox" Width="100%" ID="ASPxFormLayout1_E3" OnInit="ASPxFormLayout1_E3_Init" ValueField="ID" ItemValueType="System.String" TextField="Name"></dx:ASPxTokenBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="Description" Caption="Notes">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxMemo runat="server" ClientInstanceName="memo" Width="100%" ID="ASPxFormLayout1_E4"></dx:ASPxMemo>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:EmptyLayoutItem></dx:EmptyLayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>
                        <div style="text-align: right; padding-right: 22px">
                            <dx:ASPxButton ID="ASPxFormLayout1_E5" runat="server" Text="Cancel" AutoPostBack="false">
                                <ClientSideEvents Click="onCancelClick" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="false" Text="Update">
                                <ClientSideEvents Click="onUpdateClick" />
                            </dx:ASPxButton>
                        </div>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>
        </div>
    </form>
</body>
</html>
