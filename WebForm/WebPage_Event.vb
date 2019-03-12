Imports System.Diagnostics

Partial Class _Default
    Inherits System.Web.UI.Page

    Public Sub New()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


#Region "Default"
    Private Sub _Default_AbortTransaction(sender As Object, e As EventArgs) Handles Me.AbortTransaction
        bp()
    End Sub

    Private Sub _Default_CommitTransaction(sender As Object, e As EventArgs) Handles Me.CommitTransaction
        bp()
    End Sub

    Private Sub _Default_DataBinding(sender As Object, e As EventArgs) Handles Me.DataBinding
        bp()
    End Sub

    Private Sub _Default_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        bp()
    End Sub

    Private Sub _Default_Error(sender As Object, e As EventArgs) Handles Me.[Error]
        bp()
    End Sub

    Private Sub _Default_Init(sender As Object, e As EventArgs) Handles Me.Init
        bp()
    End Sub

    Private Sub _Default_InitComplete(sender As Object, e As EventArgs) Handles Me.InitComplete
        bp()
    End Sub

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        bp()
    End Sub

    Private Sub _Default_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        bp()
    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        bp()
    End Sub

    Private Sub _Default_PreLoad(sender As Object, e As EventArgs) Handles Me.PreLoad
        bp()
    End Sub

    Private Sub _Default_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        bp()
    End Sub

    Private Sub _Default_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        bp()
    End Sub

    Private Sub _Default_SaveStateComplete(sender As Object, e As EventArgs) Handles Me.SaveStateComplete
        bp()
    End Sub

    Private Sub _Default_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        bp()
    End Sub
#End Region
#Region "form1"
    Private Sub form1_Init(sender As Object, e As EventArgs) Handles form1.Init
        bp()
    End Sub


    Private Sub form1_DataBinding(sender As Object, e As EventArgs) Handles form1.DataBinding
        bp()
    End Sub

    Private Sub form1_Disposed(sender As Object, e As EventArgs) Handles form1.Disposed
        bp()
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        bp()
    End Sub

    Private Sub form1_PreRender(sender As Object, e As EventArgs) Handles form1.PreRender
        bp()
    End Sub

    Private Sub form1_Unload(sender As Object, e As EventArgs) Handles form1.Unload
        bp()
    End Sub
#End Region

#Region "DetailsView1_Init"
    Private Sub DetailsView1_Init(sender As Object, e As EventArgs) Handles DetailsView1.Init
        bp()

    End Sub

    Private Sub DetailsView1_DataBinding(sender As Object, e As EventArgs) Handles DetailsView1.DataBinding
        bp()

    End Sub

    Private Sub DetailsView1_DataBound(sender As Object, e As EventArgs) Handles DetailsView1.DataBound
        bp()

    End Sub

    Private Sub DetailsView1_Disposed(sender As Object, e As EventArgs) Handles DetailsView1.Disposed
        bp()

    End Sub

    Private Sub DetailsView1_Load(sender As Object, e As EventArgs) Handles DetailsView1.Load
        bp()

    End Sub

    Private Sub DetailsView1_PreRender(sender As Object, e As EventArgs) Handles DetailsView1.PreRender
        bp()

    End Sub

    Private Sub DetailsView1_Unload(sender As Object, e As EventArgs) Handles DetailsView1.Unload
        bp()

    End Sub

#End Region

#Region "SqlDataSource1_Init"
    Private Sub SqlDataSource1_DataBinding(sender As Object, e As EventArgs) Handles SqlDataSource1.DataBinding
        bp()

    End Sub

    Private Sub SqlDataSource1_Deleted(sender As Object, e As SqlDataSourceStatusEventArgs) Handles SqlDataSource1.Deleted
        bp()

    End Sub

    Private Sub SqlDataSource1_Disposed(sender As Object, e As EventArgs) Handles SqlDataSource1.Disposed
        bp()

    End Sub

    Private Sub SqlDataSource1_Init(sender As Object, e As EventArgs) Handles SqlDataSource1.Init
        bp()

    End Sub

    Private Sub SqlDataSource1_Load(sender As Object, e As EventArgs) Handles SqlDataSource1.Load
        bp()

    End Sub

    Private Sub SqlDataSource1_Unload(sender As Object, e As EventArgs) Handles SqlDataSource1.Unload
        bp()

    End Sub
    Private Sub SqlDataSource1_PreRender(sender As Object, e As EventArgs) Handles SqlDataSource1.PreRender
        bp()

    End Sub
#End Region


    Private callCount As Integer = 1
    Sub bp()
        Dim st = New StackTrace()
        Dim sf = st.GetFrame(1)
        Debug.WriteLine(callCount.ToString() + "  " + sf.GetMethod.Name)
        callCount = callCount + 1

    End Sub






    'Private Sub D_PreRenderComplete(sender As Object, e As EventArgs) Handles _Default.PreRenderComplete

    'End Sub


End Class

1  _Default_PreInit
2  SqlDataSource1_Init
3  DetailsView1_Init
4  form1_Init
5  _Default_Init
6  _Default_InitComplete
7  _Default_PreLoad
8  _Default_Load
9  form1_Load
10  SqlDataSource1_Load
11  DetailsView1_Load
12  _Default_LoadComplete
13  _Default_PreRender
14  form1_PreRender
15  _Default_Error
16  SqlDataSource1_Unload
17  DetailsView1_Unload
18  form1_Unload
19  _Default_Unload
