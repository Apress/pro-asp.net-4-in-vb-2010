Imports NorthwindModel
Imports ADOHelpers
Imports System.Data
Imports System.Data.Objects

Partial Class ConcurrencyConflict
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        ByVal sender As Object, ByVal e As System.EventArgs
        ) Handles Me.Load

        ' create the ObjectContext
        Dim context As New NorthwindEntities()
        Dim cust As Customer = context.Customers.Where(
            Function(c) c.CustomerID = "LAZYK").[Select](Function(c) c).First()
        System.Diagnostics.Debug.WriteLine("Initial value: " & cust.ContactName)
        ' change the record outside of the entity framework

        ADOHelperFunctions.ExecuteStatementInDb(
            [String].Format("update Customers " & vbNewLine &
            "        set ContactName = 'Samuel Arthur Sanders' " & vbNewLine &
            "        where CustomerID = 'LAZYK'"))

        ' modify the customer 
        cust.ContactName = "John Doe"

        ' save the changes
        Try
            context.SaveChanges()
        Catch generatedExceptionName As OptimisticConcurrencyException
            'System.Diagnostics.Debug.WriteLine(
            '    "Detected concurrency conflict - refreshing data")
            'context.Refresh(RefreshMode.ClientWins, cust)
            context.SaveChanges()
            'context.Refresh(RefreshMode.StoreWins, cust)
            System.Diagnostics.Debug.WriteLine(
                "Detected concurrency conflict - giving up")
        Finally
            Dim dbValue As String = ADOHelperFunctions.GetStringFromDb(
                [String].Format("select ContactName from Customers" & vbNewLine &
                                "    where CustomerID = 'LAZYK'"))
            System.Diagnostics.Debug.WriteLine("Database value: " & dbValue)
            System.Diagnostics.Debug.WriteLine("Cached value: " & cust.ContactName)
        End Try
    End Sub
End Class
