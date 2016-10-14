Namespace BasicMVCApplication
    Public Class ProductController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /Product

        Function Index() As ActionResult
            Dim db As New northwndEntities()
            Dim data = db.Products
            Return View(data)
        End Function

        '
        ' GET: /Product/Details/5

        Function Details(ByVal id As Integer) As ActionResult
            Dim db As New northwndEntities()
            Dim data =
                db.Products.Where(
                    Function(e) e.ProductID = id
                        ).[Select](Function(e) e).[Single]()
            Return View(data)
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
                Dim db As New northwndEntities()
                db.AddToProducts(prod)
                db.SaveChanges()
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
        
        '
        ' GET: /Product/Edit/5

        Function Edit(ByVal id As Integer) As ActionResult
            Dim db As New northwndEntities()
            Dim data =
                db.Products.Where(
                    Function(e) e.ProductID = id
                        ).[Select](Function(e) e).[Single]()
            Return View(data)

        End Function

        '
        ' POST: /Product/Edit/5

        <HttpPost()>
        Function Edit(
            ByVal id As Integer, ByVal collection As FormCollection
            ) As ActionResult
            Try
                Dim db As New northwndEntities()
                Dim prod As Product =
                    db.Products.Where(
                        Function(e) e.ProductID = id
                            ).[Select](Function(e) e).[Single]()
                UpdateModel(prod)
                db.SaveChanges()
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        '
        ' GET: /Product/Delete/5

        Function Delete(ByVal id As Integer) As ActionResult
            Dim db As New northwndEntities()
            Dim data =
                db.Products.Where(
                    Function(e) e.ProductID = id
                        ).[Select](Function(e) e).[Single]()
            Return View(data)
        End Function

        '
        ' POST: /Product/Delete/5

        <HttpPost()>
        Function Delete(
            ByVal id As Integer, ByVal collection As FormCollection
            ) As ActionResult
            Try
                Dim db As New northwndEntities()
                Dim prod As Product =
                    db.Products.Where(
                        Function(e) e.ProductID = id
                            ).[Select](Function(e) e).[Single]()
                db.Products.DeleteObject(prod)
                db.SaveChanges()
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace