Public Class Libro
    Private Shared NewId As Integer = 1000 ' Inicia en 1000
    Private id As Integer
    Private titulo As String
    Private autor As String
    Private anio As Integer
    Private paginas As Integer

    ' Propiedades
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

    ' Constructor
    Public Sub New(id As Integer, titulo_ As String, autor_ As String, anio_ As Integer, paginas_ As Integer)
        id = NewId   ' Asigna el ID actual
        NewId += 10     ' Incrementa para el próximo libro
        titulo = titulo_
        autor = autor_
        anio = anio_
        paginas = paginas_
    End Sub

    ' Método para obtener los datos del libro
    Public Function Datos() As String
        Return $"ID: {id}, Titulo: {GetTitulo}, Autor: {GetAutor}, Año: {GetAnio}, Páginas: {GetPaginas}"
    End Function
End Class
