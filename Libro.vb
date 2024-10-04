Public Class Libro
    Private Shared NewId As Integer = 1000
    Private id As Integer
    Private titulo As String
    Private autor As String
    Private anio As Integer
    Private paginas As Integer


    Public Property GetTitulo As String
        Get
            Return titulo
        End Get
        Set(value As String)
            titulo = value
        End Set
    End Property

    Public Property GetAutor As String
        Get
            Return autor
        End Get
        Set(value As String)
            autor = value
        End Set
    End Property

    Public Property GetAnio As Integer
        Get
            Return anio
        End Get
        Set(value As Integer)
            anio = value
        End Set
    End Property

    Public Property GetPaginas As Integer
        Get
            Return paginas
        End Get
        Set(value As Integer)
            If value > 0 Then paginas = value Else paginas = 1
        End Set
    End Property

    Public Sub New(titulo_ As String, autor_ As String, anio_ As Integer, paginas_ As Integer)
        id = NewId
        Me.titulo = titulo_
        Me.autor = autor_
        Me.anio = anio_
        Me.paginas = paginas_
        id += 10
    End Sub

    Public Function Datos() As String
        Datos = $"ID: {id}, titulo: {GetTitulo}, autor: {GetAutor}, Año: {GetAnio}, Paginas: {GetPaginas}"
        Return Datos
    End Function

End Class
