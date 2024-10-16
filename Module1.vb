Imports System.Text.Json
Imports System.IO

Module Module1
    Dim opciones As New JsonSerializerOptions()
    Dim libros As New List(Of Libro)() ' Uso de List para manejar los libros dinámicamente
    Dim rutaArchivoJSON As String = "libros.json"

    Sub Main()
        LeerJSON() ' Carga de libros al iniciar el programa

        Dim opcion As Integer

        Do
            Console.WriteLine("Menú:")
            Console.WriteLine("1 - Alta libro")
            Console.WriteLine("2 - Modificar libro")
            Console.WriteLine("3 - Grabar en JSON")
            Console.WriteLine("4 - Leer desde JSON")
            Console.WriteLine("0 - Salir")

            Console.Write("Elija una opción: ")
            opcion = Convert.ToInt32(Console.ReadLine())

            Select Case opcion
                Case 1
                    CrearLibro()
                    MostrarLibros()
                Case 2
                    ModificarLibro()
                Case 3
                    GrabarJSON()
                    Console.WriteLine("Libros grabados en JSON.")
                Case 4
                    LeerJSON()
                    MostrarLibros()
                Case 0
                    Console.WriteLine("Saliendo...")
                Case Else
                    Console.WriteLine("Opción no válida, intente de nuevo.")
            End Select
            Console.WriteLine()
        Loop While opcion <> 0
    End Sub

    ' Crear un nuevo libro
    Public Sub CrearLibro()
        Console.WriteLine("")

        Console.Write("Titulo: ")
        Dim titulo As String = Console.ReadLine()

        Console.Write("Autor: ")
        Dim autor As String = Console.ReadLine()

        Console.Write("Año de lanzamiento: ")
        Dim anio As Integer = Integer.Parse(Console.ReadLine())

        Console.Write("Cantidad de paginas: ")
        Dim paginas As Integer = Integer.Parse(Console.ReadLine())

        Dim nuevoLibro As New Libro(titulo, autor, anio, paginas)
        libros.Add(nuevoLibro)

        Console.WriteLine("Libro agregado exitosamente.")
    End Sub

    ' Modificar un libro existente
    Public Sub ModificarLibro()
        MostrarLibros()

        Console.WriteLine("Ingrese el índice del libro a modificar:")
        Dim indice As Integer = Integer.Parse(Console.ReadLine())

        If indice >= 0 AndAlso indice < libros.Count Then
            Console.Write("Nuevo Título: ")
            libros(indice).GetTitulo = Console.ReadLine()

            Console.Write("Nuevo Autor: ")
            libros(indice).GetAutor = Console.ReadLine()

            Console.Write("Nuevo Año de lanzamiento: ")
            libros(indice).GetAnio = Integer.Parse(Console.ReadLine())

            Console.Write("Nueva Cantidad de páginas: ")
            libros(indice).GetPaginas = Integer.Parse(Console.ReadLine())

            Console.WriteLine("Libro modificado exitosamente.")
        Else
            Console.WriteLine("Índice no válido.")
        End If
    End Sub

    ' Mostrar libros
    Public Sub MostrarLibros()
        For i As Integer = 0 To libros.Count - 1
            Console.WriteLine($"{i}. {libros(i).Datos()}")
        Next
    End Sub

    ' Guardar los libros en un archivo JSON
    Public Sub GrabarJSON()
        ' Crear opciones de serialización con indentación
        Dim opciones As New JsonSerializerOptions() With {
        .WriteIndented = True ' Habilitar la indentación
    }

        ' Serializar la lista de libros a JSON
        Dim json As String = JsonSerializer.Serialize(libros, opciones)

        ' Guardar el JSON en un archivo
        File.WriteAllText(rutaArchivoJSON, json)
        Console.WriteLine(json)
    End Sub


    ' Leer los libros desde un archivo JSON
    Public Sub LeerJSON()
        If File.Exists(rutaArchivoJSON) Then
            Dim json As String = File.ReadAllText(rutaArchivoJSON)
            libros = JsonSerializer.Deserialize(Of List(Of Libro))(json)
            If libros.Count > 0 Then
                ' Ajustar NewId al ID del último libro + 10
                Libro.AjustarNewId(libros.Last().GetId + 10)
            End If
        Else
            Console.WriteLine("No se encontró un archivo JSON, empezando desde cero.")
        End If
    End Sub
End Module