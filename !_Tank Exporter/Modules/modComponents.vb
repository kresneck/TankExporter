Public Module modComponents
    Public Class Component
        Public undamagedPath As String
        Public crashedPath As String
        Public name As String
        Public tiling As String
    End Class

    Public Class TurretComponent
        Inherits Component
        Public gunList As List(Of Component)
    End Class

End Module
