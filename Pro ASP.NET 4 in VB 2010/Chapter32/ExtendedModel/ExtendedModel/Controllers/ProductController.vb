Imports BasicMVCApplication.ExtendedModel.Models

Namespace ExtendedModel.Controllers
    <HandleError(Order:=2)>
    Public Class ProductController
        Inherits System.Web.Mvc.Controller
        Private nwa As New NorthwindAccessConsolidator()

        '
        ' GET: /Product

        Function Index() As ActionResult
            Return View(nwa.ListProducts())
        End Function

        '
        ' GET: /Product/Details/5
        <HandleError(View:="NoSuchRecordError",
            ExceptionType:=GetType(NoSuchRecordException))>
        Function Details(ByVal id As Integer) As ActionResult
            Dim prod As Product = nwa.GetProduct(id)
            If prod Is Nothing Then
                'Throw New NoSuchRecordException()
                Return RedirectToAction("CustomError", New With {
                    .message = "You requested an unknown product",
                    .detail = [String].Format("No record for ID of {0}", id)
                })
            Else
                ViewData("CatName") = nwa.GetCategoryName(prod)
                ViewData("SupName") = nwa.GetSupplierName(prod)
                Return View(prod)
            End If
        End Function

        '
        ' GET: /Product/Create

        Function Create() As ActionResult
            Return View(New Product())
        End Function

        '
        ' POST: /Product/Create

        <HttpPost()>
        Function Create(ByVal prod As Product) As ActionResult
            Try
                nwa.StoreNewProduct(prod)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        '
        ' GET: /Product/Edit/5

        Function Edit(ByVal id As Integer) As ActionResult
            ViewData("categories") = New SelectList(nwa.GetAllCategories())
            ViewData("suppliers") = New SelectList(nwa.GetAllSuppliers())
            Dim prod As Product = nwa.GetProduct(id)
            Dim wrap As New ProductListWrapper With {
                .Product = prod,
                .SelectedCategory = prod.Category.CategoryName,
                .SelectedSupplier = prod.Supplier.CompanyName
            }
            Return View(wrap)
        End Function

        '
        ' POST: /Product/Edit/5

        <HttpPost()>
        Function Edit(
            ByVal id As Integer, ByVal pwrap As ProductListWrapper
            ) As ActionResult
            Try
                If Not ModelState.IsValid Then
                    ViewData("categories") = New SelectList(nwa.GetAllCategories())
                    ViewData("suppliers") = New SelectList(nwa.GetAllSuppliers())
                    Return View("Edit", pwrap)
                End If
                Dim prod As Product = nwa.GetProduct(id)
                If prod IsNot Nothing Then
                    Dim wrapper As New ProductListWrapper() With {
                      .Product = prod
                    }
                    UpdateModel(wrapper)
                    prod.SupplierID = nwa.GetSupplierID(wrapper.SelectedSupplier)
                    prod.CategoryID = nwa.GetCategoryID(wrapper.SelectedCategory)
                    nwa.SaveChanges()

                    Return RedirectToAction("Index")
                Else
                    Throw New NoSuchRecordException()
                End If

            Catch
                Return View()
            End Try
        End Function

        '
        ' GET: /Product/Delete/5

        Function Delete(ByVal id As Integer) As ActionResult
            Return View(nwa.GetProduct(id))
        End Function

        '
        ' POST: /Product/Delete/5

        <HttpPost()>
        Function Delete(
            ByVal id As Integer, ByVal collection As FormCollection
            ) As ActionResult
            Try
                nwa.DeleteProduct(id)
                Return RedirectToAction("Index")
            Catch ex As Exception
                Console.WriteLine(ex)
                Return View()
            End Try
        End Function

        Public Function JsonDetails(ByVal id As Integer) As ActionResult
            Dim prod As Product = nwa.GetProduct(id)
            If prod Is Nothing Then
                Throw New NoSuchRecordException()
            Else
                Return Json(New With { _
                    .ProductId = prod.ProductID, _
                    .ProductName = prod.ProductName, _
                    .SupplierID = prod.SupplierID, _
                    .CategoryID = prod.CategoryID, _
                    .UnitPrice = prod.UnitPrice, _
                    .UnitsInStock = prod.UnitsInStock, _
                    .UnitsOnOrder = prod.UnitsOnOrder, _
                    .ReorderLevel = prod.ReorderLevel, _
                    .Discontinued = prod.Discontinued _
                }, JsonRequestBehavior.AllowGet)
            End If
        End Function

        Public Function CustomError(
            ByVal message As String, ByVal detail As String
            ) As ActionResult
            ViewData("ErrorMessage") = message
            ViewData("ErrorDetail") = detail
            Return View("CustomError")
        End Function

    End Class

    Class NorthwindAccessConsolidator
        Private db As New northwndEntities()

        Public Function ListProducts() As IEnumerable(Of Product)
            Return db.Products
        End Function

        Public Sub DeleteProduct(ByVal id As Integer)
            Dim prod As Product = GetProduct(id)
            If prod IsNot Nothing Then
                Dim ods As IEnumerable(Of Order_Detail) =
                    db.Order_Details.Where(
                        Function(e) e.ProductID = id
                            ).[Select](Function(e) e)
                For Each od As Order_Detail In ods
                    db.Order_Details.DeleteObject(od)
                Next

                db.Products.DeleteObject(prod)
                SaveChanges()
            End If
        End Sub

        Public Function GetProduct(ByVal id As Integer) As Product
            Dim data As IEnumerable(Of Product) =
                db.Products.Where(
                    Function(e) e.ProductID = id
                        ).[Select](Function(e) e)
            Return If(data.Count() > 0, data.[Single](), Nothing)
        End Function

        Public Sub StoreNewProduct(ByVal prod As Product)
            db.Products.AddObject(prod)
            SaveChanges()
        End Sub

        Public Sub SaveChanges()
            db.SaveChanges()
        End Sub

        Public Function GetSupplierName(ByVal prod As Product) As String
            Return db.Suppliers.Where(
                Function(e) e.SupplierID = prod.SupplierID
                    ).[Select](Function(e) e.CompanyName).[Single]()
        End Function

        Public Function GetCategoryName(ByVal prod As Product) As String
            Return db.Categories.Where(
                Function(e) e.CategoryID = prod.CategoryID
                    ).[Select](Function(e) e.CategoryName).[Single]()
        End Function

        Public Function GetAllSuppliers() As IEnumerable(Of String)
            Return db.Suppliers.[Select](Function(e) e.CompanyName)
        End Function

        Public Function GetSupplierID(ByVal name As String) As Integer
            Return db.Suppliers.Where(
                Function(e) e.CompanyName = name
                    ).[Select](Function(e) e.SupplierID).[Single]()
        End Function

        Public Function GetAllCategories() As IEnumerable(Of String)
            Return db.Categories.[Select](Function(e) e.CategoryName)
        End Function

        Public Function GetCategoryID(ByVal name As String) As Integer
            Return db.Categories.Where(
                Function(e) e.CategoryName = name
                    ).[Select](Function(e) e.CategoryID).[Single]()
        End Function

    End Class

    Class NoSuchRecordException
        Inherits Exception
        '...
    End Class

End Namespace