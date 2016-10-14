Imports System
Imports System.Web.UI
Imports System.Web.Compilation
Imports System.CodeDom
Imports System.ComponentModel

Public Class RandomNumberExpressionBuilder
    Inherits ExpressionBuilder
    Public Shared Function GetRandomNumber(
        ByVal lowerLimit As Integer, ByVal upperLimit As Integer
        ) As String
        Dim rand As New Random()
        Dim randValue As Integer = rand.[Next](lowerLimit, upperLimit + 1)
        Return randValue.ToString()
    End Function

    Public Overloads Overrides Function GetCodeExpression(
        ByVal entry As BoundPropertyEntry,
        ByVal parsedData As Object,
        ByVal context As ExpressionBuilderContext
        ) As CodeExpression
        ' entry.Expression is the number string 
        ' (minus the RandomNumber: prefix). 
        If Not entry.Expression.Contains(",") Then
            Throw New ArgumentException("Must include two numbers separated by a comma.")
        Else
            ' Get the two numbers. 
            Dim numbers As String() = entry.Expression.Split(",")

            If numbers.Length <> 2 Then
                Throw New ArgumentException("Only include two numbers.")
            Else
                Dim lowerLimit As Integer, upperLimit As Integer
                If Int32.TryParse(numbers(0), lowerLimit) AndAlso
                    Int32.TryParse(numbers(1), upperLimit) Then

                    ' So far all the operations have been performed in 
                    ' normal code. That's because the two numbers are 
                    ' specified in the expression, and so they won't 
                    ' change each time the page is requested. 
                    ' However, the random number should be allowed to 
                    ' change each time, so you need to switch to CodeDOM. 

                    ' Get a reference to the class that has the GetRandomNumber() method. 
                    ' (It's the class where this code is executing.) 
                    Dim typeRef As New CodeTypeReferenceExpression(Me.[GetType]())

                    ' Define the parameters that need to be passed to GetRandomNumber(). 
                    Dim methodParameters As CodeExpression() = New CodeExpression(1) {}
                    methodParameters(0) = New CodePrimitiveExpression(lowerLimit)
                    methodParameters(1) = New CodePrimitiveExpression(upperLimit)

                    ' Define the code expression that invokes GetRandomNumber(). 
                    Dim methodCall As New CodeMethodInvokeExpression(
                        typeRef, "GetRandomNumber", methodParameters)

                    ' The commented lines allow you to perform casting. 
                    ' It's not required in this example (as GetRandomNumber returns a string), 
                    ' but it's a common expression builder technique. 
                    'Dim theType As Type = entry.DeclaringType
                    'Dim descriptor As PropertyDescriptor =
                    '    TypeDescriptor.GetProperties(DirectCast(entry.PropertyInfo.Name, theType))
                    'return new CodeCastExpression(descriptor.PropertyType, methodCall); 

                    Return methodCall
                Else
                    Throw New ArgumentException("Use valid integers.")
                End If
            End If
        End If

    End Function
End Class

