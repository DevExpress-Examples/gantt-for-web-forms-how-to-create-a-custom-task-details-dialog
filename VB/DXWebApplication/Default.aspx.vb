Imports DevExpress.Web
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace DXWebApplication14

    Public Partial Class WebForm1
        Inherits Page

        Protected Sub ASPxFormLayout1_E3_Init(ByVal sender As Object, ByVal e As EventArgs)
            Dim tb As ASPxTokenBox = TryCast(sender, ASPxTokenBox)
            tb.DataSource = GetResources()
            tb.DataBindItems()
        End Sub
    End Class
End Namespace
