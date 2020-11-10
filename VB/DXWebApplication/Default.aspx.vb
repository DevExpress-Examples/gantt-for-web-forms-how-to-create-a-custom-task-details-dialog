Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace DXWebApplication14
	Partial Public Class WebForm1
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub
		Protected Sub ASPxFormLayout1_E3_Init(ByVal sender As Object, ByVal e As EventArgs)
			Dim tb As ASPxTokenBox = TryCast(sender, ASPxTokenBox)
			tb.DataSource = GanttDataProvider.GetResources()
			tb.DataBindItems()
		End Sub



	End Class
End Namespace