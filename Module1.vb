Module Module1
    Dim libros() As Libro ' El array puede crecer dinámicamente.

    Sub Main()
        Dim opcion As Integer

        Do
            Console.WriteLine("Menú:")
            Console.WriteLine("1 - Alta libro")
            Console.WriteLine("2 - Modificar libro")
            Console.WriteLine("0 - Salir")

            Console.Write("Elija una opción: ")
            opcion = Convert.ToInt32(Console.ReadLine())

            Select Case opcion
                Case 1
                    CrearLibro()
                    libros(libros.Length - 1) = New Libro(titulo, autor, anio, paginas)
                    For i As Integer = 0 To (libros.Length - 1)
                        Console.WriteLine(libros(i).Datos())
                    Next

                    Console.ReadKey()
                    Console.Clear()

                Case 2
                    ModificarLibro()

                Case 0
                    Console.WriteLine("Saliendo...")
                Case Else
                    Console.WriteLine("Opción no válida, intente de nuevo.")
            End Select
            Console.WriteLine()
        Loop While opcion <> 0
    End Sub

    Public Sub CrearLibro()
        Dim titulo As String
        Dim autor As String
        Dim anio As Integer
        Dim paginas As Integer

        Console.Write("Titulo: ")
        titulo = Console.ReadLine()

        Console.Write("Autor: ")
        autor = Console.ReadLine()

        Console.Write("Año de lanzamiento: ")
        anio = Integer.Parse(Console.ReadLine())

        Console.Write("Cantidad de paginas: ")
        paginas = Integer.Parse(Console.ReadLine())

        ' Redimensionar el array y agregar el nuevo libro.
        ReDim Preserve libros(libros.Length)
    End Sub

    Public Sub ModificarLibro()
        ' Mostrar los libros actuales.
        For i As Integer = 0 To (libros.Length - 1)
            Console.WriteLine($"{i + 1}. {libros(i).Datos()}")
        Next

        ' Solicitar cuál libro modificar.
        Console.WriteLine("Ingrese el número del libro a modificar:")
        Dim indice As Integer = Integer.Parse(Console.ReadLine()) - 1

        If indice >= 0 And indice < libros.Length Then
            ' Modificar los datos del libro seleccionado.
            Console.Write("Nuevo Título: ")
            libros(indice).GetTitulo = Console.ReadLine()

            Console.Write("Nuevo Autor: ")
            libros(indice).GetAutor = Console.ReadLine()

            Console.Write("Nuevo Año de lanzamiento: ")
            libros(indice).GetAnio = Integer.Parse(Console.ReadLine())

            Console.Write("Nueva Cantidad de páginas: ")
            libros(indice).GetPaginas = Integer.Parse(Console.ReadLine())

            Console.WriteLine("Libro modificado con éxito.")
        Else
            Console.WriteLine("Índice no válido.")
        End If

        Console.ReadKey()
        Console.Clear()
    End Sub
End Module
