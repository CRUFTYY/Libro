Module Module1
    Dim libro As Libro

    Dim titulo As String
    Dim autor As String
    Dim anio As Integer
    Dim paginas As Integer

    Dim libros(-1) As Libro
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
                    Console.WriteLine($"{libro.Datos()}")

                    ReDim Preserve libros(libros.Length)
                    libros(libros.Length - 1) = New Libro(titulo, autor, anio, paginas)

                    For i As Integer = 0 To (libros.Length - 1)
                        Console.WriteLine(libros(i).Datos())
                    Next
                    Console.ReadKey()
                    Console.Clear()
                Case 2
                    ModificarLibro()
                    Console.WriteLine($"{libro.Datos()}")

                Case 0
                    Console.WriteLine("Saliendo...")
                Case Else
                    Console.WriteLine("Opción no válida, intente de nuevo.")
            End Select
            Console.WriteLine()
        Loop While opcion <> 0
    End Sub
    Public Sub CrearLibro()
        Console.WriteLine("")

        Console.Write("Titulo: ")
        libros(libros.Length - 1).GetTitulo = Console.ReadLine()

        Console.WriteLine("")

        Console.Write("Autor: ")
        libros(libros.Length - 1).GetAutor = Console.ReadLine()

        Console.WriteLine("")

        Console.Write("Año de lanzamiento: ")
        libros(libros.Length - 1).GetAnio = Integer.Parse(Console.ReadLine())

        Console.WriteLine("")

        Console.Write("Cantidad de paginas ")
        libros(libros.Length - 1).GetPaginas = Integer.Parse(Console.ReadLine())
    End Sub

    Public Sub ModificarLibro()
        For i As Integer = 0 To (libros.Length - 1)
            Console.WriteLine(libros(i).Datos())
        Next


        Console.WriteLine("Ingrese libro a modificar")
        Dim opcion As Integer = Integer.Parse(Console.ReadLine())
        Console.Write("")


        Console.Write("Titulo: ")
        libros(opcion.Length - 1).GetTitulo = Console.ReadLine()

        Console.WriteLine("")

        Console.Write("Autor: ")
        libros(opcion.Length - 1).GetAutor = Console.ReadLine()

        Console.WriteLine("")

        Console.Write("Año de lanzamiento: ")
        libros(opcion.Length - 1).GetAnio = Integer.Parse(Console.ReadLine())

        Console.WriteLine("")

        Console.Write("Cantidad de paginas ")
        libros(opcion - 1).GetPaginas = Integer.Parse(Console.ReadLine())

        Console.ReadKey()
        Console.Clear()
    End Sub

End Module
