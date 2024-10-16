Public Class Libro
    Private Shared NewId As Integer = 1000
    Private id As Integer
    Private titulo As String
    Private autor As String
    Private anio As Integer
    Private paginas As Integer

    ' Getters y Setters
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
    Public Sub New(titulo As String, autor As String, anio As Integer, paginas As Integer)
        Me.id = NewId ' Asignar el ID actual
        NewId += 10
        Me.GetTitulo = titulo
        Me.GetAutor = autor
        Me.GetAnio = anio
        Me.GetPaginas = paginas
    End Sub


    ' Método para obtener los detalles del libro
    Public Function Datos() As String
        Return $"ID: {id}, Título: {GetTitulo}, Autor: {GetAutor}, Año: {GetAnio}, Páginas: {GetPaginas}"
    End Function

    ' Método para obtener el ID del libro
    Public Function GetId() As Integer
        Return id
    End Function

    ' Método para ajustar el valor de NewId
    Public Shared Sub AjustarNewId(nuevoValor As Integer)
        NewId = nuevoValor
    End Sub
End Class