Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.SessionState

Public Module GanttDataProvider

    Const TasksSessionKey As String = "Tasks", DependenciesSessionKey As String = "Dependencies", ResourcesSessionKey As String = "Resources", ResourceAssignmentsSessionKey As String = "ResourceAssignments"

    Private ReadOnly Property Session As HttpSessionState
        Get
            Return HttpContext.Current.Session
        End Get
    End Property

    Public Function GetTasks() As Object
        Return Tasks
    End Function

    Public Function GetDependencies() As Object
        Return Dependencies
    End Function

    Public Function GetResources() As Object
        Return Resources
    End Function

    Public Function GetResourceAssignments() As Object
        Return ResourceAssignments
    End Function

    Public ReadOnly Property Tasks As List(Of Task)
        Get
            If Session(TasksSessionKey) Is Nothing Then Session(TasksSessionKey) = CreateTasks()
            Return CType(Session(TasksSessionKey), List(Of Task))
        End Get
    End Property

    Public ReadOnly Property Dependencies As List(Of Dependency)
        Get
            If Session(DependenciesSessionKey) Is Nothing Then Session(DependenciesSessionKey) = CreateDependencies()
            Return CType(Session(DependenciesSessionKey), List(Of Dependency))
        End Get
    End Property

    Public ReadOnly Property Resources As List(Of Resource)
        Get
            If Session(ResourcesSessionKey) Is Nothing Then Session(ResourcesSessionKey) = CreateResources()
            Return CType(Session(ResourcesSessionKey), List(Of Resource))
        End Get
    End Property

    Public ReadOnly Property ResourceAssignments As List(Of ResourceAssignment)
        Get
            If Session(ResourceAssignmentsSessionKey) Is Nothing Then Session(ResourceAssignmentsSessionKey) = CreateResourceAssignments()
            Return CType(Session(ResourceAssignmentsSessionKey), List(Of ResourceAssignment))
        End Get
    End Property

    Private Function CreateTasks() As List(Of Task)
        Dim result = New List(Of Task)()
        result.Add(CreateTask("0", "", "Software Development", "02/21/2020 08:00:00", "07/04/2020 15:00:00", "31", "1", "0", "", ""))
        result.Add(CreateTask("1", "0", "Scope", "02/21/2020 08:00:00", "02/26/2020 12:00:00", "60", "1", "1", "", ""))
        result.Add(CreateTask("2", "1", "Determine project scope", "02/21/2020 08:00:00", "02/21/2020 12:00:00", "100", "1", "2", "1", "Important"))
        result.Add(CreateTask("3", "1", "Secure project sponsorship", "02/21/2020 13:00:00", "02/22/2020 12:00:00", "100", "1", "2", "1", ""))
        result.Add(CreateTask("4", "1", "Define preliminary resources", "02/22/2020 13:00:00", "02/25/2020 12:00:00", "60", "1", "2", "2", ""))
        result.Add(CreateTask("5", "1", "Secure core resources", "02/25/2020 13:00:00", "02/26/2020 12:00:00", "0", "1", "2", "2", ""))
        result.Add(CreateTask("6", "1", "Scope complete", "02/26/2020 12:00:00", "02/26/2020 12:00:00", "0", "0", "2", "", "Important"))
        result.Add(CreateTask("7", "0", "Analysis/Software Requirements", "02/26/2020 13:00:00", "03/18/2020 12:00:00", "80", "1", "1", "", "Important"))
        result.Add(CreateTask("8", "7", "Conduct needs analysis", "02/26/2020 13:00:00", "03/05/2020 12:00:00", "100", "1", "2", "3", ""))
        result.Add(CreateTask("9", "7", "Draft preliminary software specifications", "03/05/2020 13:00:00", "03/08/2020 12:00:00", "100", "1", "2", "3", ""))
        result.Add(CreateTask("10", "7", "Develop preliminary budget", "03/08/2020 13:00:00", "03/12/2020 12:00:00", "100", "1", "2", "2", ""))
        result.Add(CreateTask("11", "7", "Review software specifications/budget with team", "03/12/2020 13:00:00", "03/12/2020 17:00:00", "100", "1", "2", "2,3", ""))
        result.Add(CreateTask("12", "7", "Incorporate feedback on software specifications", "03/13/2020 08:00:00", "03/13/2020 17:00:00", "70", "1", "2", "3", ""))
        result.Add(CreateTask("13", "7", "Develop delivery timeline", "03/14/2020 08:00:00", "03/14/2020 17:00:00", "0", "1", "2", "2", ""))
        result.Add(CreateTask("14", "7", "Obtain approvals to proceed (concept, timeline, budget)", "03/15/2020 08:00:00", "03/15/2020 12:00:00", "0", "1", "2", "1,2", ""))
        result.Add(CreateTask("15", "7", "Secure required resources", "03/15/2020 13:00:00", "03/18/2020 12:00:00", "0", "1", "2", "2", ""))
        result.Add(CreateTask("16", "7", "Analysis complete", "03/18/2020 12:00:00", "03/18/2020 12:00:00", "0", "0", "2", "", ""))
        result.Add(CreateTask("17", "0", "Design", "03/18/2020 13:00:00", "04/05/2020 17:00:00", "80", "1", "1", "", ""))
        result.Add(CreateTask("18", "17", "Review preliminary software specifications", "03/18/2020 13:00:00", "03/20/2020 12:00:00", "100", "1", "2", "3", ""))
        result.Add(CreateTask("19", "17", "Develop functional specifications", "03/20/2020 13:00:00", "03/27/2020 12:00:00", "100", "1", "2", "3", ""))
        result.Add(CreateTask("20", "17", "Develop prototype based on functional specifications", "03/27/2020 13:00:00", "04/02/2020 12:00:00", "100", "1", "2", "3", ""))
        result.Add(CreateTask("21", "17", "Review functional specifications", "04/02/2020 13:00:00", "04/04/2020 12:00:00", "30", "1", "2", "1", ""))
        result.Add(CreateTask("22", "17", "Incorporate feedback into functional specifications", "04/04/2020 13:00:00", "04/05/2020 12:00:00", "0", "1", "2", "1", ""))
        result.Add(CreateTask("23", "17", "Obtain approval to proceed", "04/05/2020 13:00:00", "04/05/2020 17:00:00", "0", "1", "2", "1,2", ""))
        result.Add(CreateTask("24", "17", "Design complete", "04/05/2020 17:00:00", "04/05/2020 17:00:00", "0", "0", "2", "", ""))
        result.Add(CreateTask("25", "0", "Development", "04/08/2020 08:00:00", "05/07/2020 15:00:00", "42", "1", "1", "", ""))
        result.Add(CreateTask("26", "25", "Review functional specifications", "04/08/2020 08:00:00", "04/08/2020 17:00:00", "100", "1", "2", "4", ""))
        result.Add(CreateTask("27", "25", "Identify modular/tiered design parameters", "04/09/2020 08:00:00", "04/09/2020 17:00:00", "100", "1", "2", "4", ""))
        result.Add(CreateTask("28", "25", "Assign development staff", "04/10/2020 08:00:00", "04/10/2020 17:00:00", "100", "1", "2", "4", ""))
        result.Add(CreateTask("29", "25", "Develop code", "04/11/2020 08:00:00", "05/01/2020 17:00:00", "49", "1", "2", "4", ""))
        result.Add(CreateTask("30", "25", "Developer testing (primary debugging)", "04/16/2020 15:00:00", "05/07/2020 15:00:00", "24", "1", "2", "4", ""))
        result.Add(CreateTask("31", "25", "Development complete", "05/07/2020 15:00:00", "05/07/2020 15:00:00", "0", "0", "2", "", ""))
        result.Add(CreateTask("32", "0", "Testing", "04/08/2020 08:00:00", "06/13/2020 15:00:00", "23", "1", "1", "", ""))
        result.Add(CreateTask("33", "32", "Develop unit test plans using product specifications", "04/08/2020 08:00:00", "04/11/2020 17:00:00", "100", "1", "2", "5", ""))
        result.Add(CreateTask("34", "32", "Develop integration test plans using product specifications", "04/08/2020 08:00:00", "04/11/2020 17:00:00", "100", "1", "2", "5", ""))
        result.Add(CreateTask("35", "32", "Unit Testing", "05/07/2020 15:00:00", "05/28/2020 15:00:00", "0", "1", "2", "", ""))
        result.Add(CreateTask("36", "35", "Review modular code", "05/07/2020 15:00:00", "05/14/2020 15:00:00", "0", "1", "3", "5", ""))
        result.Add(CreateTask("37", "35", "Test component modules to product specifications", "05/14/2020 15:00:00", "05/16/2020 15:00:00", "0", "1", "3", "5", ""))
        result.Add(CreateTask("38", "35", "Identify anomalies to product specifications", "05/16/2020 15:00:00", "05/21/2020 15:00:00", "0", "1", "3", "5", ""))
        result.Add(CreateTask("39", "35", "Modify code", "05/21/2020 15:00:00", "05/24/2020 15:00:00", "0", "1", "3", "5", ""))
        result.Add(CreateTask("40", "35", "Re-test modified code", "05/24/2020 15:00:00", "05/28/2020 15:00:00", "0", "1", "3", "5", ""))
        result.Add(CreateTask("41", "35", "Unit testing complete", "05/28/2020 15:00:00", "05/28/2020 15:00:00", "0", "0", "3", "", ""))
        result.Add(CreateTask("42", "32", "Integration Testing", "05/28/2020 15:00:00", "06/13/2020 15:00:00", "0", "1", "2", "", ""))
        result.Add(CreateTask("43", "42", "Test module integration", "05/28/2020 15:00:00", "06/04/2020 15:00:00", "0", "1", "3", "5", ""))
        result.Add(CreateTask("44", "42", "Identify anomalies to specifications", "06/04/2020 15:00:00", "06/06/2020 15:00:00", "0", "1", "3", "5", ""))
        result.Add(CreateTask("45", "42", "Modify code", "06/06/2020 15:00:00", "06/11/2020 15:00:00", "0", "1", "3", "5", ""))
        result.Add(CreateTask("46", "42", "Re-test modified code", "06/11/2020 15:00:00", "06/13/2020 15:00:00", "0", "1", "3", "5", ""))
        result.Add(CreateTask("47", "42", "Integration testing complete", "06/13/2020 15:00:00", "06/13/2020 15:00:00", "0", "0", "3", "", ""))
        result.Add(CreateTask("48", "0", "Training", "04/08/2020 08:00:00", "06/10/2020 15:00:00", "25", "1", "1", "", ""))
        result.Add(CreateTask("49", "48", "Develop training specifications for end users", "04/08/2020 08:00:00", "04/10/2020 17:00:00", "100", "1", "2", "6", ""))
        result.Add(CreateTask("50", "48", "Develop training specifications for helpdesk support staff", "04/08/2020 08:00:00", "04/10/2020 17:00:00", "100", "1", "2", "6", ""))
        result.Add(CreateTask("51", "48", "Identify training delivery methodology (computer based training, classroom, etc.)", "04/08/2020 08:00:00", "04/09/2020 17:00:00", "100", "1", "2", "6", ""))
        result.Add(CreateTask("52", "48", "Develop training materials", "05/07/2020 15:00:00", "05/28/2020 15:00:00", "0", "1", "2", "6", ""))
        result.Add(CreateTask("53", "48", "Conduct training usability study", "05/28/2020 15:00:00", "06/03/2020 15:00:00", "0", "1", "2", "6", ""))
        result.Add(CreateTask("54", "48", "Finalize training materials", "06/03/2020 15:00:00", "06/06/2020 15:00:00", "0", "1", "2", "6", ""))
        result.Add(CreateTask("55", "48", "Develop training delivery mechanism", "06/06/2020 15:00:00", "06/10/2020 15:00:00", "0", "1", "2", "6", ""))
        result.Add(CreateTask("56", "48", "Training materials complete", "06/10/2020 15:00:00", "06/10/2020 15:00:00", "0", "0", "2", "", ""))
        result.Add(CreateTask("57", "0", "Documentation", "04/08/2020 08:00:00", "05/20/2020 12:00:00", "0", "1", "1", "", ""))
        result.Add(CreateTask("58", "57", "Develop Help specification", "04/08/2020 08:00:00", "04/08/2020 17:00:00", "80", "1", "2", "7", ""))
        result.Add(CreateTask("59", "57", "Develop Help system", "04/22/2020 13:00:00", "05/13/2020 12:00:00", "0", "1", "2", "7", ""))
        result.Add(CreateTask("60", "57", "Review Help documentation", "05/13/2020 13:00:00", "05/16/2020 12:00:00", "0", "1", "2", "7", ""))
        result.Add(CreateTask("61", "57", "Incorporate Help documentation feedback", "05/16/2020 13:00:00", "05/20/2020 12:00:00", "0", "1", "2", "7", ""))
        result.Add(CreateTask("62", "57", "Develop user manuals specifications", "04/08/2020 08:00:00", "04/09/2020 17:00:00", "65", "1", "2", "7", ""))
        result.Add(CreateTask("63", "57", "Develop user manuals", "04/22/2020 13:00:00", "05/13/2020 12:00:00", "0", "1", "2", "7", ""))
        result.Add(CreateTask("64", "57", "Review all user documentation", "05/13/2020 13:00:00", "05/15/2020 12:00:00", "0", "1", "2", "7", ""))
        result.Add(CreateTask("65", "57", "Incorporate user documentation feedback", "05/15/2020 13:00:00", "05/17/2020 12:00:00", "0", "1", "2", "7", ""))
        result.Add(CreateTask("66", "57", "Documentation complete", "05/20/2020 12:00:00", "05/20/2020 12:00:00", "0", "0", "2", "", ""))
        result.Add(CreateTask("67", "0", "Pilot", "03/18/2020 13:00:00", "06/24/2020 15:00:00", "22", "1", "1", "", ""))
        result.Add(CreateTask("68", "67", "Identify test group", "03/18/2020 13:00:00", "03/19/2020 12:00:00", "100", "1", "2", "2", ""))
        result.Add(CreateTask("69", "67", "Develop software delivery mechanism", "03/19/2020 13:00:00", "03/20/2020 12:00:00", "100", "1", "2", "", ""))
        result.Add(CreateTask("70", "67", "Install/deploy software", "06/13/2020 15:00:00", "06/14/2020 15:00:00", "0", "1", "2", "8", ""))
        result.Add(CreateTask("71", "67", "Obtain user feedback", "06/14/2020 15:00:00", "06/21/2020 15:00:00", "0", "1", "2", "8", ""))
        result.Add(CreateTask("72", "67", "Evaluate testing information", "06/21/2020 15:00:00", "06/24/2020 15:00:00", "0", "1", "2", "8", ""))
        result.Add(CreateTask("73", "67", "Pilot complete", "06/24/2020 15:00:00", "06/24/2020 15:00:00", "0", "0", "2", "", ""))
        result.Add(CreateTask("74", "0", "Deployment", "06/24/2020 15:00:00", "07/01/2020 15:00:00", "0", "1", "1", "", ""))
        result.Add(CreateTask("75", "74", "Determine final deployment strategy", "06/24/2020 15:00:00", "06/25/2020 15:00:00", "0", "1", "2", "8", ""))
        result.Add(CreateTask("76", "74", "Develop deployment methodology", "06/25/2020 15:00:00", "06/26/2020 15:00:00", "0", "1", "2", "8", ""))
        result.Add(CreateTask("77", "74", "Secure deployment resources", "06/26/2020 15:00:00", "06/27/2020 15:00:00", "0", "1", "2", "8", ""))
        result.Add(CreateTask("78", "74", "Train support staff", "06/27/2020 15:00:00", "06/28/2020 15:00:00", "0", "1", "2", "8", ""))
        result.Add(CreateTask("79", "74", "Deploy software", "06/28/2020 15:00:00", "07/01/2020 15:00:00", "0", "1", "2", "8", ""))
        result.Add(CreateTask("80", "74", "Deployment complete", "07/01/2020 15:00:00", "07/01/2020 15:00:00", "0", "0", "2", "", ""))
        result.Add(CreateTask("81", "0", "Post Implementation Review", "07/01/2020 15:00:00", "07/04/2020 15:00:00", "0", "1", "1", "", ""))
        result.Add(CreateTask("82", "81", "Document lessons learned", "07/01/2020 15:00:00", "07/02/2020 15:00:00", "0", "1", "2", "2", ""))
        result.Add(CreateTask("83", "81", "Distribute to team members", "07/02/2020 15:00:00", "07/03/2020 15:00:00", "0", "1", "2", "2", ""))
        result.Add(CreateTask("84", "81", "Create software maintenance team", "07/03/2020 15:00:00", "07/04/2020 15:00:00", "0", "1", "2", "2", ""))
        result.Add(CreateTask("85", "81", "Post implementation review complete", "07/04/2020 15:00:00", "07/04/2020 15:00:00", "0", "0", "2", "", ""))
        result.Add(CreateTask("86", "0", "Software development template complete", "07/04/2020 15:00:00", "07/04/2020 15:00:00", "0", "0", "1", "", ""))
        Return result
    End Function

    Public Function CreateTask(ByVal id As String, ByVal parentid As String, ByVal subject As String, ByVal start As String, ByVal [end] As String, ByVal percent As String, ByVal type As String, ByVal status As String, ByVal resources As String, ByVal description As String) As Task
        Dim task = New Task()
        task.ID = id
        task.ParentID = parentid
        task.Subject = subject
        task.StartDate = Date.Parse(start, Globalization.CultureInfo.InvariantCulture)
        task.EndDate = Date.Parse([end], Globalization.CultureInfo.InvariantCulture)
        task.PercentComplete = Convert.ToInt32(percent)
        task.Type = Convert.ToInt32(type)
        task.Status = Convert.ToInt32(status)
        task.Employees = resources
        task.Description = description
        Return task
    End Function

    Private Function CreateDependencies() As List(Of Dependency)
        Dim result = New List(Of Dependency)()
        For i As Integer = 0 To Tasks.Count - 1
            Dim task As Task = Tasks(i)
            If Not String.IsNullOrEmpty(task.ParentID) Then
                result.Add(New Dependency() With {.ID = CreateUniqueId(), .Type = 0, .ParentID = Tasks(i - 1).ID, .DependentID = task.ID})
            End If
        Next

        Return result
    End Function

    Private Function CreateResources() As List(Of Resource)
        Dim result = New List(Of Resource)()
        result.Add(New Resource() With {.ID = "1", .Name = "Management"})
        result.Add(New Resource() With {.ID = "2", .Name = "Project Manager"})
        result.Add(New Resource() With {.ID = "3", .Name = "Analyst"})
        result.Add(New Resource() With {.ID = "4", .Name = "Developer"})
        result.Add(New Resource() With {.ID = "5", .Name = "Testers"})
        result.Add(New Resource() With {.ID = "6", .Name = "Trainers"})
        result.Add(New Resource() With {.ID = "7", .Name = "Technical Communicators"})
        result.Add(New Resource() With {.ID = "8", .Name = "Deployment Team"})
        Return result
    End Function

    Private Function CreateResourceAssignments() As List(Of ResourceAssignment)
        Dim result = New List(Of ResourceAssignment)()
        For Each task As Task In Tasks
            If Not String.IsNullOrEmpty(task.Employees) Then
                Dim empIDs As String() = task.Employees.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
                For i As Integer = 0 To empIDs.Length - 1
                    result.Add(New ResourceAssignment() With {.ID = CreateUniqueId(), .TaskID = task.ID, .ResourceID = empIDs(i)})
                Next
            End If
        Next

        Return result
    End Function

    Public Sub UpdateTask(ByVal task As Task)
        Dim item As Task = Tasks.FirstOrDefault(Function(c) c.ID.Equals(task.ID))
        item.ParentID = task.ParentID
        item.PercentComplete = task.PercentComplete
        item.StartDate = task.StartDate
        item.EndDate = task.EndDate
        item.Subject = task.Subject
        item.Team = task.Team
        item.Description = task.Description
    End Sub

    Public Function InsertTask(ByVal task As Task) As String
        task.ID = CreateUniqueId()
        Tasks.Add(task)
        Return task.ID
    End Function

    Public Sub DeleteTask(ByVal task As Task)
        Dim taskToDelete = Tasks.FirstOrDefault(Function(t) t.ID.Equals(task.ID))
        If taskToDelete IsNot Nothing Then Tasks.Remove(taskToDelete)
    End Sub

    Public Sub DeleteTaskByKey(ByVal key As String)
        Dim taskToDelete = Tasks.FirstOrDefault(Function(t) t.ID.Equals(key))
        If taskToDelete IsNot Nothing Then Tasks.Remove(taskToDelete)
    End Sub

    Public Function InsertDependency(ByVal dependency As Dependency) As String
        dependency.ID = CreateUniqueId()
        Dependencies.Add(dependency)
        Return dependency.ID
    End Function

    Public Sub DeleteDependency(ByVal dependency As Dependency)
        Dim dependencyToDelete = Dependencies.FirstOrDefault(Function(t) t.ID.Equals(dependency.ID))
        If dependencyToDelete IsNot Nothing Then Dependencies.Remove(dependencyToDelete)
    End Sub

    Public Sub DeleteDependencyByKey(ByVal key As String)
        Dim dependencyToDelete = Dependencies.FirstOrDefault(Function(t) t.ID.Equals(key))
        If dependencyToDelete IsNot Nothing Then Dependencies.Remove(dependencyToDelete)
    End Sub

    Public Sub UpdateResource(ByVal resource As Resource)
        Dim item As Resource = Resources.FirstOrDefault(Function(c) c.ID.Equals(resource.ID))
        item.Name = resource.Name
    End Sub

    Public Function InsertResource(ByVal resource As Resource) As String
        resource.ID = CreateUniqueId()
        Resources.Add(resource)
        Return resource.ID
    End Function

    Public Sub DeleteResource(ByVal resource As Resource)
        Dim resourceToDelete = Resources.FirstOrDefault(Function(t) t.ID.Equals(resource.ID))
        If resourceToDelete IsNot Nothing Then Resources.Remove(resourceToDelete)
    End Sub

    Public Sub DeleteResourceByKey(ByVal key As String)
        Dim resourceToDelete = Resources.FirstOrDefault(Function(t) t.ID.Equals(key))
        If resourceToDelete IsNot Nothing Then Resources.Remove(resourceToDelete)
    End Sub

    Public Function InsertResourceAssignment(ByVal resourceAssignment As ResourceAssignment) As String
        resourceAssignment.ID = CreateUniqueId()
        ResourceAssignments.Add(resourceAssignment)
        Return resourceAssignment.ID
    End Function

    Public Sub DeleteResourceAssignment(ByVal resourceAssignment As ResourceAssignment)
        Dim itemToDelete = ResourceAssignments.FirstOrDefault(Function(t) t.ID.Equals(resourceAssignment.ID))
        If itemToDelete IsNot Nothing Then ResourceAssignments.Remove(itemToDelete)
    End Sub

    Public Sub DeleteResourceAssignmentByKey(ByVal key As String)
        Dim itemToDelete = ResourceAssignments.FirstOrDefault(Function(t) t.ID.Equals(key))
        If itemToDelete IsNot Nothing Then ResourceAssignments.Remove(itemToDelete)
    End Sub

    Private Function CreateUniqueId() As String
        Return Guid.NewGuid().ToString()
    End Function
End Module

Public Class Task

    Public Property ID As String

    Public Property ParentID As String

    Public Property Subject As String

    Public Property Description As String

    Public Property StartDate As Date

    Public Property EndDate As Date

    Public Property PercentComplete As Integer

    Public Property Type As Integer

    Public Property Status As Integer

    Public Property Team As String

    Public Property Employees As String
End Class

Public Class Dependency

    Public Property ID As String

    Public Property ParentID As String

    Public Property DependentID As String

    Public Property Type As Integer
End Class

Public Class Resource

    Public Property ID As String

    Public Property Name As String
End Class

Public Class ResourceAssignment

    Public Property ID As String

    Public Property TaskID As String

    Public Property ResourceID As String
End Class
